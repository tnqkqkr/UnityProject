using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                               //UI�� ����ϱ� ���ؼ�

public class ExPlayer : MonoBehaviour
{
    public Rigidbody m_Rigidbody;                    //������ �ٵ� �ҽ��� ����ϰ� �޾� �´�.
    public int Force = 100;                        //int ������ ���� 100�� ���� �Ѵ�.
    public int point = 0;                          //���� ����� ���� �߰�
    public float checkTime = 0;               //�ð� ������ ���� ���� (�Ҽ���)
    public Text m_Text;                            //UI �ؽ�Ʈ ����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) //���콺 �Է��� ������ ��
        if (Input.GetKeyDown(KeyCode.Space))                //�����̽� �Է��� ������ ��
        {
            m_Rigidbody.AddForce(transform.up * Force);           //transform.up(���� ����)���� ������ �ٵ� Force ����ŭ ������ ���� �ش�.
        }

        checkTime += Time.deltaTime;                        //������ ������ ���ؼ� �ð��� ����
        if(checkTime >= 1.0f)                               //���� 1�ʰ� ������ ���
        {
            point += 1;                                     //point = point + 1 ��� (1���� �����ش�.)
            checkTime = 0.0f;                               //1�ʰ� ������� �ʱ�ȭ (0�� -> 1�� -> 0�� -> 1��)
        }

        m_Text.text = point.ToString();                     //UI ǥ��
    }

    private void OnCollisionEnter(Collision collision)        //�浹�� ���۵Ǿ��� ��
    {
        if (collision != null)                                //�浹 ��ü�� ���� ���� ��� [ != �ٸ� ���]
        {
            point = 0;                                        //�浹�� �Ͼ���� ����Ʈ�� 0���� ���ش�
            gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);  //�浿������ ��ġ�� �ʱ�ȭ
            Debug.Log(collision.gameObject.name);             //�ش� ������Ʈ�� �̸��� ����Ѵ�.
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Debug.Log("�����۰� �浹��");
            point += 10;
            Destroy(other.gameObject);
        }
    }
}

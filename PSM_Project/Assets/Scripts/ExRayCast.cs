using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                        //UI�� ����ϱ� ���ؼ�
using UnityEngine.SceneManagement;                                           //Scene �̵� �ϱ� ���ؼ�

public class ExRayCast : MonoBehaviour
{
    public int Point = 0;                                                    //����Ʈ �Ի� ����
    public GameObject TargetObject;                                          //Ÿ�� ������
    public float CheckTime = 0;                                              //Ÿ�� Gen �ð� ����
    public float GameTime = 30.0f;                                           //���� �ð� ����

    public Text pointUI;                                                     //Unity UI ����
    public Text timeUI;                                                      //Unity UI ����
    void Update()
    {
        CheckTime += Time.deltaTime;                                         //�������� �����Ǿ�ð��� ����ϰ� �Ѵ�.
        GameTime -= Time.deltaTime;                                          //������ �ð��� �����Ͽ� 30�� -> 0�ʷ� ���� �Ѵ�.
        
        if(GameTime <= 0)                                                    //0�ʰ� �Ǹ�
        {
            PlayerPrefs.SetInt("Point", Point);                              //����Ƽ���� �����ϴ� ���� �Լ�
            SceneManager.LoadScene("MainScene");                             //MainScene���� �̵��Ѵ�.
        }

        pointUI.text = "���� : " + Point.ToString();                         //UI ���� ǥ��
        timeUI.text = "���� �ð� : " + GameTime.ToString() + "s";            //UI ���� �ð� ǥ��


        if(CheckTime >= 0.5f)                                                //0.5�� ���� �ൿ�� �Ѵ�.
        {
            int RandomX = Random.Range(0, 12);                               //0~11������ �������� �̾Ƴٴ�.
            int RandomY = Random.Range(0, 12);                               //0~11������ �������� �̾Ƴٴ�.
            GameObject temp = Instantiate(TargetObject);                           //Instantiate �Լ��� ���ؼ� �������� �����Ѵ�.
            temp.transform.position = new Vector3(-6 + RandomX, -6 + RandomY, 0);  //�������� ���ؼ� -6 ~ 5 ������ ���� �����ϰ� ��ġ
            Destroy(temp, 1.0f);                                                   //���� �� �ı��� 1���Ŀ� ���ش�
            CheckTime = 0;                                                         //�ð��� �ʱ�ȭ ���ش�. (0.5�� ���� �ݺ��ϰ� �ϱ� ���ؼ�)
        }

        if (Input.GetMouseButtonDown(1))       //���콺 ������ ��ư�� ������ ���
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);         //ī�޶� ȭ�� �������� ���콺 �����ǿ��� Ray�� ���.

            RaycastHit hit;       

            if(Physics.Raycast(cast, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);

                if(hit.collider.gameObject.tag == "Target")
                {
                    Point += 1;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}

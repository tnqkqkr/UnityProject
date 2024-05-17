using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;                 //�巡�� ������ �Ǵ��ϴ� (bool)
    public bool isUsed;                 //��� �Ϸ� �Ǵ��ϴ� (bool)
    Rigidbody2D rigidbody2D;            //2D ��ü�� �ҷ��´�.

    public int index;                   //���� ��ȣ�� �����.

    void Awake()                                         //
    {
        isUsed = false;                                  //��� �Ϸᰡ ���� ����(ó�� ���)
        rigidbody2D = GetComponent<Rigidbody2D>();       //��ü�� �����´�.
        rigidbody2D.simulated = false;                   //�����ɶ��� �ùķ����� ���� �ʴ´�.
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsed) return;                              //���Ϸ�� ��ü�� ���� ������Ʈ ���� �ʱ� ���ؼ� return �� ���� �ش�.

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       //ȭ�鿡�� -> ���� ������ ��ġ ã���ִ� �Լ� ���
            float leftBorder = -4f + transform.localScale.x / 2f;                       //�ִ� �������� �� �� �ִ� ����
            float rightBorder = 4f - transform.localScale.x / 2f;                       //�ִ� ���������� �� �� �ִ� ����

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;   //�ִ� �������� �� �� �ִ� ������ �Ѿ��� �ִ� ���� ��ġ�� �����ؼ� �Ѿ�� ���ϰ� �Ѵ�.
            if (mousePos.x > rightBorder) mousePos.x = rightBorder; //�ִ� ���������� �� �� �ִ� ������ �Ѿ��� �ִ� ���� ��ġ�� �����ؼ� �Ѿ�� ���ϰ� �Ѵ�.

            mousePos.y = 8;
            mousePos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f); //�� ������Ʈ�� ��ġ�� ���콺 ��ġ�� �̵� �ȴ�. 0.2f �ӵ��� �̵� �ȴ�.
        }

        if (Input.GetMouseButtonDown(0)) Drag();         //���콺 ��ư�� ������ �� Drag �Լ� ȣ��
        if (Input.GetMouseButtonUp(0)) Drop();           //���콺 ��ư�� �ö� �� Drop �Լ� ȣ��
    }
    void Drag()
    { 
        isDrag = true;                  //�巡�� ���� (true)
        rigidbody2D.simulated = false;  //�巡�� �߿��� ���� ������ �Ͼ�°��� ���� ���ؼ� (false)
    }
    void Drop()
    {
        isDrag = false;                 //�巡�װ� ����
        isUsed = true;                  //����� �Ϸ�
        rigidbody2D.simulated = true;   //���� ���� ����

        GameObject Temp = GameObject.FindWithTag("GameManager");             //Tag : GameManager�� Scene ã�Ƽ� ������Ʈ�� �����´�.
        if(Temp != null)                                                     //�ش� ������Ʈ�� �����ϸ�
        {
            Temp.gameObject.GetComponent<GameManager>().GenObject();         //Genobject �Լ��� ȣ�� �Ѵ�. (GetComponent ���ؼ� Ŭ������ �����Ѵ�)
        }
    }

    public void Used()
    {
        isDrag = false;                     //�巡�װ� ����
        isUsed = true;                      //����� �Ϸ�
        rigidbody2D.simulated = true;       //���� ���� ����
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (index >= 7)                     //�غ�� ������ �ִ� 7��
            return;

        if (collision.gameObject.tag == "Fruit")        //�浹 ��ü�� TAG �� Furit �� ���
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>();  //�ӽ÷� Class temp�� �����ϰ� �浹ü�� Class(CircleObject)�� �޾ƿ´�.

            if(temp.index == index) //���� ��ȣ�� ���� ���
            {
                if (gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())  //����Ƽ���� �����ϴ� ������ ID�� �޾ƿͼ� ID�� ū�ʿ��� ���� ���� ����
                {
                    GameObject Temp = GameObject.FindWithTag("GameManager");             //Tag : GameManager�� Scene ã�Ƽ� ������Ʈ�� �����´�.
                    if (Temp != null)                                                     //�ش� ������Ʈ�� �����ϸ�
                    {
                        Temp.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);        //Genobject �Լ��� ȣ�� �Ѵ�. (GetComponent ���ؼ� Ŭ������ �����Ѵ�)
                    }

                    Destroy(temp.gameObject);                                       //�浹 ��ü �ı�
                    Destroy(gameObject);                                            //�ڱ� �ڽ� �ı�
                }
            }
        }
    }
}

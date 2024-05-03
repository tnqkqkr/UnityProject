using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CircleObject;                                  //���� ������ ������Ʈ
    public Transform GenTransform;                                   //������ ������ ��ġ ������Ʈ
    public float TimeCheck;                                          //�ð��� üũ�ϱ� ���� (float) ��
    public bool isGen;                                               //���� �Ϸ� üũ (bool) ��

    void Start()
    {
        GenObject();                                                 //������ ���۵Ǿ����� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��.
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGen)   // if(isGen == false)
        {
            TimeCheck -= Time.deltaTime;                            //�� �����Ӹ��� ������ �ð��� ���ش�
            if(TimeCheck <= 0)
            {
                GameObject Temp = Instantiate(CircleObject);
                Temp.transform.position = GenTransform.position;
                isGen = true;
            }
        }
    }
    public void GenObject()
    {
        isGen = false;                  //�ʱ�ȭ : isGen�� false (���� ���� �ʾҴ�)
        TimeCheck = 1.0f;               //1���� ���� �������� ���� ��Ű�� ���� �ʱ�ȭ
    }
}

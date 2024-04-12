using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                                                        //UI를 사용하기 위해서
using UnityEngine.SceneManagement;                                           //Scene 이동 하기 위해서

public class ExRayCast : MonoBehaviour
{
    public int Point = 0;                                                    //포인트 게산 변수
    public GameObject TargetObject;                                          //타겟 프리팹
    public float CheckTime = 0;                                              //타겟 Gen 시간 변수
    public float GameTime = 30.0f;                                           //게임 시간 설정

    public Text pointUI;                                                     //Unity UI 설정
    public Text timeUI;                                                      //Unity UI 설정
    void Update()
    {
        CheckTime += Time.deltaTime;                                         //프레임이 누적되어시간을 계산하게 한다.
        GameTime -= Time.deltaTime;                                          //프레임 시간을 제거하여 30초 -> 0초로 가게 한다.
        
        if(GameTime <= 0)                                                    //0초가 되면
        {
            PlayerPrefs.SetInt("Point", Point);                              //유니티에서 제공하는 저장 함수
            SceneManager.LoadScene("MainScene");                             //MainScene으로 이동한다.
        }

        pointUI.text = "점수 : " + Point.ToString();                         //UI 점수 표시
        timeUI.text = "남은 시간 : " + GameTime.ToString() + "s";            //UI 남은 시간 표시


        if(CheckTime >= 0.5f)                                                //0.5초 마다 행동을 한다.
        {
            int RandomX = Random.Range(0, 12);                               //0~11사이의 랜덤값을 뽑아넨다.
            int RandomY = Random.Range(0, 12);                               //0~11사이의 랜덤값을 뽑아넨다.
            GameObject temp = Instantiate(TargetObject);                           //Instantiate 함수를 통해서 프리팹을 생성한다.
            temp.transform.position = new Vector3(-6 + RandomX, -6 + RandomY, 0);  //랜덤값을 더해서 -6 ~ 5 사이의 값을 랜덤하게 배치
            Destroy(temp, 1.0f);                                                   //생성 후 파괴를 1초후에 해준다
            CheckTime = 0;                                                         //시간을 초기화 해준다. (0.5초 마다 반복하게 하기 위해서)
        }

        if (Input.GetMouseButtonDown(1))       //마우스 오른쪽 버튼이 눌렸을 경우
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);         //카메라를 화면 시점에서 마우스 포지션에서 Ray를 쏜다.

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenChange : MonoBehaviour
{
    public bool isPunch = false;               //연속적으로 입력이 들어오는것을 막기위한 Flag 값

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPunch)        //펀치 체크가 false 일 경우
            {
                isPunch = true;
                transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.1f, 10, 1).OnComplete(EndPuch);
            }
        }
    }

    void EndPuch()
    {
        isPunch = false;
    }
}

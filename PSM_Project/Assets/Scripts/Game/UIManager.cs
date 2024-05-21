using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text pointText;                  //���� ǥ���� UI
    public Text bestscoreText;              //�ְ� ���� ǥ���� UI

    void OnEnable()
    {
        GameManager.OnPointChanged += UpdatePointText;                      //�̺�Ʈ ���
        GameManager.OnBsetScoreChanged += UpdateBestScoreText;              //�̺�Ʈ ���
    }

    void OnDisable()
    {
        GameManager.OnPointChanged -= UpdatePointText;                      //�̺�Ʈ ����
        GameManager.OnBsetScoreChanged -= UpdateBestScoreText;              //�̺�Ʈ ����
    }

    void UpdatePointText(int newPoint)              //�Լ� �̺�Ʈ�� ���� �μ��� ����
    {
        pointText.text = "Points : " + newPoint;
    }

    void UpdateBestScoreText(int newBestScore)  //�Լ� �̺�Ʈ�� ���� �μ��� ����
    {
        bestscoreText.text = "Best Score : " + newBestScore;
    }
}

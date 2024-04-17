using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TweenUI : MonoBehaviour
{
    public float duration = 1f;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();                                                           //�̹��� ������Ʈ�� �����´�.

        image.DOFade(0f , duration)                                  //UI Fade �� �Ѵ�. 0 : ����ó��
            .SetEase(Ease.InOutQuad)
            .SetAutoKill(false)
            .Pause()
            .OnComplete(() => Debug.Log("UI �Ϸ�"));

        image.DOPlay();
    }

   
}

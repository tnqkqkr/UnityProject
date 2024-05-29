using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Xml.Serialization;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicMasterSlider;
    [SerializeField] private Slider musicBGMSlider;
    [SerializeField] private Slider musicSFXSlider;

    //�����̴� MinValue 0.001 ���� ������ Log10 ������ �Ǿ��ֱ� ������
    private void Awake()
    {
        //������ �����̴��� ���� ����ɶ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicMasterSlider.onValueChanged.AddListener(SetMasterVolume);
        //BGM �����̴��� ���� ����ɶ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicBGMSlider.onValueChanged.AddListener(SetMasterVolume);
        //SFX �����̴��� ���� ����ɶ� �����ʸ� ���ؼ� �Լ��� ���� �����Ѵ�.
        musicSFXSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    public void SetMasterVolume(float volume)                       //������ ���� �����̴��� Mixer�� �ݿ��ǰ�
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);        //������ Log10������ x20�� ���ش�.
    }
    public void SetBGMVolume(float volume)                          //BGM ���� �����̴��� Mixer�� �ݿ��ǰ�
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);           //������ Log10������ x20�� ���ش�.
    }
    public void SetSFXVolume(float volume)                          //SFX ���� �����̴��� Mixer�� �ݿ��ǰ�
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);           //������ Log10������ x20�� ���ش�.
    }
}

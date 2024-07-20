using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#region ������
#endregion

public class AudioController : MonoBehaviour
{
    public Slider slider;
    public TMP_InputField inputField;

    [SerializeField] float currentVolume;
    [SerializeField] float lastVolume;

    public AudioSource testAudio;

    private void Awake()
    {
        testAudio.volume = slider.value = AudioManager.Instance.masterVolume;
        UpdateSliderValueToTMP();

        slider.onValueChanged.AddListener(OnSliderValueChanged);
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    void SetTestAudioVolume()
    {
        print("�׽�Ʈ ����� ���� ����");
        testAudio.volume = slider.value = currentVolume;
    }

    public void SetTestAudioVolume(float value)
    {
        print("�׽�Ʈ ����� ���� ���޵� ������ ����");
        testAudio.volume = value;
    }

    void SendValueToAudioManager()
    {
        AudioManager.Instance.SetMasterVolume(currentVolume);
    }

    /// <summary>
    /// <seealso cref="slider"/>�� value�� <seealso cref="inputField"/>�� text�� ������� �ݿ�
    /// </summary>
    void UpdateSliderValueToTMP()
    {
        int intValue = Mathf.RoundToInt(slider.value * 100f);
        inputField.text = intValue.ToString();
    }

    /*
     public void OnSliderValueChanged(float value)
    {
        if(value == lastVolume)
        {
            return;
        }

        if(value >= 0f && value <= 1f)
        {
            AudioManager.Instance.SetMasterVolume(value);
            UpdateSliderValueToTMP();
        }
    }
     
     */

    public void OnSliderValueChanged(float value)
    {
        slider.value = value;
        print($"�����̴� �� ����: {slider.value}");

        UpdateSliderValueToTMP();
        SetTestAudioVolume();
    }

    public void OnInputFieldValueChanged(string value)
    {
        int intValue = int.Parse(value);

        if(intValue >= 0 && intValue <= 100)
        {
            currentVolume = Mathf.Clamp01(intValue / 100f);
        }
        else
        {
            currentVolume = lastVolume;
        }

        OnSliderValueChanged(currentVolume);

        lastVolume = currentVolume;
    }
}

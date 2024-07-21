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
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    private void OnEnable()
    {
        testAudio.volume = slider.value = AudioManager.Instance.masterVolume;
        UpdateSliderValueToTMP();
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

    public void SendValueToAudioManager()
    {
        AudioManager.Instance.SetMasterVolume(currentVolume);

        print($"������ ����: {AudioManager.Instance.masterVolume}");
    }

    /// <summary>
    /// <seealso cref="slider"/>�� value�� <seealso cref="inputField"/>�� text�� ������� �ݿ�
    /// </summary>
    void UpdateSliderValueToTMP()
    {
        int intValue = Mathf.RoundToInt(slider.value * 100f);
        inputField.text = intValue.ToString();
    }

    /// <summary>
    /// �����̴� ���� ����Ǿ��� �� ����� �޼���
    /// </summary>
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

        if (intValue > 100 || intValue < 0)
        {
            currentVolume = lastVolume;
        }
        else
        {
            currentVolume = lastVolume = Mathf.Clamp01(intValue / 100f);
        }

        OnSliderValueChanged(currentVolume);
    }
}

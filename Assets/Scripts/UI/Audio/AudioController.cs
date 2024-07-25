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
    public TMP_InputField inputFieldTMP;
    public InputField inputField;

    [SerializeField] float currentVolume;
    [SerializeField] float lastVolume;

    public AudioSource testAudio;

    private void Awake()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        //inputFieldTMP.onValueChanged.AddListener(OnInputFieldTMPValueChanged);

        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);

    }

    private void OnEnable()
    {
        testAudio.volume = slider.value = AudioManager.Instance.masterVolume;
        //UpdateSliderValueToTMP();
        UpdateSliderValueToText();
    }

    void SetTestAudioVolume()
    {
        print("�׽�Ʈ ����� ���� ����");

        slider.value = currentVolume;
        testAudio.volume = currentVolume;
    }

    void SetTestAudioVolume(float value)
    {
        testAudio.volume = value;
    }

    public void SendValueToAudioManager()
    {
        AudioManager.Instance.SetMasterVolume(currentVolume);

        print($"������ ������ ����: {AudioManager.Instance.masterVolume}");
    }

    /// <summary>
    /// <seealso cref="slider"/>�� value�� <seealso cref="inputFieldTMP"/>�� text�� ������� �ݿ�
    /// ��Ʈ ���� ������ ���Ž÷� ����
    /// </summary>
    void UpdateSliderValueToTMP()
    {
        int intValue = Mathf.RoundToInt(slider.value * 100f);
        inputFieldTMP.text = intValue.ToString();
    }

    /// <summary>
    /// <seealso cref="slider"/>�� value�� <seealso cref="inputField"/>�� text�� ������� �ݿ�
    /// </summary>
    void UpdateSliderValueToText()
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

        //UpdateSliderValueToTMP();

        UpdateSliderValueToText();
        SetTestAudioVolume();
    }

    /// <summary>
    /// <seealso cref="inputFieldTMP"/>�� �ùٸ� ���ڰ� �ԷµǾ��� �� 0���� 1�� ����ȭ�ؼ� ���� 
    /// </summary>
    /// <param name="value"></param>
    public void OnInputFieldTMPValueChanged(string value)
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

    /// <summary>
    /// <seealso cref="inputField"/>�� �ùٸ� ���ڰ� �ԷµǾ��� �� 0���� 1�� ����ȭ�ؼ� ���� 
    /// </summary>
    /// <param name="value"></param>
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

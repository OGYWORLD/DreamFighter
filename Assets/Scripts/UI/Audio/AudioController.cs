using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#region 우인혜
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
        print("테스트 오디오 볼륨 변경");

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

        print($"마스터 볼륨에 전달: {AudioManager.Instance.masterVolume}");
    }

    /// <summary>
    /// <seealso cref="slider"/>의 value를 <seealso cref="inputFieldTMP"/>의 text에 백분위로 반영
    /// 폰트 깨짐 문제로 레거시로 변경
    /// </summary>
    void UpdateSliderValueToTMP()
    {
        int intValue = Mathf.RoundToInt(slider.value * 100f);
        inputFieldTMP.text = intValue.ToString();
    }

    /// <summary>
    /// <seealso cref="slider"/>의 value를 <seealso cref="inputField"/>의 text에 백분위로 반영
    /// </summary>
    void UpdateSliderValueToText()
    {
        int intValue = Mathf.RoundToInt(slider.value * 100f);
        inputField.text = intValue.ToString();
    }

    /// <summary>
    /// 슬라이더 값이 변경되었을 때 실행될 메서드
    /// </summary>
    public void OnSliderValueChanged(float value)
    {
        slider.value = value;
        print($"슬라이더 값 변경: {slider.value}");

        //UpdateSliderValueToTMP();

        UpdateSliderValueToText();
        SetTestAudioVolume();
    }

    /// <summary>
    /// <seealso cref="inputFieldTMP"/>에 올바른 숫자가 입력되었을 때 0에서 1로 정규화해서 적용 
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
    /// <seealso cref="inputField"/>에 올바른 숫자가 입력되었을 때 0에서 1로 정규화해서 적용 
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#region 우인혜
#endregion

public class AudioSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderTMP;

    private void Awake()
    {
        // 기본으로 설정해 둔 음량으로 슬라이더 초기화
        slider.value = AudioManager.Instance.masterVolume;
        UpdateSliderValueToTMP();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void UpdateSliderValueToTMP()
    {
        int intValue = Mathf.RoundToInt(slider.value * 100f);

        sliderTMP.text = intValue.ToString();
    }

    public void OnSliderValueChanged(float value)
    {
        AudioManager.Instance.SetMasterVolume(value);
        UpdateSliderValueToTMP();
    }
}

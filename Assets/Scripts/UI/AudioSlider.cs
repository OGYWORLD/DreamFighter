using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#region ������
#endregion

public class AudioSlider : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderTMP;

    private void Awake()
    {
        // �⺻���� ������ �� �������� �����̴� �ʱ�ȭ
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

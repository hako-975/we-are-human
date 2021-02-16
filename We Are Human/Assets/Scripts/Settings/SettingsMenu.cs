using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixerBGM;
    public Slider sliderVolume;
    public Slider sliderBGM;
    public Slider cameraDistance;
    public Slider sensitivityTouchField;
    public Dropdown dropdownQuality;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void SetBGM(float bgm)
    {
        audioMixerBGM.SetFloat("bgm", bgm);
        PlayerPrefs.SetFloat("bgm", bgm);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
    }

    public void SetCameraDistance(float cameraDistance)
    {
        PlayerPrefs.SetFloat("cameraDistance", cameraDistance);
    }

    public void SetSensitivityTouchField(float sensitivity)
    {
        PlayerPrefs.SetFloat("sensitivityTouchField", sensitivity);
    }

    public void SetDefaultSettings()
    {
        PlayerPrefs.DeleteKey("volume");
        PlayerPrefs.DeleteKey("bgm");
        PlayerPrefs.DeleteKey("qualityIndex");
        PlayerPrefs.SetFloat("cameraDistance", 4f);
        PlayerPrefs.SetFloat("sensitivityTouchField", 5f);
    }

    private void Update()
    {
        if (PlayerPrefs.GetFloat("cameraDistance") == 0f)
        {
            PlayerPrefs.SetFloat("cameraDistance", 4f);
        }

        if (PlayerPrefs.GetFloat("sensitivityTouchField") == 0f)
        {
            PlayerPrefs.SetFloat("sensitivityTouchField", 5f);
        }

        sliderVolume.value = PlayerPrefs.GetFloat("volume");
        sliderBGM.value = PlayerPrefs.GetFloat("bgm");
        dropdownQuality.value = PlayerPrefs.GetInt("qualityIndex");
        cameraDistance.value = PlayerPrefs.GetFloat("cameraDistance");
        sensitivityTouchField.value = PlayerPrefs.GetFloat("sensitivityTouchField");
    }

}

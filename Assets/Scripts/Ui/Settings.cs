using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle buttonsToggle;

    public GameObject settingsMenu;

    private float volume;
    public float Volume { get { return volume; } set { volume = value; Background._instance.UpdateGlobalVolume(volume); } }

    void Start()
    {
        


       
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);


        buttonsToggle.onValueChanged.AddListener(OnToggleValueChanged);
        buttonsToggle.isOn = PlayerPrefs.GetInt("buttons", 1) == 1 ? true : false;
        Background._instance.buttonSound.Stop();

        settingsMenu.SetActive(false);

    }

    private void OnSliderValueChanged(float newValue)
    {
        UpdateVolume();
    }

    private void OnToggleValueChanged(bool isOn)
    {
        PlayerPrefs.SetInt("buttons", isOn ? 1 : 0);
        var uiManager = UiManager.Instance;
        if (uiManager != null)
        {
            uiManager.ToggleControlsButtons();
        }

    }

    public void ButtonSound()
    {
        Background._instance.ButtonSound();
    }

    private void UpdateVolume()
    {
        Volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", Volume);
    }

    public void ToggleSettingsMenu(bool toggle)
    {
        settingsMenu.SetActive(toggle);
    }
}

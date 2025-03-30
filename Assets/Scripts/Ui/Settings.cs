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
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
        UpdateVolume();
        volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        buttonsToggle.isOn = PlayerPrefs.GetInt("buttons", 1) == 1 ? true : false;
        buttonsToggle.onValueChanged.AddListener(OnToggleValueChanged);

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

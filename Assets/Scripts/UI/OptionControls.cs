using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OptionControls : MonoBehaviour
{

    [SerializeField] private GameObject soundSliderObject;
    [SerializeField] private GameObject resolutionDropdownObject;

    private UnityEngine.UI.Slider slider;
    private UnityEngine.UI.Dropdown dropdown;

    private bool soundBlocked = true;
    private float soundBlockedVal;
    private Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        slider = soundSliderObject.GetComponent<UnityEngine.UI.Slider>();
        dropdown = resolutionDropdownObject.GetComponent<UnityEngine.UI.Dropdown>();
       
        if (PlayerPrefs.GetFloat("volume")!=0)
        {
            slider.value = PlayerPrefs.GetFloat("volume");
        } else
        {
            slider.value = 50;
            UpdateSound();
        }

        soundBlockedVal = slider.value;

        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
        {
            dropdown.options[i].text = resolutions[i].ToString();
            dropdown.options.Add(new UnityEngine.UI.Dropdown.OptionData(dropdown.options[i].text));
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateSound()
    {
        if (!soundBlocked)
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            AudioListener.volume = slider.value;
        }
        else
        {
            slider.value = soundBlockedVal;
        }

    }

    public void UpdateResolution()
    {
        Debug.Log(resolutions[dropdown.value]);
        Screen.SetResolution(resolutions[dropdown.value].width,resolutions[dropdown.value].height,false);
    }

    public void onSouth(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            soundBlocked = false;
        } else if (context.canceled)
        {
            soundBlockedVal = slider.value;
            soundBlocked = true;
        }
    }
}

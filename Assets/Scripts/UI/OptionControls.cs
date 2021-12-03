using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        }


        UpdateSound();

        soundBlockedVal = slider.value;

        resolutions = Screen.resolutions.Select(resolution =>
            new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionString = resolutions[i].width.ToString() + " X " + resolutions[i].height.ToString();
            dropdown.options[i].text = resolutionString;
            dropdown.options.Add(new UnityEngine.UI.Dropdown.OptionData(dropdown.options[i].text));
        }

        //we use this to refresh the dropdown menu 
        dropdown.value = 1;
        dropdown.value = 0;
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
        Screen.SetResolution(resolutions[dropdown.value].width,resolutions[dropdown.value].height,false);
    }

    public void onSouth(InputAction.CallbackContext context)
    {
        if (gameObject.activeSelf)
        {
            if (context.started)
            {
                soundBlocked = false;
            }
            else if (context.canceled)
            {
                soundBlockedVal = slider.value;
                soundBlocked = true;
            }
        }

    }
}

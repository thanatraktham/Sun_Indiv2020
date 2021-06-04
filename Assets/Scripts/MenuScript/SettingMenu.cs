using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    string option;

    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }

    void Start() {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();
        // option = "450" + " x " + "800";
        options.Add("360 x 640");
        options.Add("450 x 800");
        // option = "576" + " x " + "1024";
        options.Add("576 x 1024");
        currentResolutionIndex = 1;
        // for (int i = 0; i < resolutions.Length; i++) {
        //     option = resolutions[i].width + " x " + resolutions[i].height;
        //     options.Add(option);

        //     if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
        //         currentResolutionIndex = i;
        //     }
        // }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }


    public void SetResolution(int resolutionIndex) {
        // Resolution resolution = resolutions[resolutionIndex];
        if (resolutionIndex == 0) {
            Screen.SetResolution(360,640, Screen.fullScreen);
        } else if (resolutionIndex == 1) {
            Screen.SetResolution(450,800, Screen.fullScreen);
        } else if (resolutionIndex == 2) {
            Screen.SetResolution(576,1024,  Screen.fullScreen);
        }
        // Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void setResolution1() {
        Screen.SetResolution(360,640, Screen.fullScreen);
    }

    public void setResolution2() {
        Screen.SetResolution(450,800, Screen.fullScreen);
    }

    public void setResolution3() {
        Screen.SetResolution(576,1024, Screen.fullScreen);
    }
}

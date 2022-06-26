using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution_Option : MonoBehaviour
{
    // Start is called before the first frame update
    FullScreenMode screenMode;

    //public Dropdown resolutionDropdown;
    //public Toggle fullscreenBtn;
    //List<Resolution> resolutions = new List<Resolution>();

    //----
    List<int> widths = new List<int>() { 1440, 1920 };
    List<int> heights = new List<int>() { 900, 1080 };

    int resolutionNum;


    public void SetScreenSize (int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];

        Screen.SetResolution(width, height, fullscreen);
    }

    public void SetFullscreen (bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;
    }

    void Start()
    {
        //InitUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void InitUI()
    //{
    //    for(int i = 0; i < Screen.resolutions.Length; i++)
    //    {
    //        if(Screen.resolutions[i].refreshRate == 60)
    //        {
    //            resolutions.Add(Screen.resolutions[i]);
    //        }
    //    }
        
    //    //resolutions.AddRange(Screen.resolutions);
    //    resolutionDropdown.options.Clear();

    //    int optionNum = 0;

    //    foreach (Resolution item in resolutions)
    //    {
    //        //Debug.Log(item.width + "x" + item.height + " " + item.refreshRate);
    //        Dropdown.OptionData option = new Dropdown.OptionData();
    //        option.text = item.width + " X " + item.height;
    //        resolutionDropdown.options.Add(option);

    //        if(item.width == Screen.width && item.height == Screen.height)
    //        {
    //            resolutionDropdown.value = optionNum;
    //            optionNum++;
    //        }
    //    }

    //    resolutionDropdown.RefreshShownValue();

    //    fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    //}

    //public void DropboxOptionChange(int x)
    //{
    //    resolutionNum = x;
    //}

    //public void FullScreenBtn(bool isFull)
    //{
    //    screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    //}

    //public void OkBtnClick()
    //{
    //    Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    //}
}

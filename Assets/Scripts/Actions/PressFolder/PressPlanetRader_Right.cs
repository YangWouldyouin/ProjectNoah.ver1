using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressPlanetRader_Right : MonoBehaviour 
{
    public Image raderLine_PRR; // 레이더 라인

    public Button PressPlanetRaderLeftButton;

    
    public void OnPressButtonClicked()
    {
        raderLine_PRR.transform.Rotate(0, 0, -5);
        PressPlanetRaderLeftButton.onClick.RemoveAllListeners();
    }

    
}

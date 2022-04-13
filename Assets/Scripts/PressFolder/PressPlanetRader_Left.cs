using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressPlanetRader_Left : MonoBehaviour, IPressController
{
    public Image raderLine_PRL; // 레이더 라인
    public Button PressPlanetRaderLeftButton;
    public void OnPressButtonClicked()
    {
        raderLine_PRL.transform.Rotate(0, 0, 5);
        PressPlanetRaderLeftButton.onClick.RemoveAllListeners();
        InteractionButtonController.interactionButtonController.TurnOffInteractionButton();
    }
}

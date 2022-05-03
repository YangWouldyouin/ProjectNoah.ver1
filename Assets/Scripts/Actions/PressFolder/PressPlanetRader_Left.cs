using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressPlanetRader_Left : MonoBehaviour
{
    public Image raderLine_PRL; // 레이더 라인

    void OnMouseDown()
    {
        Debug.Log("Move Left");
        raderLine_PRL.transform.Rotate(0, 0, 5);
    }
}

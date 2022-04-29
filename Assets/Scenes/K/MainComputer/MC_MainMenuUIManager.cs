using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MC_MainMenuUIManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public GameObject Select_Bar_1; // ���콺 ���� �� ��� �� �Ͼ���
    public GameObject Select_Bar_2;
    public GameObject Select_Bar_3;
    public GameObject Select_Bar_4;

    void Start()
    {
    }


    void Update()
    {
    }

    public void Show_Bar()
    {
        Select_Bar_1.SetActive(true);
    }

    public void Hide_Bar()
    {
        Select_Bar_1.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       Show_Bar();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Hide_Bar();
    }

}

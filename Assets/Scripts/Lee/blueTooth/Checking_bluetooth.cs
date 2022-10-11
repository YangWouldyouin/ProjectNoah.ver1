using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_bluetooth : MonoBehaviour
{
    //public GameObject dialogManager_CCB;
    //DialogManager dialogManager;
    
    //public GameObject canConnect;

    public GameObject tablet;
    public GameObject RChip01;
    public GameObject WChip01;

    public GameObject player;

    ObjData tabletData;
    ObjData RChip01Data;
    ObjData WChip01Data;

    public ObjectData TabletData;
    public ObjectData RChipData;
    public ObjectData WChipData;

    public GameObject dialog;
    DialogManager dialogManager;

    //public static bool IsCanConnect;

    //public GameObject tablet;

    GameObject portableGroup;
    PlayerEquipment equipment;

    private bool IsAlert = false;
    private bool IsCheck = false;

    void Start()
    {
        portableGroup = InteractionButtonController.interactionButtonController.portableObjects;
        equipment = BaseCanvas._baseCanvas.equipment;
        dialogManager = dialog.GetComponent<DialogManager>();

        tabletData = tablet.GetComponent<ObjData>();
        RChip01Data = RChip01.GetComponent<ObjData>();
        WChip01Data = WChip01.GetComponent<ObjData>();
    }

    public void OnTriggerStay(Collider other)
    {
        if(!IsCheck && other.gameObject.name == "Tablet_E")
        {
            GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            IsCheck = true;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        // - 노아가 타블렛 물고 영역 안에 있을 때
        // - 타블렛이 영역 안에 있을 때
        if ((other.gameObject == player) && TabletData.IsBite)
        {
            GameManager.gameManager._gameData.IsCanConnect_C_MS = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }

        if (other.gameObject == player)
        {
            if (RChipData.IsBite )
            {
                GameData gameData = SaveSystem.Load("save_001");
                if(!gameData.IsHide)
                {
                    Debug.Log("이상한 칩 감지");
                    IsAlert = true;
                    StartCoroutine(DestroyChip(RChip01, RChipData));
                    //Invoke("NoRChip", 3f);
                    dialogManager.StartCoroutine(dialogManager.PrintAIDialog(57));
                }
            }

            if (WChipData.IsBite)
            {
                GameData gameData = SaveSystem.Load("save_001");
                if(!gameData.IsHide)
                {
                    Debug.Log("이상한 칩 감지");
                    IsAlert = true;
                    StartCoroutine(DestroyChip(WChip01, WChipData));
                    //Invoke("NoWChip", 3f);
                    dialogManager.StartCoroutine(dialogManager.PrintAIDialog(57));
                }
            }
        }


       /*if (other.tag == "chip")
        {
            if(GameManager.gameManager._gameData.IsHide)
            {
                Debug.Log("������");
            }

            else
            {
                Debug.Log("�� ���� ���Ͻô�????");
                //AI�� ����ϴ� ��� ���

                GameManager.gameManager._gameData.IsAlert = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }

        }*/
    }

    
    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "noahPlayer")
        {
            if (tabletData.IsBite)
            {
                GameManager.gameManager._gameData.IsCanConnect_C_MS = false;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }

            if (RChip01Data.IsBite || WChip01Data.IsBite)
            {
                Debug.Log("이상한 칩 나감");
                IsAlert = false;
            }
        }
    }

    IEnumerator DestroyChip(GameObject _chip, ObjectData _objectData)
    {
        yield return new WaitForSecondsRealtime(3f);
        _chip.GetComponent<Rigidbody>().isKinematic = false;
        _chip.transform.parent = null;
        _chip.transform.parent = portableGroup.transform;
        equipment.biteObjectName = "";
        _objectData.IsBite = false;

        _chip.SetActive(false);
        IsAlert = false;
    }

    public void NoRChip()
    {
        RChip01.GetComponent<Rigidbody>().isKinematic = false;
        RChip01.transform.parent = null;
        RChip01.transform.parent = portableGroup.transform;
        equipment.biteObjectName = "";
        RChipData.IsBite = false;

        RChip01.SetActive(false);
        IsAlert = false;
    }

    public void NoWChip()
    {
        WChip01.GetComponent<Rigidbody>().isKinematic = false;
        WChip01.transform.parent = null;
        RChip01.transform.parent = portableGroup.transform;
        equipment.biteObjectName = "";

        WChipData.IsBite = false;

        WChip01.SetActive(false);
        IsAlert = false;
    }
}

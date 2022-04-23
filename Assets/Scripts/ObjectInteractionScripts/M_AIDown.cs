using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AIDown : MonoBehaviour
{
    public GameObject portDoor;
    public GameObject portInsert;
    public GameObject rightDisturbingChip;
    public GameObject wrongDisturbingChip;

    ObjData portDoorData;
    ObjData portInsertData;
    ObjData rightDisturbingChipData;
    ObjData wrongDisturbingChipData;

    Outline portDoorLine;
    Outline portInsertLine;
    Outline rightDisturbingChipLine;
    Outline wrongDisturbingChipLine;

    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        portDoorData = portDoor.GetComponent<ObjData>();
        portInsertData = portInsert.GetComponent<ObjData>();
        rightDisturbingChipData = rightDisturbingChip.GetComponent<ObjData>();
        wrongDisturbingChipData = wrongDisturbingChip.GetComponent<ObjData>();

        portDoorLine = portDoor.GetComponent<Outline>();
        portInsertLine = portInsert.GetComponent<Outline>();
        rightDisturbingChipLine = rightDisturbingChip.GetComponent<Outline>();
        wrongDisturbingChipLine = wrongDisturbingChip.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InsertChip()
    {
        if (rightDisturbingChipData.IsPushOrPress)
        {

        }
    }
}

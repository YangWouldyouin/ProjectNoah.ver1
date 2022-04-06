using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SLManager : MonoBehaviour
{
    void Update()
    {
        /* ���� ���� */
        if (Input.GetKeyDown("s"))
        {
            GameData character = new GameData();

            character.IsAIAwake_M_C1 = false;
            character.IsCWDoorOpened_M_C1 = false;

            SaveSystem.Save(character, "save_001");
        }

        /* ���� ���� �ҷ��� */
        if (Input.GetKeyDown("l"))
        {
            GameData loadData = SaveSystem.Load("save_001");
            Debug.Log(string.Format("LoadData Result => IsAIAwake : {0}, IsCWDoorOpened : {1} ", loadData.IsAIAwake_M_C1, loadData.IsCWDoorOpened_M_C1));
        }
    }
}




//GameData character = new GameData(false, false);
//SaveSystem.Save(character, "save_001");
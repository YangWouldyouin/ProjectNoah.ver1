using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSkip : MonoBehaviour
{
    public InGameTime inGameTime;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            GameManager.gameManager._gameData.IsTutorialClear = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            inGameTime.timer = 0;
            inGameTime.hours = 0;
            inGameTime.days = 0;
            inGameTime.statNum = 10;

            SceneManager.LoadScene("new cockpit");
        }
    }
}

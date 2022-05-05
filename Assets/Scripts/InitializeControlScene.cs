using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeControlScene : MonoBehaviour
{
    public Animator controlWorkDoorAnim;
    public GameObject ChangeScene;
    // Start is called before the first frame update
    void Start()
    {
        GameData intialGameData = SaveSystem.Load("save_001");

        if(intialGameData.IsCWDoorOpened_M_C1)
        {
            controlWorkDoorAnim.SetBool("IsDoorOpenStart", true);
            controlWorkDoorAnim.SetBool("IsDoorOpened", true);
            ChangeScene.SetActive(true);
        }
    }

}

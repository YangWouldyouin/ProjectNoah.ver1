using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCameraController : MonoBehaviour
{
    Transform target;
    public Vector3 offset;
    GameData gameData;

    public GameObject workLight;

    void Start()
    {

        target = BaseCanvas._baseCanvas.noahPlayer.transform;
        gameData = SaveSystem.Load("save_001");
        if(gameData.IsCWDoorOpened_M_C1)
        {
            this.enabled = true;
            workLight.SetActive(true);
        }
        else
        {
            this.enabled = false;
            workLight.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, -31.54f, -25.19f), transform.position.y, transform.position.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockDoor : MonoBehaviour
{
    public static UnLockDoor unlockDoor { get; private set; }

    public bool isDoorPipeInserted = false;

    public GameObject OpenDoorPlayer;

    public GameObject PlayerDoorOpenPosition, PlayerOriginPosition;
    public GameObject DoorOpenPosition;
    //GoToWork;

    private void LateUpdate()
    {
        if (PlayerScripts.playerscripts.isPipeInserted && PlayerScripts.playerscripts.isDoorClickAreaClicked)
        {
            InteractionButtonController.interactionButtonController.ChangeInsertfalse();
            InteractionButtonController.interactionButtonController.TurnOffInsertArea();

            Time.timeScale = 1f;

            OpenDoorPlayer.transform.position = Vector3.Lerp(PlayerOriginPosition.transform.position, PlayerDoorOpenPosition.transform.position, Time.deltaTime * 20);
            transform.position = Vector3.Lerp(transform.position, DoorOpenPosition.transform.position, Time.deltaTime * 6);
            
            if (OpenDoorPlayer.transform.position.z>0.05f)
            {
                //GoToWork.SetActive(true);
                PlayerScripts.playerscripts.isDoorClickAreaClicked = false;
            }
        }
    }

    void OpenTheDoor()
    {
        InteractionButtonController.interactionButtonController.TurnOffInsertArea();
        OpenDoorPlayer.transform.position = new Vector3(22f, 34.03531f, 0.0500102f);
    }

    private void Awake()
    {
        unlockDoor = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="EnvirPipe")
        {
            isDoorPipeInserted = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "EnvirPipe")
        {
            isDoorPipeInserted = false;
        }
    }   
}

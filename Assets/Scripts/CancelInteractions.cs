using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CancelInteractions : MonoBehaviour
{
    public GameObject portableObjects;

    private float objectDistance = 1f;

    GameObject noahPlayer;
    NavMeshAgent agent;
    Animator playerAnimation;
    BoxCollider noahCollider;

    GameObject upDownObject, biteObject, pushObject, noahNovepushobject, observeObject;

    TMPro.TextMeshProUGUI CancelObjectText;

    PlayerEquipment playerObject;
    ObjectData cancelObjectData;
    ObjData biteData, pushData;

    private void Start()
    {
        noahPlayer = BaseCanvas._baseCanvas.noahPlayer;
        playerAnimation = noahPlayer.GetComponent<Animator>();
        agent = noahPlayer.GetComponent<NavMeshAgent>();
        playerObject = BaseCanvas._baseCanvas.equipment;
        CancelObjectText = BaseCanvas._baseCanvas.objectText;
        noahCollider = noahPlayer.GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            CancelInteract();
        }
    }

    public void CancelInteract()
    {
        observeObject = PlayerScripts.playerscripts.currentObserveObj;

        upDownObject = PlayerScripts.playerscripts.currentUpObj;

        /* 상호작용 취소 순서 : 관찰 -> 오르기 -> 물기 */
        for (int i = 3; i > 0; i--)
        {
            /* 관찰하기 취소 */
            if (i == 3 && observeObject != null)
            {
                ObjData cancelObserveData = observeObject.GetComponent<ObjData>();
                if (cancelObserveData.objectDATA.IsObserve)
                {
                    noahCollider.enabled = true;
                    CameraController.cameraController.CancelObserve();
                    break;
                }
                else
                {
                    continue;
                }
            }/* 오르기 취소 */
            else if (i == 2 && upDownObject != null)
            {
                ObjData cancelUpDownData = upDownObject.GetComponent<ObjData>();
                if (cancelUpDownData.objectDATA.IsUpDown)
                {
                    InteractionButtonController.interactionButtonController.PlayerFall1();
                    break;
                }
                else
                {
                    continue;
                }
            }/* 물기 취소   else if (i == 1 && biteObject != null)*/
            else if (i == 1 && playerObject.biteObjectName != "")
            {
                InteractionButtonController.interactionButtonController.CancelBite();
                break;
            }
        }

        /* 밀기 취소 */
        if (playerObject.pushObjectName != "")
        {
            InteractionButtonController.interactionButtonController.CancelPush();
        }

        CancelObjectText.text = "Noah N.113";
    }
    void Delaylittle()
    {
        noahPlayer.transform.position = new Vector3(upDownObject.transform.localPosition.x, 33.78f, upDownObject.transform.localPosition.z)+transform.forward;
        agent.updatePosition = true;
        agent.updateRotation = true;
        agent.isStopped = false;
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2f);
    }

    public void ResetPlayerEquipement()
    {
        observeObject = PlayerScripts.playerscripts.currentObserveObj;

        upDownObject = PlayerScripts.playerscripts.currentUpObj;
        if (observeObject != null)
        {
            ObjData cancelObserveData = observeObject.GetComponent<ObjData>();
            if (cancelObserveData.objectDATA.IsObserve)
            {
                noahCollider.enabled = true;
                cancelObserveData.objectDATA.IsObserve = false;
                cancelObserveData.objectDATA.IsNotInteractable = false;
            }
        }
        if (upDownObject != null)
        {
            ObjData cancelUpDownData = upDownObject.GetComponent<ObjData>();
            if (cancelUpDownData.objectDATA.IsUpDown)
            {
                cancelUpDownData.objectDATA.IsUpDown = false;
                cancelUpDownData.objectDATA.IsNotInteractable = false;
            }
        }
        if (playerObject.biteObjectName != "")
        {
            biteObject = GameObject.Find(playerObject.biteObjectName).gameObject;
            if (biteObject != null)
            {
                biteData = biteObject.GetComponent<ObjData>();
                biteData.objectDATA.IsBite = false;
                biteData.objectDATA.IsNotInteractable = false;
                playerObject.biteObjectName = "";
            }
        }
        if (playerObject.pushObjectName != "")
        {
            pushObject = GameObject.Find(playerObject.pushObjectName).gameObject;
            if (pushObject != null)
            {
                pushData = pushObject.GetComponent<ObjData>();
                pushData.objectDATA.IsBite = false;
                pushData.objectDATA.IsNotInteractable = false;
                playerObject.pushObjectName = "";
            }
        }
        CancelObjectText.text = "Noah N.113";
    }

}

//biteObject.transform.position = new Vector3(noahPosition.gameObject.transform.position.x, 33.799f, noahPosition.gameObject.transform.position.z);
//biteObject.transform.rotation = Quaternion.Euler(0, noahPosition.gameObject.transform.rotation.y + 90, 0);

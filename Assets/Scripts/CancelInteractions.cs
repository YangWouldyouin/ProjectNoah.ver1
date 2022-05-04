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

    GameObject upDownObject, biteObject, pushObject, noahNovepushobject, observeObject;

    TMPro.TextMeshProUGUI CancelObjectText;

    PlayerEquipment playerObject;
    ObjectData cancelObjectData;

    private void Start()
    {
        noahPlayer = BaseCanvas._baseCanvas.noahPlayer;
        playerAnimation = noahPlayer.GetComponent<Animator>();
        agent = noahPlayer.GetComponent<NavMeshAgent>();
        playerObject = BaseCanvas._baseCanvas.equipment;
        CancelObjectText = BaseCanvas._baseCanvas.objectText;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            observeObject = PlayerScripts.playerscripts.currentObserveObj;

            upDownObject = PlayerScripts.playerscripts.currentUpObj;
            //pushObject = PlayerScripts.playerscripts.currentPushOrPressObj;
            //if (PlayerScripts.playerscripts.currentObserveObj != null)
            //{
            //    CameraController.cameraController.CancelObserve();
            //    //PlayerScripts.playerscripts.currentObserveObj = null;
            //}
            //if(PlayerScripts.playerscripts.currentBiteObj != null)
            //{
            //    biteObject = PlayerScripts.playerscripts.currentBiteObj;

            //    ObjData cancelBiteData = biteObject.GetComponent<ObjData>();
            //    if (cancelBiteData.IsBite)
            //    {
            //        playerAnimation.SetBool("IsPutDowning", true);
            //        Invoke("CancelBitingAnimation", 1f);
            //        Invoke("PutDownObject", 0.5f);
            //        cancelBiteData.IsBite = false;
            //    }
            //}


            //if (PlayerScripts.playerscripts.currentPushOrPressObj != null)
            //{
            //    print(PlayerScripts.playerscripts.currentPushOrPressObj);
            //    playerAnimation.SetBool("IsPushing", false);
            //    //pushObject.transform.parent = moveableGroup.transform;
            //    PlayerScripts.playerscripts.currentPushOrPressObj.GetComponent<Rigidbody>().isKinematic = false;   //makes the rigidbody not be acted upon by forces
            //    //pushObject.GetComponent<Rigidbody>().useGravity = true;
            //    PlayerScripts.playerscripts.currentPushOrPressObj.transform.parent= moveableGroup.transform;
            //    //PlayerScripts.playerscripts.currentPushOrPressObj = null;
            //}

            //if (BiteDestroyButtonController.biteDestroyButtonController.noahBiteObject != null) // 여기서 널 레퍼런스 오류가 생기고 있습니다.
            //{
            //    biteObject = BiteDestroyButtonController.biteDestroyButtonController.noahBiteObject;
            //}
            //if (InteractionButtonController.interactionButtonController.noahUpDownObject != null)
            //{
            //    upDownObject = InteractionButtonController.interactionButtonController.noahUpDownObject;
            //}
            //if (InteractionButtonController.interactionButtonController.noahObserveObject != null)
            //{
            //    observeObject = InteractionButtonController.interactionButtonController.noahObserveObject;
            //}


            /* 상호작용 취소 순서 : 관찰 -> 오르기 -> 물기 */
            for (int i = 3; i > 0; i--)
            {
                /* 관찰하기 취소 */
                if (i == 3 && observeObject != null)
                {
                    ObjData cancelObserveData = observeObject.GetComponent<ObjData>();
                    if (cancelObserveData.objectDATA.IsObserve)
                    {
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
                    if (cancelUpDownData.IsUpDown)
                    {
                        //Vector3 fallrot = noahPosition.transform.eulerAngles;
                        InteractionButtonController.interactionButtonController.PlayerFall1();
                        //if (Agent.enabled)
                        //{
                        //    noahPosition.transform.eulerAngles = new Vector3(fallrot.x, fallrot.y - 180, fallrot.z);
                        //    Invoke("Delaylittle", 0.5f);

                        //}
                        //cancelUpDownData.IsUpDown = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }/* 물기 취소   else if (i == 1 && biteObject != null)*/
                else if (i == 1 && playerObject.biteObjectName!="")
                {
                    biteObject = GameObject.Find(playerObject.biteObjectName).gameObject;
                    ObjData cancelBiteData = biteObject.GetComponent<ObjData>();
                    cancelBiteData.IsBite = false;
                    playerAnimation.SetBool("IsPutDowning", true);

                    Invoke("CancelBitingAnimation", 1f);
                    Invoke("PutDownObject", 0.3f);
                    playerObject.biteObjectName = "";
                    biteObject.transform.parent = portableObjects.transform;
                    break;
                }
            }

            /* 밀기 취소 */
            if(playerObject.pushObjectName != "")
            {
                pushObject = GameObject.Find(playerObject.pushObjectName).gameObject;

                ObjData cancelPushData = pushObject.GetComponent<ObjData>();
                cancelPushData.IsPushOrPress = false;

                playerAnimation.SetBool("IsPushing", false);

                pushObject.transform.SetParent(null, true);

                pushObject.transform.localScale = playerObject.cancelPushScale;
                pushObject.transform.position = new Vector3(pushObject.transform.position.x, playerObject.cancelPushPos.y, pushObject.transform.position.z);
                pushObject.transform.eulerAngles = playerObject.cancelPushRot;

                playerObject.pushObjectName = "";
                pushObject.transform.parent = portableObjects.transform;
            }

            CancelObjectText.text = "Noah N.113";

            ///* 관찰하기 취소 */
            //if (observeObject!=null)
            //{
            //    ObjData cancelObserveData = observeObject.GetComponent<ObjData>();


            //    if (cancelObserveData.IsObserve)
            //    {

            //        CameraController.cameraController.CancelObserve();

            //        //Invoke("ObservingAnimation", 0.00000001f);
            //        //Invoke("Observing2Animation", 0.00000001f);
            //        Invoke("CancelObserving2Animation", 1f);
            //        Invoke("CancelObservingAnimation", 1f);


            //        cancelObserveData.IsObserve = false;

            //    }
            //}

            ///* 오르기 취소 */
            //if (upDownObject!=null)
            //{
            //    ObjData cancelUpDownData = upDownObject.GetComponent<ObjData>();
            //    if (cancelUpDownData.IsUpDown)
            //    {
            //        if (Agent.enabled)
            //        {
            //            noahPosition.transform.position = new Vector3(upDownObject.transform.localPosition.x, 33.78f, upDownObject.transform.localPosition.z);
            //            Agent.updatePosition = true;
            //            Agent.updateRotation = true;
            //            Agent.isStopped = false;
            //        }
            //        cancelUpDownData.IsUpDown = false;
            //    }
            //}




            ///* 물기 취소 */
            //if (biteObject != null)
            //{
            //    ObjData cancelBiteData = biteObject.GetComponent<ObjData>();
            //    if (cancelBiteData.IsBite)
            //    {
            //        playerAnimation.SetBool("IsPutDowning", true);
            //        Invoke("CancelBitingAnimation", 1f);
            //        Invoke("PutDownObject", 0.5f);
            //        cancelBiteData.IsBite = false;

            //    }
            //}
        }
    }
    void Delaylittle()
    {
        noahPlayer.transform.position = new Vector3(upDownObject.transform.localPosition.x, 33.78f, upDownObject.transform.localPosition.z)+transform.forward;
        agent.updatePosition = true;
        agent.updateRotation = true;
        agent.isStopped = false;
    }
    void CancelBitingAnimation()
    {
        playerAnimation.SetBool("IsPutDowning", false);
    }
    void PutDownObject()
    {
        biteObject.GetComponent<Rigidbody>().isKinematic = false; 
        biteObject.transform.parent = null;

        biteObject.transform.localScale = playerObject.cancelBiteScale;
        biteObject.transform.position = new Vector3(biteObject.transform.position.x, playerObject.cancelBitePos.y, biteObject.transform.position.z);
        biteObject.transform.eulerAngles = playerObject.cancelBiteRot;
    }

    void Observing2Animation()
    {
        playerAnimation.SetBool("IsObserving2", true);
    }

    void ObservingAnimation()
    {
        playerAnimation.SetBool("IsObserving", true);
    }

    void CancelObserving2Animation()
    {
        playerAnimation.SetBool("IsObserving2", false);
    }

    void CancelObservingAnimation()
    {
        playerAnimation.SetBool("IsObserving", false);
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2f);
    }
}

//biteObject.transform.position = new Vector3(noahPosition.gameObject.transform.position.x, 33.799f, noahPosition.gameObject.transform.position.z);
//biteObject.transform.rotation = Quaternion.Euler(0, noahPosition.gameObject.transform.rotation.y + 90, 0);

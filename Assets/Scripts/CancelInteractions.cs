using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CancelInteractions : MonoBehaviour
{
    private float objectDistance = 1f;
    public NavMeshAgent Agent;
    public Animator playerAnimation;

    public GameObject noahPosition;
    public GameObject moveableGroup;
    private GameObject upDownObject, biteObject, pushObject, noahNovepushobject, observeObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            if (BiteDestroyButtonController.biteDestroyButtonController.noahBiteObject != null)
            {
                biteObject = BiteDestroyButtonController.biteDestroyButtonController.noahBiteObject;
            }
            if (InteractionButtonController.interactionButtonController.noahUpDownObject != null)
            {
                upDownObject = InteractionButtonController.interactionButtonController.noahUpDownObject;
            }
            if (InteractionButtonController.interactionButtonController.noahObserveObject != null)
            {
                observeObject = InteractionButtonController.interactionButtonController.noahObserveObject;
            }


            /* 상호작용 취소 순서 : 관찰 -> 오르기 -> 물기 */
            for (int i = 3; i>0; i--)
            {
                /* 관찰하기 취소 */
                if (i==3 && observeObject != null)
                {   
                    ObjData cancelObserveData = observeObject.GetComponent<ObjData>();
                    if (cancelObserveData.IsObserve)
                    {
                        CameraController.cameraController.CancelObserve();

                        //Invoke("ObservingAnimation", 0.00000001f);
                        //Invoke("Observing2Animation", 0.00000001f);
                        Invoke("CancelObserving2Animation", 1f);
                        Invoke("CancelObservingAnimation", 1f);
                        cancelObserveData.IsObserve = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }/* 오르기 취소 */
                else if(i == 2 && upDownObject != null)
                {
                    ObjData cancelUpDownData = upDownObject.GetComponent<ObjData>();
                    if (cancelUpDownData.IsUpDown)
                    {
                        if (Agent.enabled)
                        {
                            noahPosition.transform.position = new Vector3(upDownObject.transform.localPosition.x, 33.78f, upDownObject.transform.localPosition.z);
                            Agent.updatePosition = true;
                            Agent.updateRotation = true;
                            Agent.isStopped = false;
                        }
                        cancelUpDownData.IsUpDown = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }/* 물기 취소 */
                else if(i==1&& biteObject != null)
                {
                    ObjData cancelBiteData = biteObject.GetComponent<ObjData>();
                    if (cancelBiteData.IsBite)
                    {
                        playerAnimation.SetBool("IsPutDowning", true);
                        Invoke("CancelBitingAnimation", 1f);
                        Invoke("PutDownObject", 0.5f);
                        cancelBiteData.IsBite = false;
                        break;
                    }
                }
            }

            /* 밀기 취소 */
            if (InteractionButtonController.ISPUSH)
            {
                pushObject = InteractionButtonController.interactionButtonController.noahPushObject;
                noahNovepushobject = SaveDataWhenSceneChange.savedata.obj;

                if (pushObject != null)
                {
                    playerAnimation.SetBool("IsPushing", false);
                    pushObject.transform.SetParent(null, true);
                    pushObject.transform.parent = moveableGroup.transform;
                    InteractionButtonController.interactionButtonController.ispush = false;
                }

                if (noahNovepushobject != null)
                {
                    playerAnimation.SetBool("IsPushing", false);
                    noahNovepushobject.transform.SetParent(null, true);
                    noahNovepushobject.transform.parent = moveableGroup.transform; // 다시 무바블오브젝트의 자식으로 넣기
                    InteractionButtonController.interactionButtonController.ispush = false;


                }
            }


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

    void CancelBitingAnimation()
    {
        playerAnimation.SetBool("IsPutDowning", false);
    }
    void PutDownObject()
    {
        biteObject.GetComponent<Rigidbody>().isKinematic = false; 
        biteObject.transform.parent = null;
        biteObject.transform.position = new Vector3(biteObject.transform.position.x, 33.8f, biteObject.transform.position.z);
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

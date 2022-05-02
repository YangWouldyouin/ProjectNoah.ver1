using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataWhenSceneChange : MonoBehaviour
{
    /* �� Ŭ�� �� �̵��� ��*/
    public string transferMapName;

    [SerializeField] PlayerEquipment playerEquipment;

    private GameObject biteObject;
    private GameObject pushObject;

    ObjData portableObjectData;
    Vector3 portablePos, portableRot;

    public TMPro.TextMeshProUGUI objectText;

    public GameObject myHead;

    public Animator noahAnimator;

    void Awake()
    {
        savedata = this; 

        /* �÷��̾� �ʱ�ȭ */
        if (playerEquipment.biteObjectName!="") // ���� �ִ� ������Ʈ�� �ִٸ�
        {
            // �� ������Ʈ�� ���̶�Ű���� ã�Ƽ� Ȱ��ȭ
            biteObject = GameObject.Find("Portable Objects").transform.Find(playerEquipment.biteObjectName).gameObject;
            biteObject.SetActive(true);

            // ��ҿ��� �־���!!!!!
            PlayerScripts.playerscripts.currentBiteObj = biteObject;
            PlayerScripts.playerscripts.biteFallPos = biteObject.transform.position;
            PlayerScripts.playerscripts.biteFallRot = biteObject.transform.eulerAngles;
            PlayerScripts.playerscripts.biteOriginScale = biteObject.transform.localScale;

            // ��� �Կ� ����
            portableObjectData = biteObject.GetComponent<ObjData>();
            portablePos = portableObjectData.BitePos;
            portableRot = portableObjectData.BiteRot;
            objectText.text = "Noah N.113 - " + portableObjectData.ObjectName;

            biteObject.GetComponent<Rigidbody>().isKinematic = true;  
            biteObject.GetComponent<Rigidbody>().useGravity = false;

            biteObject.transform.SetParent(myHead.transform, true);

            biteObject.transform.localPosition = portablePos; 
            biteObject.transform.localEulerAngles = portableRot; 

            //playerEquipment.biteObject = ""; // �ʱ�ȭ
        }


         if (playerEquipment.pushObjectName != "") // �а� �ִ� ������Ʈ�� �ִٸ� 
        {
            // �� ������Ʈ�� ���̶�Ű���� ã�Ƽ� Ȱ��ȭ
            pushObject = GameObject.Find("Portable Objects").transform.Find(playerEquipment.pushObjectName).gameObject;
            pushObject.SetActive(true);

            // ��ҿ��� �־���!!!!!
            playerEquipment.cancelPushPos = pushObject.transform.position;
            playerEquipment.cancelPushRot = pushObject.transform.eulerAngles;
            playerEquipment.cancelPushScale = pushObject.transform.localScale;

            // ��� �Ӹ��� ���� + �̴� �ִϸ��̼� 
            noahAnimator.SetBool("IsPushing", true);
            noahAnimator.SetBool("IsPushing2", true);

            portableObjectData = pushObject.GetComponent<ObjData>();
            objectText.text = "Noah N.113 - " + portableObjectData.ObjectName;

            pushObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            pushObject.GetComponent<Rigidbody>().useGravity = false;

            pushObject.transform.parent = myHead.transform; //makes the object become a child of the parent so that it moves with the mouth

            pushObject.transform.localPosition = portableObjectData.PushPos; // sets the position of the object to your mouth position
            pushObject.transform.localEulerAngles = portableObjectData.PushRot; // sets the position of the object to yo
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.5f);
        //if (PlayerScripts.playerscripts.currentBiteObj!=null) // ���� �ִ� ������Ʈ�� ������ 
        //{
        //    playerEquipment.biteObject = PlayerScripts.playerscripts.currentBiteObj.name;
        //}
        //else if(PlayerScripts.playerscripts.currentPushOrPressObj != null) // �а� �ִ� ������Ʈ�� ������ 
        //{
        //    playerEquipment.pushObject = PlayerScripts.playerscripts.currentPushOrPressObj.name;
        //}
        SceneManager.LoadScene(transferMapName);
    }


    public static SaveDataWhenSceneChange savedata { get; private set; }
    private GameObject noahplayer;
    public GameObject obj;

    /* Cockpit Movable Objects */
    public static bool isCurrentPushing; // longButton ���� �޾ƿ�
    public static GameObject CurrentPushingObject; // longButton ���� �޾ƿ�
    private string pushobjectname;

    public static bool C_isEnvirPipePush;
    public static bool C_isEnvirPipeSetActive = true;
    public GameObject C_EnvirPipe;

    public static bool C_isBoxPush;
    public static bool C_isBoxSetActive = true;
    public GameObject C_Box;

    /* Work Movable Objects */
    public static bool W_isEnvirPipePush;
    public static bool W_isEnvirPipeSetActive = false;
    public GameObject W_EnvirPipe;

    public static bool W_isBoxPush;
    public static bool W_isBoxSetActive = false;
    public GameObject W_Box;

    //void OnEnable()
    //{
    //    // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}

    //// ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
    //void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    Debug.Log("OnSceneLoaded: " + scene.name);
    //    noahplayer = GameObject.Find("Player").transform.Find("Noah_anim_FBX").gameObject;

    //    if (scene.name == "Cockpit")
    //    {
    //        /* 1. setActive ���� ������Ʈ���� Ȱ��ȭ��Ŵ */
    //        if (C_isBoxSetActive)
    //        {
    //            C_Box = GameObject.Find("MovableObjects").transform.Find("box").gameObject;
    //            if (C_Box != null)
    //            {
    //                C_Box.SetActive(true);
    //                W_isBoxSetActive = false;
    //            }
    //        }
    //        else
    //        {
    //            C_Box = GameObject.Find("MovableObjects").transform.Find("box").gameObject;
    //            if (C_Box != null)
    //            {
    //                C_Box.SetActive(false);
    //                W_isBoxSetActive = true;
    //            }
    //        }

    //        /* 2. ���� ������ ���� �־��� ������Ʈ�� �־����� �̰��� �÷��̾��� �ڽ�ȭ��Ŵ */
    //        if (InteractionButtonController.ISPUSH)
    //        {
    //            if (obj != null)
    //            {
    //                obj = GameObject.Find("MovableObjects").transform.Find(InteractionButtonController.pushObjectName).gameObject;
    //                if (obj != null)
    //                {
    //                    obj.SetActive(true);
    //                    if (noahplayer != null)
    //                    {
    //                        obj.transform.parent = noahplayer.transform;

    //                        /* 3. �� ������Ʈ�� �ٸ� ���鿡���� ��Ȱ��ȭ ��Ŵ */
    //                        if (InteractionButtonController.pushObjectName == "box")
    //                        {
    //                            C_isBoxSetActive = true;
    //                            W_isBoxSetActive = false;
    //                        }
    //                        if (InteractionButtonController.pushObjectName == "EnvirPipe")
    //                        {
    //                            C_isEnvirPipeSetActive = true;
    //                            W_isEnvirPipeSetActive = false;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    if(scene.name == "Work")
    //    {
    //        /* 1. setActive ������ ������Ʈ���� Ȱ��ȭ��Ŵ */
    //        if(W_isBoxSetActive)
    //        {
    //            W_Box = GameObject.Find("WorkMovableObjects").transform.Find("box").gameObject;
    //            if (W_Box != null)
    //            {
    //                W_Box.SetActive(true);
    //                C_isBoxSetActive = false;
    //            }
    //        }
    //        else
    //        {
    //            W_Box = GameObject.Find("WorkMovableObjects").transform.Find("box").gameObject;
    //            if (W_Box != null)
    //            {
    //                W_Box.SetActive(false);
    //                C_isBoxSetActive = true;
    //            }
    //        }

    //        /* 2. ���� ������ ���� �־��� ������Ʈ�� �־����� �װ��� �÷��̾��� �ڽ�ȭ��Ŵ */
    //        if (InteractionButtonController.ISPUSH)
    //        {
    //            if (obj != null)
    //            {
    //                obj = GameObject.Find("WorkMovableObjects").transform.Find(InteractionButtonController.pushObjectName).gameObject;
    //                if (obj != null)
    //                {
    //                    obj.SetActive(true);
    //                    if (noahplayer != null)
    //                    {
    //                        obj.transform.parent = noahplayer.transform;

    //                        /* 3. �� ������Ʈ�� �ٸ� ���鿡���� ��Ȱ��ȭ��Ŵ */
    //                        if (InteractionButtonController.pushObjectName == "box")
    //                        {
    //                            W_isBoxSetActive = true;
    //                            C_isBoxSetActive = false;
    //                        }
    //                        if (InteractionButtonController.pushObjectName == "EnvirPipe")
    //                        {
    //                            W_isEnvirPipeSetActive = true;
    //                            C_isEnvirPipeSetActive = false;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}
}

           ///* 1. MovableObjectController �����ؼ� ���� ������ �� �ִ� ������Ʈ�� Ȱ��ȭ��Ŵ */
           // //if(C_isEnvirPipeSetActive)
           // //{
           // //    if(C_EnvirPipe!=null)
           // //    {
           // //        C_EnvirPipe = GameObject.Find("MovableObjects").transform.Find("EnvirPipe").gameObject;
           // //        C_EnvirPipe.SetActive(true);
           // //        W_isEnvirPipeSetActive = false;
           // //    }
           // //}

           // if (C_isBoxSetActive)
           // {
           //     if (C_Box != null)
           //     {
           //         C_Box = GameObject.Find("MovableObjects").transform.Find("Box").gameObject;
           //         C_Box.SetActive(true);
           //         W_isBoxSetActive = false;
           //     }
           // }

           // /* 2. ���� ������ ���� �־��� ������Ʈ�� �־����� �̰��� �÷��̾��� �ڽ�ȭ��Ŵ */
           // if(isCurrentPushing)
           // {        
           //     obj = GameObject.Find("MovableObjects").transform.Find(CurrentPushingObject.name).gameObject;
           //     if (obj != null)
           //     {
           //         if (noahplayer != null)
           //         {
           //             obj.transform.parent = noahplayer.transform;

           //         }
           //     }
           // }

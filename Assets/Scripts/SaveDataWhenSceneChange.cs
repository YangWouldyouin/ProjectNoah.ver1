using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataWhenSceneChange : MonoBehaviour
{
    public static SaveDataWhenSceneChange savedata { get; private set; }
    private GameObject noahplayer;
    public GameObject obj;

    /* Cockpit Movable Objects */
    public static bool isCurrentPushing; // longButton 에서 받아옴
    public static GameObject CurrentPushingObject; // longButton 에서 받아옴
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


    public GameObject pipe, box, cardKey;

    public static bool IsPipeInControlActive = false;
    public static bool IsBoxInControlActive = false;
    public static bool IsCardKeyInControlActive = false;

    public static bool IsPipeInWorkActive = true;
    public static bool IsBoxInWorkActive = false;
    public static bool IsCardKeyInWorkActive = false;





    private void Awake()
    {
        savedata = this;
    }
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene currentScene, LoadSceneMode mode)
    {


        //Debug.Log("OnSceneLoaded: " + scene.name);

        //noahplayer = GameObject.Find("noahPlayer").transform.Find("Noah_anim_FBX").gameObject;

        /* 1. setActive 참인 오브젝트들을 활성화시킴 */
        //if (currentScene.name == "new cockpit")
        //{
        //    if (IsPipeInControlActive)
        //    {
        //        pipe.SetActive(true);
        //    }
        //    else
        //    {
        //        pipe.SetActive(false);
        //    }

        //    if (IsBoxInControlActive)
        //    {
        //        box.SetActive(true);
        //    }
        //    else
        //    {
        //        box.SetActive(false);
        //    }

        //    if (IsCardKeyInControlActive)
        //    {
        //        cardKey.SetActive(true);
        //    }
        //    else
        //    {
        //        cardKey.SetActive(false);
        //    }
        //}
        if (currentScene.name == "new workroom 1")
        {
            if (IsPipeInWorkActive)
            {
                pipe.SetActive(true);
            }
            else
            {
                pipe.SetActive(false);
            }

            if (IsBoxInWorkActive)
            {
                box.SetActive(true);
            }
            else
            {
                box.SetActive(false);
            }

            if (IsCardKeyInWorkActive)
            {
                cardKey.SetActive(true);
            }
            else
            {
                cardKey.SetActive(false);
            }
        }


        //if (scene.name == "Cockpit")
        //{
        //    /* 1. setActive 참인 오브젝트들을 활성화시킴 */
        //    if (C_isBoxSetActive)
        //    {
        //        C_Box = GameObject.Find("MovableObjects").transform.Find("box").gameObject;
        //        if (C_Box != null)
        //        {
        //            C_Box.SetActive(true);
        //            W_isBoxSetActive = false;
        //        }
        //    }
        //    else
        //    {
        //        C_Box = GameObject.Find("MovableObjects").transform.Find("box").gameObject;
        //        if (C_Box != null)
        //        {
        //            C_Box.SetActive(false);
        //            W_isBoxSetActive = true;
        //        }
        //    }

        //    /* 2. 이전 씬에서 "물고" 있었던 오브젝트가 있었으면 이것을 플레이어의 자식화시킴 */
        //    /* 2. 이전 씬에서 "밀고" 있었던 오브젝트가 있었으면 이것을 플레이어의 자식화시킴 */
        //    if (InteractionButtonController.ISPUSH)
        //    {
        //        if (obj != null)
        //        {
        //            obj = GameObject.Find("MovableObjects").transform.Find(InteractionButtonController.pushObjectName).gameObject;
        //            if (obj != null)
        //            {
        //                obj.SetActive(true);
        //                if (noahplayer != null)
        //                {
        //                    obj.transform.parent = noahplayer.transform;

        //                    /* 3. 이 오브젝트를 다른 씬들에서는 비활성화 시킴 */
        //                    if (InteractionButtonController.pushObjectName == "box")
        //                    {
        //                        C_isBoxSetActive = true;
        //                        W_isBoxSetActive = false;
        //                    }
        //                    if (InteractionButtonController.pushObjectName == "EnvirPipe")
        //                    {
        //                        C_isEnvirPipeSetActive = true;
        //                        W_isEnvirPipeSetActive = false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //if(scene.name == "Work")
        //{
        //    /* 1. setActive 거짓인 오브젝트들을 활성화시킴 */
        //    if(W_isBoxSetActive)
        //    {
        //        W_Box = GameObject.Find("WorkMovableObjects").transform.Find("box").gameObject;
        //        if (W_Box != null)
        //        {
        //            W_Box.SetActive(true);
        //            C_isBoxSetActive = false;
        //        }
        //    }
        //    else
        //    {
        //        W_Box = GameObject.Find("WorkMovableObjects").transform.Find("box").gameObject;
        //        if (W_Box != null)
        //        {
        //            W_Box.SetActive(false);
        //            C_isBoxSetActive = true;
        //        }
        //    }

        //    /* 2. 이전 씬에서 물고 있었던 오브젝트가 있었으면 그것을 플레이어의 자식화시킴 */
        //    if (InteractionButtonController.ISPUSH)
        //    {
        //        if (obj != null)
        //        {
        //            obj = GameObject.Find("WorkMovableObjects").transform.Find(InteractionButtonController.pushObjectName).gameObject;
        //            if (obj != null)
        //            {
        //                obj.SetActive(true);
        //                if (noahplayer != null)
        //                {
        //                    obj.transform.parent = noahplayer.transform;

        //                    /* 3. 이 오브젝트를 다른 씬들에서는 비활성화시킴 */
        //                    if (InteractionButtonController.pushObjectName == "box")
        //                    {
        //                        W_isBoxSetActive = true;
        //                        C_isBoxSetActive = false;
        //                    }
        //                    if (InteractionButtonController.pushObjectName == "EnvirPipe")
        //                    {
        //                        W_isEnvirPipeSetActive = true;
        //                        C_isEnvirPipeSetActive = false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}

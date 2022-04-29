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

    private void Awake()
    {
        savedata = this;
    }
    void OnEnable()
    {
        // �� �Ŵ����� sceneLoaded�� ü���� �Ǵ�.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ü���� �ɾ �� �Լ��� �� ������ ȣ��ȴ�.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        noahplayer = GameObject.Find("Player").transform.Find("Noah_anim_FBX").gameObject;

        if (scene.name == "Cockpit")
        {
            /* 1. setActive ���� ������Ʈ���� Ȱ��ȭ��Ŵ */
            if (C_isBoxSetActive)
            {
                C_Box = GameObject.Find("MovableObjects").transform.Find("box").gameObject;
                if (C_Box != null)
                {
                    C_Box.SetActive(true);
                    W_isBoxSetActive = false;
                }
            }
            else
            {
                C_Box = GameObject.Find("MovableObjects").transform.Find("box").gameObject;
                if (C_Box != null)
                {
                    C_Box.SetActive(false);
                    W_isBoxSetActive = true;
                }
            }

            /* 2. ���� ������ ���� �־��� ������Ʈ�� �־����� �̰��� �÷��̾��� �ڽ�ȭ��Ŵ */
            if (InteractionButtonController.ISPUSH)
            {
                if (obj != null)
                {
                    obj = GameObject.Find("MovableObjects").transform.Find(InteractionButtonController.pushObjectName).gameObject;
                    if (obj != null)
                    {
                        obj.SetActive(true);
                        if (noahplayer != null)
                        {
                            obj.transform.parent = noahplayer.transform;

                            /* 3. �� ������Ʈ�� �ٸ� ���鿡���� ��Ȱ��ȭ ��Ŵ */
                            if (InteractionButtonController.pushObjectName == "box")
                            {
                                C_isBoxSetActive = true;
                                W_isBoxSetActive = false;
                            }
                            if (InteractionButtonController.pushObjectName == "EnvirPipe")
                            {
                                C_isEnvirPipeSetActive = true;
                                W_isEnvirPipeSetActive = false;
                            }
                        }
                    }
                }
            }
        }

        if(scene.name == "Work")
        {
            /* 1. setActive ������ ������Ʈ���� Ȱ��ȭ��Ŵ */
            if(W_isBoxSetActive)
            {
                W_Box = GameObject.Find("WorkMovableObjects").transform.Find("box").gameObject;
                if (W_Box != null)
                {
                    W_Box.SetActive(true);
                    C_isBoxSetActive = false;
                }
            }
            else
            {
                W_Box = GameObject.Find("WorkMovableObjects").transform.Find("box").gameObject;
                if (W_Box != null)
                {
                    W_Box.SetActive(false);
                    C_isBoxSetActive = true;
                }
            }

            /* 2. ���� ������ ���� �־��� ������Ʈ�� �־����� �װ��� �÷��̾��� �ڽ�ȭ��Ŵ */
            if (InteractionButtonController.ISPUSH)
            {
                if (obj != null)
                {
                    obj = GameObject.Find("WorkMovableObjects").transform.Find(InteractionButtonController.pushObjectName).gameObject;
                    if (obj != null)
                    {
                        obj.SetActive(true);
                        if (noahplayer != null)
                        {
                            obj.transform.parent = noahplayer.transform;

                            /* 3. �� ������Ʈ�� �ٸ� ���鿡���� ��Ȱ��ȭ��Ŵ */
                            if (InteractionButtonController.pushObjectName == "box")
                            {
                                W_isBoxSetActive = true;
                                C_isBoxSetActive = false;
                            }
                            if (InteractionButtonController.pushObjectName == "EnvirPipe")
                            {
                                W_isEnvirPipeSetActive = true;
                                C_isEnvirPipeSetActive = false;
                            }
                        }
                    }
                }
            }
        }
    }
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

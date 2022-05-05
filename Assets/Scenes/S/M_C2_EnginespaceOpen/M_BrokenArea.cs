using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_BrokenArea : MonoBehaviour,IInteraction
{
    /*연관있는 오브젝트*/
    public GameObject M_canBrokenDoorConduction;
    //public GameObject M_biteRubber;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_BrokenArea, sniffButton_M_BrokenArea, biteButton_M_BrokenArea, pressButton_M_BrokenArea, noCenterButton_M_BrokenArea;

    ObjData brokenAreaData_M;
    ObjData canBrokenDoorConductionData_M;
    //ObjData biteRubberData_M;

    /*아웃라인*/
    Outline canBrokenDoorConductionOutline_M;
    Outline BrokenAreaOutline_M;

    void Start()
    {
        brokenAreaData_M = GetComponent<ObjData>();
        canBrokenDoorConductionData_M = M_canBrokenDoorConduction.GetComponent<ObjData>();
        //biteRubberData_M = M_biteRubber.GetComponent<ObjData>();

        barkButton_M_BrokenArea = brokenAreaData_M.BarkButton;
        barkButton_M_BrokenArea.onClick.AddListener(OnBark);

        sniffButton_M_BrokenArea = brokenAreaData_M.SniffButton;
        sniffButton_M_BrokenArea.onClick.AddListener(OnSniff);

        biteButton_M_BrokenArea = brokenAreaData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_BrokenArea = brokenAreaData_M.PushOrPressButton;
        pressButton_M_BrokenArea.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_BrokenArea = brokenAreaData_M.CenterButton1;

        /*아웃라인*/
        canBrokenDoorConductionOutline_M = GetComponent<Outline>();
        BrokenAreaOutline_M = GetComponent<Outline>();

        if(GameManager.gameManager._gameData.IsEngineDoorFix_M_C2)
        {
            //B-7 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
        }
    }

    void DisableButton()
    {
        barkButton_M_BrokenArea.transform.gameObject.SetActive(false);
        sniffButton_M_BrokenArea.transform.gameObject.SetActive(false);
        biteButton_M_BrokenArea.transform.gameObject.SetActive(false);
        pressButton_M_BrokenArea.transform.gameObject.SetActive(false);
        noCenterButton_M_BrokenArea.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        brokenAreaData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        brokenAreaData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHead();

        StartCoroutine(ChangePressFalse());

        //Debug.Log("전도체 물었다!");
        if (canBrokenDoorConductionData_M.IsBite)
        {
            // 끼우기 성공
            // 부모 자식 관계를 해제한다.
            M_canBrokenDoorConduction.GetComponent<Rigidbody>().isKinematic = false;
            M_canBrokenDoorConduction.transform.parent = null;

            // 해당 위치, 각도, 크기로 바꾸겠다.
            M_canBrokenDoorConduction.transform.position = new Vector3(-260.954f, 539.4967f, 666.558f); //위치 고정
            M_canBrokenDoorConduction.transform.rotation = Quaternion.Euler(0, -90, 90); //각도 고정

            // 망가진 문 부분이랑 끼운 전도체의 상호작용을 삭제한다.
            canBrokenDoorConductionData_M.IsNotInteractable = true;
            canBrokenDoorConductionOutline_M.OutlineWidth = 0;

            brokenAreaData_M.IsNotInteractable = true;
            BrokenAreaOutline_M.OutlineWidth = 0;

            GameManager.gameManager._gameData.IsEngineDoorFix_M_C2 = true;

        }


/*        if (biteRubberData_M.IsBite)
        {
        }

        else
        {
            Debug.Log("감전엔딩");
        }*/

       

    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        brokenAreaData_M.IsPushOrPress = false;
        CameraController.cameraController.CancelObserve();
    }


    public void OnSniff()
    {
        brokenAreaData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnBite()
    {
        
    }

    public void OnEat()
    {
        
    }

    public void OnInsert()
    {
        
    }

    public void OnObserve()
    {
        
    }

    public void OnSmash()
    {
        
    }

    public void OnUp()
    {
        
    }
}

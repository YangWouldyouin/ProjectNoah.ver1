using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Pack : MonoBehaviour, IInteraction
{
    /*관련있는 오브젝트*/
    public GameObject M_canCardKey;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_Pack, sniffButton_M_Pack, 
        biteButton_M_Pack, pressButton_M_Pack, noCenterButton_M_Pack, smashButton_M_Pack;

    ObjData packObjData_M;
    public ObjectData packData_M;

    public GameObject dialog_CS;
    DialogManager dialogManager;

    PortableObjectData workRoomData;
   

    void Start()
    {
        workRoomData = BaseCanvas._baseCanvas.workRoomData;
        dialogManager = dialog_CS.GetComponent<DialogManager>();

        packObjData_M = GetComponent<ObjData>();


        barkButton_M_Pack = packObjData_M.BarkButton;
        barkButton_M_Pack.onClick.AddListener(OnBark);

        sniffButton_M_Pack = packObjData_M.SniffButton;
        sniffButton_M_Pack.onClick.AddListener(OnSniff);

        biteButton_M_Pack = packObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Pack = packObjData_M.PushOrPressButton;
        pressButton_M_Pack.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_Pack = packObjData_M.CenterButton1;

        smashButton_M_Pack = packObjData_M.SmashButton;
        smashButton_M_Pack.onClick.AddListener(OnSmash);
    }

    void Update()
    {
        if(packData_M.IsClicked)
        {
            //B-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(24));
        }

    }

    void DisableButton()
    {
        barkButton_M_Pack.transform.gameObject.SetActive(false);
        sniffButton_M_Pack.transform.gameObject.SetActive(false);
        biteButton_M_Pack.transform.gameObject.SetActive(false);
        pressButton_M_Pack.transform.gameObject.SetActive(false);
        smashButton_M_Pack.transform.gameObject.SetActive(false);
        noCenterButton_M_Pack.transform.gameObject.SetActive(false);
    }
    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();
    }


    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnSmash()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerSmash1();

        StartCoroutine(canLookCardKey1());
        //StartCoroutine(canLookCardKey2());

        //Invoke(" canLookCardKey", 2f); // 인보크 함수 안 먹 는 다...

        /* 오브젝트 흔드는 애니메이션 끝냄 */
        InteractionButtonController.interactionButtonController.PlayerSmash2();

    }

    IEnumerator canLookCardKey1()
    {
        yield return new WaitForSeconds(3f);

        //Destroy(gameObject, 0f);

        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.parent = null;

        //위치 고정: 이유는 얘 위치 따라서 카드키 위치 나오니까 카드키가 공중 부양하기 때문에
        gameObject.transform.position = new Vector3(transform.position.x, 1.5412f, transform.position.z);

        packData_M.IsBite = false;

        M_canCardKey.SetActive(true);
        M_canCardKey.transform.position = gameObject.transform.position;

        /*카드키 찾기 퍼즐 완료*//*
        GameManager.gameManager._gameData.IsCompleteFindEngineKey = true;
        GameManager.gameManager._gameData.ActiveMissionList[3] = false;
        MissionGenerator.missionGenerator.ActivateMissionList();
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/

        // 앞으로 카드팩 업무공간에서 없으므로 체크해제
        workRoomData.IsObjectActiveList[31] = false;
        //엔진키는 체크활성화
        workRoomData.IsObjectActiveList[32] = true;

        gameObject.SetActive(false);



        // 엔진실 카드키 찾기 임무리스트 끝 ♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧♧

    }


    /*    IEnumerator canLookCardKey2()
        {
            yield return new WaitForSeconds(3f);

            M_canCardKey.SetActive(true);
            M_canCardKey.transform.position = gameObject.transform.position;
        }*/

    /*    void canLookCardKey()
        {
            M_canCardKey.SetActive(true);
            M_canCardKey.transform.position = gameObject.transform.position;
            GameManager.gameManager._gameData.IsDestroyPack_M_C2 = true;   

        }*/

    public void OnUp()
    {
        
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

}

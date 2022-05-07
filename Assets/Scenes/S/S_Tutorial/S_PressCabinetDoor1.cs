using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PressCabinetDoor1 : MonoBehaviour,IInteraction
{

    public bool IsPressCabinetDoorOpen = false;

    private Button barkButton_S_PressCabinetDoor1, sniffButton_S_PressCabinetDoor1, biteButton_S_PressCabinetDoor1, 
        pressButton_S_PressCabinetDoor1, noCenterButton_S_PressCabinetDoor1 /*smashButton_M_MiniCabinetDoor*/;

    ObjData pressCabinetDoor1Data_S;
    public ObjectData canPressCabinetDoor1Data_S;
    public ObjectData canPressCabinetBody1Data_S;

    /*아웃라인*/
    public Outline canPressCabinetBody1Outline_S;
    Outline pressCabinetDoor1Outline_S;

    /*애니메이션*/
    public Animator canPressCabinetDoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        /*연관있는 오브젝트*/
        pressCabinetDoor1Data_S = GetComponent<ObjData>();

        barkButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.BarkButton;
        barkButton_S_PressCabinetDoor1.onClick.AddListener(OnBark);

        sniffButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.SniffButton;
        sniffButton_S_PressCabinetDoor1.onClick.AddListener(OnSniff);

        biteButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.BiteButton;
        biteButton_S_PressCabinetDoor1.onClick.AddListener(OnBite);

/*        smashButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SmashButton;
        //biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);*/

        pressButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.PushOrPressButton;
        pressButton_S_PressCabinetDoor1.onClick.AddListener(OnPushOrPress);

        noCenterButton_S_PressCabinetDoor1 = pressCabinetDoor1Data_S.CenterButton1;

        /*아웃라인*/
        pressCabinetDoor1Outline_S = GetComponent<Outline>();
    }

    void DisableButton()
    {
        barkButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        sniffButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        biteButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        pressButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
        noCenterButton_S_PressCabinetDoor1.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 앞에 카드키 꽂기 퍼즐이 완료되었는지 확인
        //S-5 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆
    }

    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        canPressCabinetBody1Data_S.IsNotInteractable = false;
        canPressCabinetBody1Outline_S.OutlineWidth = 8;

        // 캐비닛 문 비활성화
        pressCabinetDoor1Data_S.IsNotInteractable = true;
        pressCabinetDoor1Outline_S.OutlineWidth = 0;

        //캐비닛 문 여는 애니메이션
        Invoke("CabinetOpen1", 2f);
    }

    void CabinetOpen1()
    {
        //S-6 대사 출력 ☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆

        canPressCabinetDoorAnim.SetBool("ePressCabinetOpen", true);
        canPressCabinetDoorAnim.SetBool("ePressCabinetEnd", true);

        //bool 캐비닛 문이 열렸다를 트루로 체크 save를 넣어줘야 되나?
        Debug.Log("캐비닛 몸에 상호작용 가능해요");
        //캐비닛 바디에 상호작용 가능하게



        /*        IsminiCabinetDoorOpen = true;

                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/
    }



    public void OnUp()
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

    public void OnBite()
    {
        //상호작용 버튼을 끔
        DisableButton();
        //물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MiniCabinetDoor : MonoBehaviour,IInteraction
{

    public bool IsminiCabinetDoorOpen = false;

    /*연관있는 오브젝트*/
    public GameObject M_canMiniCabinetBody;

    private Button barkButton_M_MiniCabinetDoor, sniffButton_M_MiniCabinetDoor, biteButton_M_MiniCabinetDoor, pressButton_M_MiniCabinetDoor, noCenterButton_M_MiniCabinetDoor /*smashButton_M_MiniCabinetDoor*/;

    ObjData miniCabinetDoorData_M;
    ObjData canMiniCabinetBodyData_M;

    /*아웃라인*/
    Outline miniCabinetBodyOutline_M;
    Outline miniCabinetDoorOutline_M;


    /*애니메이션*/
    public Animator canMiniCabinetDoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        /*연관있는 오브젝트*/
        canMiniCabinetBodyData_M = M_canMiniCabinetBody.GetComponent<ObjData>();

        miniCabinetDoorData_M = GetComponent<ObjData>();

        barkButton_M_MiniCabinetDoor = miniCabinetDoorData_M.BarkButton;
        barkButton_M_MiniCabinetDoor.onClick.AddListener(OnBark);

        sniffButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SniffButton;
        sniffButton_M_MiniCabinetDoor.onClick.AddListener(OnSniff);

        biteButton_M_MiniCabinetDoor = miniCabinetDoorData_M.BiteButton;
        biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);

/*        smashButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SmashButton;
        //biteButton_M_MiniCabinetDoor.onClick.AddListener(OnBite);*/

        pressButton_M_MiniCabinetDoor = miniCabinetDoorData_M.PushOrPressButton;
        pressButton_M_MiniCabinetDoor.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MiniCabinetDoor = miniCabinetDoorData_M.CenterButton1;



        /*아웃라인*/
        miniCabinetBodyOutline_M = M_canMiniCabinetBody.GetComponent<Outline>();
        miniCabinetDoorOutline_M = GetComponent<Outline>();
    }

    void DisableButton()
    {
        barkButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        sniffButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        biteButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        pressButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        noCenterButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBark()
    {
        miniCabinetDoorData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBiteDestroy()
    {
        //상호작용 버튼을 끔
        DisableButton();
        //물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }


    public void OnSniff()
    {
        miniCabinetDoorData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        miniCabinetDoorData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

        //캐비닛 문 여는 애니메이션
        Invoke("CabinetOpen", 2f);
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        miniCabinetDoorData_M.IsPushOrPress = false;
    }


    void CabinetOpen()
    {
        canMiniCabinetDoorAnim.SetBool("eCabinetOpen", true);
        canMiniCabinetDoorAnim.SetBool("eCabinetEnd", true);

        //bool 캐비닛 문이 열렸다를 트루로 체크 save를 넣어줘야 되나?
        Debug.Log("캐비닛 몸에 상호작용 가능해요");
        //캐비닛 바디에 상호작용 가능하게
        canMiniCabinetBodyData_M.IsNotInteractable = false;
        miniCabinetBodyOutline_M.OutlineWidth = 8;

        // 캐비닛 문 비활성화
        miniCabinetDoorData_M.IsNotInteractable = true;
        miniCabinetDoorOutline_M.OutlineWidth = 0;


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
        miniCabinetDoorData_M.IsBite = true;
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

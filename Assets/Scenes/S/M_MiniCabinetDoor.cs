using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MiniCabinetDoor : MonoBehaviour,IInteraction
{

    public bool IsminiCabinetDoorOpen = false;


    private Button barkButton_M_MiniCabinetDoor, sniffButton_M_MiniCabinetDoor, biteButton_M_MiniCabinetDoor, pressButton_M_MiniCabinetDoor;

    ObjData miniCabinetDoorData_M;

    public Animator canMiniCabinetDoorAnim;

    // Start is called before the first frame update
    void Start()
    {
        miniCabinetDoorData_M = GetComponent<ObjData>();

        barkButton_M_MiniCabinetDoor = miniCabinetDoorData_M.BarkButton;
        barkButton_M_MiniCabinetDoor.onClick.AddListener(OnBark);

        sniffButton_M_MiniCabinetDoor = miniCabinetDoorData_M.SniffButton;
        sniffButton_M_MiniCabinetDoor.onClick.AddListener(OnSniff);

        biteButton_M_MiniCabinetDoor = miniCabinetDoorData_M.BiteDestroyButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MiniCabinetDoor = miniCabinetDoorData_M.PushOrPressButton;
        pressButton_M_MiniCabinetDoor.onClick.AddListener(OnPushOrPress);

    }

    void DisableButton()
    {
        barkButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        sniffButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        biteButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
        pressButton_M_MiniCabinetDoor.transform.gameObject.SetActive(false);
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
        miniCabinetDoorData_M.IsBite = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerBite();
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
         IsminiCabinetDoorOpen = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // 캐비닛 문 비활성화
        //miniCabinetDoorData_M.IsNotInteractable = true;
        //cabinetDoorOutline_WED.OutlineWidth = 0;

        // 캐비닛에 상호작용 가능하게
        //cabinetFirstFloorData_WED.IsNotInteractable = false;
        //cabinetFirstFloorOutline_WED.OutlineWidth = 8;
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

}

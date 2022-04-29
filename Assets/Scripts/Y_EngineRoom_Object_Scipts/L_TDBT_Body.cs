using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L_TDBT_Body : MonoBehaviour, IInteraction
{
    private Button barkButton_L_TDBT_Body, sniffButton_L_TDBT_Body, biteButton_L_TDBT_Body, pushButton_L_TDBT_Body, noCenterButton_L_TDBT_Body;

    ObjData TDBT_BodyData_L;

    public GameObject TDBT_fixPart;

    ObjData TDBT_fixPartData;
    Outline TDBT_BodyOutline, TDBT_fixPartOutline;

    // Start is called before the first frame update
    void Start()
    {
        TDBT_BodyData_L = GetComponent<ObjData>();
        TDBT_fixPartData = TDBT_fixPart.GetComponent<ObjData>();

        TDBT_BodyOutline = GetComponent<Outline>();
        TDBT_fixPartOutline = TDBT_fixPart.GetComponent<Outline>();
        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_L_TDBT_Body = TDBT_BodyData_L.BarkButton;

        barkButton_L_TDBT_Body.onClick.AddListener(OnBark);

        sniffButton_L_TDBT_Body = TDBT_BodyData_L.SniffButton;
        sniffButton_L_TDBT_Body.onClick.AddListener(OnSniff);

        biteButton_L_TDBT_Body = TDBT_BodyData_L.BiteButton;
        biteButton_L_TDBT_Body.onClick.AddListener(OnBite);

        pushButton_L_TDBT_Body = TDBT_BodyData_L.PushOrPressButton;
        pushButton_L_TDBT_Body.onClick.AddListener(OnPushOrPress);

        noCenterButton_L_TDBT_Body = TDBT_BodyData_L.CenterButton1;
    }

    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        sniffButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        biteButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        pushButton_L_TDBT_Body.transform.gameObject.SetActive(false);
        noCenterButton_L_TDBT_Body.transform.gameObject.SetActive(false);
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        TDBT_BodyData_L.IsPushOrPress = false;
    }

    public void OnBark()
    {
        TDBT_BodyData_L.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        TDBT_BodyData_L.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());


        if (TDBT_fixPartData.IsBite) // 부품을 물었으면
        {
            Invoke("TrashDoorButtonDone", 1.5f);
        }
    }

    public void TrashDoorButtonDone()
    {
        TDBT_fixPartData.GetComponent<Rigidbody>().isKinematic = false;
        TDBT_fixPartData.transform.parent = null;

        TDBT_fixPartData.transform.position = new Vector3(-27.253f, 1.844f, 35.729f);
        TDBT_fixPartData.transform.rotation = Quaternion.Euler(0, -90, 0);
        TDBT_fixPart.transform.localScale = new Vector3(50f, 50.00002f, 50.00002f);

        //TDBT_fixPartData.enabled = false;
        //TDBT_BodyData_L.enabled = false;

        TDBT_fixPartData.IsNotInteractable = true;
        TDBT_BodyData_L.IsNotInteractable = true;
        TDBT_BodyOutline.OutlineWidth = 0;
        TDBT_fixPartOutline.OutlineWidth = 0;


        GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSniff()
    {
        TDBT_BodyData_L.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}

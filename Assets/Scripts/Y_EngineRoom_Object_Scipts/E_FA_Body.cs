using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_FA_Body : MonoBehaviour, IInteraction
{
    private Button barkButton_E_FA_Body, sniffButton_E_FA_Body, biteButton_E_FA_Body, pushButton_E_FA_Body, noCenterButton_E_FA_Body;

    ObjData FA_BodyData_E;

    public GameObject FA_fuelabsorberfixPart;
    public GameObject FA_fuelabsorber;

    ObjData FA_fuelabsorberfixPartData;

    // Start is called before the first frame update
    void Start()
    {
        FA_BodyData_E = GetComponent<ObjData>();
        FA_fuelabsorberfixPartData = FA_fuelabsorberfixPart.GetComponent<ObjData>();

        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_E_FA_Body = FA_BodyData_E.BarkButton;

        barkButton_E_FA_Body.onClick.AddListener(OnBark);

        sniffButton_E_FA_Body = FA_BodyData_E.SniffButton;
        sniffButton_E_FA_Body.onClick.AddListener(OnSniff);

        biteButton_E_FA_Body = FA_BodyData_E.BiteButton;
        biteButton_E_FA_Body.onClick.AddListener(OnBite);

        pushButton_E_FA_Body = FA_BodyData_E.PushOrPressButton;
        pushButton_E_FA_Body.onClick.AddListener(OnPushOrPress);

        noCenterButton_E_FA_Body = FA_BodyData_E.CenterButton1;
    }

    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_E_FA_Body.transform.gameObject.SetActive(false);
        sniffButton_E_FA_Body.transform.gameObject.SetActive(false);
        biteButton_E_FA_Body.transform.gameObject.SetActive(false);
        pushButton_E_FA_Body.transform.gameObject.SetActive(false);
        noCenterButton_E_FA_Body.transform.gameObject.SetActive(false);
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        FA_BodyData_E.IsPushOrPress = false;
    }

    public void OnBark()
    {
        FA_BodyData_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        FA_BodyData_E.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());


        if (FA_fuelabsorberfixPartData.IsBite) // 부품을 물었으면
        {
            Invoke("fuelabsorberDone", 1.5f); 
        }
    }

    public void fuelabsorberDone()
    {
        FA_fuelabsorber.SetActive(true);

        GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        FA_fuelabsorberfixPart.SetActive(false);
        gameObject.SetActive(false);
    }

        public void OnSniff()
    {
        FA_BodyData_E.IsSniff = true;
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

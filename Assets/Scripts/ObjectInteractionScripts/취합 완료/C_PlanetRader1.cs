using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_PlanetRader1 : MonoBehaviour, IInteraction
{
    public ObjectData planetRaderData;
    private Button barkButton, sniffButton, biteButton,
pressButton, observeButton;

    public GameObject CS_GUI;

    /* 오브젝트 데이터 */
    ObjData planetRaderData_PR;

    /* Outline 변수 */
    Outline planetRaderOutline_PR;


    // 관찰하기 시 추가 UI가 뜨는 경우, 2초간의 텀이 있다. 이것을 체크하기 위한 변수

    void Start()
    {

        planetRaderData_PR = GetComponent<ObjData>();

        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton = planetRaderData_PR.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = planetRaderData_PR.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = planetRaderData_PR.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = planetRaderData_PR.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        observeButton = planetRaderData_PR.CenterButton1;
        observeButton.onClick.AddListener(OnObserve);

        planetRaderOutline_PR = GetComponent<Outline>();

        //planetReportButton_PR.onClick.AddListener(ReportPlanet);
        //exitButton_PR.onClick.AddListener(ExitPlanetRader);
    }

    void Update()
    {
        if (planetRaderData.IsObserve == false)
        {
            CS_GUI.SetActive(false);
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        observeButton.transform.gameObject.SetActive(false);
    }

   public void OnObserve()
    {
        Debug.Log("관찰");

        /* 상호작용 버튼을 끔 */
        DisableButton();

        /* 취소할 때 참고할 오브젝트 저장 */
        //PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* 카메라 컨트롤러에 뷰 전달 */
        //CameraController.cameraController.currentView = planetRaderData_PR.ObserveView; // 관찰 뷰 : 위쪽
        /* 관찰 애니메이션 & 카메라 전환 */
        //InteractionButtonController.interactionButtonController.playerObserve();

        /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ X-1대사 삽입 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */

        Invoke("secondsf", 3f);
    }

    public void secondsf() 
    {
        Debug.Log("유아이팝업");
        CS_GUI.SetActive(true);
    }


    public void OnBark()
    {     
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
    }

    public void OnBite()
    {
        /* 상호작용 버튼을 끔 */
        DisableButton();
        /*  물기만 하는 애니메이션 & 물 수 없는 오브젝트임을 알림 */
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }



    public void OnUp()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }
}

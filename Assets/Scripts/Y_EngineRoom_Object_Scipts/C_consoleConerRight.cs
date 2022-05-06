using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_consoleConerRight : MonoBehaviour, IInteraction
{

    private Button barkButton_C_consoleConerRight, sniffButton_C_consoleConerRight, biteButton_C_consoleConerRight, pushButton_C_consoleConerRight, observeButton_C_consoleConerRight;

    /* 해당 오브젝트의 ObjData 변수 */
    ObjData ConsoleCenterRObjData_C;
    public ObjectData ConsoleCenterRData_C;

    public GameObject CMS_GUI;

    // Start is called before the first frame update
    void Start()
    {
        ConsoleCenterRObjData_C = GetComponent<ObjData>();

        barkButton_C_consoleConerRight = ConsoleCenterRObjData_C.BarkButton;
        barkButton_C_consoleConerRight.onClick.AddListener(OnBark);

        sniffButton_C_consoleConerRight = ConsoleCenterRObjData_C.SniffButton;
        sniffButton_C_consoleConerRight.onClick.AddListener(OnSniff);

        biteButton_C_consoleConerRight = ConsoleCenterRObjData_C.BiteButton;
        biteButton_C_consoleConerRight.onClick.AddListener(OnBite);

        pushButton_C_consoleConerRight = ConsoleCenterRObjData_C.PushOrPressButton;
        pushButton_C_consoleConerRight.onClick.AddListener(OnPushOrPress);

        observeButton_C_consoleConerRight = ConsoleCenterRObjData_C.CenterButton1;
        observeButton_C_consoleConerRight.onClick.AddListener(OnObserve);
    }

    // Update is called once per frame
    void Update()
    {
        if (ConsoleCenterRObjData_C.IsObserve == false)
        {
            CMS_GUI.SetActive(false);
        }
    }
    void DiableButton()
    {
        barkButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        sniffButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        biteButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        pushButton_C_consoleConerRight.transform.gameObject.SetActive(false);
        observeButton_C_consoleConerRight.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        InteractionButtonController.interactionButtonController.playerBark();
        DiableButton();
    }

    public void OnBite()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerBite();
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
        ConsoleCenterRObjData_C.IsObserve = true;


        CMS_GUI.SetActive(true);

        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 취소할 때 참고할 오브젝트 저장 */
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        /* 카메라 컨트롤러에 뷰 전달 */
        CameraController.cameraController.currentView = ConsoleCenterRObjData_C.ObserveView; // 관찰 뷰 : 위쪽
        /* 관찰 애니메이션 & 카메라 전환 */
        InteractionButtonController.interactionButtonController.playerObserve();


    }

    public void OnPushOrPress()
    {
        /* 오브젝트의 누르기 변수 true로 바꿈 */
        ConsoleCenterRObjData_C.IsPushOrPress = true;

        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHead(); 

        /* 2초 뒤에 IsPushOrPress 를 false 로 바꿈 */
        StartCoroutine(ChangePressFalse());
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        ConsoleCenterRObjData_C.IsPushOrPress = false;
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

}

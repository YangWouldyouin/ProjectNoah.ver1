using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MiniCabinetBody : MonoBehaviour,IInteraction
{

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_M_MiniCabinetBody, sniffButton_M_MiniCabinetBody, biteButton_M_MiniCabinetBody, pressButton_M_MiniCabinetBody, observeButton_M_MiniCabinetBody;

    ObjData miniCabinetBodyData_M;

    // Start is called before the first frame update
    void Start()
    {
        miniCabinetBodyData_M = GetComponent<ObjData>();


        barkButton_M_MiniCabinetBody = miniCabinetBodyData_M.BarkButton;
        barkButton_M_MiniCabinetBody.onClick.AddListener(OnBark);

        sniffButton_M_MiniCabinetBody = miniCabinetBodyData_M.SniffButton;
        sniffButton_M_MiniCabinetBody.onClick.AddListener(OnSniff);

        biteButton_M_MiniCabinetBody = miniCabinetBodyData_M.BiteDestroyButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MiniCabinetBody = miniCabinetBodyData_M.PushOrPressButton;
        pressButton_M_MiniCabinetBody.onClick.AddListener(OnPushOrPress);

        observeButton_M_MiniCabinetBody = miniCabinetBodyData_M.CenterButton1;
        observeButton_M_MiniCabinetBody.onClick.AddListener(OnObserve);
    }

    void DisableButton()
    {
        barkButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        sniffButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        biteButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        pressButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
        observeButton_M_MiniCabinetBody.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnObserve()
    {
        InteractionButtonController.interactionButtonController.playerObserve();
        DisableButton();

        CameraController.cameraController.currentView = miniCabinetBodyData_M.ObserveView;
    }

    public void OnBark()
    {
        miniCabinetBodyData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBiteDestroy()
    {
        miniCabinetBodyData_M.IsBite = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerBite();
    }


    public void OnPushOrPress()
    {
        miniCabinetBodyData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        miniCabinetBodyData_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        miniCabinetBodyData_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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

}

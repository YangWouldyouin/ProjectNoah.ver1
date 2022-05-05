using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_LoverPicture : MonoBehaviour, IInteraction
{
    private Button barkButton_W_LoverPicture, sniffButton_W_LoverPicture, biteButton_W_LoverPicture,
pushButton_W_LoverPicture, upButton_W_LoverPicture, upDisableButton_W_LoverPicture, smashButton_W_LoverPicture;

    ObjData LoverPicture_W;

    public GameObject LoverPicture_Image_W;
    ObjData LoverPicture_ImageData_W;

    // 상호작용 오브젝트
    public GameObject Tablet_W;

    // 상호작용 오브젝트 데이터
    ObjData TabletData_W;

    public bool TabletUnlock = false; // 태블릿 잠금

    void Start()
    {
        LoverPicture_W = GetComponent<ObjData>();
        LoverPicture_ImageData_W = LoverPicture_Image_W.GetComponent<ObjData>();
        TabletData_W = Tablet_W.GetComponent<ObjData>();

        barkButton_W_LoverPicture = LoverPicture_W.BarkButton;
        barkButton_W_LoverPicture.onClick.AddListener(OnBark);

        sniffButton_W_LoverPicture = LoverPicture_W.SniffButton;
        sniffButton_W_LoverPicture.onClick.AddListener(OnSniff);

        biteButton_W_LoverPicture = LoverPicture_W.BiteButton;

        smashButton_W_LoverPicture = LoverPicture_W.SmashButton;
        smashButton_W_LoverPicture.onClick.AddListener(OnSmash);

        pushButton_W_LoverPicture = LoverPicture_W.PushOrPressButton;
        pushButton_W_LoverPicture.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        upDisableButton_W_LoverPicture = LoverPicture_W.CenterDisableButton1;
    }
    void DiableButton()
    {
        // 비활성화 버튼까지 포함하여 위에서 만든 모든 버튼 변수를 끈다.

        // ex. 누르기 버튼, 가운데 버튼이 오르기 버튼인데 처음에 비활성화
        barkButton_W_LoverPicture.transform.gameObject.SetActive(false);
        sniffButton_W_LoverPicture.transform.gameObject.SetActive(false);
        biteButton_W_LoverPicture.transform.gameObject.SetActive(false);
        // 파괴하기가 되는 오브젝트이면 파괴하기 버튼 추가
        smashButton_W_LoverPicture.transform.gameObject.SetActive(false);
        pushButton_W_LoverPicture.transform.gameObject.SetActive(false);
        upDisableButton_W_LoverPicture.transform.gameObject.SetActive(false);
    }


    void Update()
    {
    }
    public void OnBark()
    {
        LoverPicture_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        LoverPicture_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        if(TabletData_W.IsObserve)
        {
            GameManager.gameManager._gameData.IsTabletUnlock = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
        else
        {
            GameManager.gameManager._gameData.IsTabletUnlock = false;
            // SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    public void OnObserve()
    {
        LoverPicture_W.IsObserve = true;
        DiableButton();
        //PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        //CameraController.cameraController.currentView = LoverPicture_W.ObserveView; // 관찰 뷰 : 위쪽
        InteractionButtonController.interactionButtonController.playerObserve();

        LoverPicture_ImageData_W.gameObject.SetActive(true); // UI로 사진이미지 크게 보여주기
    }

    public void OnPushOrPress()
    {
        LoverPicture_W.IsPushOrPress = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션
        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        LoverPicture_W.IsPushOrPress = false;
    }


    public void OnEat()
    {
    }

    public void OnInsert()
    {
    }
    public void OnSmash()
    {
    }
    public void OnSniff()
    {
    }
    public void OnUp()
    {
    }
}

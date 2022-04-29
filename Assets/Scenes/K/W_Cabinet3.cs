using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W_Cabinet3 : MonoBehaviour, IInteraction
{
    private Button barkButton_W_Cabinet3, sniffButton_W_Cabinet3, biteButton_W_Cabinet3,
pushButton_W_Cabinet3, upButton_W_Cabinet3, upDisableButton_W_Cabinet3, smashButton_W_Cabinet3;

    ObjData Cabinet3_W;


    void Start()
    {
        Cabinet3_W = GetComponent<ObjData>();

        /* ObjData 로부터 상호작용 버튼을 가져온다. */
        barkButton_W_Cabinet3 = Cabinet3_W.BarkButton;
        /* 버튼에 함수를 넣어준다. */
        barkButton_W_Cabinet3.onClick.AddListener(OnBark);

        sniffButton_W_Cabinet3 = Cabinet3_W.SniffButton;
        sniffButton_W_Cabinet3.onClick.AddListener(OnSniff);

        biteButton_W_Cabinet3 = Cabinet3_W.BiteButton;
        biteButton_W_Cabinet3.onClick.AddListener(OnBite);

        pushButton_W_Cabinet3 = Cabinet3_W.PushOrPressButton;
        pushButton_W_Cabinet3.onClick.AddListener(OnPushOrPress);
    }

    /* 상호작용 버튼을 끄는 함수 */
    void DiableButton()
    {
        barkButton_W_Cabinet3.transform.gameObject.SetActive(false);
        sniffButton_W_Cabinet3.transform.gameObject.SetActive(false);
        biteButton_W_Cabinet3.transform.gameObject.SetActive(false);
        pushButton_W_Cabinet3.transform.gameObject.SetActive(false);
    }
    void Update()
    {
    }


    public void OnBark()
    {
        Cabinet3_W.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnObserve()
    {
        Cabinet3_W.IsObserve = true;
        DiableButton();
        PlayerScripts.playerscripts.currentObserveObj = this.gameObject;
        CameraController.cameraController.currentView = Cabinet3_W.ObserveView; // 관찰 뷰 : 위쪽
        InteractionButtonController.interactionButtonController.playerObserve(); // 관찰 애니메이션 & 카메라 전환
    }

    public void OnPushOrPress()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        Cabinet3_W.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }





    public void OnBite()
    {
        // throw new System.NotImplementedException();
    }
    public void OnInsert()
    {
    }
    public void OnEat()
    {
    }
    public void OnSmash()
    {
    }
    public void OnUp()
    {
    }

}

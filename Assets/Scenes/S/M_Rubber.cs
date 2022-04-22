using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Rubber : MonoBehaviour, IInteraction
{
     /*오브젝트의 상호작용 버튼들*/
     private Button barkButton_M_Rubber, sniffButton_M_Rubber, biteButton_M_Rubber, pressButton_M_Rubber;

    ObjData rubberData_M;

    // Start is called before the first frame update
    void Start()
    {
        rubberData_M = GetComponent<ObjData>();


        barkButton_M_Rubber = rubberData_M.BarkButton;
        barkButton_M_Rubber.onClick.AddListener(OnBark);

        sniffButton_M_Rubber = rubberData_M.SniffButton;
        sniffButton_M_Rubber.onClick.AddListener(OnSniff);

        biteButton_M_Rubber = rubberData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_Rubber = rubberData_M.PushOrPressButton;
        pressButton_M_Rubber.onClick.AddListener(OnPushOrPress);
    }

    void DisableButton()
    {
        barkButton_M_Rubber.transform.gameObject.SetActive(false);
        sniffButton_M_Rubber.transform.gameObject.SetActive(false);
        biteButton_M_Rubber.transform.gameObject.SetActive(false);
        pressButton_M_Rubber.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBark()
    {
        rubberData_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();

        //물기 했을 때 무는 각도도 추가할 예정
        //if(노아의 입 안, 입 하위자식으로 들어가 있다면){각도를 항상 ~~게 한다.}

        //이거 때문에 오류나면 만약 캐비닛을 관찰하고 있었다면 -> 고무판을 물었다면 -> 관찰하기를 해제해줍니다. 라고 바꾸기
        CameraController.cameraController.CancelObserve();
        //cabinetFirstFloorData_WED.IsObserve = false;
    }

    public void OnBiteDestroy()
    {
        rubberData_M.IsBite = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }


    public void OnPushOrPress()
    {
        rubberData_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        rubberData_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        rubberData_M.IsSniff = true;

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

    public void OnObserve()
    {
    }

    public void OnBite()
    {
        throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }
}

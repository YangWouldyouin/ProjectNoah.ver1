using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class E_Boxes: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, NoCenterButton_M_Box;

    ObjData Boxes_E;

    public Animator BoxDestroyAnimation; // 박스 무너지는 애니메이션


    void Start()
    {
        Boxes_E = GetComponent<ObjData>();


        barkButton = Boxes_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Boxes_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Boxes_E.BiteButton;
        biteButton.onClick.AddListener(OnBite); // "물기"가 안되는 오브젝트

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = Boxes_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        NoCenterButton_M_Box = Boxes_E.CenterButton1;
    }

    void DiableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        NoCenterButton_M_Box.transform.gameObject.SetActive(false);
    }

    void Update()
    {
    }


    public void OnBark()
    {
        Boxes_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        Boxes_E.IsPushOrPress = true;
        DiableButton();
        // 머리로 누르는 애니메이션  
        InteractionButtonController.interactionButtonController.playerPressHead(); 
        StartCoroutine(ChangePressFalse()); // 2초 뒤에 IsPushOrPress 를 false 로 바꿈

        Invoke("DestroyBoxAnim", 1f); // 1초 뒤 박스 무너지는 애니메이션 실행
        Invoke("DestroyBox", 2f); // 2초 뒤 박스 오브젝트 비활성화
        GameManager.gameManager._gameData.IsNoBoxes = true;
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Boxes_E.IsPushOrPress = false;
    }

    void DestroyBoxAnim() // 박스 무너지는 애니메이션
    {
        BoxDestroyAnimation.SetBool("Destroy", true);
    }
    void DestroyBox() // 박스 오브젝트 비활성화
    {
        Boxes_E.gameObject.SetActive(false);
    }




    public void OnBite()
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

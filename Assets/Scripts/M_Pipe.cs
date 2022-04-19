using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_Pipe : MonoBehaviour, IInteraction
{
    public Button barkButton_M_Pipe, biteButton_M_Pipe, pressButton_M_Pipe, sniffButton_M_Pipe, noCenterButton_M_Pipe;
    ObjData pipeData_M;

    void Start()
    {
        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton_M_Pipe.onClick.AddListener(OnBark);
        sniffButton_M_Pipe.onClick.AddListener(OnSniff);
        biteButton_M_Pipe.onClick.AddListener(OnBiteDestroy);
        pressButton_M_Pipe.onClick.AddListener(OnPushOrPress);

        pipeData_M = GetComponent<ObjData>();
    }

    /* 상호작용 버튼 끄는 함수 */
    void DiableButton()
    {
        barkButton_M_Pipe.transform.gameObject.SetActive(false);
        biteButton_M_Pipe.transform.gameObject.SetActive(false);
        pressButton_M_Pipe.transform.gameObject.SetActive(false);
        sniffButton_M_Pipe.transform.gameObject.SetActive(false);
        noCenterButton_M_Pipe.transform.gameObject.SetActive(false);
    }

    public void OnBiteDestroy()
    {
        // 진짜 물기는 BiteDestroy컨트롤러스크립트를붙인다.
    }

    public void OnBark()
    {
        /* 오브젝트의 짖기 변수 true로 바꿈 */
        pipeData_M.IsBark = true;
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* 오브젝트의 냄새맡기 변수 true로 바꿈 */
        pipeData_M.IsSniff = true;
        /* 상호작용 버튼을 끔 */
        DiableButton();
        /* 애니메이션 보여주고 냄새 텍스트 띄움 */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* 오브젝트의 누르기 변수 true로 바꿈 */
        pipeData_M.IsPushOrPress = true;

        /* 상호작용 버튼을 끔 */
        DiableButton();

        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerPressHand(); // 손으로 누르는 애니메이션

        /* 2초 뒤에 Ispushorpress 를 false 로 바꿈 */
        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        pipeData_M.IsPushOrPress = false;
    }
    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }

    public void OnObserve()
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
}

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
        /* �� ��ȣ�ۿ� ��ư�� �Լ��� �ִ´� */
        barkButton_M_Pipe.onClick.AddListener(OnBark);
        sniffButton_M_Pipe.onClick.AddListener(OnSniff);
        biteButton_M_Pipe.onClick.AddListener(OnBiteDestroy);
        pressButton_M_Pipe.onClick.AddListener(OnPushOrPress);

        pipeData_M = GetComponent<ObjData>();
    }

    /* ��ȣ�ۿ� ��ư ���� �Լ� */
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
        // ��¥ ����� BiteDestroy��Ʈ�ѷ���ũ��Ʈ�����δ�.
    }

    public void OnBark()
    {
        /* ������Ʈ�� ¢�� ���� true�� �ٲ� */
        pipeData_M.IsBark = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        /* ������Ʈ�� �����ñ� ���� true�� �ٲ� */
        pipeData_M.IsSniff = true;
        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();
        /* �ִϸ��̼� �����ְ� ���� �ؽ�Ʈ ��� */
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        /* ������Ʈ�� ������ ���� true�� �ٲ� */
        pipeData_M.IsPushOrPress = true;

        /* ��ȣ�ۿ� ��ư�� �� */
        DiableButton();

        /* �ִϸ��̼� ������ */
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�

        /* 2�� �ڿ� Ispushorpress �� false �� �ٲ� */
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

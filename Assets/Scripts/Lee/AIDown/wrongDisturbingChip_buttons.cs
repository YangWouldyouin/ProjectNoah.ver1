using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wrongDisturbingChip_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData wrongdisturbingChipData;

    void Start()
    {
        wrongdisturbingChipData = GetComponent<ObjData>();

        barkButton = wrongdisturbingChipData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = wrongdisturbingChipData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = wrongdisturbingChipData.BiteButton;
        // biteButton.onClick.AddListener(OnBiteDestroy);

        pressButton = wrongdisturbingChipData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = wrongdisturbingChipData.CenterButton1;

        //GameManager.gameManager._gameData.IsHide = true;
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "canConnectZone")
        {
            if (GameManager.gameManager._gameData.IsHide)
            {
                Debug.Log("������");
            }

            else
            {
                Debug.Log("�� ���� ���Ͻô�????�װ� �м�");
                //AI�� ����ϴ� ��� ���

                GameManager.gameManager._gameData.IsAlert = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

                Destroy(gameObject, 3f);
            }

        }
    }*/

    void Update()
    {
        if (wrongdisturbingChipData.IsClicked)
        {
            if (GameManager.gameManager._gameData.IsAIVSMissionCount >= 2)
            {
                GameManager.gameManager._gameData.ActiveMissionList[9] = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                MissionGenerator.missionGenerator.ActivateMissionList();
            }

            wrongdisturbingChipData.IsClicked = false;
        }
    }

    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        wrongdisturbingChipData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
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

    public void OnPushOrPress()
    {
        wrongdisturbingChipData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        wrongdisturbingChipData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        wrongdisturbingChipData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    void IInteraction.OnBite()
    {
        //��ư�� �����ϱ�
        //throw new System.NotImplementedException();
    }

    void IInteraction.OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}

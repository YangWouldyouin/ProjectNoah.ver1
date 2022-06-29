using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rightDisturbingChip_buttons : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData rightdisturbingChipData;

    void Start()
    {
        rightdisturbingChipData = GetComponent<ObjData>();

        barkButton = rightdisturbingChipData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = rightdisturbingChipData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = rightdisturbingChipData.BiteButton;
        // biteButton.onClick.AddListener(OnBite);

        pressButton = rightdisturbingChipData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = rightdisturbingChipData.CenterButton1;
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
        if (rightdisturbingChipData.IsClicked)
        {
            if (GameManager.gameManager._gameData.IsAIVSMissionCount >= 2)
            {
                //GameManager.gameManager._gameData.ActiveMissionList[9] = true;
                //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                //MissionGenerator.missionGenerator.ActivateMissionList();
                MissionGenerator.missionGenerator.AddNewMission(9);
            }

            rightdisturbingChipData.IsClicked = false;
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
        rightdisturbingChipData.IsBark = true;
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
        rightdisturbingChipData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        rightdisturbingChipData.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        rightdisturbingChipData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        //��ư�� �����ϱ�
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }
}

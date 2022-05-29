using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert_planet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData insertData;
    Outline insertLine;

    public GameObject RChip01;
    ObjData RChip01Data;
    Outline RChip01Line;

    public GameObject WChip01;
    ObjData WChip01Data;
    Outline WChip01Line;

    public GameObject dialog;
    DialogManager dialogManager;



    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        insertData = GetComponent<ObjData>();
        insertLine = GetComponent<Outline>();

        RChip01Data = RChip01.GetComponent<ObjData>();
        RChip01Line = RChip01.GetComponent<Outline>();

        WChip01Data = WChip01.GetComponent<ObjData>();
        WChip01Line = WChip01.GetComponent<Outline>();


        barkButton = insertData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = insertData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = insertData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = insertData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = insertData.CenterButton1;
        noCenterButton.onClick.AddListener(OnObserve);
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
        insertData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        insertData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        insertData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();

        if (RChip01Data.IsBite)
        {
            Debug.Log("변화없음");

            // dialogManager.StartCoroutine(dialogManager.PrintAIDialog(59));

/*            GameManager.gameManager._gameData.IsAIDown = true;
            GameManager.gameManager._gameData.IsAIDown_M_C1C3 = true;
            GameManager.gameManager._gameData.IsStartOrbitChange = true;
            GameManager.gameManager._gameData.ActiveMissionList[9] = false;
            GameManager.gameManager._gameData.ActiveMissionList[12] = true;
            MissionGenerator.missionGenerator.ActivateMissionList();
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");*/

            Invoke("NoChip", 0.5f);
        }

        if (WChip01Data.IsBite)
        {
            // dialogManager.StartCoroutine(dialogManager.PrintAIDialog(60));

            GameManager.gameManager._gameData.IsFakePlanetOpen = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            Debug.Log("가짜 행성 해금");

            Invoke("NoChip", 0.5f);
        }

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        insertData.IsPushOrPress = false;
    }


    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    void NoChip() //
    {
        Debug.Log("칩 꽂았음");

        if (RChip01Data.IsBite)
        {
            RChip01Data.IsBite = false;

            RChip01Data.GetComponent<Rigidbody>().isKinematic = false;
            RChip01Data.transform.parent = null;

            RChip01Data.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            RChip01Data.transform.position = new Vector3(-37.866f, 0.676f, -30.357f);
            RChip01Data.transform.rotation = Quaternion.Euler(-90, 0, 0);

            RChip01Data.IsNotInteractable = false;
            RChip01Line.OutlineWidth = 0;

            insertData.IsNotInteractable = false;
            insertLine.OutlineWidth = 0;

        }

        if (WChip01Data.IsBite)
        {
            WChip01Data.IsBite = false;

            WChip01Data.GetComponent<Rigidbody>().isKinematic = false;
            WChip01Data.transform.parent = null;

            WChip01Data.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            WChip01Data.transform.position = new Vector3(-37.866f, 0.676f, -30.357f);
            WChip01Data.transform.rotation = Quaternion.Euler(-90, 0, 0);

            WChip01Data.IsNotInteractable = false;
            WChip01Line.OutlineWidth = 0;

            insertData.IsNotInteractable = false;
            insertLine.OutlineWidth = 0;
        }
    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {
        //throw new System.NotImplementedException();
    }

}

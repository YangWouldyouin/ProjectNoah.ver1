using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insert_planet : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData Planet_insertObjData;
    public ObjectData Planet_insertData;
    Outline Planet_insertLine;

    ObjData R_ChipObjData;
    public GameObject R_Chip;
    public ObjectData R_ChipData;
    Outline R_ChipLine;

    ObjData W_ChipObjData;
    public GameObject W_Chip;
    public ObjectData W_ChipData;
    Outline W_ChipLine;

    public GameObject dialog;
    DialogManager dialogManager;



    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        Planet_insertObjData = GetComponent<ObjData>();
        Planet_insertLine = GetComponent<Outline>();

        R_ChipLine = R_Chip.GetComponent<Outline>();

        W_ChipLine = W_Chip.GetComponent<Outline>();


        barkButton = Planet_insertObjData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = Planet_insertObjData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = Planet_insertObjData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = Planet_insertObjData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = Planet_insertObjData.CenterButton1;
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
        Planet_insertObjData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        Planet_insertObjData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }


    public void OnPushOrPress()
    {
        Planet_insertObjData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHead();
        StartCoroutine(ChangePressFalse());

        if (R_ChipData.IsBite)
        {
            Debug.Log("변화없음");

            Invoke("NoChip", 0.5f);
        }

        if (W_ChipData.IsBite)
        {
            Debug.Log("가짜 행성 해금");

            Invoke("NoChip", 0.5f);

            GameManager.gameManager._gameData.IsFakePlanetOpen = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    /* 2초 뒤에 누르기 변수를 false 로 바꾸는 코루틴 */
    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        Planet_insertObjData.IsPushOrPress = false;
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

        if (R_ChipObjData.IsBite)
        {
            R_ChipObjData.IsBite = false;

            R_Chip.GetComponent<Rigidbody>().isKinematic = false;
            R_Chip.transform.parent = null;

            R_Chip.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            R_Chip.transform.position = new Vector3(-36.433f, 0.735f, -33.7f);
            R_Chip.transform.rotation = Quaternion.Euler(90, 0, 0);

            R_ChipObjData.IsNotInteractable = false;
            R_ChipLine.OutlineWidth = 0;

            Planet_insertObjData.IsNotInteractable = false;
            Planet_insertLine.OutlineWidth = 0;

        }

        if (W_ChipObjData.IsBite)
        {
            W_ChipObjData.IsBite = false;

            W_Chip.GetComponent<Rigidbody>().isKinematic = false;
            W_Chip.transform.parent = null;

            W_Chip.transform.localScale = new Vector3(15.89634f, 15.89634f, 2.835073f);
            W_Chip.transform.position = new Vector3(-36.433f, 0.735f, -33.7f);
            W_Chip.transform.rotation = Quaternion.Euler(90, 0, 0);

            W_ChipObjData.IsNotInteractable = false;
            W_ChipLine.OutlineWidth = 0;

            Planet_insertObjData.IsNotInteractable = false;
            Planet_insertLine.OutlineWidth = 0;
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

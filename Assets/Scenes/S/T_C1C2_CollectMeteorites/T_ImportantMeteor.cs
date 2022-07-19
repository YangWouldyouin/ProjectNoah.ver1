using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_ImportantMeteor : MonoBehaviour, IInteraction
{
    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_ImportantMeteor, sniffButton_T_ImportantMeteor, biteButton_T_ImportantMeteor,
        pressButton_T_ImportantMeteor, noCenterButton_T_ImportantMeteor;

    ObjData importantMeteorData_T;
    public ObjectData importantMeteorObjData_T;

    public GameObject dialog;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();

        importantMeteorData_T = GetComponent<ObjData>();


        barkButton_T_ImportantMeteor = importantMeteorData_T.BarkButton;
        barkButton_T_ImportantMeteor.onClick.AddListener(OnBark);

        sniffButton_T_ImportantMeteor = importantMeteorData_T.SniffButton;
        sniffButton_T_ImportantMeteor.onClick.AddListener(OnSniff);

        biteButton_T_ImportantMeteor = importantMeteorData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_ImportantMeteor = importantMeteorData_T.PushOrPressButton;
        pressButton_T_ImportantMeteor.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_ImportantMeteor = importantMeteorData_T.CenterButton1;
    }

    void DisableButton()
    {
        barkButton_T_ImportantMeteor.transform.gameObject.SetActive(false);
        sniffButton_T_ImportantMeteor.transform.gameObject.SetActive(false);
        biteButton_T_ImportantMeteor.transform.gameObject.SetActive(false);
        pressButton_T_ImportantMeteor.transform.gameObject.SetActive(false);
        noCenterButton_T_ImportantMeteor.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if(importantMeteorObjData_T.IsClicked && !GameManager.gameManager._gameData.IsIsReallySmellDone_T_C2)
        {
            //C - 3 대사  ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(44));
        }
    }

    public void OnBark()
    {
       // importantMeteorData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

 
    public void OnPushOrPress()
    {
       // importantMeteorData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.PlayerCanNotPush();

        //StartCoroutine(ChangePressFalse());
    }

/*    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        importantMeteorData_T.IsPushOrPress = false;
    }*/

    public void OnSniff()
    {
        //importantMeteorData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();

        GameManager.gameManager._gameData.IsIsReallySmellDone_T_C2 = true;

        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }

    public void OnSmash()
    {

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


    public void OnUp()
    {
        
    }
}

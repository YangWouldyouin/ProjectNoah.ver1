using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T_AnalyticalMachineButton : MonoBehaviour, IInteraction
{
    public bool IsSmellDone_T = false; // 운석 냄새를 맡았는지

    /*연관있는 오브젝트*/
    public GameObject T_AreNormalMeteor1;
    public GameObject T_AreImportantMeteor;
    public GameObject T_AreAnalyticalMachine;

    /*오브젝트의 상호작용 버튼들*/
    private Button barkButton_T_AnalyticalMachineButton, sniffButton_T_AnalyticalMachineButton, biteButton_T_AnalyticalMachineButton,
        pressButton_T_AnalyticalMachineButton, noCenterButton_T_AnalyticalMachineButton;


    /*ObjData*/
    ObjData analyticalMachineButtonData_T;
    ObjData areNormalMeteor1Data_T;
    ObjData areimportantMeteorData_T;
    ObjData areAnalyticalMachineData_T;


    /*Outline*/
    Outline analyticalMachineButtonOutline_T;
    Outline areAnalyticalMachineOutline_T;
    Outline areNormalMeteor1Outline_T;
    Outline areimportantMeteorOutline_T;

    /*Animator*/
    public Animator analyticalMachineAnim_T;
    // Start is called before the first frame update
    void Start()
    {
        /*ObjData*/
        analyticalMachineButtonData_T = GetComponent<ObjData>();
        areAnalyticalMachineData_T = T_AreAnalyticalMachine.GetComponent<ObjData>();
        areNormalMeteor1Data_T = T_AreNormalMeteor1.GetComponent<ObjData>();
        areimportantMeteorData_T = T_AreImportantMeteor.GetComponent<ObjData>();

        /*Outline*/
        analyticalMachineButtonOutline_T = GetComponent<Outline>();
        areAnalyticalMachineOutline_T = T_AreAnalyticalMachine.GetComponent<Outline>();
        areNormalMeteor1Outline_T = T_AreNormalMeteor1.GetComponent<Outline>();
        areimportantMeteorOutline_T = T_AreImportantMeteor.GetComponent<Outline>();


        barkButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.BarkButton;
        barkButton_T_AnalyticalMachineButton.onClick.AddListener(OnBark);

        sniffButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.SniffButton;
        sniffButton_T_AnalyticalMachineButton.onClick.AddListener(OnSniff);

        biteButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.PushOrPressButton;
        pressButton_T_AnalyticalMachineButton.onClick.AddListener(OnPushOrPress);

        noCenterButton_T_AnalyticalMachineButton = analyticalMachineButtonData_T.CenterButton1;
    }

    void Update()
    {
        /*항상 운석을 수집기에 넣기 전 노아의 후각을 통해 운석의 상태를 검증하는 단계가 필요하다는 식으로
         운석 냄새를 먼저 맡아야 된다는 것을 AI가 알려준다.*/

        //운석의 냄새를 맡고 분석기와 닿는 높이가 충분하다면
        if(areNormalMeteor1Data_T.IsSniff  || areimportantMeteorData_T.IsSniff )
        {
            IsSmellDone_T = true;
        }

        //높이가 되면 수집기계의 가운데 버튼을 켜준다.
        if(analyticalMachineButtonData_T.IsCollision && IsSmellDone_T)
        {
            analyticalMachineButtonData_T.IsNotInteractable = false; // 상호작용 가능하게
            analyticalMachineButtonOutline_T.OutlineWidth = 16;

            areAnalyticalMachineData_T.IsCenterButtonDisabled = false;
        }
        else if (!analyticalMachineButtonData_T.IsCollision)
        {
            analyticalMachineButtonData_T.IsNotInteractable = true; // 상호작용 불가능하게
            analyticalMachineButtonOutline_T.OutlineWidth = 0;

            areAnalyticalMachineData_T.IsCenterButtonDisabled = true;
        }

        if(GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 
            || GameManager.gameManager._gameData.IsInputImportantMeteor1_T_C2)
        {
            StartCoroutine(analyticalMachineClose(2f, 0f));
        }
    }

    void DisableButton()
    {
        barkButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        sniffButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        biteButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        pressButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
        noCenterButton_T_AnalyticalMachineButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        analyticalMachineButtonData_T.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }


    public void OnPushOrPress()
    {
        analyticalMachineButtonData_T.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

        StartCoroutine(analyticalMachineOpen());

        areAnalyticalMachineData_T.IsNotInteractable = false; // 상호작용 가능하게
        areAnalyticalMachineOutline_T.OutlineWidth = 8;


    }


    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        analyticalMachineButtonData_T.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        analyticalMachineButtonData_T.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
    }

    IEnumerator analyticalMachineOpen()
    {
        yield return new WaitForSeconds(1f);

        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpen", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpenEnd", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineClose", false);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineCloseEnd", false);

        //count1 += 1;
    }

    IEnumerator analyticalMachineClose(float delay2, float CloseTimeCheck2)
    {
        yield return new WaitForSeconds(delay2);


        bool isAnalyticalTimeOver = false;
        float closeTime2 = 0f;

        while (isAnalyticalTimeOver == false)
        {
            yield return null;

            closeTime2 += Time.deltaTime;

            //현재 시간이>=제한 걸어둔 시간보다 크거나 같으면
            //isTimeOver = true;가 되어 이 (isTimeOver == false)에서 나가겠다.
            if (closeTime2 >= CloseTimeCheck2)
            {
                isAnalyticalTimeOver = true;
            }

            //혹은 운석을 물었다면 이 (isTimeOver == false)에서 나가겠다
            if (areNormalMeteor1Data_T.IsBite)
            {
                isAnalyticalTimeOver = true;
            }
        }

        analyticalMachineAnim_T.SetBool("isAnalyticalMachineClose", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineCloseEnd", true);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpen", false);
        analyticalMachineAnim_T.SetBool("isAnalyticalMachineOpenEnd", false);

        areAnalyticalMachineData_T.IsNotInteractable = true; // 상호작용 불가능하게
        areAnalyticalMachineOutline_T.OutlineWidth = 0;

        //count1 += 1;
    }
    public void OnBite()
    {

    }

    public void OnSmash()
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

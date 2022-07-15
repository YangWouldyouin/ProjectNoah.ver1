using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class E_Boxes: MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, NoCenterButton_M_Box;

    ObjData BoxesObjData_E;
    public ObjectData BoxesData_E;

    public GameObject Tablet_E;
    ObjData TabletData_E;

    //public GameObject TabletOutli_E;
    //ObjData TabletOutlineData_E;

    public Animator BoxDestroyAnimation; // 박스 무너지는 애니메이션

    /* 소리 */
    AudioSource Box_Collapse_Sound;
    public AudioClip Box_Collapse; // 오디오 소스

    void Start()
    {
        Box_Collapse_Sound = GetComponent<AudioSource>(); 

        BoxesObjData_E = GetComponent<ObjData>();
        TabletData_E = Tablet_E.GetComponent<ObjData>();
        // TabletOutlineData_E = Tablet_E.GetComponent<Outline>();

        // Tablet_E.SetActive(false);

        barkButton = BoxesObjData_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = BoxesObjData_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = BoxesObjData_E.BiteButton;
        biteButton.onClick.AddListener(OnBite); // "물기"가 안되는 오브젝트

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = BoxesObjData_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // 비활성화 버튼은 버튼을 가져오기만 한다. 
        NoCenterButton_M_Box = BoxesObjData_E.CenterButton1;
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
        BoxesObjData_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }
    public void OnBite()
    {
        DiableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }
    public void OnSniff()
    {
        BoxesObjData_E.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    /* ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ 퍼즐 끝 ♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥ */
    public void OnPushOrPress()
    {
        DiableButton();
        // 머리로 누르는 애니메이션  
        InteractionButtonController.interactionButtonController.playerPressHead(); 

        Invoke("DestroyBoxAnim", 1f); // 1초 뒤 박스 무너지는 애니메이션 실행
        Box_Collapse_Sound.Play();
        Invoke("DestroyBox", 2f); // 2초 뒤 박스 오브젝트 비활성화

        GameManager.gameManager._gameData.IsNoBoxes = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // 미션이 추가되어있는지 확인 후 삭제
        GameData gameData = SaveSystem.Load("save_001");
        if (gameData.ActiveMissionList[6])
        {
            MissionGenerator.missionGenerator.DeleteNewMission(6);
        }
        StartCoroutine(DelayAdding());
    }

    IEnumerator DelayAdding()
    {
        yield return new WaitForSeconds(2f);

        GameData gameData = SaveSystem.Load("save_001");
        // 아직 미션 추가 전인지 확인 후 추가
        if (!gameData.CompleteMissionList[7])
        {
            MissionGenerator.missionGenerator.AddNewMission(7);
            GameManager.gameManager._gameData.CompleteMissionList[7] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    void DestroyBoxAnim() // 박스 무너지는 애니메이션
    {
        BoxDestroyAnimation.SetBool("Destroy", true);
    }
    void DestroyBox() // 박스 오브젝트 비활성화
    {
        BoxesObjData_E.gameObject.SetActive(false);
    }

/*    void FindTablet()
    {

    }*/

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
    public void OnUp()
    {
    }
}

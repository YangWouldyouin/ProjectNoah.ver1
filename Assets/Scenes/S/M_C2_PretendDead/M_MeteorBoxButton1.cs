using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton1 : MonoBehaviour, IInteraction
{
    public bool IsClickMeteorBoxButton1 = false;

    /*�����ִ� ������Ʈ*/
    public GameObject M_Box_Obj3;
    public GameObject M_Noah_Obj3;
    public GameObject M_IsMeteoritesStorage1;



    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_MeteorBoxButton1, sniffButton_M_MeteorBoxButton1, biteButton_M_MeteorBoxButton1,
        pressButton_M_MeteorBoxButton1, noCenterButton_M_MeteorBoxButton1;

    /*ObjData*/
    ObjData MeteorBoxButton1Data_M;
    ObjData Box_Obj3Data_M;
    ObjData Noah_Obj3Data_M;
    ObjData IsMeteoritesStorage1Data_M;


    /*Outline*/
    Outline IsMeteoritesStorage1Outline_M;
    Outline MeteorBoxButton1Outline_M;

    /*�ִϸ��̼�*/
    public Animator meteorBox1Anim_M;

    /*Collider*/
    BoxCollider MeteorBoxButton1_Collider;
    BoxCollider Box3_Collider;
    BoxCollider Noah3_Collider;
    BoxCollider IsMeteoritesStorage1_Collider;

    void Start()
    {
        /*Collider*/
        MeteorBoxButton1_Collider = GetComponent<BoxCollider>();
        Box3_Collider = M_Box_Obj3.GetComponent<BoxCollider>();
        Noah3_Collider = M_Noah_Obj3.GetComponent<BoxCollider>();
        IsMeteoritesStorage1_Collider = M_IsMeteoritesStorage1.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage1Outline_M = M_IsMeteoritesStorage1.GetComponent<Outline>();
        MeteorBoxButton1Outline_M = GetComponent<Outline>();


        /*ObjData*/
        MeteorBoxButton1Data_M = GetComponent<ObjData>();
        Box_Obj3Data_M = M_Box_Obj3.GetComponent<ObjData>();
        IsMeteoritesStorage1Data_M = M_IsMeteoritesStorage1.GetComponent<ObjData>();

        /*��ư ����*/
        barkButton_M_MeteorBoxButton1 = MeteorBoxButton1Data_M.BarkButton;
        barkButton_M_MeteorBoxButton1.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton1 = MeteorBoxButton1Data_M.SniffButton;
        sniffButton_M_MeteorBoxButton1.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton1 = MeteorBoxButton1Data_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton1 = MeteorBoxButton1Data_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton1.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton1 = MeteorBoxButton1Data_M.CenterButton1;

        /*�������
         ���� � �ӹ��� �� �����ߴٸ� �ӹ� ����*/
        if (GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2)
        {
            GameManager.gameManager._gameData.IsStartPretendDead = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            //D-1 ��� ��� �١١١١١١١١١١١١١١١١١١١١�
        }
    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton1.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Box_Obj3Data_M.IsUpDown)
        {
            Box3_Collider.enabled = false;
            MeteorBoxButton1_Collider.enabled = true;
        }
        else
        {
            Box3_Collider.enabled = true;
            MeteorBoxButton1_Collider.enabled = false;
            MeteorBoxButton1Data_M.IsCollision = false;
        }

        /*��ư�� �ε����� ��ư�� ��ȣ�ۿ� ����*/
        if(MeteorBoxButton1Data_M.IsCollision)
        {
            MeteorBoxButton1Data_M.IsNotInteractable = false; // ��ư ��ȣ�ۿ� �����ϰ�
            MeteorBoxButton1Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage1Data_M.IsCenterButtonDisabled = false;  // �����ϱ� Ȱ��ȭ
        }
        else
        {
            MeteorBoxButton1Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton1Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage1Data_M.IsCenterButtonDisabled = true; // �����ϱ� �� Ȱ��ȭ
        }


        /*� �����Կ� �����ϱ⸦ �ϸ�*/
        if (IsMeteoritesStorage1Data_M.IsObserve)
        {
            IsMeteoritesStorage1_Collider.enabled = false;

            Noah3_Collider.enabled = false; // ��� �ݶ��̴��� ���ش�.

            MeteorBoxButton1Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton1Outline_M.OutlineWidth = 0;

            MeteorBoxButton1_Collider.enabled = false;

        }

        /*� �����Կ� �����ϸ� && ��ư�� 1���̶� Ŭ���ߴٸ�,
          �׻� ������ �� ������ ������ �ϳ� ��*/
        else if (!IsMeteoritesStorage1Data_M.IsObserve && IsClickMeteorBoxButton1==true)
        {
            IsMeteoritesStorage1_Collider.enabled = true;

            Noah3_Collider.enabled = true;

            MeteorBoxButton1_Collider.enabled = true;
        }

    }

    public void OnBark()
    {
        MeteorBoxButton1Data_M.IsBark = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        MeteorBoxButton1Data_M.IsPushOrPress = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());

        Invoke("OpenMeteorBox", 2f);
    }

    void OpenMeteorBox()
    {
        meteorBox1Anim_M.SetBool("isMeteorBox1Open", true);
        meteorBox1Anim_M.SetBool("isMeteorBox1End", true);

        IsMeteoritesStorage1Data_M.IsNotInteractable = false; // �ڽ��� ��ȣ�ۿ� �����ϰ�
        IsMeteoritesStorage1Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton1 = true;

/*     MeteorBoxButton1Data_M.IsNotInteractable = true; // ��ư�� �ι� �ٽ� ��ȣ�ۿ� ���ϰ�
        MeteorBoxButton1Outline_M.OutlineWidth = 0;*/

        //IsMeteoritesStorage1_Collider.enabled = true;
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        MeteorBoxButton1Data_M.IsPushOrPress = false;
    }

    public void OnSniff()
    {
        MeteorBoxButton1Data_M.IsSniff = true;

        DisableButton();

        InteractionButtonController.interactionButtonController.playerSniff();
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
    public void OnUp()
    {
    }
}

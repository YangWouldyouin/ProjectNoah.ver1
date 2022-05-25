using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton2 : MonoBehaviour, IInteraction
{

    public bool IsClickMeteorBoxButton2 = false;

    /*�����ִ� ������Ʈ*/
    public GameObject M_Box_Obj4;
    public GameObject M_Noah_Obj4;
    public GameObject M_IsMeteoritesStorage2;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_MeteorBoxButton2, sniffButton_M_MeteorBoxButton2, biteButton_M_MeteorBoxButton3,
        pressButton_M_MeteorBoxButton4, noCenterButton_M_MeteorBoxButton5;


    /*ObjData*/
    ObjData MeteorBoxButton2ObjData_M;
    public ObjectData MeteorBoxButton2Data_M;
    public ObjectData Box_Obj4Data_M;
    public ObjectData IsMeteoritesStorage2Data_M;

    /*Outline*/
    Outline IsMeteoritesStorage2Outline_M;
    Outline MeteorBoxButton2Outline_M;

    /*�ִϸ��̼�*/
    public Animator meteorBox2Anim_M;


    /*Collider*/
    BoxCollider MeteorBoxButton2_Collider;
    BoxCollider Box4_Collider;
    BoxCollider Noah4_Collider;
    BoxCollider IsMeteoritesStorage2_Collider;


    void Start()
    {
        /*Collider*/
        MeteorBoxButton2_Collider = GetComponent<BoxCollider>();
        Box4_Collider = M_Box_Obj4.GetComponent<BoxCollider>();
        Noah4_Collider = M_Noah_Obj4.GetComponent<BoxCollider>();
        IsMeteoritesStorage2_Collider = M_IsMeteoritesStorage2.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage2Outline_M = M_IsMeteoritesStorage2.GetComponent<Outline>();
        MeteorBoxButton2Outline_M = GetComponent<Outline>();

        /*ObjData*/
        MeteorBoxButton2ObjData_M = GetComponent<ObjData>();

        barkButton_M_MeteorBoxButton2 = MeteorBoxButton2ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton2.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton2 = MeteorBoxButton2ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton2.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton3 = MeteorBoxButton2ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton4 = MeteorBoxButton2ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton4.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton5 = MeteorBoxButton2ObjData_M.CenterButton1;

        /*�������*/
        //IsMeteoritesStorage2Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage2Data_M.IsObserve = false;

    }

    void Update()
    {
        if (Box_Obj4Data_M.IsUpDown)
        {
            Box4_Collider.enabled = false;
            MeteorBoxButton2_Collider.enabled = true;
        }
        else
        {
            Box4_Collider.enabled = true;
            MeteorBoxButton2_Collider.enabled = false;
            MeteorBoxButton2Data_M.IsCollision = false;
        }

        /*��ư�� �ε����� ��ư�� ��ȣ�ۿ� ����*/
        if (MeteorBoxButton2Data_M.IsCollision)
        {
            MeteorBoxButton2Data_M.IsNotInteractable = false; // ��ư ��ȣ�ۿ� �����ϰ�
            MeteorBoxButton2Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage2Data_M.IsCenterButtonDisabled = false;  // �����ϱ� Ȱ��ȭ
        }
        else
        {
            MeteorBoxButton2Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton2Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage2Data_M.IsCenterButtonDisabled = true; // �����ϱ� �� Ȱ��ȭ
        }


        /*� �����Կ� �����ϱ⸦ �ϸ�*/
        if (IsMeteoritesStorage2Data_M.IsObserve)
        {
            IsMeteoritesStorage2_Collider.enabled = false;

            //Noah4_Collider.enabled = false; // ��� �ݶ��̴��� ���ش�.

            MeteorBoxButton2Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton2Outline_M.OutlineWidth = 0;

            MeteorBoxButton2_Collider.enabled = false;

        }

        /*� �����Կ� �����ϸ� && ��ư�� 1���̶� Ŭ���ߴٸ�,
          �׻� ������ �� ������ ������ �ϳ� ��*/
        else if (!IsMeteoritesStorage2Data_M.IsObserve && IsClickMeteorBoxButton2 == true)
        {
            IsMeteoritesStorage2_Collider.enabled = true;

            //Noah4_Collider.enabled = true;

            MeteorBoxButton2_Collider.enabled = true;
        }

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton2.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton2.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton5.transform.gameObject.SetActive(false);
    }


    public void OnBark()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnPushOrPress()
    {
        DisableButton();

        InteractionButtonController.interactionButtonController.playerPressHand();

        Invoke("OpenMeteorBox2", 2f);
    }


    void OpenMeteorBox2()
    {
        meteorBox2Anim_M.SetBool("isMeteorBox2Open", true);
        meteorBox2Anim_M.SetBool("isMeteorBox2End", true);

        IsMeteoritesStorage2Data_M.IsNotInteractable = false; // �ڽ��� ��ȣ�ۿ� �����ϰ�
        IsMeteoritesStorage2Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton2 = true;
    }

    public void OnSniff()
    {
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

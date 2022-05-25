using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton3 : MonoBehaviour, IInteraction
{
    public bool IsClickMeteorBoxButton3 = false;

    /*�����ִ� ������Ʈ*/
    public GameObject M_Box_Obj5;
    public GameObject M_Noah_Obj5;
    public GameObject M_IsMeteoritesStorage3;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_MeteorBoxButton3, sniffButton_M_MeteorBoxButton3, biteButton_M_MeteorBoxButton3,
        pressButton_M_MeteorBoxButton3, noCenterButton_M_MeteorBoxButton3;


    /*ObjData*/
    ObjData MeteorBoxButton3ObjData_M;
    public ObjectData MeteorBoxButton3Data_M;

    public ObjectData Box_Obj5Data_M;
    public ObjectData IsMeteoritesStorage3Data_M;

    /*Outline*/
    Outline IsMeteoritesStorage3Outline_M;
    Outline MeteorBoxButton3Outline_M;

    /*�ִϸ��̼�*/
    public Animator meteorBox3Anim_M;

    /*Collider*/
    BoxCollider MeteorBoxButton3_Collider;
    BoxCollider Box5_Collider;
    BoxCollider Noah5_Collider;
    BoxCollider IsMeteoritesStorage3_Collider;

    void Start()
    {
        /*Collider*/
        MeteorBoxButton3_Collider = GetComponent<BoxCollider>();
        Box5_Collider = M_Box_Obj5.GetComponent<BoxCollider>();
        Noah5_Collider = M_Noah_Obj5.GetComponent<BoxCollider>();
        IsMeteoritesStorage3_Collider = M_IsMeteoritesStorage3.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage3Outline_M = M_IsMeteoritesStorage3.GetComponent<Outline>();
        MeteorBoxButton3Outline_M = GetComponent<Outline>();

        /*ObjData*/
        MeteorBoxButton3ObjData_M = GetComponent<ObjData>();

        /*��ư ����*/
        barkButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton3.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton3.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton3.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton3 = MeteorBoxButton3ObjData_M.CenterButton1;

        /*�������*/
        //IsMeteoritesStorage3Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage3Data_M.IsObserve = false;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton3.transform.gameObject.SetActive(false);
    }


    void Update()
    {
        if (Box_Obj5Data_M.IsUpDown)
        {
            Box5_Collider.enabled = false;
            MeteorBoxButton3_Collider.enabled = true;
        }
        else
        {
            Box5_Collider.enabled = true;
            MeteorBoxButton3_Collider.enabled = false;
            MeteorBoxButton3Data_M.IsCollision = false;
        }

        /*��ư�� �ε����� ��ư�� ��ȣ�ۿ� ����*/
        if (MeteorBoxButton3Data_M.IsCollision)
        {
            MeteorBoxButton3Data_M.IsNotInteractable = false; // ��ư ��ȣ�ۿ� �����ϰ�
            MeteorBoxButton3Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage3Data_M.IsCenterButtonDisabled = false;  // �����ϱ� Ȱ��ȭ
        }
        else
        {
            MeteorBoxButton3Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton3Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage3Data_M.IsCenterButtonDisabled = true; // �����ϱ� �� Ȱ��ȭ
        }


        /*� �����Կ� �����ϱ⸦ �ϸ�*/
        if (IsMeteoritesStorage3Data_M.IsObserve)
        {
            IsMeteoritesStorage3_Collider.enabled = false;

            //Noah5_Collider.enabled = false; // ��� �ݶ��̴��� ���ش�.

            MeteorBoxButton3Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton3Outline_M.OutlineWidth = 0;

            MeteorBoxButton3_Collider.enabled = false;

        }

        /*� �����Կ� �����ϸ� && ��ư�� 1���̶� Ŭ���ߴٸ�,
          �׻� ������ �� ������ ������ �ϳ� ��*/
        else if (!IsMeteoritesStorage3Data_M.IsObserve && IsClickMeteorBoxButton3 == true)
        {
            IsMeteoritesStorage3_Collider.enabled = true;

            //Noah5_Collider.enabled = true;

            MeteorBoxButton3_Collider.enabled = true;
        }

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

        Invoke("OpenMeteorBox3", 2f);
    }

    void OpenMeteorBox3()
    {
        meteorBox3Anim_M.SetBool("isMeteorBox3Open", true);
        meteorBox3Anim_M.SetBool("isMeteorBox3End", true);

        IsMeteoritesStorage3Data_M.IsNotInteractable = false; // �ڽ��� ��ȣ�ۿ� �����ϰ�
        IsMeteoritesStorage3Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton3 = true;

        /*     MeteorBoxButton1Data_M.IsNotInteractable = true; // ��ư�� �ι� �ٽ� ��ȣ�ۿ� ���ϰ�
                MeteorBoxButton1Outline_M.OutlineWidth = 0;*/

        //IsMeteoritesStorage1_Collider.enabled = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class M_MeteorBoxButton4 : MonoBehaviour, IInteraction
{
    public bool IsClickMeteorBoxButton4 = false;

    /*�����ִ� ������Ʈ*/
    public GameObject M_Box_Obj6;
    public GameObject M_Noah_Obj6;
    public GameObject M_IsMeteoritesStorage4;

    /*������Ʈ�� ��ȣ�ۿ� ��ư��*/
    private Button barkButton_M_MeteorBoxButton4, sniffButton_M_MeteorBoxButton4, biteButton_M_MeteorBoxButton4,
        pressButton_M_MeteorBoxButton4, noCenterButton_M_MeteorBoxButton4;


    /*ObjData*/
    ObjData MeteorBoxButton4ObjData_M;
    public ObjectData MeteorBoxButton4Data_M;

    public ObjectData Box_Obj6Data_M;
    public ObjectData IsMeteoritesStorage4Data_M;

    /*Outline*/
    Outline IsMeteoritesStorage4Outline_M;
    Outline MeteorBoxButton4Outline_M;

    /*�ִϸ��̼�*/
    public Animator meteorBox4Anim_M;

    /*Collider*/
    BoxCollider MeteorBoxButton4_Collider;
    BoxCollider Box6_Collider;
    BoxCollider Noah6_Collider;
    BoxCollider IsMeteoritesStorage4_Collider;

    void Start()
    {
        /*Collider*/
        MeteorBoxButton4_Collider = GetComponent<BoxCollider>();
        Box6_Collider = M_Box_Obj6.GetComponent<BoxCollider>();
        Noah6_Collider = M_Noah_Obj6.GetComponent<BoxCollider>();
        IsMeteoritesStorage4_Collider = M_IsMeteoritesStorage4.GetComponent<BoxCollider>();

        /*Outline*/
        IsMeteoritesStorage4Outline_M = M_IsMeteoritesStorage4.GetComponent<Outline>();
        MeteorBoxButton4Outline_M = GetComponent<Outline>();

        /*ObjData*/
        MeteorBoxButton4ObjData_M = GetComponent<ObjData>();


        /*��ư ����*/
        barkButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.BarkButton;
        barkButton_M_MeteorBoxButton4.onClick.AddListener(OnBark);

        sniffButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.SniffButton;
        sniffButton_M_MeteorBoxButton4.onClick.AddListener(OnSniff);

        biteButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.BiteButton;
        //biteButton_M_Rubber.onClick.AddListener(OnBiteDestroy);

        pressButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.PushOrPressButton;
        pressButton_M_MeteorBoxButton4.onClick.AddListener(OnPushOrPress);

        noCenterButton_M_MeteorBoxButton4 = MeteorBoxButton4ObjData_M.CenterButton1;

        /*�������*/
        //IsMeteoritesStorage4Data_M.IsCenterButtonDisabled = true;
        IsMeteoritesStorage4Data_M.IsObserve = false;

    }

    void DisableButton()
    {
        barkButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        sniffButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        biteButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        pressButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
        noCenterButton_M_MeteorBoxButton4.transform.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Box_Obj6Data_M.IsUpDown)
        {
            Box6_Collider.enabled = false;
            MeteorBoxButton4_Collider.enabled = true;
        }
        else
        {
            Box6_Collider.enabled = true;
            MeteorBoxButton4_Collider.enabled = false;
            MeteorBoxButton4Data_M.IsCollision = false;
        }

        /*��ư�� �ε����� ��ư�� ��ȣ�ۿ� ����*/
        if (MeteorBoxButton4Data_M.IsCollision)
        {
            MeteorBoxButton4Data_M.IsNotInteractable = false; // ��ư ��ȣ�ۿ� �����ϰ�
            MeteorBoxButton4Outline_M.OutlineWidth = 8;

            IsMeteoritesStorage4Data_M.IsCenterButtonDisabled = false;  // �����ϱ� Ȱ��ȭ
        }
        else
        {
            MeteorBoxButton4Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton4Outline_M.OutlineWidth = 0;

            IsMeteoritesStorage4Data_M.IsCenterButtonDisabled = true; // �����ϱ� �� Ȱ��ȭ
        }


        /*� �����Կ� �����ϱ⸦ �ϸ�*/
        if (IsMeteoritesStorage4Data_M.IsObserve)
        {
            IsMeteoritesStorage4_Collider.enabled = false;

            //Noah6_Collider.enabled = false; // ��� �ݶ��̴��� ���ش�.

            MeteorBoxButton4Data_M.IsNotInteractable = true; // ��ư ��ȣ�ۿ� �Ұ����ϰ�
            MeteorBoxButton4Outline_M.OutlineWidth = 0;

            MeteorBoxButton4_Collider.enabled = false;

        }

        /*� �����Կ� �����ϸ� && ��ư�� 1���̶� Ŭ���ߴٸ�,
          �׻� ������ �� ������ ������ �ϳ� ��*/
        else if (!IsMeteoritesStorage4Data_M.IsObserve && IsClickMeteorBoxButton4 == true)
        {
            IsMeteoritesStorage4_Collider.enabled = true;

            //Noah6_Collider.enabled = true;

            MeteorBoxButton4_Collider.enabled = true;
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

        Invoke("OpenMeteorBox4", 2f);
    }

    void OpenMeteorBox4()
    {
        meteorBox4Anim_M.SetBool("isMeteorBox4Open", true);
        meteorBox4Anim_M.SetBool("isMeteorBox4End", true);

        IsMeteoritesStorage4Data_M.IsNotInteractable = false; // �ڽ��� ��ȣ�ۿ� �����ϰ�
        IsMeteoritesStorage4Outline_M.OutlineWidth = 8;

        IsClickMeteorBoxButton4 = true;

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

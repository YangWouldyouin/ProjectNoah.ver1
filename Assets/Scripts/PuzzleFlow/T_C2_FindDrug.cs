using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_FindDrug : MonoBehaviour
{
    private GameObject nowObject_T_C2_FindDrug;

    public GameObject canSmellSpace;
    public float smellRange; //�������� Ȯ��

    public GameObject drugBag;
    public GameObject drug;
    public GameObject specificDrug;

    private Outline drugBagOutline;
    private Outline drugCheckerOutline;

    public GameObject drugChecker;
    public GameObject drugCheckerLED;
    public GameObject drugCheckerInsert;
    public GameObject drugCheckerWhole;

    Renderer LEDColor;

    public bool IsCheckDrug = false;
    public bool IsDetox = false;

    //public Transform Target;

    // Start is called before the first frame update
    void Start()
    {   
        //�ƿ�����
        drugBagOutline = drugBag.GetComponent<Outline>();
        drugCheckerOutline = drugChecker.GetComponent<Outline>();

        smellRange = 2;
    }

    // Update is called once per frame
    void Update()
    {
        nowObject_T_C2_FindDrug = PlayerScripts.playerscripts.currentObject;

        if (nowObject_T_C2_FindDrug != null)
        {
            if (IsCheckDrug)
            {
                Invoke("detoxDrug", 0f);

                if (IsDetox)
                {
                    Invoke("noSpecificDrug", 0.5f);
                }
            }

            else
            {
                researchDrug();
            }
        }
    }


    //���� Ȯ���� ���� ���� ���� ���� ���� ��� �ൿ Ȱ��ȭ

    public void OnTriggerEnter(Collider other)
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();
        smellRange = Random.Range(0, 3);

    }
    public void OnTriggerStay(Collider other)
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        if (other.gameObject.name == "Player")
        {
            if (smellRange <= 1)
            {
                //���� ���� ���� ���� �׳� ����â���� ������ ����?
                canSmellSpaceData.IsNotInteractable = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        if (other.gameObject.name == "Player")
        {
            canSmellSpaceData.IsNotInteractable = true;
        }
    }

    
    public void researchDrug()
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        ObjData drugBagData = drugBag.GetComponent<ObjData>();
        Interactable drugBagCan = drugBag.GetComponent<Interactable>();
        drugBagOutline = drugBag.GetComponent<Outline>();

        ObjData drugData = drug.GetComponent<ObjData>();

        ObjData drugCheckerWholeData = drugCheckerWhole.GetComponent<ObjData>();
        
        ObjData drugCheckerData = drugChecker.GetComponent<ObjData>();
        Interactable drugCheckerCan = drugChecker.GetComponent<Interactable>();
        drugCheckerOutline = drugChecker.GetComponent<Outline>();

        LEDColor = drugCheckerLED.GetComponent<Renderer>();


        if (canSmellSpaceData.IsSniff) //���� ��ȣ�ۿ� Ȱ��ȭ
        {
            drugBagCan.enabled = true;
            drugBagOutline.OutlineWidth = 8;
        }

        if (drugBagData.IsBite) //���� �߰� �� ����
        {
            Invoke("noBag", 1.5f);
            Invoke("cantSmell", 0f);
        }

        if (drugCheckerWholeData.IsObserve) //�����ϱ� �ϸ� �๰ �ֱ� Ȱ��ȭ
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;
            drugCheckerCan.enabled = true;
            drugCheckerOutline.OutlineWidth = 8;
        }

        if (drugCheckerWholeData.IsObserve == false) //�����ϱ� �����ϸ� �๰ �ֱ� ��Ȱ��ȭ
        {
            drugCheckerCan.enabled = false;
            drugCheckerOutline.OutlineWidth = 0;
        }

        if (drugData.IsBite && drugCheckerData.IsPushOrPress) //���� üũ
        {
            LEDColor.material.color = Color.red; //�˻� ��� ���� ��ȯ
            IsCheckDrug = true;
            //Debug.Log("�� �����̴�~!"); �ƴ� �� �αװ� �� ����?
        }
    }

    public void detoxDrug()
    {
        ObjData drugCheckerData = drugChecker.GetComponent<ObjData>();
        ObjData specificDrugData = specificDrug.GetComponent<ObjData>();

        ObjData drugCheckerWholeData = drugCheckerWhole.GetComponent<ObjData>();

        Interactable drugCheckerCan = drugChecker.GetComponent<Interactable>();
        drugCheckerOutline = drugChecker.GetComponent<Outline>();

        LEDColor = drugCheckerLED.GetComponent<Renderer>();

        Invoke("noDrug", 0.5f);

        if (drugCheckerWholeData.IsObserve) //�����ϱ� �ϸ� �๰ �ֱ� Ȱ��ȭ
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;
            drugCheckerCan.enabled = true;
            drugCheckerOutline.OutlineWidth = 8;
        }

        if (drugCheckerWholeData.IsObserve == false) //�����ϱ� �����ϸ� �๰ �ֱ� ��Ȱ��ȭ
        {
            drugCheckerCan.enabled = false;
            drugCheckerOutline.OutlineWidth = 0;
        }


        if (specificDrugData.IsBite && drugCheckerData.IsPushOrPress) //���� �ص�
        {
            LEDColor.material.color = Color.blue; //�˻� ��� ���� ��ȯ
            IsDetox = true;
            //Debug.Log("���� �ص� �Ϸ�~!");
        }

    }
    
    void cantSmell() //�����ñ� ���� ��Ȱ��ȭ
    {
        MeshCollider meshcollider = GetComponent<MeshCollider>();
        meshcollider.enabled = false;
    }
    void noBag() //������ ������� ������ ���̵��� �Ѵ�
    {
        drugBag.SetActive(false);
        drug.SetActive(true);
    }

    void noDrug() //���� ������� �ϱ�
    {
        drug.SetActive(false);
    }

    void noSpecificDrug() //Ư�� �๰ ������� �ϱ�
    {
        specificDrug.SetActive(false);
    }
}

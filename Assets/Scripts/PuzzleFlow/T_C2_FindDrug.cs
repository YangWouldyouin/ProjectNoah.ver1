using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_FindDrug : MonoBehaviour
{
    private GameObject nowObject_T_C2_FindDrug;

    public GameObject canSmellSpace;
    public float smellRange; //�������� Ȯ��

    public GameObject player;
    private Transform drugPos;
    public float speed; //�ٶ󺸴� �ӵ�

    public GameObject drugBag;
    public GameObject drug;
    public GameObject specificDrug;

    private Outline drugBagOutline;
    private Outline drugCheckerInsert01Outline;
    private Outline drugCheckerInsert02Outline;
    private Outline drugCheckerWholeOutline;
    private Outline specificDrugOutline;

    public GameObject drugCheckerLED;
    public GameObject drugCheckerDetoxLED;
    public GameObject drugCheckerInsert01;
    public GameObject drugCheckerInsert02;
    public GameObject drugCheckerWhole;

    public GameObject chair;

    Renderer LEDColor;
    Renderer detoxLEDColor;

    public bool IsCheckDrug = false;
    public bool IsDetox = false;

    public bool canFollowDrug = false;

    //public Transform Target;

    // Start is called before the first frame update
    void Start()
    {   
        //�ƿ�����
        drugBagOutline = drugBag.GetComponent<Outline>();
        drugCheckerInsert01Outline = drugCheckerInsert01.GetComponent<Outline>();
        drugCheckerInsert02Outline = drugCheckerInsert02.GetComponent<Outline>();
        drugCheckerWholeOutline = drugCheckerWhole.GetComponent<Outline>();
        specificDrugOutline = specificDrug.GetComponent<Outline>();

        drugPos = drug.GetComponent<Transform>();

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
        
        if (other.gameObject.name == "Player")
        {
            smellRange = Random.Range(0, 3);

            if (smellRange <= 1)
            {
                canSmellSpaceData.IsNotInteractable = false;
            }
        }
        

    }
    /*public void OnTriggerStay(Collider other)
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
    }*/

    public void OnTriggerExit(Collider other)
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        if (other.gameObject.name == "Player")
        {
            canSmellSpaceData.IsNotInteractable = true;
            CancelInvoke("followDrug");
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
        Interactable drugCheckerWholeCan = drugCheckerWhole.GetComponent<Interactable>();
        drugCheckerWholeOutline = drugCheckerWhole.GetComponent<Outline>();
        
        ObjData drugCheckerInsert01Data = drugCheckerInsert01.GetComponent<ObjData>();
        Interactable drugCheckerInsert01Can = drugCheckerInsert01.GetComponent<Interactable>();
        drugCheckerInsert01Outline = drugCheckerInsert01.GetComponent<Outline>();

        Interactable drugCheckerInsert02Can = drugCheckerInsert02.GetComponent<Interactable>();
        drugCheckerInsert02Outline = drugCheckerInsert02.GetComponent<Outline>();

        LEDColor = drugCheckerLED.GetComponent<Renderer>();


        if (canSmellSpaceData.IsSniff) //���� ��ȣ�ۿ� Ȱ��ȭ
        {
            Invoke("followDrug", 2f);
            //Invoke("dontFollowDrug", 5f);

            drugBagCan.enabled = true;
            drugBagOutline.OutlineWidth = 8;

            /*if (canSmellSpaceData.IsSniff == false)
            {
                Invoke("dontFollowDrug", 3f);
            }*/

        }

        if (drugBagData.IsBite)
        {
            drugData.GetComponent<Rigidbody>().isKinematic = true;
            drugData.transform.parent = drugBag.transform;

            CancelInvoke("followDrug");
        }

        if (drugBagData.IsDestroy) //���� �߰� �� ����
        {
            drugData.GetComponent<Rigidbody>().isKinematic = true;
            drugData.transform.parent = null;

            Invoke("noBag", 1.5f);
            Invoke("cantSmell", 0f);

            CancelInvoke("followDrug");

            //drugData.IsBite = false;
        }

        if (drugCheckerWholeData.IsObserve) //�˻�� ��Ȱ��ȭ(�����ϱ� �� �� �ϴ°� ����)
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;

            drugCheckerWholeCan.enabled = false;
            drugCheckerWholeOutline.OutlineWidth = 0;
        }

        if (drugCheckerWholeData.IsObserve == false) //�����ϱ� �����ϸ� �๰ �ֱ� ��Ȱ��ȭ
        {
            drugCheckerWholeCan.enabled = true;
            drugCheckerWholeOutline.OutlineWidth = 8;

            drugCheckerInsert01Can.enabled = false;
            drugCheckerInsert01Outline.OutlineWidth = 0;

            drugCheckerInsert02Can.enabled = false;
            drugCheckerInsert02Outline.OutlineWidth = 0;
        }

        if (drugData.IsBite && drugCheckerWholeData.IsObserve)
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;

            drugCheckerInsert01Can.enabled = true;
            drugCheckerInsert01Outline.OutlineWidth = 8;
        }

        if (drugData.IsBite && drugCheckerInsert01Data.IsPushOrPress) //���� üũ
        {
            LEDColor.material.color = Color.red; //�˻� ��� ���� ��ȯ
            IsCheckDrug = true;
            //Debug.Log("�� �����̴�~!"); �ƴ� �� �αװ� �� ����?
        }
    }

    public void detoxDrug()
    {
        
        ObjData drugCheckerInsert02Data = drugCheckerInsert02.GetComponent<ObjData>();
        
        ObjData specificDrugData = specificDrug.GetComponent<ObjData>();
        Interactable specificDrugCan = specificDrug.GetComponent<Interactable>();
        specificDrugOutline = specificDrug.GetComponent<Outline>();

        ObjData drugCheckerWholeData = drugCheckerWhole.GetComponent<ObjData>();
        Interactable drugCheckerWholeCan = drugCheckerWhole.GetComponent<Interactable>();

        Interactable drugCheckerInsert02Can = drugCheckerInsert02.GetComponent<Interactable>();
        drugCheckerInsert02Outline = drugCheckerInsert02.GetComponent<Outline>();

        Interactable drugCheckerInsert01Can = drugCheckerInsert01.GetComponent<Interactable>();
        drugCheckerInsert01Outline = drugCheckerInsert01.GetComponent<Outline>();

        ObjData chairData = chair.GetComponent<ObjData>();

        detoxLEDColor = drugCheckerDetoxLED.GetComponent<Renderer>();

        Invoke("noDrug", 0.5f);

        if (drugCheckerWholeData.IsObserve) //�����ϱ� �ϸ� �๰ �ֱ� Ȱ��ȭ
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;

            drugCheckerWholeCan.enabled = false;
            drugCheckerWholeOutline.OutlineWidth = 0;
        }

        if (chairData.IsUpDown)
        {
            specificDrugCan.enabled = true;
            specificDrugOutline.OutlineWidth = 8;
        }

        if (drugCheckerWholeData.IsObserve == false) //�����ϱ� �����ϸ� �๰ �ֱ� ��Ȱ��ȭ
        {
            drugCheckerWholeCan.enabled = true;
            drugCheckerWholeOutline.OutlineWidth = 8;

            drugCheckerInsert01Can.enabled = false;
            drugCheckerInsert01Outline.OutlineWidth = 0;

            drugCheckerInsert02Can.enabled = false;
            drugCheckerInsert02Outline.OutlineWidth = 0;
        }

        if (drugCheckerWholeData.IsObserve && specificDrugData.IsBite)
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;

            drugCheckerInsert02Can.enabled = true;
            drugCheckerInsert02Outline.OutlineWidth = 8;
        }


        if (specificDrugData.IsBite && drugCheckerInsert02Data.IsPushOrPress) //���� �ص�
        {
            detoxLEDColor.material.color = Color.blue; //�˻� ��� ���� ��ȯ
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
        //ObjData drugData = drug.GetComponent<ObjData>();
        ObjData drugBagData = drugBag.GetComponent<ObjData>();

        drugBagData.GetComponent<Rigidbody>().isKinematic = true;
        drugBagData.transform.parent = null;

        drugBagData.IsBite = false;
        //drugData.IsBite = false;

        drugBag.SetActive(false);
        drug.SetActive(true);
    }

    void noDrug() //���� ������� �ϱ�
    {
        ObjData drugData = drug.GetComponent<ObjData>();
        Interactable drugCheckerInsert01Can = drugCheckerInsert01.GetComponent<Interactable>();

        drugData.IsBite = false;

        drugData.GetComponent<Rigidbody>().isKinematic = false;
        drugData.transform.parent = null;

        drugData.transform.position = new Vector3(-249.0776f, 538.895f, 669.806f);
        drugData.transform.rotation = Quaternion.Euler(0, 0, 90);

        drugData.GetComponent<Interactable>().enabled = false;

        drugCheckerInsert01Can.enabled = false;
        drugCheckerInsert01Outline.OutlineWidth = 0;
    }

    void noSpecificDrug() //Ư�� �๰ ������� �ϱ�
    {
        ObjData specificDrugData = drug.GetComponent<ObjData>();
        Interactable drugCheckerInsert02Can = drugCheckerInsert01.GetComponent<Interactable>();

        specificDrugData.IsBite = false;

        specificDrugData.GetComponent<Rigidbody>().isKinematic = false;
        specificDrugData.transform.parent = null;

        specificDrugData.transform.position = new Vector3(-249.0776f, 538.575f, 669.806f);
        specificDrugData.transform.rotation = Quaternion.Euler(0, 0, 90);

        specificDrugData.GetComponent<Interactable>().enabled = false;

        drugCheckerInsert02Can.enabled = false;
        drugCheckerInsert02Outline.OutlineWidth = 0;
    }

    void followDrug() //���� �ٶ󺸰� �ϱ�
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        canSmellSpaceData.IsNotInteractable = true;

        Vector3 dir = drugPos.transform.position - player.transform.position;
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }

    /*void dontFollowDrug() //���� �ٶ󺸰� �ϱ� ����
    {
        CancelInvoke("followDrug");
    }*/
}

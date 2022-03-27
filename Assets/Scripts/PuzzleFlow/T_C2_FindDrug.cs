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
    private Outline drugCheckerOutline;
    private Outline drugCheckerWholeOutline;

    public GameObject drugChecker;
    public GameObject drugCheckerLED;
    public GameObject drugCheckerInsert;
    public GameObject drugCheckerWhole;

    Renderer LEDColor;

    public bool IsCheckDrug = false;
    public bool IsDetox = false;

    public bool canFollowDrug = false;

    //public Transform Target;

    // Start is called before the first frame update
    void Start()
    {   
        //�ƿ�����
        drugBagOutline = drugBag.GetComponent<Outline>();
        drugCheckerOutline = drugChecker.GetComponent<Outline>();
        drugCheckerWholeOutline = drugCheckerWhole.GetComponent<Outline>();

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
        Interactable drugChecherWholeCan = drugCheckerWhole.GetComponent<Interactable>();
        drugCheckerWholeOutline = drugCheckerWhole.GetComponent<Outline>();
        
        ObjData drugCheckerData = drugChecker.GetComponent<ObjData>();
        Interactable drugCheckerCan = drugChecker.GetComponent<Interactable>();
        drugCheckerOutline = drugChecker.GetComponent<Outline>();

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

        if (drugBagData.IsDestroy) //���� �߰� �� ����
        {
            Invoke("noBag", 1.5f);
            Invoke("cantSmell", 0f);

            CancelInvoke("followDrug");
        }

        if (drugCheckerWholeData.IsObserve) //�����ϱ� �ϸ� �๰ �ֱ� Ȱ��ȭ & �˻�� ��Ȱ��ȭ(�����ϱ� �� �� �ϴ°� ����)
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;
            drugCheckerCan.enabled = true;
            drugCheckerOutline.OutlineWidth = 8;

            drugChecherWholeCan.enabled = false;
            drugCheckerWholeOutline.OutlineWidth = 0;
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

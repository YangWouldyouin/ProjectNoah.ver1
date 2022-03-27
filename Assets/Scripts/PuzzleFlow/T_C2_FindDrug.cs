using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_C2_FindDrug : MonoBehaviour
{
    private GameObject nowObject_T_C2_FindDrug;

    public GameObject canSmellSpace;
    public float smellRange; //냄새맡을 확률

    public GameObject player;
    private Transform drugPos;
    public float speed; //바라보는 속도

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
        //아웃라인
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


    //일정 확률로 냄새 감지 구역 내에 있을 경우 행동 활성화

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
                //영역 냄새 맡지 말고 그냥 상태창으로 띄울수는 없나?
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


        if (canSmellSpaceData.IsSniff) //마약 상호작용 활성화
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

        if (drugBagData.IsDestroy) //마약 발견 및 물기
        {
            Invoke("noBag", 1.5f);
            Invoke("cantSmell", 0f);

            CancelInvoke("followDrug");
        }

        if (drugCheckerWholeData.IsObserve) //관찰하기 하면 약물 넣기 활성화 & 검사기 비활성화(관찰하기 두 번 하는거 방지)
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;
            drugCheckerCan.enabled = true;
            drugCheckerOutline.OutlineWidth = 8;

            drugChecherWholeCan.enabled = false;
            drugCheckerWholeOutline.OutlineWidth = 0;
        }

        if (drugCheckerWholeData.IsObserve == false) //관찰하기 해제하면 약물 넣기 비활성화
        {
            drugCheckerCan.enabled = false;
            drugCheckerOutline.OutlineWidth = 0;
        }

        if (drugData.IsBite && drugCheckerData.IsPushOrPress) //마약 체크
        {
            LEDColor.material.color = Color.red; //검사 결과 색상 변환
            IsCheckDrug = true;
            //Debug.Log("헐 마약이다~!"); 아니 왜 로그가 안 찍힘?
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

        if (drugCheckerWholeData.IsObserve) //관찰하기 하면 약물 넣기 활성화
        {
            CameraController.cameraController.currentView = drugCheckerWholeData.ObserveView;
            drugCheckerCan.enabled = true;
            drugCheckerOutline.OutlineWidth = 8;
        }

        if (drugCheckerWholeData.IsObserve == false) //관찰하기 해제하면 약물 넣기 비활성화
        {
            drugCheckerCan.enabled = false;
            drugCheckerOutline.OutlineWidth = 0;
        }


        if (specificDrugData.IsBite && drugCheckerData.IsPushOrPress) //마약 해독
        {
            LEDColor.material.color = Color.blue; //검사 결과 색상 변환
            IsDetox = true;
            //Debug.Log("마약 해독 완료~!");
        }

    }
    
    void cantSmell() //냄새맡기 구역 비활성화
    {
        MeshCollider meshcollider = GetComponent<MeshCollider>();
        meshcollider.enabled = false;
    }
    void noBag() //봉투는 사라지고 마약이 보이도록 한다
    {
        drugBag.SetActive(false);
        drug.SetActive(true);
    }

    void noDrug() //마약 사라지게 하기
    {
        drug.SetActive(false);
    }

    void noSpecificDrug() //특정 약물 사라지게 하기
    {
        specificDrug.SetActive(false);
    }

    void followDrug() //마약 바라보게 하기
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        canSmellSpaceData.IsNotInteractable = true;

        Vector3 dir = drugPos.transform.position - player.transform.position;
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }

    /*void dontFollowDrug() //마약 바라보게 하기 해제
    {
        CancelInvoke("followDrug");
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataWhenSceneChange : MonoBehaviour
{


    [SerializeField] PlayerEquipment playerEquipment;

    [SerializeField] List<PortableObjectData> DataList = new List<PortableObjectData>();

    private PortableObjectData currentPortableObjectData;

    [SerializeField] List<string> portableObjectNameList = new List<string>();
    private GameObject biteObject, pushObject;

    ObjData portableObjectData;


    [SerializeField] List<GameObject> portableObjectList = new List<GameObject>();
    /* 문 클릭시 이동할 씬 */
    public string transferMapName;


    TMPro.TextMeshProUGUI objectText;
    GameObject myHead;
    Animator noahAnimator;


    void Awake()
    {
        objectText = BaseCanvas._baseCanvas.objectText;
        myHead = BaseCanvas._baseCanvas.myMouth;
        noahAnimator = BaseCanvas._baseCanvas.noahPlayer.GetComponent<Animator>();

        /* 현재 씬을 가져와서 그 씬의 포터블오브젝트리스트를 가져옴 */
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        switch (sceneNum)
        {
            case 0:
                currentPortableObjectData = DataList[0];
                break;
            case 1:
                currentPortableObjectData = DataList[1];
                break;
            case 2:
                currentPortableObjectData = DataList[2];
                break;
            case 3:
                currentPortableObjectData = DataList[3];
                break;
        }

        /* 씬의 포터블 오브젝트 초기화 */
        for(int i =0;  i< currentPortableObjectData.IsObjectActiveList.Count; i++)
        {
            if(currentPortableObjectData.IsObjectActiveList[i]==true)
            {
                portableObjectList[i].SetActive(true);
            }
            else
            {
                portableObjectList[i].SetActive(false);
            }
        }




        /* 플레이어 초기화 */
        if (playerEquipment.pushObjectName != "") // 밀고 있는 오브젝트가 있다면 
        {
            // 그 오브젝트를 하이라키에서 찾아서 활성화
            pushObject = GameObject.Find("Portable Objects").transform.Find(playerEquipment.pushObjectName).gameObject;
            pushObject.SetActive(true);

            // 오브젝트 이름으로 배열의 인덱스를 가져옴
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.pushObjectName));
            // 씬의 포터블오브젝트리스트의 해당 오브젝트의 값을 참으로 수정
            currentPortableObjectData.IsObjectActiveList[idx] = true;

            // 취소에도 넣어줌!!!!!
            playerEquipment.cancelPushPos = pushObject.transform.position;
            playerEquipment.cancelPushRot = pushObject.transform.eulerAngles;
            playerEquipment.cancelPushScale = pushObject.transform.localScale;

            // 노아 머리에 들어가게 + 미는 애니메이션 
            noahAnimator.SetBool("IsPushing", true);
            noahAnimator.SetBool("IsPushing2", true);

            portableObjectData = pushObject.GetComponent<ObjData>();
            objectText.text = "Noah N.113 - " + portableObjectData.ObjectName;

            pushObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            pushObject.GetComponent<Rigidbody>().useGravity = false;

            pushObject.transform.parent = myHead.transform; //makes the object become a child of the parent so that it moves with the mouth

            pushObject.transform.localPosition = portableObjectData.PushPos; // sets the position of the object to your mouth position
            pushObject.transform.localEulerAngles = portableObjectData.PushRot; // sets the position of the object to yo
        }
        else if (playerEquipment.biteObjectName != "") // 물고 있는 오브젝트가 있다면 
        {
            // 그 오브젝트를 하이라키에서 찾아서 활성화
            biteObject = GameObject.Find("Portable Objects").transform.Find(playerEquipment.biteObjectName).gameObject;
            biteObject.SetActive(true);

            // 오브젝트 이름으로 배열의 인덱스를 가져옴
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.biteObjectName));
            // 씬의 포터블오브젝트리스트의 해당 오브젝트의 값을 참으로 수정
            currentPortableObjectData.IsObjectActiveList[idx] = true;

            // 취소에도 넣어줌!!!!!
            playerEquipment.cancelBitePos = biteObject.transform.position;
            playerEquipment.cancelBiteRot = biteObject.transform.eulerAngles;
            playerEquipment.cancelBiteScale = biteObject.transform.localScale;

            // 노아 입에 들어가게
            portableObjectData = biteObject.GetComponent<ObjData>();
            objectText.text = "Noah N.113 - " + portableObjectData.ObjectName;

            biteObject.GetComponent<Rigidbody>().isKinematic = true;
            biteObject.GetComponent<Rigidbody>().useGravity = false;

            biteObject.transform.SetParent(myHead.transform, true);

            biteObject.transform.localPosition = portableObjectData.BitePos;
            biteObject.transform.localEulerAngles = portableObjectData.BiteRot;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.5f);

        if (playerEquipment.pushObjectName != "") // 밀고 있는 오브젝트가 있으면
        {
            // 오브젝트 이름으로 배열의 인덱스를 가져옴
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.pushObjectName));
            // 씬의 포터블오브젝트리스트의 해당 오브젝트의 값을 거짓으로 수정
            currentPortableObjectData.IsObjectActiveList[idx] =  false;
        }
        else if(playerEquipment.biteObjectName != "") // 물고 있는 오브젝트가 있으면
        {
            // 오브젝트 이름으로 배열의 인덱스를 가져옴
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.biteObjectName));
            // 씬의 포터블오브젝트리스트의 해당 오브젝트의 값을 거짓으로 수정
            currentPortableObjectData.IsObjectActiveList[idx] = false;
        }

        SceneManager.LoadScene(transferMapName);
    }
}
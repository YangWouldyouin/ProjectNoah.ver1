using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveDataWhenSceneChange : MonoBehaviour
{
    // 플레이어가 현재 이동시키고 있는 중인 오브젝트 이름과 다시 내려놓을 때의 위치, 각도를 가지고 있는 스크립터블 오브젝트 
    [SerializeField] PlayerEquipment playerEquipment;

    [SerializeField] List<PortableObjectData> DataList = new List<PortableObjectData>();

    private PortableObjectData currentPortableObjectData;

    [SerializeField] List<string> portableObjectNameList = new List<string>(); // 이름으로 비교해서 현재 물건의 게임오브젝트리스트에서의 인덱스를 알아내기 위한 리스트
    [SerializeField] List<GameObject> portableObjectList = new List<GameObject>();

    private GameObject biteObject, pushObject;

    /* 이동하는 씬 이름 */
    public string transferMapName;

    /* 물건을 물거나 밀고 가는 애니메이션 관련 */
    ObjData portableObjectData;
    [SerializeField] TMPro.TextMeshProUGUI objectText;
    [SerializeField] GameObject myHead;
    [SerializeField] Animator noahAnimator;

    GameData intialGameData;

    void Awake()
    {
        /* 현재 씬에 해당하는 물건 리스트를 가져옴 */
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        switch (sceneNum)
        {
            case 2:
                currentPortableObjectData = DataList[0];
                break;
            case 3:
                currentPortableObjectData = DataList[1];
                break;
            case 4:
                currentPortableObjectData = DataList[2];
                break;
            case 5:
                currentPortableObjectData = DataList[3];
                break;
        }

        /* 현재 씬 내의 물고 다닐 수 있는 물건들 활성화 & 비활성화 */
        for (int i =0;  i< currentPortableObjectData.IsObjectActiveList.Count; i++)
        {
            // 이 오브젝트가 현재 씬에 있는 물건이면
            if(currentPortableObjectData.IsObjectActiveList[i]==true)
            {
                portableObjectList[i].SetActive(true);
            }
            else
            { // 이 오브젝트가 현재 씬에 없는 물건이면
                portableObjectList[i].SetActive(false);
            }
        }




        /* 플레이어 초기화 */
        if (playerEquipment.pushObjectName != "")  // 플레이어가 이전 씬으로부터 가져온 물건이 있으면 
        {
            // 이 물건을 물건의 이름으로 현재 씬에서 찾아서 활성화 시킨다. 
            pushObject = GameObject.Find("Portable Objects").transform.Find(playerEquipment.pushObjectName).gameObject;
            pushObject.SetActive(true);

            // 현재씬의 물건 리스트에서 이 물건에 해당하는 bool 변수 원소를 찾아서 true 로 바꾼다. 
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.pushObjectName));
            currentPortableObjectData.IsObjectActiveList[idx] = true;

            // 플레이어가 현재 물건을 내려놓을 때 참고하기 위해 이 물건의 위치, 각도, 크기를 저장한다. 
            playerEquipment.cancelPushPos = pushObject.transform.position;
            playerEquipment.cancelPushRot = pushObject.transform.eulerAngles;
            playerEquipment.cancelPushScale = pushObject.transform.localScale;

            // 물건에 맞는 플레이어 애니메이션
            noahAnimator.SetBool("IsPushing", true);
            noahAnimator.SetBool("IsPushing2", true);

            // 갖고 이동 중인 오브젝트 이름을 화면에 표시
            portableObjectData = pushObject.GetComponent<ObjData>();
            objectText.text = "Noah N.113 - " + portableObjectData.ObjectName;

            // 물건에 맞는 플레이어 애니메이션
            pushObject.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
            pushObject.GetComponent<Rigidbody>().useGravity = false;

            pushObject.transform.parent = myHead.transform; //makes the object become a child of the parent so that it moves with the mouth

            pushObject.transform.localPosition = portableObjectData.PushPos; // sets the position of the object to your mouth position
            pushObject.transform.localEulerAngles = portableObjectData.PushRot; // sets the position of the object to yo
        }
        else if (playerEquipment.biteObjectName != "") // ���� �ִ� ������Ʈ�� �ִٸ� 
        {
            // �� ������Ʈ�� ���̶�Ű���� ã�Ƽ� Ȱ��ȭ
            biteObject = GameObject.Find("Portable Objects").transform.Find(playerEquipment.biteObjectName).gameObject;
            biteObject.SetActive(true);

            // ������Ʈ �̸����� �迭�� �ε����� ������
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.biteObjectName));
            // ���� ���ͺ�������Ʈ����Ʈ�� �ش� ������Ʈ�� ���� ������ ����
            currentPortableObjectData.IsObjectActiveList[idx] = true;

            // ��ҿ��� �־���!!!!!
            playerEquipment.cancelBitePos = biteObject.transform.position;
            playerEquipment.cancelBiteRot = biteObject.transform.eulerAngles;
            playerEquipment.cancelBiteScale = biteObject.transform.localScale;

            // ��� �Կ� ����
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
            //업무공간 첫미션이 전부 나오기 전에 조종실로 나가면 
            intialGameData = SaveSystem.Load("save_001");
            if(!intialGameData.IsFirstEnterWorking)
            {
                GameManager.gameManager._gameData.ActiveMissionList[4] = true; // 생활공간 진입
                GameManager.gameManager._gameData.ActiveMissionList[5] = true; // 엔진실 진입
                GameManager.gameManager._gameData.ActiveMissionList[13] = true;  //냄새로 업무공간 고치기 시작

                GameManager.gameManager._gameData.IsFirstEnterWorking = true;
                SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            }

            StartCoroutine(ChangeScene());
        }
    }

    /* 플레이어가 다른씬으로 이동하려고 할 때 */
    IEnumerator ChangeScene()
    {
        yield return null;

        if (playerEquipment.pushObjectName != "") // 만일 플레이어가 물건을 가지고 다른씬으로 이동하려고 하면
        {
            // 현재 씬의 물건 이름 리스트에서 이름을 비교해서 현재 물건의 인덱스를 찾음
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.pushObjectName));
            // 현재 씬의 물건 오브젝트 리스트에서 위에서 찾은 인덱스에 해당하는 오브젝트가 비활성화 상태라고 저장함
            currentPortableObjectData.IsObjectActiveList[idx] =  false;
        }
        else if(playerEquipment.biteObjectName != "") 
        {
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.biteObjectName));
            currentPortableObjectData.IsObjectActiveList[idx] = false;
        }

        SceneManager.LoadScene(transferMapName);
    }
}
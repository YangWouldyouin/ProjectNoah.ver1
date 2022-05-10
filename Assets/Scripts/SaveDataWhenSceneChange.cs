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

    ObjectData portableData;
    [SerializeField] List<GameObject> portableObjectList = new List<GameObject>();
    /* �� Ŭ���� �̵��� �� */
    public string transferMapName;


    [SerializeField] TMPro.TextMeshProUGUI objectText;
    [SerializeField] GameObject myHead;
    [SerializeField] Animator noahAnimator;


    void Awake()
    {
        /* ���� ���� �����ͼ� �� ���� ���ͺ�������Ʈ����Ʈ�� ������ */
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

        /* ���� ���ͺ� ������Ʈ �ʱ�ȭ */
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




        /* �÷��̾� �ʱ�ȭ */
        if (playerEquipment.pushObjectName != "") // �а� �ִ� ������Ʈ�� �ִٸ� 
        {
            // �� ������Ʈ�� ���̶�Ű���� ã�Ƽ� Ȱ��ȭ
            pushObject = GameObject.Find("Portable Objects").transform.Find(playerEquipment.pushObjectName).gameObject;
            pushObject.SetActive(true);

            // ������Ʈ �̸����� ����Ʈ�� �ε����� ������
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.pushObjectName));
            // ���� ���ͺ�������Ʈ����Ʈ�� �ش� ������Ʈ�� ���� ������ ����
            currentPortableObjectData.IsObjectActiveList[idx] = true;

            // ��ҿ��� �־���!!!!!
            playerEquipment.cancelPushPos = pushObject.transform.position;
            playerEquipment.cancelPushRot = pushObject.transform.eulerAngles;
            playerEquipment.cancelPushScale = pushObject.transform.localScale;

            // ��� �Ӹ��� ���� + �̴� �ִϸ��̼� 
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
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.5f);

        if (playerEquipment.pushObjectName != "") // �а� �ִ� ������Ʈ�� ������
        {
            pushObject = GameObject.Find(playerEquipment.pushObjectName).gameObject;
            // ������Ʈ �̸����� �迭�� �ε����� ������
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.pushObjectName));
            // ���� ���ͺ�������Ʈ����Ʈ�� �ش� ������Ʈ�� ���� �������� ����

            currentPortableObjectData.IsObjectActiveList[idx] =  false;
        }
        else if(playerEquipment.biteObjectName != "") // ���� �ִ� ������Ʈ�� ������
        {
            biteObject = GameObject.Find(playerEquipment.biteObjectName).gameObject;
            int idx = portableObjectNameList.FindIndex(a => a.Contains(playerEquipment.biteObjectName));
            // ���� ���ͺ�������Ʈ����Ʈ�� �ش� ������Ʈ�� ���� �������� ����
            currentPortableObjectData.IsObjectActiveList[idx] = false;
        }

        SceneManager.LoadScene(transferMapName);
    }
}
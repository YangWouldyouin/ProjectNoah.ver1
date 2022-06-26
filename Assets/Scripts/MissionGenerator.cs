using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionGenerator : MonoBehaviour
{
    public static MissionGenerator missionGenerator { get; private set; }

    Dictionary<int, string> missionDic = new Dictionary<int, string>();

    List<GameObject> missionPanelList = new List<GameObject>();
    List<string> missionNameList = new List<string>();

    public GameObject missionmom;

    public GameObject missionPanel;
    public GameObject newMissionPanel;

    TMPro.TextMeshProUGUI textget;
    Animator missionAnim;
    Image[] newMissionImage;
    public Sprite newMissionSprite;
    public Sprite currentMissionSprite;

    public bool IsOn = false;
    bool IsPrintingFinish = false;
    GameData currentData;

    private void Awake()
    {
        missionGenerator = this;
        //Ʃ�丮��
        missionDic.Add(0, "AI Ȱ��ȭ");
        missionDic.Add(1, "�������� ����");

        //����_���� �ر�
        missionDic.Add(2, "��Ȱ���� ī��Ű Ž��");
        missionDic.Add(3, "������ ī��Ű Ž��");
        missionDic.Add(4, "��Ȱ���� ����");
        missionDic.Add(5, "������ ����");

        //����_���丮����
        missionDic.Add(6, "�Ҹ��� �ٿ� ã��");
        missionDic.Add(7, "�º� ��� ����");
        missionDic.Add(8, "��� �ڷ� �ٿ�ε�");
        missionDic.Add(9, "AI �ٿ� ��Ű��");
        missionDic.Add(10, "Ĩ �뵵 �ľ�");
        missionDic.Add(11, "��� ���·� �����ϱ�");
        missionDic.Add(12, "������ ���ϱ�");

        //�ӹ�_������ ��ġ�� ����
        missionDic.Add(13, "���� üũ ��� ����");
        missionDic.Add(14, "��� ��ü ������ ����");
        missionDic.Add(15, "������ ���ⱸ ����");
        missionDic.Add(16, "���� ���� ���Ա� ����");

        //�ӹ�_����Ʈ�� ����
        missionDic.Add(17, "����Ʈ�� ����");
        missionDic.Add(18, "����� ����");
        missionDic.Add(19, "�Ĺ� ��� ����");
        missionDic.Add(20, "��� ���� ��� ����");
        missionDic.Add(21, "������ ����");

        //��Ÿ �ӹ�
        missionDic.Add(22, "� �м� ������ ����");
        missionDic.Add(23, "������ ���� �Կ�");

        //��ݵ� ����_���� Ž�� & �̻��� ���� �߰�
        missionDic.Add(24, "������ �ٿ� ã��");
        missionDic.Add(25, "�๰ �м�");
        missionDic.Add(26, "�๰ ó��");
        missionDic.Add(27, "���� �뵵 �ľ�");

        //��ݵ� ����_���� ������ ����
        missionDic.Add(28, "���� ��ǻ�Ϳ� �º� ����");
        missionDic.Add(29, "���� ������ ����");

        missionDic.Add(30, "������ �� ��ġ��");

        //�༱�� ��ǥ ����
        missionDic.Add(31, "�༱�� ����");
        missionDic.Add(32, "�˵� �ý��� ����");
        missionDic.Add(33, "���� �༱�� ����");
    }

    /* �� �̼� �߰��ϴ� �Լ� */
    public void AddNewMission(int newMissionNum)
    {
        currentData = SaveSystem.Load("save_001");
        StartCoroutine(PrintCurrentMissionList(newMissionNum));
    }

    IEnumerator PrintCurrentMissionList(int newMissionNum)  // ���� �̼� ��ϵ� ��� 
    {
        // ���� ��� ����
        missionNameList.Clear();  // ���⿡ ��ư ���� ������ �˴ϴ�
        missionPanelList.Clear();
        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
        missionmom.SetActive(true);

        // ���� Ȱ��ȭ�� �̼ǵ��� ������
        for (int k = 0; k < GameManager.gameManager._gameData.ActiveMissionList.Length; k++)
        {
            if (currentData.ActiveMissionList[k])
            {
                missionNameList.Add(missionDic[k]);
            }
        }

        // ���� Ȱ��ȭ�� �̼� ������ŭ �г� ����
        for (int i = 0; i < missionNameList.Count; i++)
        {
            GameObject currentMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(currentMission);
            currentMission.transform.SetParent(missionmom.transform, false);
        }

        // ���� �̼ǵ� ���
        for (int j = 0; j < missionPanelList.Count; j++)
        {
            missionPanelList[j].SetActive(true);
            Animator missionAnim = missionPanelList[j].GetComponentInChildren<Animator>();
            missionAnim.SetBool("IsOpening1", true);
            missionAnim.SetBool("IsOpening2", true);
            yield return new WaitForSeconds(1f);
            textget = missionPanelList[j].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            StartCoroutine(_typing(missionNameList[j]));
            yield return new WaitForSeconds(1f);
        }

        IsPrintingFinish = true;
        StartCoroutine(AddNew(newMissionNum));
    }

    IEnumerator AddNew(int newMissionNum) // �� �̼� �߰� 
    {
        // ���� �̼� ����� �� ��µɶ����� ��ٸ�
        while (!IsPrintingFinish)
        {
            yield return null;
        }

        if (!currentData.ActiveMissionList[newMissionNum]) // missionDic[newMissionNum] �� �̹� �߰��Ǳ����̸�
        {
            // ���� �̼� �г� ����Ʈ�� �� �������� �г� �ϳ� �߰�
            GameObject newMission1 = Instantiate(newMissionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(newMission);
            newMission1.transform.SetParent(missionmom.transform, false);
            newMission.transform.SetParent(missionmom.transform, false);
            newMissionImage = missionPanelList[missionNameList.Count].GetComponentsInChildren<Image>();
            newMissionImage[1].sprite = newMissionSprite;
            /* �� �̼� �߰� �ִϸ��̼� */
            missionPanelList[missionNameList.Count].SetActive(true);
            Animator addMission1Anim = newMission1.GetComponentInChildren<Animator>();
            Animator addMissionAnim = missionPanelList[missionNameList.Count].GetComponentInChildren<Animator>();
            addMissionAnim.SetBool("IsOpening1", true);
            addMissionAnim.SetBool("IsOpening2", true);



            //addMissionAnim.SetBool("IsOpening3", true);

            textget = missionPanelList[missionNameList.Count].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            // textget.color = new Color32(238, 192, 230, 255);

            /* �� �̼ǵ� ���� �̼� ����Ʈ�� �߰� */
            missionNameList.Add(missionDic[newMissionNum]);
            StartCoroutine(_typing(missionNameList[missionNameList.Count - 1]));
            yield return new WaitForSeconds(2f);
            addMissionAnim.SetBool("IsNewMissionStart", true);
            newMission1.SetActive(true);
            addMission1Anim.SetBool("IsOpening1", true);
            addMission1Anim.SetBool("IsOpening2", true);

            yield return new WaitForSeconds(10f);
            GameManager.gameManager._gameData.ActiveMissionList[newMissionNum] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            IsPrintingFinish = false;
        }
        else // missionDic[newMissionNum] �� �̹� �߰��Ǿ�����
        {
            while (!IsPrintingFinish)
            {
                yield return null;
            }
            yield return new WaitForSeconds(10f);
            IsPrintingFinish = false;
        }
    }

    // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* �Ϸ��� �̼� �����ϴ� �Լ� */
    public void DeleteNewMission(int newMissionNum)
    {
        //currentData = SaveSystem.Load("save_001");
        //StartCoroutine(PrintCurrentMissionList(newMissionNum));
    }

    IEnumerator DeleteMission(int newMissionNum) // �� �̼� �߰� 
    {
        // ���� �̼� ����� �� ��µɶ����� ��ٸ�
        while (!IsPrintingFinish)
        {
            yield return null;
        }

        if (!currentData.ActiveMissionList[newMissionNum]) // missionDic[newMissionNum] �� �̹� �߰��Ǳ����̸�
        {
            // ���� �̼� �г� ����Ʈ�� �� �������� �г� �ϳ� �߰�
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(newMission);
            newMission.transform.SetParent(missionmom.transform, false);

            /* �� �̼� �߰� �ִϸ��̼� */
            missionPanelList[missionNameList.Count].SetActive(true);
            Animator addMissionAnim = missionPanelList[missionNameList.Count].GetComponentInChildren<Animator>();
            addMissionAnim.SetBool("IsOpening1", true);
            addMissionAnim.SetBool("IsOpening2", true);
            yield return new WaitForSeconds(1f);
            textget = missionPanelList[missionNameList.Count].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            textget.color = new Color32(238, 192, 230, 255);

            /* �� �̼ǵ� ���� �̼� ����Ʈ�� �߰� */
            missionNameList.Add(missionDic[newMissionNum]);
            StartCoroutine(_typing(missionNameList[missionNameList.Count - 1]));

            yield return new WaitForSeconds(10f);
            GameManager.gameManager._gameData.ActiveMissionList[newMissionNum] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            IsPrintingFinish = false;
        }
        else // missionDic[newMissionNum] �� �̹� �߰��Ǿ�����
        {
            while (!IsPrintingFinish)
            {
                yield return null;
            }
            yield return new WaitForSeconds(10f);
            IsPrintingFinish = false;
        }
    }

    // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* �̼� ��� ��ư �������� �Լ� */
    public void ShowMissionList()
    {
        currentData = SaveSystem.Load("save_001");

        /* ���⿡ ��ư ���� ������ �˴ϴ� */
        missionNameList.Clear();
        missionPanelList.Clear();
        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
        missionmom.SetActive(true);

        if (!IsOn)
        {
            for (int k = 0; k < GameManager.gameManager._gameData.ActiveMissionList.Length; k++)
            {
                if (currentData.ActiveMissionList[k] )
                {
                    missionNameList.Add(missionDic[k]);
                }
            }
            StartCoroutine(PrintMissionList());

            IsOn = true;
        }
        else
        {
            foreach (Transform child in missionmom.transform)
            {
                Destroy(child.gameObject);
            }

            IsOn = false;
        }
    }

    IEnumerator PrintMissionList()
    {
        // ���� �̼� ������ŭ �г� ���� 
        for (int i = 0; i < missionNameList.Count; i++)
        {
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(newMission);
            newMission.transform.SetParent(missionmom.transform, false);
        }

        for(int j=0; j< missionPanelList.Count; j++)
        {
            missionPanelList[j].SetActive(true);
            Animator missionAnim = missionPanelList[j].GetComponentInChildren<Animator>();
            missionAnim.SetBool("IsOpening1", true);
            missionAnim.SetBool("IsOpening2", true);
            yield return new WaitForSeconds(1f);
            textget = missionPanelList[j].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            StartCoroutine(_typing(missionNameList[j]));
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(10f);
        missionmom.SetActive(false);
    }

    public void ActivateMissionList() // �� �̼� �߰��� �ű�� 
    {
        IsOn = false;
        ShowMissionList();
    }     

    IEnumerator _typing(string data)
    {
        for (int i = 0; i <= data.Length; i++)
        {
            textget.text = data.Substring(0, i);
            yield return new WaitForSeconds(0.02f);
        }
    }
}

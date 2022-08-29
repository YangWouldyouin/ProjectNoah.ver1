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
    List<TMPro.TextMeshProUGUI> missionText = new List<TMPro.TextMeshProUGUI>();
    List<TMPro.TextMeshProUGUI> DDayText = new List<TMPro.TextMeshProUGUI>();

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
    GameData currentData, addData, deleteData;
    public InGameTime inGameTime;

    // ������ �߰��ؼ� add �̵� delete �̵� �� �� �ϳ��� �ϰ� ������ �������� ���������� ��ٸ���!!!
    public Dictionary<int, string> regularDic = new Dictionary<int, string>();

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
        missionDic.Add(14, "��� ��ü ������ ����");     // �����ӹ�
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
        missionDic.Add(23, "������ ���� �Կ�"); // �����ӹ�

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
        missionDic.Add(31, "�༱�� ����"); // �����ӹ�
        missionDic.Add(32, "�˵� �ý��� ����");
        missionDic.Add(33, "���� �༱�� ����"); // �����ӹ�

        regularDic.Add(14, "4�� 10��");
        ///* ���� �̼� üũ */
        //GameData gameData = SaveSystem.Load("save_001");

        //// ��ü������ ���� �߰� 
        //if (gameData.ActiveRegularMissionList[0])
        //{
        //    regularDic.Add(0, "��� ��ü ������ ���� D-DAY : " + (int)(inGameTime.days) + 2 + " 10H");
        //}
    }

    /* �� �̼� �߰��ϴ� �Լ� */
    public void AddNewMission(int newMissionNum)
    {
        StartCoroutine(PrintCurrentMissionList(newMissionNum, AddNew(newMissionNum), addData));
    }

    IEnumerator AddNew(int newMissionNum) // �� �̼� �߰� 
    {
        while (!IsPrintingFinish) // ���� �̼� ����� �� ��µɶ����� ��ٸ�
        {
            yield return null;
        }

        addData = SaveSystem.Load("save_001");

        if (!addData.ActiveMissionList[newMissionNum]) // missionDic[newMissionNum] �� �̹� �߰��Ǳ����̸�
        {
            GameManager.gameManager._gameData.ActiveMissionList[newMissionNum] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            // ���� �̼� �г� ����Ʈ�� �� �������� �г� �ϳ� �߰�
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            GameObject newMissionBack = Instantiate(newMissionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(newMission);
            newMissionBack.transform.SetParent(missionmom.transform, false);
            newMission.transform.SetParent(missionmom.transform, false);

            missionText.Add(newMission.transform.GetChild(0).GetComponentInChildren<TMPro.TextMeshProUGUI>()); // �̼� �̸�

            DDayText.Add(newMission.transform.GetChild(1).GetComponentInChildren<TMPro.TextMeshProUGUI>()); // ���� �ð�
            newMissionImage = missionPanelList[missionNameList.Count].GetComponentsInChildren<Image>();
            newMissionImage[1].sprite = newMissionSprite;

            /* �� �̼� �߰� �ִϸ��̼� */
            missionPanelList[missionNameList.Count].SetActive(true);
            Animator addMission1Anim = newMissionBack.GetComponentInChildren<Animator>();
            Animator addMissionAnim = missionPanelList[missionNameList.Count].GetComponentInChildren<Animator>();
            addMissionAnim.SetBool("IsOpening1", true);
            addMissionAnim.SetBool("IsOpening2", true);

            textget = missionPanelList[missionNameList.Count].transform.GetChild(0).GetComponentInChildren<TMPro.TextMeshProUGUI>();

            /* �� �̼ǵ� ���� �̼� ����Ʈ�� �߰� */
            missionNameList.Add(missionDic[newMissionNum]);
            StartCoroutine(_typing(missionNameList[missionNameList.Count - 1], missionNameList.Count-1));

            /* ���ѽð��� �ִ� �̼��̸� */
            //if(regularDic.ContainsKey(newMissionNum))
            //{
            //    StartCoroutine(_typingDDay(regularDic[missionNameList.Count - 1], missionNameList.Count - 1));
            //}

            yield return new WaitForSeconds(0.2f);
            addMissionAnim.SetBool("IsNewMissionStart", true);
            newMissionBack.SetActive(true);
            addMission1Anim.SetBool("IsOpening1", true);
            addMission1Anim.SetBool("IsOpening2", true);

            yield return new WaitForSeconds(10f);
            missionmom.SetActive(false);
            IsPrintingFinish = false;
        }
        else // missionDic[newMissionNum] �� �̹� �߰��Ǿ�����
        {
            while (!IsPrintingFinish)
            {
                yield return null;
            }
            yield return new WaitForSeconds(10f);
            missionmom.SetActive(false);
            IsPrintingFinish = false;
        }
    }

    // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* �Ϸ��� �̼� �����ϴ� �Լ� */
    public void DeleteNewMission(int deleteMissionNum)
    {
        deleteData = SaveSystem.Load("save_001");
        StartCoroutine(PrintCurrentMissionList(deleteMissionNum, DeleteMission(deleteMissionNum), deleteData));
    }

    IEnumerator DeleteMission(int deleteMissionNum) // �Ϸ� �̼� ����
    {
        // ���� �̼� ����� �� ��µɶ����� ��ٸ�
        while (!IsPrintingFinish)
        {
            yield return null;
        }

        int idx = missionNameList.FindIndex(a => a.Contains(missionDic[deleteMissionNum]));
        newMissionImage = missionPanelList[idx].GetComponentsInChildren<Image>();
        Animator addMissionAnim = missionPanelList[idx].GetComponentInChildren<Animator>();

        GameManager.gameManager._gameData.ActiveMissionList[deleteMissionNum] = false;

        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // �Ϸ��� �̼� ���� 
        yield return new WaitForSeconds(1f);

        //newMissionImage[1].sprite = newMissionSprite;
        //Animator addMission1Anim = newMissionBack.GetComponentInChildren<Animator>();

        addMissionAnim.SetBool("IsOpening1", true);
        addMissionAnim.SetBool("IsOpening2", true);

        //StartCoroutine(_typing(missionNameList[missionNameList.Count - 1], missionNameList.Count - 1));
        yield return new WaitForSeconds(1f);
        addMissionAnim.SetBool("IsOpening3", true);
        addMissionAnim.SetBool("IsOpening1", false);
        addMissionAnim.SetBool("IsNewMissionStart", true);
        missionText[idx].text = "";
        yield return new WaitForSeconds(0.5f);
        missionPanelList[idx].SetActive(false);

        //newMissionBack.SetActive(true);
        //addMission1Anim.SetBool("IsOpening1", true);
        //addMission1Anim.SetBool("IsOpening2", true);

        //yield return new WaitForSeconds(1f);
        missionmom.SetActive(false);
        IsPrintingFinish = false;
    }

    // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

        // 1750 : day 3 10H

    /* ���� �̼� �߰� */
    public void AddRegularMission(int index, int day)
    {
        //string missionName = day +"�� 10��";
        string missionName = string.Format("< color =#EEC045><size=14>{0}�� 10��</size></color> ", day);
        regularDic.Add(index, "��� ��ü ������ ����" + missionName);
        StartCoroutine(PrintCurrentMissionList(index, AddNewRegular(index, day), addData));
    }
    IEnumerator AddNewRegular(int index, int day) // �� �̼� �߰� 
    {
        while (!IsPrintingFinish) // ���� �̼� ����� �� ��µɶ����� ��ٸ�
        {
            yield return null;
        }

        addData = SaveSystem.Load("save_001");

        if (!addData.ActiveRegularMissionList[index]) // missionDic[newMissionNum] �� �̹� �߰��Ǳ����̸�
        {
            GameManager.gameManager._gameData.ActiveRegularMissionList[index] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

            // ���� �̼� �г� ����Ʈ�� �� �������� �г� �ϳ� �߰�
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            GameObject newMissionBack = Instantiate(newMissionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(newMission);
            newMissionBack.transform.SetParent(missionmom.transform, false);
            newMission.transform.SetParent(missionmom.transform, false);
            missionText.Add(newMission.GetComponentInChildren<TMPro.TextMeshProUGUI>());

            newMissionImage = missionPanelList[missionNameList.Count].GetComponentsInChildren<Image>();
            newMissionImage[1].sprite = newMissionSprite;

            /* �� �̼� �߰� �ִϸ��̼� */
            missionPanelList[missionNameList.Count].SetActive(true);
            Animator addMission1Anim = newMissionBack.GetComponentInChildren<Animator>();
            Animator addMissionAnim = missionPanelList[missionNameList.Count].GetComponentInChildren<Animator>();
            addMissionAnim.SetBool("IsOpening1", true);
            addMissionAnim.SetBool("IsOpening2", true);

            textget = missionPanelList[missionNameList.Count].GetComponentInChildren<TMPro.TextMeshProUGUI>();

            /* �� �̼ǵ� ���� �̼� ����Ʈ�� �߰� */
            missionNameList.Add(regularDic[index]);
            StartCoroutine(_typing(missionNameList[missionNameList.Count - 1], missionNameList.Count - 1));
            yield return new WaitForSeconds(0.2f);
            addMissionAnim.SetBool("IsNewMissionStart", true);
            newMissionBack.SetActive(true);
            addMission1Anim.SetBool("IsOpening1", true);
            addMission1Anim.SetBool("IsOpening2", true);

            yield return new WaitForSeconds(10f);
            missionmom.SetActive(false);
            IsPrintingFinish = false;
        }
        else // missionDic[newMissionNum] �� �̹� �߰��Ǿ�����
        {
            while (!IsPrintingFinish)
            {
                yield return null;
            }
            yield return new WaitForSeconds(10f);
            missionmom.SetActive(false);
            IsPrintingFinish = false;
        }
    }
    public void DeleteRegularMission(int deleteMissionNum)
    {
        deleteData = SaveSystem.Load("save_001");
        StartCoroutine(PrintCurrentMissionList(deleteMissionNum, DeleteRegular(deleteMissionNum), deleteData));
    }
    IEnumerator DeleteRegular(int deleteMissionNum) // �Ϸ� �̼� ����
    {
        // ���� �̼� ����� �� ��µɶ����� ��ٸ�
        while (!IsPrintingFinish)
        {
            yield return null;
        }

        int idx = missionNameList.FindIndex(a => a.Contains(regularDic[deleteMissionNum]));
        newMissionImage = missionPanelList[idx].GetComponentsInChildren<Image>();
        Animator addMissionAnim = missionPanelList[idx].GetComponentInChildren<Animator>();

        GameManager.gameManager._gameData.ActiveRegularMissionList[deleteMissionNum] = false;

        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");

        // �Ϸ��� �̼� ���� 
        yield return new WaitForSeconds(1f);

        //newMissionImage[1].sprite = newMissionSprite;
        //Animator addMission1Anim = newMissionBack.GetComponentInChildren<Animator>();

        addMissionAnim.SetBool("IsOpening1", true);
        addMissionAnim.SetBool("IsOpening2", true);

        //StartCoroutine(_typing(missionNameList[missionNameList.Count - 1], missionNameList.Count - 1));
        yield return new WaitForSeconds(1f);
        addMissionAnim.SetBool("IsOpening3", true);
        addMissionAnim.SetBool("IsOpening1", false);
        addMissionAnim.SetBool("IsNewMissionStart", true);
        missionText[idx].text = "";
        yield return new WaitForSeconds(0.5f);
        missionPanelList[idx].SetActive(false);

        //newMissionBack.SetActive(true);
        //addMission1Anim.SetBool("IsOpening1", true);
        //addMission1Anim.SetBool("IsOpening2", true);

        //yield return new WaitForSeconds(1f);
        missionmom.SetActive(false);
        regularDic.Remove(deleteMissionNum); // ��ųʸ����� ����
        IsPrintingFinish = false;
    }

    // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* �̼� ��� ��ư �������� �Լ� */
    public void ShowMissionList()
    {
        currentData = SaveSystem.Load("save_001");

        /* ���⿡ ��ư ���� ������ �˴ϴ� */
        missionNameList.Clear();
        missionPanelList.Clear();
        missionText.Clear();

        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
        missionmom.SetActive(true);

        if (!IsOn)
        {
            for (int k = 0; k < 34; k++)
            {
                if (currentData.ActiveMissionList[k] )
                {
                    missionNameList.Add(missionDic[k]);
                }
            }

            //for(int l=0; l<3; l++)
            //{
            //    if (currentData.ActiveRegularMissionList[l])
            //    {
            //        missionNameList.Add(regularDic[l]);
            //    }
            //}
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
            missionText.Add(newMission.GetComponentInChildren<TMPro.TextMeshProUGUI>());
            newMission.transform.SetParent(missionmom.transform, false);
        }

        // �̼� �ִϸ��̼�
        for(int j=0; j< missionNameList.Count; j++)
        {
            missionPanelList[j].SetActive(true);
            Animator missionAnim = missionPanelList[j].GetComponentInChildren<Animator>();
            missionAnim.SetBool("IsOpening1", true);
            missionAnim.SetBool("IsOpening2", true);
        }

        // �̼� ���
        for (int k = 0; k < missionNameList.Count; k++)
        {
            StartCoroutine(_typing(missionNameList[k], k));
        }

        yield return new WaitForSeconds(10f);
        missionmom.SetActive(false);
    }

    public void ActivateMissionList() // �� �̼� �߰��� �ű�� 
    {
        IsOn = false;
        ShowMissionList();
    }     

    IEnumerator _typing(string data, int missionIndex)
    {
        for (int i = 0; i <= data.Length; i++)
        {
            missionText[missionIndex].text = data.Substring(0, i);
            //textget.text = data.Substring(0, i);
            yield return new WaitForSeconds(0.0005f);
        }
    }

    IEnumerator _typingDDay(string data, int missionIndex)
    {
        for (int i = 0; i <= data.Length; i++)
        {
            DDayText[missionIndex].text = data.Substring(0, i);
            //textget.text = data.Substring(0, i);
            yield return new WaitForSeconds(0.0005f);
        }
    }

    IEnumerator PrintCurrentMissionList(int newMissionNum, IEnumerator AddOrDelete, GameData gameData)  // ���� �̼� ��ϵ� ��� 
    {
        currentData = SaveSystem.Load("save_001");

        // ���� ��� ����
        missionNameList.Clear();  // ���⿡ ��ư ���� ������ �˴ϴ�
        missionPanelList.Clear();
        missionText.Clear();


        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
        missionmom.SetActive(true);

        // ���� Ȱ��ȭ�� �̼ǵ��� ������
        for (int k = 0; k < 34; k++)
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
            missionText.Add(currentMission.GetComponentInChildren<TMPro.TextMeshProUGUI>());
            currentMission.transform.SetParent(missionmom.transform, false);
        }

        // �г� �ִϸ��̼�
        for (int j = 0; j < missionNameList.Count; j++)
        {
            missionPanelList[j].SetActive(true);
            Animator missionAnim = missionPanelList[j].GetComponentInChildren<Animator>();
            missionAnim.SetBool("IsOpening1", true);
            missionAnim.SetBool("IsOpening2", true);
            yield return null;
        }

        // ���� �̼ǵ� ���
        for (int r = 0; r < missionNameList.Count; r++)
        {
            StartCoroutine(_typing(missionNameList[r], r));
        }

        IsPrintingFinish = true;
        StartCoroutine(AddOrDelete);
    }



    
}

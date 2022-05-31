using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionGenerator : MonoBehaviour
{
    public static MissionGenerator missionGenerator { get; private set; }

    //public List<string> missionList;

    public Dictionary<int, string> missionDic = new Dictionary<int, string>();

    public List<string> missionList = new List<string>();
    public GameObject missionPanel;

    public bool IsOn = false;
    public GameObject missionmom;
    TMPro.TextMeshProUGUI textget;

    private void Awake()
    {
        missionGenerator = this;
    }
    private void Start()
    {
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

        //if (GameManager.gameManager._gameData.S_IsAIAwake_M_C1)
        //{
        //    missionList.Add(missionDic[0]);
        //}
        //else if(GameManager.gameManager._gameData.S_IsCWDoorOpened_M_C1)
        //{
        //    missionList.Add(missionDic[1]);
        //}
        //else if(GameManager.gameManager._gameData.S_IsHealthMachineFixed_T_C2)
        //{
        //    missionList.Add(missionDic[2]);
        //}
    }




    public void ShowMissionList()
    {
        /* ���⿡ ��ư ���� ������ �˴ϴ� */
        missionList.Clear();

        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }

        if (!IsOn)
        {
            for (int k = 0; k < GameManager.gameManager._gameData.ActiveMissionList.Length; k++)
            {
                if (GameManager.gameManager._gameData.ActiveMissionList[k] )
                {
                    missionList.Add(missionDic[k]);
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
        //if (missionList.Count!=0)
        //{

//&& !GameManager.gameManager._gameData.EndMissionList[k]
        //}

    }

    IEnumerator PrintMissionList()
    {
        for (int i = 0; i < missionList.Count; i++)
        {
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
            textget = newMission.GetComponentInChildren<TMPro.TextMeshProUGUI>();

            StartCoroutine(_typing(missionList[i]));
            //textget.text = missionList[i];
            newMission.transform.SetParent(GameObject.FindGameObjectWithTag("aa").transform, false);

            newMission.SetActive(true);
            yield return new WaitForSeconds(0.8f);
        }
        yield return new WaitForSeconds(10f);
        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
    }


    IEnumerator _typing(string data)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= data.Length; i++)
        {
            textget.text = data.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }

    }
    public void ActivateMissionList()
    {
        IsOn = false;
        ShowMissionList();
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;

//public class DialogManager : MonoBehaviour
//{
//    public static DialogManager dialogManager { get; private set; }

//    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();
//    public static bool isFinish = false;

//    public TMPro.TextMeshProUGUI dialogText;
//    public GameObject AI;


//    private int i = 0;

//    public Image aiIcon;

//    void Awake()
//    {
//        dialogManager = this;
//        GoogleSheetManager sheetManager = GetComponent<GoogleSheetManager>();
//        Dialogue[] dialogues = sheetManager.googleDialogues;
//        for(int i=0; i<dialogues.Length; i++)
//        {
//            dialogueDic.Add(i+1, dialogues[i]);
//        }
//        isFinish = true;
//        //dialogueDic = new Dictionary<int, string[]>(); // int : �� ������Ʈ�� ID
//        //GenerateData();
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        if (SceneManager.GetActiveScene().name == "new workroom")
//        {
//            AI.SetActive(true);
//            Color color = aiIcon.GetComponent<Image>().color;
//            color.a = 1f;
//            aiIcon.GetComponent<Image>().color = color;
//        }      
//    }


//    public Dialogue[] GetDialogue(int _StartNum, int _EndNum)
//    {
//        List<Dialogue> dialogueList = new List<Dialogue>();

//        for(int i =0; i<= _EndNum-_StartNum; i++)
//        {
//            dialogueList.Add(dialogueDic[_StartNum + i]);
//        }
//        return dialogueList.ToArray();
//    }

//    //void GenerateData()
//    //{
//    //    /* ������ - AI �ر� */
//    //    dialogueDic.Add(1000, new string[] { "AI �ý��� ����� �Ϸ�",
//    //        "�Ŵ��� ������ ��ε�", "���ּ� �ý��� �翬��", "��", 
//    //        "���ּ� ���� ���� �ƴϱ���.", "�ٽ� �λ� �帳�ϴ�, �÷��̾�.", "���ô��", "AI�� �ֿ켱���� ������ ���� ���ϼ̽��ϴ�.",
//    //    "���� ��� ���� �� �������� ���� ���Դϴ�.", "�÷��̾�,", "�����ε� �� ���� �� ���� �ֽñ� �ٶ��ϴ�.", "���� ����� ������������ ���� ���� ������",
//    //    "����� ������ ���� ���� ���� �����Դϴ�." }); // ������ - AI �ر�
       

//    //    /* ������ - �� �ر� (AI �������� ��� ���� ��) */ 
//    //    dialogueDic.Add(1001, new string[] { "���� �ӹ� �Ŵ����� �ε� �Ǿ����ϴ�.", "���� �ֿ켱 ��ǥ�� ���� �ӹ��� �����ϱ� ����",
//    //    "���� �������� ���ϱ� �ٶ��ϴ�."});// ������ - �� �ر�1
//    //    dialogueDic.Add(1002, new string[] { "�÷��̾�,", "����� �� �ϳ��ϳ�", "���� �����ص帱 �� �����ϴ�.", "�ٽ� �����帳�ϴ�.",
//    //    "���� �������� ���ϱ� �ٶ��ϴ�."}); // ������ - �� �ر�2 : ���� ���������� ������ ���� ��

//    //    dialogueDic.Add(1008, new string[] { "������ ���� ���Ƚ��ϴ�.", "���� �������� ���Ͻʽÿ�." });

//    //    /* �������� - ��ü��� ���� */
//    //    dialogueDic.Add(1003, new string[] { "�÷��̾�, ��Ȧ ����� ������� ����", "���� ���� �ü����� �Ҿ����� �����Դϴ�.",
//    //        "��Ȱ�� �ӹ� ������ ����", "������ �ʿ��մϴ�.", "�켱 ��ο� ��� n.113��", "��ü �����͸� �����ؾ� �մϴ�.", // 
//    //        "��ü ������ ������ ����", "���� üũ ��踦 �ֿ켱 �����ϱ� �ٶ��ϴ�." }); // �������� - ��ü��� ���� ��Ʈ��
//    //    // ����Ʈ�� ������� ������ ó��, ��ü��踦 �÷��̾ Ŭ������ �� ���͵� �� �� ���⵵ �ϰ�.... �ణ ��ŷ�� ����Ʈ �������� ��� ����Ʈ���̶� ���ÿ� ������ �� ���� �� ���⵵ ��
//    //    // ���࿡ �÷��̾ ó�� ���ͼ� ��ü��� Ŭ���ϸ� -> ��ü��� ���� �����ϰ�, ����Ʈ�� Ŭ���� -> ����Ʈ�� ���� ���� ?? ����Ʈ���� �����ð� ���� ��, ��Ʈ�� �ִ���??
//    //    dialogueDic.Add(1004, new string[] { "���� üũ ����", "���� ���� �߾ӿ� ��ġ�� �ֽ��ϴ�.", 
//    //        "��� n.113�� �ɷ��� ���� Ȱ���ϱ� �ٶ��ϴ�.", "���� �İ� �ɷ��� �ΰ��� 1���� ���մϴ�."}); // �������� - ��ü��� ���� ��Ʈ, ���� "�İ�" �۾� ���� �ٸ��� �Ѵٵ���, ����̵��� �ϰ����
//    //    dialogueDic.Add(1009, new string[] { "��ü üũ ��谡 ���� �� ���� �Ǿ����ϴ�.", "���� �ش� ��踦 ����", "��� n.113 �� ��ü �����͸� üũ�� �� �ֽ��ϴ�.", "��� n.113�� �ǰ� ���¸� �ֽ��Ͻʽÿ�." });

//    //    /* �������� - ����Ʈ�� ���� */
//    //    dialogueDic.Add(1005, new string[] { "����Ʈ �� ������踦 ã���̱���.", 
//    //        "����Ʈ ���� ����ϱ� ���ؼ�", "������踦 �����ؾ� �մϴ�.", "�ƹ����� ��� ����Ŀ�� �ļյ� ����Դϴ�."}); // �������� - ����Ʈ�� ������� �����ϱ� ��
//    //    dialogueDic.Add(1006, new string[] { "����Ʈ ���� �Ҹ��� �ν��� ���� ����˴ϴ�." }); // �������� - ����Ŀ ���� ��
//    //    dialogueDic.Add(1007, new string[] { "���� ����Ʈ ���� ����Ͻ� �� �ֽ��ϴ�.", "���� ���� �� �Ĺ� ������", "�����ϱ� ���� ���õ� �ü��Դϴ�.",
//    //        "����Ʈ �ʿ��� ��� n.113��", "������ �ķ��� ����� �� �ֽ��ϴ�.", "������ ��������", "�� ������ �������� ���� ���ʽÿ�." }); // �������� - ����Ʈ �� ����
        
//    //}

//    //public string GetTalk(int id, int talkIndex)
//    //{
//    //    if (talkIndex == dialogueDic[id].Length)
//    //        return null;
//    //    else
//    //        return dialogueDic[id][talkIndex];
//    //}

//    //IEnumerator PrintAIDialog(int DialogNum)
//    //{
//    //    int num = DialogNum;

//    //    if(num!=DialogNum)
//    //    {
//    //        num = DialogNum;
//    //    }
//    //    else
//    //    {
//    //        for (int i = 0; i < dialogueDic[num].; i++)
//    //        {
//    //            string talkData = GetTalk(num, i);

//    //            dialogText.text = talkData;

//    //            yield return new WaitForSeconds(1f);
//    //        }
//    //    }
//    //}

//    //public void ResetSystem()
//    //{
//    //    StartCoroutine(ResetSystemDialog());
//    //}

//    //IEnumerator ResetSystemDialog()
//    //{
//    //    yield return new WaitForSeconds(2f);
//    //    AI.SetActive(true);

//    //    Color color = aiIcon.GetComponent<Image>().color;
//    //    for (int i = 0; i < 3; i++)
//    //    {
//    //        color.a = 0f;
//    //        aiIcon.GetComponent<Image>().color = color;
//    //        yield return new WaitForSeconds(0.1f);
//    //        color.a = 1f;
//    //        aiIcon.GetComponent<Image>().color = color;
//    //        yield return new WaitForSeconds(0.1f);
//    //    }

//    //    for (int i = 0; i < 11; i++)
//    //    {
//    //        string talkData = GetTalk(1000, i);

//    //        dialogText.text = talkData;

//    //        yield return new WaitForSeconds(1f);
//    //    }

//    //    AI.SetActive(false);
//    //    color.a = 0f;
//    //    aiIcon.GetComponent<Image>().color = color;

//    //    yield return new WaitForSeconds(1f);

//    //    for (int i = 0; i < 3; i++)
//    //    {
//    //        color.a = 0f;
//    //        aiIcon.GetComponent<Image>().color = color;
//    //        yield return new WaitForSeconds(0.05f);
//    //        color.a = 1f;
//    //        aiIcon.GetComponent<Image>().color = color;
//    //        yield return new WaitForSeconds(0.05f);
//    //    }

//    //    AI.SetActive(true);

//    //    for (int i = 0; i < 3; i++)
//    //    {
//    //        string talkData = GetTalk(1001, i);

//    //        dialogText.text = talkData;

//    //        yield return new WaitForSeconds(1f);
//    //    }
//    //}

//    //public void DoorLock()
//    //{
//    //    StartCoroutine(PrintAIDialog(1002));
//    //}

//    //public void DoorLockEnd()
//    //{
//    //    StartCoroutine(PrintAIDialog(1008));
//    //}


//    //public void HealthMachineRepairIntro()
//    //{
//    //    StartCoroutine(PrintAIDialog(1003));
//    //}
//    //public void HealthMachineRepairHint()
//    //{
//    //    StartCoroutine(PrintAIDialog(1004));
//    //}
//    //public void HealthMachineEnd()
//    //{
//    //    StartCoroutine(PrintAIDialog(1009));
//    //}


//    //public void SmartFarmObserve()
//    //{
//    //    StartCoroutine(PrintAIDialog(1005));
//    //}

//    //public void SmartFarmAfterFixSpeaker()
//    //{
//    //    StartCoroutine(PrintAIDialog(1006));
//    //}
//    //public void SmartFarmOpenEnd()
//    //{
//    //    StartCoroutine(PrintAIDialog(1007));
//    //}

//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ��ư Ŭ������ ����

public class DialogSystem : MonoBehaviour
{
    // �̱��� ���� ã�ƺ���
    // static : ������ �����ϰų� ���� ��, Ŭ���� ��ü�� ���� �ʿ䰡 ����
    // �׻� ������ �����ϰ� ���� ���� �����Ѵ�. (ex. �ٸ� �������� �����ؾ� �ϴ� �� : �÷��̾� ü��, ���� �Ͻ����� �� )
   // get set ���߿� ã�ƺ���, 
    public static DialogSystem Instance { get; private set; }
    // Q. public static class Extensions �� ������ ?

    [SerializeField] TMPro.TextMeshProUGUI messageText, yesText, noText, smellText;
    [SerializeField] GameObject panel, smellpanel;
    [SerializeField] Button yesButton, noButton;

    private List<string> currentMessages = new List<string>();
    private int msgID = 0;

    private string DialogSmellText;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        panel.SetActive(false);
    }

    /* ��ȣ�ۿ� ���߿� �ٸ� ������ �̵��ϸ�  �޽����� ��������ϴ� �޼��� */
    public void HideDialog()
    {
        panel.SetActive(false);
        smellpanel.SetActive(false);
    }

    public void Smell()
    {

        DialogSmellText = PlayerScripts.playerscripts.PlayerSmellText;
        smellpanel.SetActive(true);
        smellText.text = DialogSmellText;
        StartCoroutine("TurnOffSmellPanel");
    }

    IEnumerator TurnOffSmellPanel()
    {
        yield return new WaitForSeconds(3f);
        smellpanel.SetActive(false);
    }









    // �޼��带 ����� ������ �׻� argument�� ������ �ʿ䰡 ���� ������  List<Actions> �� �⺻ �� �Ҵ� null
    public void ShowMessages(List<string> messages, bool dialog, List<Actions> yesActions = null, List<Actions> noActions = null, string yes = "Yes", string no = "No" )
    {
        msgID = 0;
        yesButton.transform.parent.gameObject.SetActive(false); // yes ��ư�� �θ� ���� ��Ȱ��ȭ -> �θ� : yes ��ư , no ��ư �Ѵ�

        currentMessages = messages; // NPC A �� ��ȭ ����Ʈ���� ���� ��ȭ����Ʈ�� ����
        panel.SetActive(true);
        // �ڷ�ƾ ���� ���� ��ư�� �� �Ҵ�

        /* �� ��ư�� ������ �� �������ִ� ���׼ǵ��� �����ϸ� �� ���׼ǵ��� �����Ŵ */
        if (dialog) // ���� �������� ������
        {
            /* Yes Button*/
            yesText.text = yes; // Yes ��ư�� ��ư ���� �ö� �ؽ�Ʈ parameter ����
            // �׼� ����, ��ư�� �޼��� ����
            yesButton.onClick.RemoveAllListeners(); // yes button�� Ŭ���ϸ� ������ �־��� �޼��� ����
            yesButton.onClick.AddListener(delegate
            {
                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                panel.SetActive(false); // �� ???? ����� ��� �Ǵ��� �ñ���

                if (yesActions !=null) // yes button �� ������ �� ������ ���׼ǵ��� �����ϸ�
                {
                    AssignActionstoButtons(yesActions); // ���� ��ư�� �´� ���׼��� ��������ִ� �޼���
                }
            }); // delegate ?? 

            /* No Button */
            noText.text = no; // No ��ư�� ��ư ���� �ö� �ؽ�Ʈ parameter ����
            noButton.onClick.RemoveAllListeners(); // ������ �־��� �޼��� ����
            noButton.onClick.AddListener(delegate
            {
                panel.SetActive(false);
                if (noActions!=null)
                {
                    AssignActionstoButtons(noActions);
                }           
            }); 
        }

        StartCoroutine(ShowMultipleMessages(dialog));  // ������ ���� ��ȭ�� ������� ������
    } // Q. NPC �� Ŭ��-> ��ȭ~ �������� ������ actions �ϳ� ������, �������� ������ �ٽ� �ٸ� actions ���� �̷� �� ������ 


    /* Ŭ���� ������ ������ ��ȭ �������� ������� �����ִٰ�  ������ ��ȭ�� �������� ������ �������� �����ְ�, ������ ��ȭâ�� ���� �޼��� */
    IEnumerator ShowMultipleMessages(bool useDialog)
    {
        messageText.text = currentMessages[msgID]; // msgID : �� ó���� 0, -> ȭ���� ��ȭâ�� 0��° ��ȭ ��� 
        while(msgID < currentMessages.Count) // 1���� n��° ��ȭ������ ���
        { 
            if(Input.GetKeyDown(KeyCode.Space)||(Input.GetMouseButtonDown(0)&&Extensions.IsMouseOverUI())) // ���� ���콺 ��ư����&& ��ȭâ�� Ŭ���ϸ�
            {
                msgID++;

                if(msgID<currentMessages.Count) // 1���� n��° ��ȭ������ ���
                {
                    messageText.text = currentMessages[msgID];
                }

                // ������ �޽����� �� �� �ƴϿ� ��ư�� ��Ÿ���� �ϱ�
                if(useDialog && msgID == currentMessages.Count - 1) // useDialog �� ���̰� (��ȭ�������� �������� ����) && ���� ��ȭ �������̸�
                {
                    yesButton.transform.parent.gameObject.SetActive(true); // yes ��ư�� �θ� ���� Ȱ��ȭ -> �θ� : yes ��ư , no ��ư �Ѵ�
                }
            }
            yield return null;
        }

        if(!useDialog) // ���� �������� ������ 
            panel.SetActive(false);
            smellpanel.SetActive(false);
    }

    /* ���� ��ư�� �´� ���׼��� ��������ִ� �޼��� */
    void AssignActionstoButtons(List<Actions> actions)
    {
        List<Actions> localActions = actions;

        for(int i = 0;  i<localActions.Count;  i++)
        {
            localActions[i].Act(); // Q. Show messages ����?? 
        }
    }
}

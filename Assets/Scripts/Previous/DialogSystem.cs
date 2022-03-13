using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // 버튼 클래스에 접근

public class DialogSystem : MonoBehaviour
{
    // 싱글톤 패턴 찾아보기
    // static : 변수를 수정하거나 읽을 때, 클래스 객체를 만들 필요가 없음
    // 항상 참조가 가능하고 같은 값을 유지한다. (ex. 다른 씬에서도 유지해야 하는 것 : 플레이어 체력, 게임 일시정지 등 )
   // get set 나중에 찾아보기, 
    public static DialogSystem Instance { get; private set; }
    // Q. public static class Extensions 와 차이점 ?

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
        smellpanel.SetActive(false);
    }

    /* 상호작용 도중에 다른 곳으로 이동하면  메시지가 사라지게하는 메서드 */
    public void HideDialog()
    {
        panel.SetActive(false);
        smellpanel.SetActive(false);
    }

    public void Smell()
    {
        DialogSmellText = PlayerScripts.playerscripts.PlayerSmellText;
        //smellpanel.SetActive(true);
        smellText.text = DialogSmellText;
    }









    // 메서드를 사용할 때마다 항상 argument를 전달할 필요가 없기 때문에  List<Actions> 에 기본 값 할당 null
    public void ShowMessages(List<string> messages, bool dialog, List<Actions> yesActions = null, List<Actions> noActions = null, string yes = "Yes", string no = "No" )
    {
        msgID = 0;
        yesButton.transform.parent.gameObject.SetActive(false); // yes 버튼의 부모 까지 비활성화 -> 부모 : yes 버튼 , no 버튼 둘다

        currentMessages = messages; // NPC A 의 대화 리스트들을 현대 대화리스트로 전달
        panel.SetActive(true);
        // 코루틴 시작 전에 버튼에 값 할당

        /* 각 버튼을 눌렀을 때 정해져있는 리액션들이 존재하면 그 리액션들을 실행시킴 */
        if (dialog) // 다음 선택지가 있으면
        {
            /* Yes Button*/
            yesText.text = yes; // Yes 버튼에 버튼 위에 올라갈 텍스트 parameter 전달
            // 액션 전달, 버튼에 메서드 전달
            yesButton.onClick.RemoveAllListeners(); // yes button을 클릭하면 이전에 있었던 메서드 삭제
            yesButton.onClick.AddListener(delegate
            {
                // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                panel.SetActive(false); // 왜 ???? 지우면 어떻게 되는지 궁금함

                if (yesActions !=null) // yes button 을 눌렀을 때 나오는 리액션들이 존재하면
                {
                    AssignActionstoButtons(yesActions); // 누른 버튼에 맞는 리액션을 실행시켜주는 메서드
                }
            }); // delegate ?? 

            /* No Button */
            noText.text = no; // No 버튼에 버튼 위에 올라갈 텍스트 parameter 전달
            noButton.onClick.RemoveAllListeners(); // 이전에 있었던 메서드 삭제
            noButton.onClick.AddListener(delegate
            {
                panel.SetActive(false);
                if (noActions!=null)
                {
                    AssignActionstoButtons(noActions);
                }           
            }); 
        }

        StartCoroutine(ShowMultipleMessages(dialog));  // 선택지 없이 대화만 순서대로 보여줌
    } // Q. NPC 를 클릭-> 대화~ 선택지가 나오면 actions 하나 마무리, 선택지를 누르면 다시 다른 actions 시작 이런 것 같은데 


    /* 클릭할 때마다 정해진 대화 여러개를 순서대로 보여주다가  마지막 대화에 선택지가 있으면 선택지를 보여주고, 없으면 대화창을 끄는 메서드 */
    IEnumerator ShowMultipleMessages(bool useDialog)
    {
        messageText.text = currentMessages[msgID]; // msgID : 맨 처음에 0, -> 화면의 대화창에 0번째 대화 출력 
        while(msgID < currentMessages.Count) // 1부터 n번째 대화까지만 출력
        { 
            if(Input.GetKeyDown(KeyCode.Space)||(Input.GetMouseButtonDown(0)&&Extensions.IsMouseOverUI())) // 왼쪽 마우스 버튼으로&& 대화창을 클릭하면
            {
                msgID++;

                if(msgID<currentMessages.Count) // 1부터 n번째 대화까지만 출력
                {
                    messageText.text = currentMessages[msgID];
                }

                // 마지막 메시지일 때 예 아니오 버튼도 나타나게 하기
                if(useDialog && msgID == currentMessages.Count - 1) // useDialog 가 참이고 (대화마지막에 선택지가 있음) && 현재 대화 마지막이면
                {
                    yesButton.transform.parent.gameObject.SetActive(true); // yes 버튼의 부모 까지 활성화 -> 부모 : yes 버튼 , no 버튼 둘다
                }
            }
            yield return null;
        }

        if(!useDialog) // 다음 선택지가 없으면 
            panel.SetActive(false);
            smellpanel.SetActive(false);
    }

    /* 누른 버튼에 맞는 리액션을 실행시켜주는 메서드 */
    void AssignActionstoButtons(List<Actions> actions)
    {
        List<Actions> localActions = actions;

        for(int i = 0;  i<localActions.Count;  i++)
        {
            localActions[i].Act(); // Q. Show messages 실행?? 
        }
    }
}

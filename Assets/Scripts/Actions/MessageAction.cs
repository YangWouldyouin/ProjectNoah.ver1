using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NPC 에게 붙는 스크립트
public class MessageAction : Actions
{
    [Multiline(5)]
    [SerializeField] List<string> messages; // 대화 리스트
    [SerializeField] bool enableDialog; // 대화 마지막에 다음 선택지가 있으면 참
    [SerializeField] List<Actions> yesActions, noActions; // 각 버튼을 눌렀을 때의 리액션 리스트, Message Action 스크립트 하나 자체가 Actions 가 됨
    [SerializeField] string yesText, noText; // 버튼 위의 텍스트
    public override void Act() // Actions 추상 클래스를 상속받았기 때문에 반드시 Act() 메서드를 가지고 있어야 한다. 
    {
        // 메세지 출력함, Instance 가 static reference 이므로 (getComponet findObjectType 을 쓸 필요 없음)
        // 플레이어가 예 / 아니오 중 하나 선택 -> 그에 맞는 리액션 실행시키기 
        DialogSystem.Instance.ShowMessages(messages, enableDialog, yesActions, noActions, yesText, noText);
    }
}

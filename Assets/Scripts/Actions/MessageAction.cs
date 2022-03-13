using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NPC ���� �ٴ� ��ũ��Ʈ
public class MessageAction : Actions
{
    [Multiline(5)]
    [SerializeField] List<string> messages; // ��ȭ ����Ʈ
    [SerializeField] bool enableDialog; // ��ȭ �������� ���� �������� ������ ��
    [SerializeField] List<Actions> yesActions, noActions; // �� ��ư�� ������ ���� ���׼� ����Ʈ, Message Action ��ũ��Ʈ �ϳ� ��ü�� Actions �� ��
    [SerializeField] string yesText, noText; // ��ư ���� �ؽ�Ʈ
    public override void Act() // Actions �߻� Ŭ������ ��ӹ޾ұ� ������ �ݵ�� Act() �޼��带 ������ �־�� �Ѵ�. 
    {
        // �޼��� �����, Instance �� static reference �̹Ƿ� (getComponet findObjectType �� �� �ʿ� ����)
        // �÷��̾ �� / �ƴϿ� �� �ϳ� ���� -> �׿� �´� ���׼� �����Ű�� 
        DialogSystem.Instance.ShowMessages(messages, enableDialog, yesActions, noActions, yesText, noText);
    }
}

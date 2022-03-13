using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateActions : Actions
{
    [SerializeField] List<AnimParameter> anims = new List<AnimParameter>();

    [SerializeField] List<Actions> actions = new List<Actions>(); // �ִϸ��̼��� ������ ���� �׼����� �Ѿ

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        // ���α׷��� ����Ǹ� triggerName�� int ������ �ؽ÷� �ٲ�
        for (int i = 0; i<anims.Count; i++)
        {
            anims[i].InitHashID();
        }

    }

    public override void Act()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        int i = 0;

        while(i < anims.Count)
        {
            yield return new WaitForSeconds(anims[i].InvokeDelay);

            animator.SetTrigger(anims[i].HashID);

            i++;


            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(animator.GetNextAnimatorStateInfo(0).length);
        }

        for(int j = 0; j < actions.Count; j++)
        {
            actions[j].Act();
        }

    }

}

[System.Serializable]
public class AnimParameter
{
    [SerializeField] string triggerName; // �ٸ� �ִϸ��̼����� ��ȯ��Ű�� Ʈ����
    [SerializeField] float invokeDelay;

    public float InvokeDelay { get { return invokeDelay; } }
    public int HashID { get; private set; }

    public void InitHashID()
    {
        HashID = Animator.StringToHash(triggerName);
    }
}
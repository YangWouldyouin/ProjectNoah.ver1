using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimateActions : Actions
{
    [SerializeField] List<AnimParameter> anims = new List<AnimParameter>();

    [SerializeField] List<Actions> actions = new List<Actions>(); // 애니메이션이 끝나면 다음 액션으로 넘어감

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        // 프로그램이 실행되면 triggerName을 int 형태의 해시로 바꿈
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
    [SerializeField] string triggerName; // 다른 애니메이션으로 전환시키는 트리거
    [SerializeField] float invokeDelay;

    public float InvokeDelay { get { return invokeDelay; } }
    public int HashID { get; private set; }

    public void InitHashID()
    {
        HashID = Animator.StringToHash(triggerName);
    }
}
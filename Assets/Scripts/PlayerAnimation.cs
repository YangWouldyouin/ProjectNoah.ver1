using UnityEngine;

public class PlayerAnimation
{
    // Monobehavior �� ��ӹ��� �ʾƼ� GetComponent ��� �Ұ�

    private Animator animator;
    // Start is called before the first frame update
    private int animSpeed = Animator.StringToHash("Speed"); // ??
    // PlayerScripts �� Start �޼��忡�� ������ ����
    public void Init(Animator anim)
    {
        animator = anim;

    }

    public void UpdateAnimation(float speed)
    {
        animator.SetFloat(animSpeed, speed);
    }
}

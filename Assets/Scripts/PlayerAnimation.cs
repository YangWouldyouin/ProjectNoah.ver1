using UnityEngine;

public class PlayerAnimation
{
    // Monobehavior 를 상속받지 않아서 GetComponent 사용 불가

    private Animator animator;
    // Start is called before the first frame update
    private int animSpeed = Animator.StringToHash("Speed"); // ??
    // PlayerScripts 의 Start 메서드에서 실행할 것임
    public void Init(Animator anim)
    {
        animator = anim;

    }

    public void UpdateAnimation(float speed)
    {
        animator.SetFloat(animSpeed, speed);
    }
}

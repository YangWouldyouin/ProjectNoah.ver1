using UnityEngine;

public class PlayerAnimation
{
    // Monobehavior �� ��ӹ��� �ʾƼ� GetComponent ��� �Ұ�

    private Animator animator;
    // Start is called before the first frame update
    private int animSpeed = Animator.StringToHash("Speed"); // ??
    private int animRotate = Animator.StringToHash("rotate");

   // 			if (move.magnitude > 1f) move.Normalize();
			//move = transform.InverseTransformDirection(move);
			//CheckGroundStatus();
   // move = Vector3.ProjectOnPlane(move, m_GroundNormal);
			//m_TurnAmount = Mathf.Atan2(move.x, move.z);
    // PlayerScripts �� Start �޼��忡�� ������ ����
    public void Init(Animator anim)
    {
        animator = anim;

    }

    public void UpdateAnimation(float speed, float rotate)
    {

        animator.SetFloat(animSpeed, speed, 0.1f, Time.deltaTime);
        animator.SetFloat(animRotate, rotate, 0.05f, Time.deltaTime);
        //animator.SetFloat(animRotate, rotate);
    }
}

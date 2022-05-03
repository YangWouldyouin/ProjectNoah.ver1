using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInteraction_P : MonoBehaviour, IInteraction
{
    [SerializeField] PortableObjectData pipeData;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBark()
    {
        /* 오브젝트의 짖기 변수 true로 바꿈 */
        //pipeData.IsBark = true;
        /* 상호작용 버튼을 끔 */
        // DiableButton();
        /* 애니메이션 보여줌 */
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        throw new System.NotImplementedException();
    }
    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }

    public void OnPushOrPress()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        throw new System.NotImplementedException();
    }

    // @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }
    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }
    public void OnObserve()
    {
        throw new System.NotImplementedException();
    }
    public void OnUp()
    {
        throw new System.NotImplementedException();
    }
}

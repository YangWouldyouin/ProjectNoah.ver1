using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] float distancePosition; // NPC 와의 약간의 distance

    [HideInInspector]
    [SerializeField] Actions[] actionss; // NPC 와의 첫 번째 상호작용


    private GameObject noahPressObject;

    //public Button barkInterButton, sniffInterButton;
    //public GameObject biteInterButton;

    private Button currentCenterButton, currentPushOrPressButton;

    //public Button noCenterInterButton, eatInterButton, eatDisableInterButton, insertInterButton, upDownInterButton, observeInterButton, insertDisableInterButton, upDownDisableInterButton, observeDisableInterButton;

    private GameObject nowInteractObject;

    //Outline outline; // 마우스 오버시 오브젝트 외곽선
    //private void Start()
    //{
    //    outline = GetComponent<Outline>(); // 상호작용 오브젝트로부터 아웃라인 컴포넌트를 가져옴
    //}

    ///* 마우스 오버시 아웃라인 활성화 */
    //public void OnMouseOver()
    //{
    //    if(outline!=null)
    //    {
    //        outline.enabled = true;
    //    }
    //}

    ///* 마우스가 오브젝트로부터 벗어나면 아웃라인 비활성화 */
    //public void OnMouseExit()
    //{
    //    if(outline != null)
    //    { 
    //        outline.enabled = false;
    //    }
    //}

    /* NPC 의 위치를 반환하는 메서드 */
    public Vector3 InteractPosition()
    {
        //return transform.position + transform.right*distancePosition;
        return transform.position;
    }

    /* 플레이어가 NPC를 클릭하면 1)NPC 위치로 갈때까지 기다렸다가 도착하면 2) NPC 를 바라보는 방향으로 플레이어를 돌리고, 3) 상호작용들을 실행하는 메서드 */
    public void Interact(PlayerScripts player)
    {
        //currentPushOrPressButton = PlayerScripts.playerscripts.ObjectpushOrpressbutton;



        if (player.pressFunc != null)
        {
            currentPushOrPressButton.onClick.AddListener(player.pressFunc.OnPressButtonClicked);
        }
        else
        {
            currentPushOrPressButton.onClick.AddListener(PressBasic);
        }
        StartCoroutine(WaitforPlayerArriving(player));
    }

    IEnumerator WaitforPlayerArriving(PlayerScripts player)
    {
        // 1) 플레이어가 도착하지 않았으면 코루틴으로 딜레이하면서 기다림
        while(!player.CheckIfArrived())
        {
            yield return null;
        }

        Debug.Log("Player arrived");

        // 2) 플레이어가 npc 위치로 도착하면 npc를 바라보게 각도를 바꿈 
        //player.SetDirection(transform.position);

        /* 오브젝트 위에 상호작용 버튼을 띄움 */

        //기본 4가지 상호작용 버튼을 띄움
        BaseCanvas._baseCanvas.barkButton.transform.gameObject.SetActive(true);
        BaseCanvas._baseCanvas.sniffButton.transform.gameObject.SetActive(true);
        BaseCanvas._baseCanvas.biteDestroyButton.transform.gameObject.SetActive(true);

        // 누르기 버튼의 경우 - 현재 상호작용 중인 오브젝트가 누르기(밀기)인지, 누르기인지 확인 후 그에 맞는 버튼을 띄움


        currentPushOrPressButton.transform.gameObject.SetActive(true);

        // 가운데 버튼을 띄움
        nowInteractObject = PlayerScripts.playerscripts.currentObject;
        if(nowInteractObject!=null)
        {
            ObjData nowInteractData = nowInteractObject.GetComponent<ObjData>();

            if (nowInteractData.IsCenterButtonChanged) // 만약 가운데 버튼이 바뀌었다면 
            {
                if (nowInteractData.IsCenterPlusButtonDisabled) //  바뀐 가운데 버튼이 비활성화 상태이면 
                {
                    // 누를 수 없는 버튼을 띄운다.
                    if (nowInteractData.CenterButton2.name == "InsertButton")
                    {
                        BaseCanvas._baseCanvas.insertDisableButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton2.name == "UpDownButton")
                    {
                        BaseCanvas._baseCanvas.upDownDisableButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton2.name == "ObserveButton")
                    {
                        BaseCanvas._baseCanvas.observeDisableButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton2.name == "EatButton")
                    {
                        BaseCanvas._baseCanvas.eatDisableButton.transform.gameObject.SetActive(true);
                    }
                }
                else // 바뀐 가운데 버튼이 활성화 상태이면 누를 수 있는 버튼을 띄운다. 
                {
                    if (nowInteractData.CenterButton2.name == "InsertButton")
                    {
                        BaseCanvas._baseCanvas.insertButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton2.name == "UpDownButton")
                    {
                        BaseCanvas._baseCanvas.upDownButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton2.name == "ObserveButton")
                    {
                        BaseCanvas._baseCanvas.observeButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton2.name == "EatButton")
                    {
                        BaseCanvas._baseCanvas.eatButton.transform.gameObject.SetActive(true);
                    }

                }
        }
            else // 만약 가운데 버튼이 바뀌지 않았다면
            {
                if (nowInteractData.IsCenterButtonDisabled) // 바뀌지 않은 가운데 버튼이 비활성화 상태이면 
                {
                    // 누를 수 없는 버튼을 띄운다.
                    if(nowInteractData.CenterButton1.name == "InsertButton")
                    {
                        BaseCanvas._baseCanvas.insertDisableButton.transform.gameObject.SetActive(true);
                    }
                    else if(nowInteractData.CenterButton1.name == "UpDownButton")
                    {
                        BaseCanvas._baseCanvas.upDownDisableButton.transform.gameObject.SetActive(true);
                    }
                    else if(nowInteractData.CenterButton1.name == "ObserveButton")
                    {
                        BaseCanvas._baseCanvas.observeDisableButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton1.name == "EatButton")
                    {
                        BaseCanvas._baseCanvas.eatDisableButton.transform.gameObject.SetActive(true);
                    }

                }
                else // 활성화상태이면 누를 수 있는 버튼을 띄운다. 
                {
                    if (nowInteractData.CenterButton1.name == "InsertButton")
                    {
                        BaseCanvas._baseCanvas.insertButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton1.name == "UpDownButton")
                    {
                        BaseCanvas._baseCanvas.upDownButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton1.name == "ObserveButton")
                    {
                        BaseCanvas._baseCanvas.observeButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton1.name == "EatButton")
                    {
                        BaseCanvas._baseCanvas.eatButton.transform.gameObject.SetActive(true);
                    }
                    else if(nowInteractData.CenterButton1.name == "NoCenterButton")
                    {
                        BaseCanvas._baseCanvas.noCenterButton.transform.gameObject.SetActive(true);
                    }
                }
            }

            //if (nowInteractData.IsCenterButtonChanged)
            //{
            //    currentCenterButton = PlayerScripts.playerscripts.ObjectCenterPlusButton;
            //}
            //else
            //{
            //    currentCenterButton = PlayerScripts.playerscripts.ObjectCenterButton;
            //}
            //currentCenterButton.transform.gameObject.SetActive(true);
        }


        // 3) npc 와 상호작용함
        //for (int i=0; i < actionss.length; i++)
        //{
        //    actionss[i].act(); // actions 클래스의 act() 메서드를 실행함
        //    // q. 이걸로 actions 클래스를 상속받은 다른 클래스들을 전부 부를 수 있는 건가? 
        //}     
    }


    //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 누르기 - 버튼 등을 누르기 */

    void PressBasic()
    {
        noahPressObject = PlayerScripts.playerscripts.currentObject;
        


        if (noahPressObject != null)
        {
            ObjData noahPushOrPressData = noahPressObject.GetComponent<ObjData>();

            InteractionButtonController.interactionButtonController.TurnOffInteractionButton();

            //if (noahPushOrPressData.ISPushOrPressActive) // 현재 오브젝트가 "누르기" 가능한 오브젝트이면
            //{
            //    noahPushOrPressData.IsPushOrPress = true; // 현재 상호작용 중인 오브젝트의 데이터에서 누르기 == true 로 저장
            //    Invoke("ChangePressTrue", 0.5f); // 버튼이 눌러지고 0.5초 후 누르기 누르기 동작 시작
            //    Invoke("ChangePressFalse", 2f); // 2초 후 누르기 끝내고 다시 Idle 상태로 돌아감
            //    Invoke("PressFalse", 1f);
            //}
            //else // 실제로는 누르기 불가능한 오브젝트 이므로 동작만 보여준다. 
            //{
            //    noahPushOrPressData.IsPushOrPress = true; // 현재 상호작용 중인 오브젝트의 데이터에서 누르기 == true 
            //    Invoke("JustPlayPushAnimationTrue", 0.5f);
            //    Invoke("JustPlayPushAnimationFalse", 2f);
            //    Invoke("PressFalse", 1f);
            //}
        }
    }

    /* 실제 누르기 애니메이션 동작들 */
    void ChangePressTrue()
    {
        PlayerScripts.playerscripts.noahAnim.SetBool("IsPressing", true);
    }
    void ChangePressFalse()
    {

        PlayerScripts.playerscripts.noahAnim.SetBool("IsPressing", false);
    }

    /* 누르기 불가능한 오브젝트일 때 보여주기용 동작들 */
    void JustPlayPushAnimationTrue()
    {
        PlayerScripts.playerscripts.noahAnim.SetBool("IsNonePushing", true);
    }

    void JustPlayPushAnimationFalse()
    {
        PlayerScripts.playerscripts.noahAnim.SetBool("IsNonePushing", false);
    }

    void PressFalse()
    {
        noahPressObject = PlayerScripts.playerscripts.currentObject;
        ObjData noahPushOrPressData = noahPressObject.GetComponent<ObjData>();
        noahPushOrPressData.IsPushOrPress = false;
    }
}



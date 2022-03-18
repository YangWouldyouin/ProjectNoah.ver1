using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] float distancePosition; // NPC 와의 약간의 distance
    [SerializeField] Actions[] actionss; // NPC 와의 첫 번째 상호작용

    public Button barkInterButton, sniffInterButton;
    public GameObject biteInterButton;

    private Button currentCenterButton, currentPushOrPressButton;

    public Button noCenterInterButton, insertInterButton, upDownInterButton, observeInterButton, insertDisableInterButton, upDownDisableInterButton, observeDisableInterButton;

    private GameObject nowInteractObject;


    Outline outline; // 마우스 오버시 오브젝트 외곽선
    private void Start()
    {
        outline = GetComponent<Outline>(); // 상호작용 오브젝트로부터 아웃라인 컴포넌트를 가져옴
    }

    /* 마우스 오버시 아웃라인 활성화 */
    public void OnMouseOver()
    {
        outline.enabled = true;
    }

    /* 마우스가 오브젝트로부터 벗어나면 아웃라인 비활성화 */
    public void OnMouseExit()
    {
        outline.enabled = false;
    }

    /* NPC 의 위치를 반환하는 메서드 */
    public Vector3 InteractPosition()
    {
        //return transform.position + transform.right*distancePosition;
        return transform.position;
    }

    /* 플레이어가 NPC를 클릭하면 1)NPC 위치로 갈때까지 기다렸다가 도착하면 2) NPC 를 바라보는 방향으로 플레이어를 돌리고, 3) 상호작용들을 실행하는 메서드 */
    public void Interact(PlayerScripts player)
    {
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
        barkInterButton.transform.gameObject.SetActive(true);
        sniffInterButton.transform.gameObject.SetActive(true);
        biteInterButton.transform.gameObject.SetActive(true);

        // 누르기 버튼의 경우 - 현재 상호작용 중인 오브젝트가 누르기(밀기)인지, 누르기인지 확인 후 그에 맞는 버튼을 띄움
        currentPushOrPressButton = PlayerScripts.playerscripts.ObjectpushOrpressbutton;
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
                    if (nowInteractData.CenterPlusButton.name == "InsertButton")
                    {
                        insertDisableInterButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterPlusButton.name == "UpDownButton")
                    {
                        upDownDisableInterButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterPlusButton.name == "ObserveButton")
                    {
                        observeDisableInterButton.transform.gameObject.SetActive(true);
                    }
                }
                else // 바뀐 가운데 버튼이 활성화 상태이면 누를 수 있는 버튼을 띄운다. 
                {
                    if (nowInteractData.CenterPlusButton.name == "InsertButton")
                    {
                        insertInterButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterPlusButton.name == "UpDownButton")
                    {
                        upDownInterButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterPlusButton.name == "ObserveButton")
                    {
                        observeInterButton.transform.gameObject.SetActive(true);
                    }

                }
            }
            else // 만약 가운데 버튼이 바뀌지 않았다면
            {
                if (nowInteractData.IsCenterButtonDisabled) // 바뀌지 않은 가운데 버튼이 비활성화 상태이면 
                {
                    // 누를 수 없는 버튼을 띄운다.
                    if(nowInteractData.CenterButton.name == "InsertButton")
                    {
                        insertDisableInterButton.transform.gameObject.SetActive(true);
                    }
                    else if(nowInteractData.CenterButton.name == "UpDownButton")
                    {
                        upDownDisableInterButton.transform.gameObject.SetActive(true);
                    }
                    else if(nowInteractData.CenterButton.name == "ObserveButton")
                    {
                        observeDisableInterButton.transform.gameObject.SetActive(true);
                    }
                    
                }
                else // 활성화상태이면 누를 수 있는 버튼을 띄운다. 
                {
                    if (nowInteractData.CenterButton.name == "InsertButton")
                    {
                        insertInterButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton.name == "UpDownButton")
                    {
                        upDownInterButton.transform.gameObject.SetActive(true);
                    }
                    else if (nowInteractData.CenterButton.name == "ObserveButton")
                    {
                        observeInterButton.transform.gameObject.SetActive(true);
                    }
                    else if(nowInteractData.CenterButton.name == "NoCenterButton")
                    {
                        noCenterInterButton.transform.gameObject.SetActive(true);
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
}



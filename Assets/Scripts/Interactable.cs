using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    [SerializeField] float distancePosition; // NPC 와의 약간의 distance
    [SerializeField] Actions[] actionss; // NPC 와의 첫 번째 상호작용

    public Button barkButton, sniffButton, insertButton;
    public GameObject biteButton;
    private Button currentCenterButton, currentPushOrPressButton;

    private GameObject nowInteractObject;

    Outline outline;
    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void OnMouseOver()
    {
        outline.enabled = true;
    }

    public void OnMouseExit()
    {
        outline.enabled = false;
    }

    /* NPC 의 위치를 반환하는 메서드 */
    public Vector3 InteractPosition()
    {
        return transform.position + transform.right*distancePosition;
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
        player.SetDirection(transform.position);

        barkButton.transform.gameObject.SetActive(true);
        sniffButton.transform.gameObject.SetActive(true);
        biteButton.transform.gameObject.SetActive(true);

        currentPushOrPressButton = PlayerScripts.playerscripts.ObjectpushOrpressbutton;
        currentPushOrPressButton.transform.gameObject.SetActive(true);

        nowInteractObject = PlayerScripts.playerscripts.currentObject;
        if(nowInteractObject!=null)
        {
            ObjData nowInteractData = nowInteractObject.GetComponent<ObjData>();

            if (nowInteractData.IsCenterButtonChanged)
            {
                currentCenterButton = PlayerScripts.playerscripts.ObjectCenterPlusButton;
            }
            else
            {
                currentCenterButton = PlayerScripts.playerscripts.ObjectCenterButton;
            }
            currentCenterButton.transform.gameObject.SetActive(true);
        }


        // 3) npc 와 상호작용함
        //for (int i=0; i < actionss.length; i++)
        //{
        //    actionss[i].act(); // actions 클래스의 act() 메서드를 실행함
        //    // q. 이걸로 actions 클래스를 상속받은 다른 클래스들을 전부 부를 수 있는 건가? 
        //}     
    }
}

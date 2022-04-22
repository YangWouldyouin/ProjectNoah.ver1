using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ObjData : MonoBehaviour
{
    /* 값이 바뀌지 않는 데이터 목록 */
    //public int id;
    [Header("< 오브젝트 정보 >")]
    [SerializeField] string objectName;

    [SerializeField] string smellText;

    [Header("도착 위치 & 각도")]
    [SerializeField] Transform interactionDestination;

    [Header("< 기본 상호작용 버튼 >")]
    [SerializeField] Button barkButton;
    [SerializeField] Button sniffButton;

    [SerializeField] Button biteButton;
    [SerializeField] Button smashButton;

    [SerializeField] Button pushOrPressButton;
    
    [Header("< 추가 상호작용 버튼 >")]
    [SerializeField] Button centerButton1; // 가운데 추가행동 : 관찰, 오르기 등, 가운데 버튼 비활성화이면 NoCenterButton 넣으면 됨
    [SerializeField] Button centerDisableButton1;

    [SerializeField] Button centerButton2; // 가운데 버튼 비활성화 상태에서 활성화로 바뀔 때 바뀌는 버튼을 넣으면 됨
    [SerializeField] Button centerDisableButton2;

    [SerializeField] GameObject interactButton; // 가운데 버튼 비활성화 상태에서 활성화로 바뀔 때 바뀌는 버튼을 넣으면 됨
    //[SerializeField] Button pushOrPressButton; // 물건 옮기기 : PushButton // 버튼 누르기 or 그냥 누르는 애니메이션만 보여줄 때(실제로는 누르기가 안되는 오브젝트일 때) : PressButton

  
    
    [SerializeField] Transform observeView;

    [SerializeField] Transform observePlusView;


    //[SerializeField] bool IsPushOrPressActive; // 진짜 누르기,밀기가 가능하면 true, 사실 안되고 그냥 애니메이션만 보여줄거면 false

    //[SerializeField] bool IsBiteActive; // 진짜 물기가 가능하면 true, 아니면 false





    // 위 목록을 다른 스크립트에서 쓸 수 있도록 한 것들
    public string ObjectName { get { return objectName; } }
    public string SmellText { get { return smellText; } }
    public Transform InteractionDestination { get { return interactionDestination; } }

    public Button BarkButton { get { return barkButton; } }
    public Button SniffButton { get { return sniffButton; } }

    public Button BiteButton { get { return biteButton; } }
    public Button SmashButton { get { return smashButton; } }

    public Button PushOrPressButton { get { return pushOrPressButton; } }

    public Button CenterButton1 { get { return centerButton1; } }
    public Button CenterDisableButton1 { get { return centerDisableButton1; } }

    public Button CenterButton2 { get { return centerButton2; } }
    public Button CenterDisableButton2 { get { return centerDisableButton2; } }


    public GameObject InteractButton { get { return interactButton; } }
    public Transform ObserveView { get { return observeView; } } 
    public Transform ObservePlusView { get { return observePlusView; } }

    //public bool ISBiteActive { get { return IsBiteActive; } }




    public bool IsCenterButtonDisabled = false; // true면 첫 번째 가운데 버튼 비활성화
    public bool IsCenterPlusButtonDisabled = false; // true면 두 번째 가운데 버튼 비활성화
    
    public bool IsNotInteractable = false;


    [Header("< 상호작용 시 바뀌는 데이터 목록 (평소에 건드리지 x) >")]
    public bool IsBark = false;
    public bool IsPushOrPress = false;
    public bool IsSniff = false;
    public bool IsBite = false;
    public bool IsSmash = false;
    public bool IsUpDown = false;
    public bool IsEaten = false;
    public bool IsInsert = false;
    public bool IsObserve = false;
    public bool IsObservePlus = false;
    public bool IsCenterButtonChanged = false;
    public bool IsCollision = false; // 책상 올라가려고 추가한 것이다. UpUP, M_C2_FindEnginespaceKey 코드 참고
    public bool IsClicked = false;

  

    Outline outline; // 마우스 오버시 오브젝트 외곽선
    private void Start()
    {
        outline = GetComponent<Outline>(); // 상호작용 오브젝트로부터 아웃라인 컴포넌트를 가져옴
    }

    /* 마우스 오버시 아웃라인 활성화 */
    public void OnMouseOver()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    /* 마우스가 오브젝트로부터 벗어나면 아웃라인 비활성화 */
    public void OnMouseExit()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}

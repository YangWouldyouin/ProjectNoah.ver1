using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    /* 값이 바뀌지 않는 데이터 목록 */
    //public int id;
    //[SerializeField] string objectName;

    [SerializeField] string smellText;

    [SerializeField] Button centerButton; // 가운데 추가행동 : 관찰, 오르기 등, 가운데 버튼 비활성화이면 NoCenterButton 넣으면 됨

    [SerializeField] Button centerPlusButton; // 가운데 버튼 비활성화 상태에서 활성화로 바뀔 때 바뀌는 버튼을 넣으면 됨

    [SerializeField] Button pushOrPressButton; // 물건 옮기기 : PushButton // 버튼 누르기 or 그냥 누르는 애니메이션만 보여줄 때(실제로는 누르기가 안되는 오브젝트일 때) : PressButton

    [SerializeField] Transform observeView;

    [SerializeField] Transform observePlusView;

    [SerializeField] GameObject extraDescription;

    [SerializeField] bool IsPushOrPressActive; // 진짜 누르기,밀기가 가능하면 true, 사실 안되고 그냥 애니메이션만 보여줄거면 false

    [SerializeField] bool IsBiteActive; // 진짜 물기가 가능하면 true, 아니면 false

    // 위 목록을 다른 스크립트에서 쓸 수 있도록 한 것들
    public string SmellText { get { return smellText; } }
    public Button PushOrPressButton { get { return pushOrPressButton; } }
    public Button CenterButton { get { return centerButton; } }
    public Button CenterPlusButton { get { return centerPlusButton; } }
    public Transform ObserveView { get { return observeView; } }
    public Transform ObservePlusView { get { return observePlusView; } }
    public bool ISPushOrPressActive { get { return IsPushOrPressActive; } }
    public bool ISBiteActive { get { return IsBiteActive; } }



    /* 상호작용하면 값이 바뀌는 데이터 목록 */
    public bool IsNotInteractable = false;

    public bool IsBark = false;
    public bool IsPushOrPress = false;
    public bool IsSniff = false;
    public bool IsBite = false;
    public bool IsDestroy = false;

    public bool IsUpDown = false;
    public bool IsInsert = false;
    public bool IsObserve = false;

    public bool IsObservePlus = false;

    public bool IsCenterButtonDisabled = false; // true면 첫 번째 가운데 버튼 비활성화
    public bool IsCenterPlusButtonDisabled = false; // true면 두 번째 가운데 버튼 비활성화
    public bool IsCenterButtonChanged = false;

    public bool IsCollision = false; // 책상 올라가려고 추가한 것이다. UpUP, M_C2_FindEnginespaceKey 코드 참고
}

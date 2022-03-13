using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    //public int id;

    //[SerializeField] string objectName;

    [SerializeField] string smellText;

    [SerializeField] Button centerButton; // 가운데 추가행동 : 관찰, 오르기... 없으면 centerDisable 넣으면 됨

    [SerializeField] Button centerPlusButton;

    [SerializeField] Button pushOrPressButton; // 물건 옮기기 : push, 버튼 누르기or그냥 애니메이션만 보여줄 때 : press 

    [SerializeField] bool IsPushOrPressActive; // 진짜 누르기,밀기가 가능하면 true, 사실 안되고 그냥 애니메이션만 보여줄거면 false

    [SerializeField] bool IsBiteActive; // 진짜 물기가 가능하면 true, 아니면 false

    [SerializeField] Transform observeView;

    [SerializeField] Transform observePlusView;



    public string SmellText { get { return smellText; } }
    public Button PushOrPressButton { get { return pushOrPressButton; } }
    public bool ISPushOrPressActive { get { return IsPushOrPressActive; } }

    public bool ISBiteActive { get { return IsBiteActive; } }
    public Button CenterButton { get { return centerButton; } }
    public Button CenterPlusButton { get { return centerPlusButton; } }
    public Transform ObserveView { get { return observeView; } }
    public Transform ObservePlusView { get { return observePlusView; } }


    public bool IsBark = false;
    public bool IsPushOrPress = false;
    public bool IsSniff = false;
    public bool IsBite = false;
    public bool IsDestroy = false;

    public bool IsUpDown = false;
    public bool IsInsert = false;
    public bool IsObserve = false;
    public bool IsObservePlus = false;
    public bool IsExtraDescriptionActive = false;
    public bool IsCenterButtonChanged = false;

    public GameObject exterDescription;
    
}

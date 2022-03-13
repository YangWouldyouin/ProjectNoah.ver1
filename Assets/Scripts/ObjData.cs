using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    //public int id;

    //[SerializeField] string objectName;

    [SerializeField] string smellText;

    [SerializeField] Button centerButton; // ��� �߰��ൿ : ����, ������... ������ centerDisable ������ ��

    [SerializeField] Button centerPlusButton;

    [SerializeField] Button pushOrPressButton; // ���� �ű�� : push, ��ư ������or�׳� �ִϸ��̼Ǹ� ������ �� : press 

    [SerializeField] bool IsPushOrPressActive; // ��¥ ������,�бⰡ �����ϸ� true, ��� �ȵǰ� �׳� �ִϸ��̼Ǹ� �����ٰŸ� false

    [SerializeField] bool IsBiteActive; // ��¥ ���Ⱑ �����ϸ� true, �ƴϸ� false

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

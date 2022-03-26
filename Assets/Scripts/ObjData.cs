using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    /* ���� �ٲ��� �ʴ� ������ ��� */
    //public int id;
    //[SerializeField] string objectName;

    [SerializeField] string smellText;

    [SerializeField] Button centerButton; // ��� �߰��ൿ : ����, ������ ��, ��� ��ư ��Ȱ��ȭ�̸� NoCenterButton ������ ��

    [SerializeField] Button centerPlusButton; // ��� ��ư ��Ȱ��ȭ ���¿��� Ȱ��ȭ�� �ٲ� �� �ٲ�� ��ư�� ������ ��

    [SerializeField] Button pushOrPressButton; // ���� �ű�� : PushButton // ��ư ������ or �׳� ������ �ִϸ��̼Ǹ� ������ ��(�����δ� �����Ⱑ �ȵǴ� ������Ʈ�� ��) : PressButton

    [SerializeField] Transform observeView;

    [SerializeField] Transform observePlusView;

    [SerializeField] GameObject extraDescription;

    [SerializeField] bool IsPushOrPressActive; // ��¥ ������,�бⰡ �����ϸ� true, ��� �ȵǰ� �׳� �ִϸ��̼Ǹ� �����ٰŸ� false

    [SerializeField] bool IsBiteActive; // ��¥ ���Ⱑ �����ϸ� true, �ƴϸ� false

    // �� ����� �ٸ� ��ũ��Ʈ���� �� �� �ֵ��� �� �͵�
    public string SmellText { get { return smellText; } }
    public Button PushOrPressButton { get { return pushOrPressButton; } }
    public Button CenterButton { get { return centerButton; } }
    public Button CenterPlusButton { get { return centerPlusButton; } }
    public Transform ObserveView { get { return observeView; } }
    public Transform ObservePlusView { get { return observePlusView; } }
    public bool ISPushOrPressActive { get { return IsPushOrPressActive; } }
    public bool ISBiteActive { get { return IsBiteActive; } }



    /* ��ȣ�ۿ��ϸ� ���� �ٲ�� ������ ��� */
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

    public bool IsCenterButtonDisabled = false; // true�� ù ��° ��� ��ư ��Ȱ��ȭ
    public bool IsCenterPlusButtonDisabled = false; // true�� �� ��° ��� ��ư ��Ȱ��ȭ
    public bool IsCenterButtonChanged = false;

    public bool IsCollision = false; // å�� �ö󰡷��� �߰��� ���̴�. UpUP, M_C2_FindEnginespaceKey �ڵ� ����
}

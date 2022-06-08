using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    /* ���� �ٲ��� �ʴ� ������ ��� */
    //public int id;
    [Header("< ������Ʈ ���� >")]
    [SerializeField] string objectName;

    [SerializeField] string smellText;

    [SerializeField] ObjectData objectData;

    [Header("���� ��ġ & ����")]
    [SerializeField] Transform interactionDestination;

    [Header("< ��ȣ�ۿ� ��ư ������ >")]
    [SerializeField] Vector3 buttonOffset;

    [Header("< �⺻ ��ȣ�ۿ� ��ư >")]
    [SerializeField] GameObject interactButton; // ��� ��ư ��Ȱ��ȭ ���¿��� Ȱ��ȭ�� �ٲ� �� �ٲ�� ��ư�� ������ ��

    [SerializeField] Button barkButton;
    [SerializeField] Button sniffButton;

    [SerializeField] Button biteButton;
    [SerializeField] Button smashButton;

    [SerializeField] Button pushOrPressButton;
    
    [Header("< �߰� ��ȣ�ۿ� ��ư >")]
    [SerializeField] Button centerButton1; // ��� �߰��ൿ : ����, ������ ��, ��� ��ư ��Ȱ��ȭ�̸� NoCenterButton ������ ��
    [SerializeField] Button centerDisableButton1;

    [SerializeField] Button centerButton2; // ��� ��ư ��Ȱ��ȭ ���¿��� Ȱ��ȭ�� �ٲ� �� �ٲ�� ��ư�� ������ ��
    [SerializeField] Button centerDisableButton2;


    //[SerializeField] Button pushOrPressButton; // ���� �ű�� : PushButton // ��ư ������ or �׳� ������ �ִϸ��̼Ǹ� ������ ��(�����δ� �����Ⱑ �ȵǴ� ������Ʈ�� ��) : PressButton


    [Header("< ���� �� >")]
    [SerializeField] Transform observeView;

    [SerializeField] Transform observePlusView;

    [Header("< ������ ��ġ >")]
    [SerializeField] Transform upPos;
    [SerializeField] Transform downPos;

    [Header("< ���� ��ġ, ���� >")]
    [SerializeField] Vector3 bitePos;
    [SerializeField] Vector3 biteRot;

    [Header("< �б� ��ġ, ���� >")]
    [SerializeField] Vector3 pushPos;
    [SerializeField] Vector3 pushRot;

    //[SerializeField] bool IsPushOrPressActive; // ��¥ ������,�бⰡ �����ϸ� true, ��� �ȵǰ� �׳� �ִϸ��̼Ǹ� �����ٰŸ� false

    //[SerializeField] bool IsBiteActive; // ��¥ ���Ⱑ �����ϸ� true, �ƴϸ� false

    // �� ����� �ٸ� ��ũ��Ʈ���� �� �� �ֵ��� �� �͵�
    public string ObjectName { get { return objectName; } }
    public string SmellText { get { return smellText; } }
    public ObjectData objectDATA { get { return objectData; } }

    public Transform InteractionDestination { get { return interactionDestination; } }
    public  Vector3 ButtonOffset { get { return buttonOffset; } }
    public GameObject InteractButton { get { return interactButton; } }

    public Button BarkButton { get { return barkButton; } }
    public Button SniffButton { get { return sniffButton; } }

    public Button BiteButton { get { return biteButton; } }
    public Button SmashButton { get { return smashButton; } }

    public Button PushOrPressButton { get { return pushOrPressButton; } }

    public Button CenterButton1 { get { return centerButton1; } }
    public Button CenterDisableButton1 { get { return centerDisableButton1; } }

    public Button CenterButton2 { get { return centerButton2; } }
    public Button CenterDisableButton2 { get { return centerDisableButton2; } }



    public Transform ObserveView { get { return observeView; } } 
    public Transform ObservePlusView { get { return observePlusView; } }

    public Transform UpPos { get { return upPos; } }
    public Transform DownPos { get { return downPos; } }

    //public bool ISBiteActive { get { return IsBiteActive; } }

    public Vector3 BitePos { get { return bitePos; } }
    public Vector3 BiteRot { get { return biteRot; } }

    public Vector3 PushPos { get { return pushPos; } }
    public Vector3 PushRot { get { return pushRot; } }

    public bool IsCenterButtonDisabled = false; // true�� ù ��° ��� ��ư ��Ȱ��ȭ
    public bool IsCenterPlusButtonDisabled = false; // true�� �� ��° ��� ��ư ��Ȱ��ȭ
    public bool IsCenterButtonChanged = false;
    public bool IsNotInteractable = false;

    [Header("< ��ȣ�ۿ� �� �ٲ�� ������ ��� (��ҿ� �ǵ帮�� x) >")]
    public bool IsBark = false;
    public bool IsPushOrPress = false;
    public bool IsSniff = false;
    public bool IsBite = false;
    public bool IsSmash = false;
    public bool IsUpDown = false;
    public bool IsEaten = false;
    public bool IsInsert = false;
    public bool IsObserve = false;
    public bool IsCollision = false; // å�� �ö󰡷��� �߰��� ���̴�. UpUP, M_C2_FindEnginespaceKey �ڵ� ����
    public bool IsClicked = false;



    Outline outline; // ���콺 ������ ������Ʈ �ܰ���
    private void Start()
    {
        outline = GetComponent<Outline>(); // ��ȣ�ۿ� ������Ʈ�κ��� �ƿ����� ������Ʈ�� ������
    }

    /* ���콺 ������ �ƿ����� Ȱ��ȭ */
    public void OnMouseOver()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    /* ���콺�� ������Ʈ�κ��� ����� �ƿ����� ��Ȱ��ȭ */
    public void OnMouseExit()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
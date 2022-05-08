using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_FullEGPad : MonoBehaviour, IInteraction
{
    private Button barkButton, sniffButton, biteButton,
pushButton, smashButton, NoCenterButton;

    ObjData FullEGPad_E;

    /* ��ȣ�ۿ� ������Ʈ */
    public GameObject Tablet_E;
    ObjData TabletData_E;

    private float Charge; // �º� - �����е� �Ÿ� ���

    void Start()
    {
        FullEGPad_E = GetComponent<ObjData>();
        TabletData_E = Tablet_E.GetComponent<ObjData>();


        barkButton = FullEGPad_E.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = FullEGPad_E.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = FullEGPad_E.BiteButton; // ���Ⱑ �Ǵ� ������Ʈ

        //smashButton_M_Box = boxData_M.SmashButton;
        //smashButton_M_Box.onClick.AddListener(OnSmash);

        pushButton = FullEGPad_E.PushOrPressButton;
        pushButton.onClick.AddListener(OnPushOrPress);

        // ��Ȱ��ȭ ��ư�� ��ư�� �������⸸ �Ѵ�. 
        NoCenterButton = FullEGPad_E.CenterButton1;

        GameManager.gameManager._gameData.IsFullChargeTablet = false;
    }
    void DiableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pushButton.transform.gameObject.SetActive(false);
        NoCenterButton.transform.gameObject.SetActive(false);
    }

    void Update()
    {
    }

    public void OnSniff()
    {
        FullEGPad_E.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerSniff();
    }

    public void OnPushOrPress()
    {
        FullEGPad_E.IsSniff = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerPressHand(); // ������ ������ �ִϸ��̼�
    }

    public void OnBark()
    {
        FullEGPad_E.IsBark = true;
        DiableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnBite()
    {
        // throw new System.NotImplementedException();

/*        Charge = Vector3.Distance(Tablet_E.transform.position, FullEGPad_E.transform.position);

        if (Charge <= 100f) // �º��� ����O�е� ���̰� 100f ���� �� ��
        {
            Debug.Log("�����Ϸ�");
            GameManager.gameManager._gameData.IsFullChargeTablet = true; // �º� ���� ��
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }*/
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Tablet_E")
        {
            Debug.Log("�����Ϸ�");
            GameManager.gameManager._gameData.IsFullChargeTablet = true; // �º� ���� ��
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            StartCoroutine(delay1Seconds());
           
        }
    }

    IEnumerator delay1Seconds()
    {
        yield return new WaitForSeconds(3f);
        FullEGPad_E.gameObject.SetActive(false);
    }

    public void OnEat()
    {
    }
    public void OnInsert()
    {
    }
    public void OnObserve()
    {
    }
    public void OnSmash()
    {
    }
    public void OnUp()
    {
    }
}

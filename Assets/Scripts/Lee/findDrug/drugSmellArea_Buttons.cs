using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drugSmellArea_Buttons : MonoBehaviour, IInteraction
{
    public GameObject drugBag;
    ObjData drugBagData;
    Outline drugBagLine;

    public GameObject player;
    public float speed;

    public float smellRange;

    private Button barkButton, sniffButton, biteButton, pressButton, noCenterButton;

    ObjData drugSmellAreaData;

    //public Vector3 areaPos;

    // Start is called before the first frame update
    void Start()
    {
        //오브젝트
        drugBagData = drugBag.GetComponent<ObjData>();
        drugBagLine = drugBag.GetComponent<Outline>();

        drugSmellAreaData = GetComponent<ObjData>();


        //버튼
        barkButton = drugSmellAreaData.BarkButton;
        barkButton.onClick.AddListener(OnBark);

        sniffButton = drugSmellAreaData.SniffButton;
        sniffButton.onClick.AddListener(OnSniff);

        biteButton = drugSmellAreaData.BiteButton;
        biteButton.onClick.AddListener(OnBite);

        pressButton = drugSmellAreaData.PushOrPressButton;
        pressButton.onClick.AddListener(OnPushOrPress);

        noCenterButton = drugSmellAreaData.CenterButton1;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            smellRange = Random.Range(0, 3);

            if (smellRange <= 1)
            {
                drugSmellAreaData.IsNotInteractable = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            //drugSmellAreaData.IsNotInteractable = true;
            CancelInvoke("followDrug");
        }
    }


    void DisableButton()
    {
        barkButton.transform.gameObject.SetActive(false);
        sniffButton.transform.gameObject.SetActive(false);
        biteButton.transform.gameObject.SetActive(false);
        pressButton.transform.gameObject.SetActive(false);
        noCenterButton.transform.gameObject.SetActive(false);
    }

    public void OnBark()
    {
        drugSmellAreaData.IsBark = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerBark();
    }

    public void OnSniff()
    {
        drugSmellAreaData.IsSniff = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerSniff();

        Invoke("followDrug", 2f);

        drugBagData.IsNotInteractable = false;
        drugBagLine.OutlineWidth = 8;
    }


    public void OnPushOrPress()
    {
        drugSmellAreaData.IsPushOrPress = true;
        DisableButton();
        InteractionButtonController.interactionButtonController.playerPressHand();

        StartCoroutine(ChangePressFalse());
    }

    IEnumerator ChangePressFalse()
    {
        yield return new WaitForSeconds(2f);
        drugSmellAreaData.IsPushOrPress = false;
    }

    public void OnBite()
    {
        DisableButton();
        InteractionButtonController.interactionButtonController.PlayerCanNotBite();
    }

    public void OnSmash()
    {

    }

    public void OnEat()
    {
        //throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        //throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        //throw new System.NotImplementedException();
    }

    public void followDrug() //마약 바라보게 하기
    {
        drugSmellAreaData.IsNotInteractable = true;

        Vector3 dir = drugBag.transform.position - player.transform.position;
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }
}

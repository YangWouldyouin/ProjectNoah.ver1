using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class E_Table : MonoBehaviour, IInteraction
{
    Button barkButton_M_Box, sniffButton_M_Box, biteButton_M_Box, pushButton_M_Box, upButton_M_Box;
    ObjData tableData;
    public Vector3 tableRisePos;
    public Transform tablePos;

    // Start is called before the first frame update
    void Start()
    {
        tableData = GetComponent<ObjData>();
        /* 각 상호작용 버튼에 함수를 넣는다 */
        barkButton_M_Box = tableData.BarkButton;
        barkButton_M_Box.onClick.AddListener(OnBark);

        sniffButton_M_Box = tableData.SniffButton;
        sniffButton_M_Box.onClick.AddListener(OnSniff);

        biteButton_M_Box = tableData.BiteButton;
        sniffButton_M_Box.onClick.AddListener(OnBite);

        pushButton_M_Box = tableData.PushOrPressButton;
        pushButton_M_Box.onClick.AddListener(OnPushOrPress);

        upButton_M_Box = tableData.CenterButton1;
        upButton_M_Box.onClick.AddListener(OnUp);
    }
    void DiableButton()
    {
        barkButton_M_Box.transform.gameObject.SetActive(false);
        sniffButton_M_Box.transform.gameObject.SetActive(false);
        biteButton_M_Box.transform.gameObject.SetActive(false);
        pushButton_M_Box.transform.gameObject.SetActive(false);
        upButton_M_Box.transform.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnBark()
    {
        throw new System.NotImplementedException();
    }

    public void OnBite()
    {
        throw new System.NotImplementedException();
    }

    public void OnEat()
    {
        throw new System.NotImplementedException();
    }

    public void OnInsert()
    {
        throw new System.NotImplementedException();
    }

    public void OnObserve()
    {
        throw new System.NotImplementedException();
    }

    public void OnPushOrPress()
    {
        throw new System.NotImplementedException();
    }

    public void OnSmash()
    {
        throw new System.NotImplementedException();
    }

    public void OnSniff()
    {
        throw new System.NotImplementedException();
    }

    public void OnUp()
    {
        DiableButton();
        if (!tableData.IsUpDown)
        {
            PlayerScripts.playerscripts.currentUpObj = this.gameObject;
            tableData.IsUpDown = true;

            tableRisePos.x = tablePos.position.x;
            //boxRisePos.y = transform.position.y;
            tableRisePos.z = tablePos.position.z;

            InteractionButtonController.interactionButtonController.PlayerRise1();
            InteractionButtonController.interactionButtonController.risePosition = tableRisePos;
            InteractionButtonController.interactionButtonController.PlayerRise2();
        }
    }


}

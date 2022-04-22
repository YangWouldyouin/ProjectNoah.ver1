using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_StrangeObj : MonoBehaviour
{
    public GameObject strangeObj;
    ObjData strangeObjData;

    public ParticleSystem smoke;

    public GameObject dialogManager_SObj;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_SObj.GetComponent<DialogManager>();

        strangeObjData = strangeObj.GetComponent<ObjData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameManager._gameData.IsSmoke_T_C3)
        {
            UsingObj();
        }
    }

    public void UsingObj()
    {
        if (strangeObjData.IsBite)
        {
            smoke.GetComponent<Rigidbody>().isKinematic = true;
            smoke.transform.parent = strangeObj.transform;
        }

        if (strangeObjData.IsBite && strangeObjData.IsSmash)
        {
            smoke.GetComponent<Rigidbody>().isKinematic = true;
            smoke.transform.parent = null;
            smoke.transform.localScale = new Vector3(1f, 1f, 1f);

            smoke.Play();

            Invoke("NoObj", 1.5f); 
            Invoke("EndSmoke", 180f);

            //GameManager.gameManager._gameData.IsSmoke_T_C3 = true;
            //SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        }
    }

    public void NoObj()
    {
        strangeObj.GetComponent<Rigidbody>().isKinematic = true;
        strangeObj.transform.parent = null;

        strangeObj.SetActive(false);
    }

    public void EndSmoke()
    {
        Destroy(smoke);
    }    
}

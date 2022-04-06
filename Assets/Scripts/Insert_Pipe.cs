using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Insert_Pipe : MonoBehaviour
{
    public Button insertPipeButton;

    [HideInInspector]
    public GameObject noahInsertObject;

    public GameObject noahInsertModel;
    public Animator noahPipeAnim;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* ³¢¿ì±â */
    void playerInserting()
    {
        noahInsertObject = PlayerScripts.playerscripts.currentObject;
        if (noahInsertObject != null)
        {
            ObjData noahInsertData = noahInsertObject.GetComponent<ObjData>();
            noahInsertData.IsInsert = true;
            InteractionButtonController.interactionButtonController.TurnOffInteractionButton();
            noahInsertModel.transform.position = noahInsertObject.transform.position + new Vector3(1, 0, 1);
            noahInsertModel.transform.rotation = noahInsertObject.transform.rotation;
            Invoke("ChangeInsertTrue", 0.5f);
            //Invoke("ChangeInsertFalse", 2f);
        }
    }

    void ChangeInsertTrue()
    {
        noahPipeAnim.SetBool("IsInserting", true);
    }

    public void ChangeInsertFalse()
    {
        noahPipeAnim.SetBool("IsInserting", false);
    }
}

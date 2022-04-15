using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghfghgfh : MonoBehaviour
{
    public GameObject dialogManager_CWD;
    private DialogManager dialogManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogManager_CWD.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dialogManager.StartCoroutine(dialogManager.PrintAIDialog(3));
        }
    }
}

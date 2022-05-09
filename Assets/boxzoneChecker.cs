using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxzoneChecker : MonoBehaviour
{
    public GameObject box;

    public GameObject dialog;
    DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialog.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == box)
        {
            Debug.Log("박스 준비 완");
            dialogManager.StartCoroutine(dialogManager.PrintSubtitles(17));
        }
    }
}

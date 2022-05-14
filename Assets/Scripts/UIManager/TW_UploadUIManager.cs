using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TW_UploadUIManager : MonoBehaviour
{
    public Text downloadingText;
    public GameObject UploadPage;

    float setTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(UploadPage.activeSelf == true)
        {
            Debug.Log("dd");
            downloadingText.text = "FileUploading " + 0 + "%";

            if (setTime < 99)
            {
                setTime += Time.deltaTime * 70;
            }

            downloadingText.text = "FileUploading " + Mathf.Round(setTime).ToString() + "%";
        }
        else if(UploadPage.activeSelf == false)
        {
            Debug.Log("ss");
            setTime = 0;
            downloadingText.text = "FileUploading " + 0 + "%";
        }
    }
}

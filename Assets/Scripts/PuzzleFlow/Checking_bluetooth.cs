using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checking_bluetooth : MonoBehaviour
{
    // Start is called before the first frame update

    //public GameObject dialogManager_CCB;
    //DialogManager dialogManager;
    
    //public GameObject canConnect;

    public static bool IsCanConnect;

    //public GameObject tablet;

    void Start()
    {
        //dialogManager = dialogManager_CCB.GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.name == "tablet")
        {
            IsCanConnect = true;
            Debug.Log("연결이 가능합니다");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "tablet")
        {
            IsCanConnect = false;
            Debug.Log("연결이 불가능합니당 ㅠㅠ");
        }
    }

}

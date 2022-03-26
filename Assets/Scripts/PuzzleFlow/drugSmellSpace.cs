using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drugSmellSpace : MonoBehaviour
{
    public GameObject canSmellSpace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        if (other.gameObject.name == "Player")
        {
            Debug.Log("충돌함");
            canSmellSpaceData.IsNotInteractable = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        ObjData canSmellSpaceData = canSmellSpace.GetComponent<ObjData>();

        if (other.gameObject.name == "Player")
        {
            Debug.Log("빠져나감");
            canSmellSpaceData.IsNotInteractable = true;
        }
    }
}

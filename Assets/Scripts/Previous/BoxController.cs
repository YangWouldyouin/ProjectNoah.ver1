using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    //public GameObject cover; 

    public Transform currentViewww;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown("b"))
        {
            Vector3 currentAnglle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentViewww.transform.rotation.eulerAngles.x, Time.deltaTime*50),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentViewww.transform.rotation.eulerAngles.y, Time.deltaTime*50),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentViewww.transform.rotation.eulerAngles.z, Time.deltaTime*50));
        
            transform.eulerAngles = currentAnglle;

       



        }
        
    }
}

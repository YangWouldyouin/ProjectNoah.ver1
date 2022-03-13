/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockpitCam : MonoBehaviour
{
public Transform[] viewss;
    public float transitionSpeedd;
    public Transform currentView;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            currentView = viewss[1];

        }
        if(Input.GetMouseButtonDown(1))
        {
            currentView = viewss[0];

        }
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime*transitionSpeedd);
        
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime*transitionSpeedd),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime*transitionSpeedd),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime*transitionSpeedd));
        
        transform.eulerAngles = currentAngle;
  
    }
}
*/

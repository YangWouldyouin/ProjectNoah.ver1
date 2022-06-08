using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlanetRaderController : MonoBehaviour
{
    public Image raderLine_PRL; // 레이더 라인

    public UnityEvent unityEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
            }
        }
    }

    public void OnRaderLeftButtonClicked()
    {
        raderLine_PRL.transform.Rotate(0, 0, 5);
    }

    public void OnRaderRightButtonClicked()
    {
        raderLine_PRL.transform.Rotate(0, 0, -5);
    }
}

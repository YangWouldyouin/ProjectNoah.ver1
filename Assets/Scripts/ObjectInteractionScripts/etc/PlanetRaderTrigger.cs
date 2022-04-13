using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRaderTrigger : MonoBehaviour
{

    public GameObject[] normalPlanet_PR; // 青己
    public GameObject[] selectPlanet_PR; // 急琶茄 青己

    private void OnTriggerEnter(Collider other)
    {

        for (int i = 0; i < 6; i++)
        {
            if (other.gameObject == normalPlanet_PR[i])
            {
                normalPlanet_PR[i].SetActive(false);
                selectPlanet_PR[i].SetActive(true);
        
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < 6; i++)
        {
            if (other.gameObject == selectPlanet_PR[i])
            {
                normalPlanet_PR[i].SetActive(true);
                selectPlanet_PR[i].SetActive(false);
           
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

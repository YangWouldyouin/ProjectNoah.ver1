using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampeTest : MonoBehaviour
{
    bool ismissionstarted = true;
    public InGameTime inGameTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inGameTime.days%3 == 0&& ismissionstarted)
        {
            Debug.Log("mission start");
            StartCoroutine(missoin());
        }          
    }
    IEnumerator missoin()
    {
        yield return new WaitForSeconds(1f);
        ismissionstarted = false;
    }
}

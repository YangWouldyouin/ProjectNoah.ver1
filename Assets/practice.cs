using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class practice : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "noahPlayer")
            SceneManager.LoadScene("new engineRoom 1");
           
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

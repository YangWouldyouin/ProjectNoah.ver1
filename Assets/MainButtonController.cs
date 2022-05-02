using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButtonController : MonoBehaviour
{

    public void OnOpenButtonClicked()
    {
        StartCoroutine(GoToScene());
    }

    IEnumerator GoToScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("new cockpit");
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

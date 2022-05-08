using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUIManager : MonoBehaviour
{
    public GameObject[] EndingScreen;

    public int ListEndingNum = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ListEndingNum = GameManager.gameManager._gameData.EndingNum;

        EndingScreen[ListEndingNum].SetActive(true);
    }

    public void ChangeMainScreen()
    {
        SceneManager.LoadScene("Main");
    }
}

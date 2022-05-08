using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    [SerializeField] Image timerBar;

    public float maxTime = 5f;
    public float timeLeft = 5f;

    public InGameTime inGameTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inGameTime.missionTimer > 0)
        {
            inGameTime.missionTimer -= Time.deltaTime;
            timerBar.fillAmount = inGameTime.missionTimer / maxTime;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {


        }
    }

    public void getscene()
    {
        SceneManager.LoadScene("new livingroom");
    }
}

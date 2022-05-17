using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUIManager : MonoBehaviour
{
    public GameObject[] EndingScreen;

    public int ListEndingNum = 0;

    AudioSource EndingAudio; 
    public AudioClip RealEnding_clip;
    public AudioClip MiniEnding_clip;

    // Start is called before the first frame update
    void Start()
    {
        EndingAudio = GetComponent<AudioSource>();
        RealEnding_clip = GetComponent<AudioClip>();
        MiniEnding_clip = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        ListEndingNum = GameManager.gameManager._gameData.EndingNum;

        EndingScreen[ListEndingNum].SetActive(true);
    }

    public void ChangeMainScreen()
    {
        EndingScreen[ListEndingNum].SetActive(false);
        SceneManager.LoadScene("Main");
    }

    public void PlayBGM()
    {
        if (ListEndingNum == 6)
        {
            EndingAudio.clip = RealEnding_clip;
            EndingAudio.Play();
        }
        else
        {
            EndingAudio.clip = MiniEnding_clip;
            EndingAudio.Play();
        }
    }
}

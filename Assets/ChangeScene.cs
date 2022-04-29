using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    /* 문 클릭 시 이동할 씬*/
    public string transferMapName;

    /*  다른 씬으로 이동하기 전 저장할 오브젝트 이름 */
    public static string BiteObjectName;
    public static string PushObjectName;
    /* 이동하는 씬 이름 */
    public static string moveSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "noahPlayer")
        {
            
            //    if(/* 현재 물고 있는 오브젝트가 있다면 */)
            //    {
            //        // 물고 있는 오브젝트 이름 저장
            //    }
            //    if (/* 현재 밀고 있는 오브젝트가 있다면 */ )
            //    {
            //        // 밀고 있는 오브젝트 이름 저장 
            //    }
            //    // 어디로 이동하는지 저장

            Invoke("ChangePlayerScene", 1f);
        }
    }


    void ChangePlayerScene()
    {
        SceneManager.LoadScene(transferMapName);
    }
}

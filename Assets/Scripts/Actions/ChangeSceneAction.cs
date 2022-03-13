//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class ChangeSceneAction : Actions
//{
//    [SerializeField] string sceneTarget;
//    // Start is called before the first frame update

//    public override void Act()
//    {
        
//        // 이전 씬의 이름을 저장 -> 플레이어 위치 지정에 사용(엔진실 문앞-> 엔진실씬, 생활공간 문 -> 생활공간씬)
//        DataManager.Instance.SetPrevScene(SceneManager.GetActiveScene().name); // 현재 씬의 이름을 가져와서 이전씬 변수에 저장
//        //LevelManager.Instance.SceneLoad(sceneTarget);
//        DataManager.Instance.LevelManager.SceneLoad(sceneTarget);
//    }
//}

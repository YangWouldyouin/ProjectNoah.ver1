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
        
//        // ���� ���� �̸��� ���� -> �÷��̾� ��ġ ������ ���(������ ����-> �����Ǿ�, ��Ȱ���� �� -> ��Ȱ������)
//        DataManager.Instance.SetPrevScene(SceneManager.GetActiveScene().name); // ���� ���� �̸��� �����ͼ� ������ ������ ����
//        //LevelManager.Instance.SceneLoad(sceneTarget);
//        DataManager.Instance.LevelManager.SceneLoad(sceneTarget);
//    }
//}

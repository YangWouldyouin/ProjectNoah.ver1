using UnityEngine;
using UnityEngine.SceneManagement;

public enum CheckMethod
{
    Distance,
    Trigger
}
public class ScenePartLoader : MonoBehaviour
{
    //public GameObject NOAH;
    //public Camera cockpitCamera;

    public Transform player;

    public CheckMethod checkMethod;
    public float loadRange;

    //Scene state
    private bool isLoaded; // let us to avoid loading the scene twice

    private bool shouldLoad; // used for trigger method
    void Start()
    {
        //verify if the scene is already open to avoid opening a scene twice
        if (SceneManager.sceneCount > 0) // SceneManager.sceneCount : 현재 로딩된 씬 개수
        {
            for (int i = 0; i < SceneManager.sceneCount; ++i)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.name == gameObject.name) // 프리팹과 씬 이름을 같게 한 이유
                {
                    isLoaded = true;
                    Debug.Log("isLoaded : " + isLoaded);
                }

            }
        }
        
    }

    void Update()
    {
        //Checking which method to use
        if (checkMethod == CheckMethod.Distance)
        {
            //DistanceCheck();
        }
        else if (checkMethod == CheckMethod.Trigger)
        {
            TriggerCheck();
        }
    }

    //void DistanceCheck()
    //{
    //    //Checking if the player is within the range
    //    if (Vector3.Distance(player.position, transform.position) < loadRange)
    //    {
    //        LoadScene();
    //    }
    //    else
    //    {
    //        UnLoadScene(); // 플레이어가 일정 범위를 벗어나면 씬 삭제
    //    }
    //}

    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldLoad = false;
        }
    }

    void TriggerCheck()
    {
        //shouldLoad is set from the Trigger methods
        if (shouldLoad)
        {
            LoadScene();
        }
        else
        {
            UnLoadScene();
        }
    }

    void LoadScene()
    {
        if (!isLoaded)
        {
            //Loading the scene, using the gameobject name as it's the same as the name of the scene to load
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            //Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            //SceneManager.SetActiveScene(newlyLoadedScene);

            //SceneManager.MoveGameObjectToScene(NOAH, SceneManager.GetSceneByName(gameObject.name));
            //We set it to true to avoid loading the scene twice
            isLoaded = true;
        }
    }

    void UnLoadScene() 
    {
        if (isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }
}
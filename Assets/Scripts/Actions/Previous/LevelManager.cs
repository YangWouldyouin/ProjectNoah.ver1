using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    // canvas 컴포넌트 - sort order 를 1로 해주기(UI 앞에서 랜더링 되도록

    [SerializeField] GameObject panel; // 로딩 패널
    [SerializeField] RectTransform loadBar; 

    private Vector3 barScale = Vector3.one;
    private void Awake()
    {
        // 싱글턴 패턴을 만들지 않을 것임 (데이터 매니저의 자식이므로 다른 씬에서도 유지돰 )
        HidePanel();
    }

    public void SceneLoad(string sceneName)
    {
        StartCoroutine(AsyncLoading(sceneName));
    }

    IEnumerator AsyncLoading(string sceneName) // Async : 비동기, 동시에 일어나지 않는
    {
        ShowPanel(); // 다른씬으로 이동을 시도할 때마다 먼저 로딩바를 보여줌

        yield return new WaitForEndOfFrame(); // 다음 씬이 전부 랜더링 될때까지만 로딩바를 보여줌

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName); // 다음 씬을 불러옴 ??

        while (!asyncLoad.isDone) // 다음씬이 아직 안불러와졌으면
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // asyncLoad.progress 0에서 1사이의 값 반환, 진행양을 로딩바에 반영
            // Clamp01 : 값이 0아래나 1이상이 되지 않게 함
            UpdateBar(progress);

            yield return null;
        }

        HidePanel();
    }

    void UpdateBar(float value) // 앵커는 가운데, 오브젝트 피봇은 왼쪽에 -> rect transform - scale 에서 x 값만 바꾸면 왼쪽에서 오른쪽으로 바 늘어남
    { // shift 누르고 오브젝트 피봇 왼쪽으로 지정, 이후 다시 가운데 눌러서 앵커 가운데 지정
        barScale.x = value;

        loadBar.localScale = barScale;
    }

    void ShowPanel()
    {
        panel.SetActive(true);
    }

    void HidePanel()
    {
        panel.SetActive(false);
    }
}

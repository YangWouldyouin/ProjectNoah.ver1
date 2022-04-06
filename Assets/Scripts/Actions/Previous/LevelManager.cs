using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    // canvas ������Ʈ - sort order �� 1�� ���ֱ�(UI �տ��� ������ �ǵ���

    [SerializeField] GameObject panel; // �ε� �г�
    [SerializeField] RectTransform loadBar; 

    private Vector3 barScale = Vector3.one;
    private void Awake()
    {
        // �̱��� ������ ������ ���� ���� (������ �Ŵ����� �ڽ��̹Ƿ� �ٸ� �������� ������ )
        HidePanel();
    }

    public void SceneLoad(string sceneName)
    {
        StartCoroutine(AsyncLoading(sceneName));
    }

    IEnumerator AsyncLoading(string sceneName) // Async : �񵿱�, ���ÿ� �Ͼ�� �ʴ�
    {
        ShowPanel(); // �ٸ������� �̵��� �õ��� ������ ���� �ε��ٸ� ������

        yield return new WaitForEndOfFrame(); // ���� ���� ���� ������ �ɶ������� �ε��ٸ� ������

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName); // ���� ���� �ҷ��� ??

        while (!asyncLoad.isDone) // �������� ���� �Ⱥҷ���������
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // asyncLoad.progress 0���� 1������ �� ��ȯ, ������� �ε��ٿ� �ݿ�
            // Clamp01 : ���� 0�Ʒ��� 1�̻��� ���� �ʰ� ��
            UpdateBar(progress);

            yield return null;
        }

        HidePanel();
    }

    void UpdateBar(float value) // ��Ŀ�� ���, ������Ʈ �Ǻ��� ���ʿ� -> rect transform - scale ���� x ���� �ٲٸ� ���ʿ��� ���������� �� �þ
    { // shift ������ ������Ʈ �Ǻ� �������� ����, ���� �ٽ� ��� ������ ��Ŀ ��� ����
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

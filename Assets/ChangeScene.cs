using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    /* �� Ŭ�� �� �̵��� ��*/
    public string transferMapName;

    /*  �ٸ� ������ �̵��ϱ� �� ������ ������Ʈ �̸� */
    public static string BiteObjectName;
    public static string PushObjectName;
    /* �̵��ϴ� �� �̸� */
    public static string moveSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "noahPlayer")
        {
            
            //    if(/* ���� ���� �ִ� ������Ʈ�� �ִٸ� */)
            //    {
            //        // ���� �ִ� ������Ʈ �̸� ����
            //    }
            //    if (/* ���� �а� �ִ� ������Ʈ�� �ִٸ� */ )
            //    {
            //        // �а� �ִ� ������Ʈ �̸� ���� 
            //    }
            //    // ���� �̵��ϴ��� ����

            Invoke("ChangePlayerScene", 1f);
        }
    }


    void ChangePlayerScene()
    {
        SceneManager.LoadScene(transferMapName);
    }
}

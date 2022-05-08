using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager._gameData.statNum <=0)
        {
            GameManager.gameManager._gameData.IsSuddenDeath = true;
            // ���� ���� ���� ; ui 5�ʰ� ���ٰ� ������� �����
            // ���� 50���� ���ϰ� �ϰ�
            // ���ȹ� ���ݸ� �� ���ϰ� �ϱ�
        }

        if (GameManager.gameManager._gameData.IsInputImportantMeteorEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 0;
            //Ư�� � ���� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsMakeForestEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 1;
            //���°豸�࿣��
            //����, ��� ����Ʈ ���� ���� (���� ����)
            SceneManager.LoadScene("EndingScene");
        }

        if (GameManager.gameManager._gameData.IsReportCancleCount >= 3)
        {
            GameManager.gameManager._gameData.IsDefyMissionEnd = true;
            Debug.Log("Game Over");

            GameManager.gameManager._gameData.EndingNum = 2;
            //��� �Һ��� ����
            // ����, ��� ����Ʈ ���� ����
            SceneManager.LoadScene("EndingScene");
            // ����Ʈ ���� ���������� �̵�
            // ���� ����
        }

        if (GameManager.gameManager._gameData.IsDisqualifiedEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 3;
            //������� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsDiscardNoahEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 4;
            //����ü ��� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 5;
            //����� ���� �ϳ� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 6;
            //����� ���� ���� ����, ������, ���O
            //����, ��� ����Ʈ ���� ���� (���� ����)
            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

    }
}

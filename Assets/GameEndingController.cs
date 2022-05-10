using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingController : MonoBehaviour
{
    public InGameTime inGameTime;

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
            GameManager.gameManager._gameData.IsManagerAbilityLack = true;
            
            GameManager.gameManager._gameData.statNum = 5;
        }

        if (GameManager.gameManager._gameData.IsInputImportantMeteorEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 0;
            //Ư�� � ���� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�

        }

        if (GameManager.gameManager._gameData.IsMakeForestEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 1;
            //���°豸�࿣��
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
        }

        if (GameManager.gameManager._gameData.IsReportCancleCount >= 3)
        {
            GameManager.gameManager._gameData.IsDefyMissionEnd = true;
            Debug.Log("Game Over");

            GameManager.gameManager._gameData.EndingNum = 2;
            //��� �Һ��� ����
            // ����, ��� ����Ʈ ���� ����
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            // ����Ʈ ���� ���������� �̵�
            // ���� ����
        }

        if (GameManager.gameManager._gameData.IsDisqualifiedEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 3;
            //������� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsDiscardNoahEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 4;
            //����ü ��� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 5;
            //����� ���� �ϳ� ����
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if (GameManager.gameManager._gameData.IsSaveAllEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 6;
            //����� ���� ���� ����, ������, ���O
            //����, ��� ����Ʈ ���� ���� (���� ����)
            GameManager.gameManager._gameData.statNum = 10;

            inGameTime.days = 0;
            inGameTime.hours = 0;
            inGameTime.timer = 0;

            SceneManager.LoadScene("EndingScene");
            //���� �� �̵�
        }

        if(GameManager.gameManager._gameData.IsReturnOfTheEarth == false && GameManager.gameManager._gameData.IsFakeCoordinateDatafile_Tablet)
        {
            GameManager.gameManager._gameData.IsSaveOnlyOneEnd = true;
        }

        if (GameManager.gameManager._gameData.IsReturnOfTheEarth)
        {
            GameManager.gameManager._gameData.IsSaveAllEnd = true;
        }

    }
}

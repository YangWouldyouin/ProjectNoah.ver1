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
            // 스탯 게임 오버 ; ui 5초간 떴다가 사라지고 재시작
            // 스탯 50으로 변하게 하고
            // 스탯바 절반만 색 변하게 하기
        }

        if (GameManager.gameManager._gameData.IsInputImportantMeteorEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 0;
            //특별 운석 보고 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

        if (GameManager.gameManager._gameData.IsMakeForestEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 1;
            //생태계구축엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            SceneManager.LoadScene("EndingScene");
        }

        if (GameManager.gameManager._gameData.IsReportCancleCount >= 3)
        {
            GameManager.gameManager._gameData.IsDefyMissionEnd = true;
            Debug.Log("Game Over");

            GameManager.gameManager._gameData.EndingNum = 2;
            //명령 불복종 엔딩
            // 스탯, 취소 리포트 개수 리셋
            SceneManager.LoadScene("EndingScene");
            // 리포트 게임 엔딩씬으로 이동
            // 게임 오버
        }

        if (GameManager.gameManager._gameData.IsDisqualifiedEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 3;
            //인재부족 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

        if (GameManager.gameManager._gameData.IsDiscardNoahEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 4;
            //실험체 폐기 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 5;
            //당신이 구한 하나 엔딩
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

        if (GameManager.gameManager._gameData.IsSaveOnlyOneEnd == true)
        {
            GameManager.gameManager._gameData.EndingNum = 6;
            //당신이 구한 전부 엔딩, 진엔딩, 고발O
            //스탯, 취소 리포트 개수 리셋 (게임 리셋)
            SceneManager.LoadScene("EndingScene");
            //엔딩 씬 이동
        }

    }
}

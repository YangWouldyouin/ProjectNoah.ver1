using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelGameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager._gameData.IsReportCancleCount>=3)
        {
            Debug.Log("Game Over");
            // 리포트 게임 엔딩씬으로 이동
            // 게임 오버
            // 스탯, 취소 리포트 개수 리셋
            
        }


        if(GameManager.gameManager._gameData.statNum <=0)
        {
            GameManager.gameManager._gameData.IsSuddenDeath = true;
            // 스탯 게임 오버 ; ui 5초간 떴다가 사라지고 재시작
            // 스탯 50으로 변하게 하고
            // 스탯바 절반만 색 변하게 하기
        }
    }
}

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
            // ����Ʈ ���� ���������� �̵�
            // ���� ����
            // ����, ��� ����Ʈ ���� ����
            
        }


        if(GameManager.gameManager._gameData.statNum <=0)
        {
            GameManager.gameManager._gameData.IsSuddenDeath = true;
            // ���� ���� ���� ; ui 5�ʰ� ���ٰ� ������� �����
            // ���� 50���� ���ϰ� �ϰ�
            // ���ȹ� ���ݸ� �� ���ϰ� �ϱ�
        }
    }
}

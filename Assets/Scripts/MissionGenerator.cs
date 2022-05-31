using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionGenerator : MonoBehaviour
{
    public static MissionGenerator missionGenerator { get; private set; }

    //public List<string> missionList;

    public Dictionary<int, string> missionDic = new Dictionary<int, string>();

    public List<string> missionList = new List<string>();
    public GameObject missionPanel;

    public bool IsOn = false;
    public GameObject missionmom;
    TMPro.TextMeshProUGUI textget;

    private void Awake()
    {
        missionGenerator = this;
    }
    private void Start()
    {
        //튜토리얼
        missionDic.Add(0, "AI 활성화");
        missionDic.Add(1, "업무공간 진입");

        //메인_공간 해금
        missionDic.Add(2, "생활공간 카드키 탐색");
        missionDic.Add(3, "엔진실 카드키 탐색");
        missionDic.Add(4, "생활공간 진입");
        missionDic.Add(5, "엔진실 진입");

        //메인_스토리진행
        missionDic.Add(6, "소리의 근원 찾기");
        missionDic.Add(7, "태블릿 잠금 해제");
        missionDic.Add(8, "고발 자료 다운로드");
        missionDic.Add(9, "AI 다운 시키기");
        missionDic.Add(10, "칩 용도 파악");
        missionDic.Add(11, "사망 상태로 위장하기");
        missionDic.Add(12, "지구로 향하기");

        //임무_냄새로 고치기 관련
        missionDic.Add(13, "상태 체크 기계 수리");
        missionDic.Add(14, "노아 생체 데이터 보고");
        missionDic.Add(15, "쓰레기 배출구 수리");
        missionDic.Add(16, "엔진 연료 주입구 수리");

        //임무_스마트팜 관련
        missionDic.Add(17, "스마트팜 수리");
        missionDic.Add(18, "영양분 섭취");
        missionDic.Add(19, "식물 배양 연구");
        missionDic.Add(20, "배양 실험 결과 보고");
        missionDic.Add(21, "영양제 투약");

        //기타 임무
        missionDic.Add(22, "운석 분석 데이터 보고");
        missionDic.Add(23, "선전용 사진 촬영");

        //상반된 퍼즐_마약 탐지 & 이상한 물건 발견
        missionDic.Add(24, "냄새의 근원 찾기");
        missionDic.Add(25, "약물 분석");
        missionDic.Add(26, "약물 처리");
        missionDic.Add(27, "물건 용도 파악");

        //상반된 퍼즐_더미 데이터 보고
        missionDic.Add(28, "메인 컴퓨터와 태블릿 연결");
        missionDic.Add(29, "더미 데이터 보고");

        missionDic.Add(30, "엔진실 문 고치기");

        //행선지 좌표 설정
        missionDic.Add(31, "행선지 설정");
        missionDic.Add(32, "궤도 시스템 교란");
        missionDic.Add(33, "거짓 행선지 설정");

        //if (GameManager.gameManager._gameData.S_IsAIAwake_M_C1)
        //{
        //    missionList.Add(missionDic[0]);
        //}
        //else if(GameManager.gameManager._gameData.S_IsCWDoorOpened_M_C1)
        //{
        //    missionList.Add(missionDic[1]);
        //}
        //else if(GameManager.gameManager._gameData.S_IsHealthMachineFixed_T_C2)
        //{
        //    missionList.Add(missionDic[2]);
        //}
    }




    public void ShowMissionList()
    {
        /* 여기에 버튼 사운드 넣으면 됩니다 */
        missionList.Clear();

        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }

        if (!IsOn)
        {
            for (int k = 0; k < GameManager.gameManager._gameData.ActiveMissionList.Length; k++)
            {
                if (GameManager.gameManager._gameData.ActiveMissionList[k] )
                {
                    missionList.Add(missionDic[k]);
                }
            }
            StartCoroutine(PrintMissionList());

            IsOn = true;
        }
        else
        {

            foreach (Transform child in missionmom.transform)
            {
                Destroy(child.gameObject);
            }

            IsOn = false;
        }
        //if (missionList.Count!=0)
        //{

//&& !GameManager.gameManager._gameData.EndMissionList[k]
        //}

    }

    IEnumerator PrintMissionList()
    {
        for (int i = 0; i < missionList.Count; i++)
        {
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
            textget = newMission.GetComponentInChildren<TMPro.TextMeshProUGUI>();

            StartCoroutine(_typing(missionList[i]));
            //textget.text = missionList[i];
            newMission.transform.SetParent(GameObject.FindGameObjectWithTag("aa").transform, false);

            newMission.SetActive(true);
            yield return new WaitForSeconds(0.8f);
        }
        yield return new WaitForSeconds(10f);
        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
    }


    IEnumerator _typing(string data)
    {
        //yield return new WaitForSeconds(2f);
        for (int i = 0; i <= data.Length; i++)
        {
            textget.text = data.Substring(0, i);

            yield return new WaitForSeconds(0.05f);
        }

    }
    public void ActivateMissionList()
    {
        IsOn = false;
        ShowMissionList();
    }
}

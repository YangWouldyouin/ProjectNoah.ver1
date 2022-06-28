using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionGenerator : MonoBehaviour
{
    public static MissionGenerator missionGenerator { get; private set; }

    Dictionary<int, string> missionDic = new Dictionary<int, string>();

    List<GameObject> missionPanelList = new List<GameObject>();
    List<string> missionNameList = new List<string>();
    List<TMPro.TextMeshProUGUI> missionText = new List<TMPro.TextMeshProUGUI>();

    public GameObject missionmom;
    public GameObject missionPanel;
    public GameObject newMissionPanel;

    TMPro.TextMeshProUGUI textget;
    Animator missionAnim;
    Image[] newMissionImage;
    public Sprite newMissionSprite;
    public Sprite currentMissionSprite;

    public bool IsOn = false;
    bool IsPrintingFinish = false;
    GameData currentData;

    private void Awake()
    {
        missionGenerator = this;
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
    }

    /* 새 미션 추가하는 함수 */
    public void AddNewMission(int newMissionNum)
    {
        currentData = SaveSystem.Load("save_001");
        StartCoroutine(PrintCurrentMissionList(newMissionNum, AddNew(newMissionNum)));
    }

    IEnumerator AddNew(int newMissionNum) // 새 미션 추가 
    {
        // 기존 미션 목록이 다 출력될때까지 기다림
        while (!IsPrintingFinish)
        {
            yield return null;
        }

        if (!currentData.ActiveMissionList[newMissionNum]) // missionDic[newMissionNum] 이 이미 추가되기전이면
        {
            // 기존 미션 패널 리스트의 맨 마지막에 패널 하나 추가
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            GameObject newMissionBack = Instantiate(newMissionPanel, new Vector3(0, 13.25f - missionNameList.Count * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(newMission);
            newMissionBack.transform.SetParent(missionmom.transform, false);
            newMission.transform.SetParent(missionmom.transform, false);
            missionText.Add(newMission.GetComponentInChildren<TMPro.TextMeshProUGUI>());

            newMissionImage = missionPanelList[missionNameList.Count].GetComponentsInChildren<Image>();
            newMissionImage[1].sprite = newMissionSprite;

            /* 새 미션 추가 애니메이션 */
            missionPanelList[missionNameList.Count].SetActive(true);
            Animator addMission1Anim = newMissionBack.GetComponentInChildren<Animator>();
            Animator addMissionAnim = missionPanelList[missionNameList.Count].GetComponentInChildren<Animator>();
            addMissionAnim.SetBool("IsOpening1", true);
            addMissionAnim.SetBool("IsOpening2", true);



            //addMissionAnim.SetBool("IsOpening3", true);

            textget = missionPanelList[missionNameList.Count].GetComponentInChildren<TMPro.TextMeshProUGUI>();
            // textget.color = new Color32(238, 192, 230, 255);

            /* 새 미션도 기존 미션 리스트에 추가 */
            missionNameList.Add(missionDic[newMissionNum]);
            StartCoroutine(_typing(missionNameList[missionNameList.Count - 1], missionNameList.Count-1));
            yield return new WaitForSeconds(1f);
            addMissionAnim.SetBool("IsNewMissionStart", true);
            newMissionBack.SetActive(true);
            addMission1Anim.SetBool("IsOpening1", true);
            addMission1Anim.SetBool("IsOpening2", true);

            yield return new WaitForSeconds(10f);
            GameManager.gameManager._gameData.ActiveMissionList[newMissionNum] = true;
            SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
            IsPrintingFinish = false;
        }
        else // missionDic[newMissionNum] 이 이미 추가되었으면
        {
            while (!IsPrintingFinish)
            {
                yield return null;
            }
            yield return new WaitForSeconds(10f);
            IsPrintingFinish = false;
        }
    }

    // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 완료한 미션 삭제하는 함수 */
    public void DeleteNewMission(int deleteMissionNum)
    {
        currentData = SaveSystem.Load("save_001");
        StartCoroutine(PrintCurrentMissionList(deleteMissionNum, DeleteMission(deleteMissionNum)));
    }

    IEnumerator DeleteMission(int deleteMissionNum) // 완료 미션 삭제
    {
        // 기존 미션 목록이 다 출력될때까지 기다림
        while (!IsPrintingFinish)
        {
            yield return null;
        }
        int idx = missionNameList.FindIndex(a => a.Contains(missionDic[deleteMissionNum]));
        newMissionImage = missionPanelList[idx].GetComponentsInChildren<Image>();
        Animator addMissionAnim = missionPanelList[idx].GetComponentInChildren<Animator>();
        // 완료한 미션 삭제 
        yield return new WaitForSeconds(2f);

        //newMissionImage[1].sprite = newMissionSprite;
        //Animator addMission1Anim = newMissionBack.GetComponentInChildren<Animator>();

        addMissionAnim.SetBool("IsOpening1", true);
        addMissionAnim.SetBool("IsOpening2", true);

        //StartCoroutine(_typing(missionNameList[missionNameList.Count - 1], missionNameList.Count - 1));
        yield return new WaitForSeconds(2f);
        addMissionAnim.SetBool("IsNewMissionStart", true);
        missionText[idx].text = "";
        yield return new WaitForSeconds(1f);
        missionPanelList[idx].SetActive(false);

        //newMissionBack.SetActive(true);
        //addMission1Anim.SetBool("IsOpening1", true);
        //addMission1Anim.SetBool("IsOpening2", true);

        yield return new WaitForSeconds(10f);

        GameManager.gameManager._gameData.ActiveMissionList[deleteMissionNum] = false;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
        IsPrintingFinish = false;
    }

    // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

    /* 미션 목록 버튼 눌렸을때 함수 */
    public void ShowMissionList()
    {
        currentData = SaveSystem.Load("save_001");

        /* 여기에 버튼 사운드 넣으면 됩니다 */
        missionNameList.Clear();
        missionPanelList.Clear();
        missionText.Clear();

        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
        missionmom.SetActive(true);

        if (!IsOn)
        {
            for (int k = 0; k < GameManager.gameManager._gameData.ActiveMissionList.Length; k++)
            {
                if (currentData.ActiveMissionList[k] )
                {
                    missionNameList.Add(missionDic[k]);
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
    }

    IEnumerator PrintMissionList()
    {
        // 현재 미션 개수만큼 패널 생성 
        for (int i = 0; i < missionNameList.Count; i++)
        {
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(newMission);
            missionText.Add(newMission.GetComponentInChildren<TMPro.TextMeshProUGUI>());
            newMission.transform.SetParent(missionmom.transform, false);
        }

        // 미션 애니메이션
        for(int j=0; j< missionNameList.Count; j++)
        {
            missionPanelList[j].SetActive(true);
            Animator missionAnim = missionPanelList[j].GetComponentInChildren<Animator>();
            missionAnim.SetBool("IsOpening1", true);
            missionAnim.SetBool("IsOpening2", true);
        }

        // 미션 출력
        for (int k = 0; k < missionNameList.Count; k++)
        {
            StartCoroutine(_typing(missionNameList[k], k));
        }

        yield return new WaitForSeconds(10f);
        missionmom.SetActive(false);
    }

    public void ActivateMissionList() // 새 미션 추가로 옮기기 
    {
        IsOn = false;
        ShowMissionList();
    }     

    IEnumerator _typing(string data, int missionIndex)
    {
        for (int i = 0; i <= data.Length; i++)
        {
            missionText[missionIndex].text = data.Substring(0, i);
            //textget.text = data.Substring(0, i);
            yield return new WaitForSeconds(0.0005f);
        }
    }

    IEnumerator PrintCurrentMissionList(int newMissionNum, IEnumerator AddOrDelete)  // 기존 미션 목록들 출력 
    {
        // 이전 목록 삭제
        missionNameList.Clear();  // 여기에 버튼 사운드 넣으면 됩니다
        missionPanelList.Clear();
        missionText.Clear();
        foreach (Transform child in missionmom.transform)
        {
            Destroy(child.gameObject);
        }
        missionmom.SetActive(true);

        // 현재 활성화된 미션들을 가져옴
        for (int k = 0; k < GameManager.gameManager._gameData.ActiveMissionList.Length; k++)
        {
            if (currentData.ActiveMissionList[k])
            {
                missionNameList.Add(missionDic[k]);
            }
        }

        // 현재 활성화된 미션 개수만큼 패널 생성
        for (int i = 0; i < missionNameList.Count; i++)
        {
            GameObject currentMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
            missionPanelList.Add(currentMission);
            missionText.Add(currentMission.GetComponentInChildren<TMPro.TextMeshProUGUI>());
            currentMission.transform.SetParent(missionmom.transform, false);
        }

        // 패널 애니메이션
        for (int j = 0; j < missionNameList.Count; j++)
        {
            missionPanelList[j].SetActive(true);
            Animator missionAnim = missionPanelList[j].GetComponentInChildren<Animator>();
            missionAnim.SetBool("IsOpening1", true);
            missionAnim.SetBool("IsOpening2", true);
            yield return null;
        }

        // 기존 미션들 출력
        for (int r = 0; r < missionNameList.Count; r++)
        {
            StartCoroutine(_typing(missionNameList[r], r));
        }

        IsPrintingFinish = true;
        StartCoroutine(AddOrDelete);
    }
}

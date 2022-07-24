using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabletDiaryUIManager : MonoBehaviour
{
    public GameObject Diary;
    public Text PageNum;

    public GameObject[] DiaryList;

    public int CurrentPageNum;

    public Text Secret1;
    public Text Secret2;
    public Text Secret3;
    public Text Secret4;
    public Text Secret5;
    public Text Secret6;

    // Start is called before the first frame update
    void Start()
    {
        CurrentPageNum = 1;

        DiaryList[CurrentPageNum-1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 && GameManager.gameManager._gameData.IsPlanetSelectMission && GameManager.gameManager._gameData.IsDollListen && GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 && GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L1 && GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2)
        {
            GameManager.gameManager._gameData.IsAIVSMissionFinish = true;
        }

        PageNum.text = CurrentPageNum + "/11";

        if (GameManager.gameManager._gameData.IsHealthMachineFixed_T_C2 == false)
        {
            Secret1.text = "다운로드 진행 중...";
        }

        else
        {
            Secret1.text = "선내 굴러다니는 칩을 개조해 재밌는 물건을 만들었다." + "\n" + "일명 교란칩." + "\n" + "이름 그대로 교란을 일으키는 물건으로, 기기의 포트에 꽂기만 한다면 대부분의 시스템에 오류를 발생시킬 수 있다." + "\n"
                + "아무리 기기에 문외한인 사람이더라도 이런 물건을 본다면 의심하겠지." + "\n" + "들키면 변명조차 못하고 빼앗길 것이 분명하다." +"\n" + "때문에 다른 정상적인 칩들과 함께 모아 숨겨 두었다.";
        }

        if (GameManager.gameManager._gameData.IsPlanetSelectMission == false)
        {
            Secret2.text = "다운로드 진행 중...";
        }

        else
        {
            Secret2.text = "교란칩 ver.2를 만들었다. (여전히 직설적인 이름이네.)" + "\n" + "마이크의 통신 데이터칩을 몰래 훔쳐서…" + "\n" + "아침에 칩을 잃어버렸다고 울상이길래 점심시간 동안 빠르게 손을 보고 다시 돌려 놓았다." + "\n" 
                + "저녁 즈음 슬쩍 떠보니 아직 알아채지는 못한 것 같다." + "\n" + "말이 많은 것과는 달리 둔한 편이다." + "\n" + "아무튼 이 교란칩을 통해선 존재하지 않는 행성을 목적지로 설정할 수 있다." + "\n" + "이렇게 가상의 행성들을 여러 번 거쳐 선회하면 레비젼에게 들키지 않고 원하는 곳을 향할 수 있다." + "\n" + "이를테면 지구라던지.";
        }

        if (GameManager.gameManager._gameData.IsDollListen == false)
        {
            Secret3.text = "다운로드 진행 중...";
        }
        else
        {
            Secret3.text = "우주선이 향할 행선지는 조종실의 궤도 추적 시스템이 설정해둔 행성으로만 설정이 가능하다." + "\n" + "이를 임의로 바꾸기 위해서는 조종실 시스템에 오류를 발생시키고 강제로 행선지 값을 수정하는 수밖에 없다." + "\n"
                + "조종실 시스템은 조종기 하단에 위치하는 포트를 열어 접근할 수 있었다." + "\n" + "이 모든 일에 내가 엔지니어인 것은 큰 도움이 됐다." + "\n" + "대놓고 수상한 짓을 해도 수리를 핑계로 들면 다들 의심을 거두니까.";
        }

        if (GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 == false)
        {
            Secret4.text = "다운로드 진행 중...";
        }
        else
        {
            Secret4.text = "수잔이 점심시간에 조심히 찾아왔다." + "\n" + "\n" + "정기 건강 검진 결과에 대한 것인데, 마이크의 체내에서 꾸준히 마약성 물질이 검출되고 있다는 것이다." + "\n" + "저번에 샐비어가 우연으로 만들어 낸 마약성 물질이 도난 당한 것 같다 했는데 그 범인이 마이크였던 모양이다." + "\n"
                + "수잔은 이 사실에 레비젼에 알려지길 바라지 않았다." + "\n" + "수잔은 까칠한 척 보여도 사실 동료들을 걱정하는 인물이니까…" + "\n" + "나는 마이크 녀석이 정신차릴 때가 되었다 생각하지만 수잔을 위해 방법을 찾아보기로 했고, 샐비어도 돕기로 하였다." + "\n" + "\n" + "샐비어가 해독 방법을 찾았다."
                + "무언가 열심히 설명해주었는데 솔직히 이 분야는 내 전문이 아니어서 기억이 잘 안 난다." + "\n" + "대충 오렌지 향기가 나는 약물을 함께 섞으면 중화된다 한 것 같다." + "\n" + "수잔은 고마워하며 당장 마이크의 뒷덜미를 잡고 긴 설교를 시작했다." + "\n" + "나도 수잔에게 걸리지 않도록 조심해야 겠다.";
        }

        if (GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L1 == false)
        {
            Secret5.text = "다운로드 진행 중...";
        }
        else
        {
            Secret5.text = "샐비어의 도움을 받아 레비젼이 저지른 만행을 기록할 수 있었다." + "\n" + "이 기록에는 현재까지의, 탐사 초기를 제한 거의 모든 반윤리적인 행위에 대한 내용이 담겨있다." + "\n" + "이것만 있다면 ‘위대한 선구자’인 레비젼도 큰 타격을 받을 수 밖에 없을 것이다." + "\n"
                + "고발을 위한 준비는 모두 끝냈다." + "\n" + "언론인이라는 샐비어의 동생에게 이 파일을 보내기만 한다면 그 후 일은 무사히 풀릴 것이다. 그래, 이 파일을 지구로 무사히 보낼 수만 있다면…" + "\n" +"자료는 업무공간의 컴퓨터에 담겨 있다." + "\n" + "문제는 지구로 자료를 보낼 수 있는 통신 기능을 갖춘 곳은 조종실 뿐이란 것이다." + "\n" + "문제는 지구로 자료를 보낼 수 있는 통신 기능을 갖춘 곳은 조종실 뿐이고, 자료는 업무공간의 컴퓨터에 담겨 있다는 것이다." + "\n" + "무선 연결로 파일을 전송하기엔 둘 사이의 거리가 너무 멀다."
                + "\n" + "귀환까지는 시간이 남아있고, 아직까진 회사도 나를 대놓고 의심하진 않으니 이 기회를 놓치기 전에 빨리 방법을 찾아야겠다." + "\n" + "+" + "\n" + "저녁을 먹고서 다른 동료들은 모두 개인 시간을 가지느라 바쁜 틈을 타 샐비어에게 고민을 토로하였다." + "\n" + "그러자 타블렛을 이용해보라는 의견을 주었다. 나쁘지 않은 생각인 것 같다." +"\n" + "타블렛의 무선연결 기능을 활용하면 멀리서도 데이터를 주고 받을 수 있을테니까." + "\n" + "누구 여친이길래 이렇게 똑똑하고 사랑스러운 것인지.";
        }

        if (GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 == false)
        {
            Secret6.text = "다운로드 진행 중...";
        }
        else
        {
            Secret6.text = "항상 그렇듯, 오늘도 수리를 핑계로 대며 시스템을 살짝 손보았다." + "\n" + "시스템 설정 권한은 나에게 있어 보안 설정도 건들 수 있었다." + "\n" + "물론 아주 사소한 옵션만 변경할 수 있었지만 이것이 어딘가 싶다." + "\n"
                + "나중에 이 사실이 밝혀진다면 나에게 기술자 직책을 부여한 인사팀은 아주 속이 터질 것이다." + "\n" + "\n" + "변경한 설정 덕분에 내 태블릿을 통한 무선 연결은 회사의 추적을 피할 수 있게 되었다." + "\n" + "태블릿을 엔진실 밖으로 이동시키지 못해 걸린 제약들이 많았는데 이젠 좀 더 대담하게 작업할 수 있을 것이다." + "\n" + "엔진실 내에선 메인 컴퓨터와 연결이 가능한 것 같다. 벽 하나를 둔 거리이기 때문일 것이다."
                + "\n" + "무선 연결 방법은 매우 간단하여, 태블릿의 무선 연결 버튼을 누르기만 하면 된다.";
        }

    }

    public void NextBT()
    {
        if (CurrentPageNum < 11)
        {
            CurrentPageNum += 1;
            DiaryList[CurrentPageNum - 2].SetActive(false);
            DiaryList[CurrentPageNum - 1].SetActive(true);
        }
    }

    public void PrevBT()
    {
        if (CurrentPageNum > 1)
        {
            CurrentPageNum -= 1;
            DiaryList[CurrentPageNum-1].SetActive(true);
            DiaryList[CurrentPageNum].SetActive(false);
        }
    }
}

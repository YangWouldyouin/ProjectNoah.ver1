using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_ReportUIManager : MonoBehaviour
{
    /* 오브젝트 */
    // 좌우 버튼
    public GameObject RightButton_Rep;
    public GameObject LeftButton_Rep;

    public string[] Title_Rep; // 제목
    public string[] Writer_Rep; // 작성자
    public string[] Day_Rep; // 작성일자
    public string[] Detail_Rep; // 내용

    public Text TitleText_Rep;
    public Text WriterText_Rep;
    public Text DayText_Rep;
    public Text DetailText_Rep;
    public Text PageNum_Rep; // 페이지넘버

    public int r = 0;

    void Start()
    {
        /* 제목 */
        Title_Rep[0] = "[식물 성장 촉진제 개선]";
        Title_Rep[1] = "[미확인 물질이 포함된 운석 발견]";
        Title_Rep[2] = "[생체 반응 최소화 약물]";
        Title_Rep[3] = "[환각 반응 유도 약물]";

        /* 작성자 */
        Writer_Rep[0] = "작성자: 샐비어 그레이_ RVS30020";
        Writer_Rep[1] = "작성자: 코츠 트렐러니_RVS30004";
        Writer_Rep[2] = "작성자: 샐비어 그레이_ RVS30020";
        Writer_Rep[3] = "작성자: 샐비어 그레이_ RVS30020";

        /* 작성일자 */
        Day_Rep[0] = "작성 일자: 2XXX.XX.XX";
        Day_Rep[1] = "작성 일자: 2XXX.XX.XX";
        Day_Rep[2] = "작성 일자: 2XXX.XX.XX / 최종 수정 일자: 2XXX.XX.XX";
        Day_Rep[3] = "작성 일자: 2XXX.XX.XX / 최종 수정 일자: 2XXX.XX.XX";

        /* 내용 */
        Detail_Rep[0] = "이번 탐사를 통해 발견한 약품 X에 대해 추가 연구를 진행해야 한다. 기존의 식물 성장 촉진제 Y에 약품 X를 섞어\n실험 개체에 투약하자, 동일한 성장 조건에서 약 5배 향상된 성장 속도를 보였기 때문이다.\n사실 이 발견은 순전히 실수에서 탄생했다. 약품 X의 색상은 노란색으로, 기존 레시피에 포함된 약품 Z와 같은 색상이다. 계속되는 철야에 두 약품을 제대로 구분하지 못하고 혼합하고 말았다.\n긍정적인 결과가 나와서 다행이다. 아니었다면 트렐러니가 나를 거세게 질책했을 것이다.";
        Detail_Rep[1] = "제 XX회 탐사에서 채집한 운석-명칭 KK001-에서 미확인 물질 검출.\n운석의 외형과 경도의 경우, 타 운석과 차이점이 없으나 견과류 냄새가 난다는 특징이 있음.\n보다 자세한 연구와 미확인 물질의 활용 방안 모색을 위해 샐비어 그레이에게 협업 요청\nKK001은 현재 샐비어 그레이가 보관 및 연구 진행 중.";
        Detail_Rep[2] = "트렐러니가 협업을 요청하여 함께 연구를 진행 중이다.\n새롭게 채집한 운석 KK001에서 학계에 보고되지 않은 물질이 검출되었다.\n해당 물질을 추출한 뒤 기존 식물 성장 촉진제와 혼합하자 분홍빛의 약물이 완성되었다.\n이를 식물에 투약하여 반응을 지켜 보기로 했다.\n\n투약한 직후, 실험체는 급속도로 시들어 이내 사망하였다.\n실험체는 폐기하지 말고 연구 샘플로 보관해 지구로 가져가야겠다.\n\n투약 후 3분이 경과했다.\n결과는 놀랍다!\n틀림없이 사망에 이르렀다 생각한 실험체가 서서히 생기를 되찾더니 결국은 투약 전의 모습으로 되살아났다.\n식물이 아닌 다른 생물에게도 같은 반응이 나올까?";
        Detail_Rep[3] = "운석에서 발견된 물질들을 가지고 여러 합성 반응을 실험하다 조금 위험한 약물을 만들어냈다.\n실험 중 옆을 지나던 마이크가 기화된 해당 약물을 들이키고 환각 반응을 보였다.\n다행히도 한 시간 정도가 지나자 마이크의 체내에서 해당 물질은 모두 중화되어 검출되지 않았다.\n다만 가벼운 두통을 호소하는 중이다.\n출입 인원과 실험 장비를 제대로 관리하지 않은 나의 불찰이다.\n사과의 의미로 일주일간 마이크의 업무를 맡아 대신 해주기로 하였다.\n\n마이크가 보였던 증상으로 짐작해보건데 내가 만들어 낸 약물이 환각 반응을 유도하는 마약성 물질인 것 같다.\n안전한 폐기 방법은 불분명하여 우선 안전하게 숨겨두었다.\n다만 오늘 아침 다시 확인해보니 약물 하나가 사라져 있다.\n누군가 숨겨둔 걸까…\n불안한 마음에 오늘부터 해독제 연구에 들어가기로 하였다.\n\n해독 방법을 찾았다.";


        TitleText_Rep.text = Title_Rep[0];
        WriterText_Rep.text = Writer_Rep[0];
        DayText_Rep.text = Day_Rep[0];
        DetailText_Rep.text = Detail_Rep[0];

        PageNum_Rep.text = "1 / 4";
    }



    void Update()
    {
        if (r == 0)
        {
            LeftButton_Rep.SetActive(false);
        }
        else
        {
            LeftButton_Rep.SetActive(true);
        }
        if (r == 3)
        {
            RightButton_Rep.SetActive(false);
        }
        else
        {
            RightButton_Rep.SetActive(true);
        }
    }



    public void OnClickRightButton() // 오른쪽 버튼을 누를 시
    {
        if (Title_Rep.Length > r)
        {
            PageNum_Rep.text = (r + 2).ToString() + " / 4"; // 페이지 넘버

            TitleText_Rep.text = Title_Rep[r + 1];
            WriterText_Rep.text = Writer_Rep[r + 1];
            DayText_Rep.text = Day_Rep[r + 1];
            DetailText_Rep.text = Detail_Rep[r + 1];

            r++;
        }
    }

    public void OnClickLeftButton() // 왼쪽 버튼을 누를 시
    {
        if (0 < r)
        {
            PageNum_Rep.text = (r).ToString() + " / 4"; // 페이지 넘버

            TitleText_Rep.text = Title_Rep[r - 1];
            WriterText_Rep.text = Writer_Rep[r - 1];
            DayText_Rep.text = Day_Rep[r - 1];
            DetailText_Rep.text = Detail_Rep[r - 1];

            r--;
        }
    }
}

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
            Secret1.text = "�ٿ�ε� ���� ��...";
        }

        else
        {
            Secret1.text = "���� �����ٴϴ� Ĩ�� ������ ��մ� ������ �������." + "\n" + "�ϸ� ����Ĩ." + "\n" + "�̸� �״�� ������ ����Ű�� ��������, ����� ��Ʈ�� �ȱ⸸ �Ѵٸ� ��κ��� �ý��ۿ� ������ �߻���ų �� �ִ�." + "\n"
                + "�ƹ��� ��⿡ �������� ����̴��� �̷� ������ ���ٸ� �ǽ��ϰ���." + "\n" + "��Ű�� �������� ���ϰ� ���ѱ� ���� �и��ϴ�." +"\n" + "������ �ٸ� �������� Ĩ��� �Բ� ��� ���� �ξ���.";
        }

        if (GameManager.gameManager._gameData.IsPlanetSelectMission == false)
        {
            Secret2.text = "�ٿ�ε� ���� ��...";
        }

        else
        {
            Secret2.text = "����Ĩ ver.2�� �������. (������ �������� �̸��̳�.)" + "\n" + "����ũ�� ��� ������Ĩ�� ���� ���ļ���" + "\n" + "��ħ�� Ĩ�� �Ҿ���ȴٰ� ����̱淡 ���ɽð� ���� ������ ���� ���� �ٽ� ���� ���Ҵ�." + "\n" 
                + "���� ���� ��½ ������ ���� �˾�ä���� ���� �� ����." + "\n" + "���� ���� �Ͱ��� �޸� ���� ���̴�." + "\n" + "�ƹ�ư �� ����Ĩ�� ���ؼ� �������� �ʴ� �༺�� �������� ������ �� �ִ�." + "\n" + "�̷��� ������ �༺���� ���� �� ���� ��ȸ�ϸ� ���������� ��Ű�� �ʰ� ���ϴ� ���� ���� �� �ִ�." + "\n" + "�̸��׸� ���������.";
        }

        if (GameManager.gameManager._gameData.IsDollListen == false)
        {
            Secret3.text = "�ٿ�ε� ���� ��...";
        }
        else
        {
            Secret3.text = "���ּ��� ���� �༱���� �������� �˵� ���� �ý����� �����ص� �༺���θ� ������ �����ϴ�." + "\n" + "�̸� ���Ƿ� �ٲٱ� ���ؼ��� ������ �ý��ۿ� ������ �߻���Ű�� ������ �༱�� ���� �����ϴ� ���ۿ� ����." + "\n"
                + "������ �ý����� ������ �ϴܿ� ��ġ�ϴ� ��Ʈ�� ���� ������ �� �־���." + "\n" + "�� ��� �Ͽ� ���� �����Ͼ��� ���� ū ������ �ƴ�." + "\n" + "����� ������ ���� �ص� ������ �ΰ�� ��� �ٵ� �ǽ��� �ŵδϱ�.";
        }

        if (GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 == false)
        {
            Secret4.text = "�ٿ�ε� ���� ��...";
        }
        else
        {
            Secret4.text = "������ ���ɽð��� ������ ã�ƿԴ�." + "\n" + "\n" + "���� �ǰ� ���� ����� ���� ���ε�, ����ũ�� ü������ ������ ���༺ ������ ����ǰ� �ִٴ� ���̴�." + "\n" + "������ ���� �쿬���� ����� �� ���༺ ������ ���� ���� �� ���� �ߴµ� �� ������ ����ũ���� ����̴�." + "\n"
                + "������ �� ��ǿ� �������� �˷����� �ٶ��� �ʾҴ�." + "\n" + "������ ��ĥ�� ô ������ ��� ������� �����ϴ� �ι��̴ϱ" + "\n" + "���� ����ũ �༮�� �������� ���� �Ǿ��� ���������� ������ ���� ����� ã�ƺ���� �߰�, ���� ����� �Ͽ���." + "\n" + "\n" + "���� �ص� ����� ã�Ҵ�."
                + "���� ������ �������־��µ� ������ �� �оߴ� �� ������ �ƴϾ ����� �� �� ����." + "\n" + "���� ������ ��Ⱑ ���� �๰�� �Բ� ������ ��ȭ�ȴ� �� �� ����." + "\n" + "������ �����ϸ� ���� ����ũ�� �޴��̸� ��� �� ������ �����ߴ�." + "\n" + "���� ���ܿ��� �ɸ��� �ʵ��� �����ؾ� �ڴ�.";
        }

        if (GameManager.gameManager._gameData.IsTrashDoorBTFixed_L_L1 == false)
        {
            Secret5.text = "�ٿ�ε� ���� ��...";
        }
        else
        {
            Secret5.text = "������� ������ �޾� �������� ������ ������ ����� �� �־���." + "\n" + "�� ��Ͽ��� ���������, Ž�� �ʱ⸦ ���� ���� ��� ���������� ������ ���� ������ ����ִ�." + "\n" + "�̰͸� �ִٸ� �������� �����ڡ��� �������� ū Ÿ���� ���� �� �ۿ� ���� ���̴�." + "\n"
                + "����� ���� �غ�� ��� ���´�." + "\n" + "������̶�� ������� �������� �� ������ �����⸸ �Ѵٸ� �� �� ���� ������ Ǯ�� ���̴�. �׷�, �� ������ ������ ������ ���� ���� �ִٸ顦" + "\n" +"�ڷ�� ���������� ��ǻ�Ϳ� ��� �ִ�." + "\n" + "������ ������ �ڷḦ ���� �� �ִ� ��� ����� ���� ���� ������ ���̶� ���̴�." + "\n" + "������ ������ �ڷḦ ���� �� �ִ� ��� ����� ���� ���� ������ ���̰�, �ڷ�� ���������� ��ǻ�Ϳ� ��� �ִٴ� ���̴�." + "\n" + "���� ����� ������ �����ϱ⿣ �� ������ �Ÿ��� �ʹ� �ִ�."
                + "\n" + "��ȯ������ �ð��� �����ְ�, �������� ȸ�絵 ���� ����� �ǽ����� ������ �� ��ȸ�� ��ġ�� ���� ���� ����� ã�ƾ߰ڴ�." + "\n" + "+" + "\n" + "������ �԰� �ٸ� ������� ��� ���� �ð��� �������� �ٻ� ƴ�� Ÿ ������ ����� ����Ͽ���." + "\n" + "�׷��� Ÿ���� �̿��غ���� �ǰ��� �־���. ������ ���� ������ �� ����." +"\n" + "Ÿ���� �������� ����� Ȱ���ϸ� �ָ����� �����͸� �ְ� ���� �� �����״ϱ�." + "\n" + "���� ��ģ�̱淡 �̷��� �ȶ��ϰ� ��������� ������.";
        }

        if (GameManager.gameManager._gameData.IsInputNormalMeteor1_T_C2 == false)
        {
            Secret6.text = "�ٿ�ε� ���� ��...";
        }
        else
        {
            Secret6.text = "�׻� �׷���, ���õ� ������ �ΰ�� ��� �ý����� ��¦ �պ��Ҵ�." + "\n" + "�ý��� ���� ������ ������ �־� ���� ������ �ǵ� �� �־���." + "\n" + "���� ���� ����� �ɼǸ� ������ �� �־����� �̰��� ��� �ʹ�." + "\n"
                + "���߿� �� ����� �������ٸ� ������ ����� ��å�� �ο��� �λ����� ���� ���� ���� ���̴�." + "\n" + "\n" + "������ ���� ���п� �� �º��� ���� ���� ������ ȸ���� ������ ���� �� �ְ� �Ǿ���." + "\n" + "�º��� ������ ������ �̵���Ű�� ���� �ɸ� ������� ���Ҵµ� ���� �� �� ����ϰ� �۾��� �� ���� ���̴�." + "\n" + "������ ������ ���� ��ǻ�Ϳ� ������ ������ �� ����. �� �ϳ��� �� �Ÿ��̱� ������ ���̴�."
                + "\n" + "���� ���� ����� �ſ� �����Ͽ�, �º��� ���� ���� ��ư�� �����⸸ �ϸ� �ȴ�.";
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

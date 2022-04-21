using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionGenerator : MonoBehaviour
{
    public static MissionGenerator missionGenerator { get; private set; }

    //public List<string> missionList;

    public Dictionary<int, string> missionDic = new Dictionary<int, string>();

    public List<string> missionList;
    public GameObject missionPanel;

    public bool IsOn = false;
    public GameObject missionmom;

    private void Awake()
    {
        missionGenerator = this;
    }
    private void Start()
    {
        //missionDic.Add(0, "AI 활성화");
        //missionDic.Add(1, "조종실 탈출");
        //missionDic.Add(2, "상태 체크 기계 수리");
        //missionDic.Add(3, "스마트팜 수리");
        //missionDic.Add(4, "연료 기계 수리");

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
        if(missionList.Count!=0)
        {
            if(!IsOn)
            {
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

    }

    IEnumerator PrintMissionList()
    {
        for (int i = 0; i < missionList.Count; i++)
        {
            GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
            TMPro.TextMeshProUGUI textget = newMission.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            textget.text = missionList[i];
            newMission.transform.SetParent(GameObject.FindGameObjectWithTag("aa").transform, true);

            newMission.SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }      
    }
}

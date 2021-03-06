using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkSmellRange : MonoBehaviour
{
    public float smellRange;
    public float speed;

    public GameObject smellArea;
    ObjData smellAreaData;

    public GameObject player;

    public GameObject drugBag;
    ObjData drugBagData;

    public GameObject samplePanel;
    public TMPro.TextMeshProUGUI sampleText;

    // Start is called before the first frame update
    void Start()
    {
        smellRange = 0;

        drugBagData = drugBag.GetComponent<ObjData>();
        smellAreaData = smellArea.GetComponent<ObjData>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            smellRange = Random.Range(0, 3);

            if (smellRange <= 1)
            {
                smellArea.SetActive(true);
                PrintUI();
                GameData gameData = SaveSystem.Load("save_001");
                {
                    // 아직 미션 추가 전인지 확인 후 추가
                    if (!gameData.CompleteMissionList[24])
                    {
                        MissionGenerator.missionGenerator.AddNewMission(24);
                        GameManager.gameManager._gameData.CompleteMissionList[24] = true;
                        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
                    }
                }
            }
        }      
    }

    void PrintUI()
    {
        samplePanel.SetActive(true);
        sampleText.text = "[냄새] 이상한 냄새";
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player && smellAreaData.IsSniff)
        {
            Invoke("followDrug", 2f);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("���Ż��!!");

            //drugSmellAreaData.IsNotInteractable = true;
            CancelInvoke("followDrug");

            smellArea.SetActive(false);
        }
    }

    public void followDrug() // 바라봄
    {
        smellAreaData.IsNotInteractable = true;

        Vector3 dir = drugBag.transform.position - player.transform.position;
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }

}

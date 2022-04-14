using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MissionGenerator : MonoBehaviour
{
    public static MissionGenerator missionGenerator { get; private set; }

    private void Awake()
    {
        missionGenerator = this;
    }

    public List<string> missionList;

    public GameObject missionPanel;
    public TMPro.TextMeshProUGUI missionText;




    public void ShowMissionList()
    {
        if(missionList.Count!=0)
        {
            for (int i = 0; i < missionList.Count; i++)
            {
                //Instantiate(missionPanel, new Vector3(transform.position.x, transform.position.y - i*5, transform.position.z), transform.rotation);
                //Instantiate(missionText, transform.position, transform.rotation);
                //missionText.text = missionList[i];
                //missionPanel.SetActive(true);
                //missionText.transform.gameObject.SetActive(true);
                GameObject newMission = Instantiate(missionPanel, new Vector3(0, 13.25f - i * 55, 0), transform.rotation) as GameObject;
                newMission.transform.SetParent(GameObject.FindGameObjectWithTag("aa").transform, false);
                newMission.SetActive(true);

            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(missionPanel, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

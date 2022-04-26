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
            Debug.Log("노아진입!!");

            smellRange = Random.Range(0, 3);

            if (smellRange <= 1)
            {
                smellArea.SetActive(true);
            }
        }
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
            Debug.Log("노아탈출!!");

            //drugSmellAreaData.IsNotInteractable = true;
            CancelInvoke("followDrug");

            smellArea.SetActive(false);
        }
    }

    public void followDrug() //마약 바라보게 하기
    {
        smellAreaData.IsNotInteractable = true;

        Vector3 dir = drugBag.transform.position - player.transform.position;
        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
    }

}

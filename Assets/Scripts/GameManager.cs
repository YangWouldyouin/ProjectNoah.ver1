using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public static int Hp = 100;
    public bool isBark = false;

    private void Awake()
    {
        gameManager = this;
    }

    private void Update()
    {
        if(isBark == true) // Â¢À¸¸é
        {
            Hp -= 10;
            isBark = false;
        }


        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    Debug.Log("Ã¼·Â: " + Hp);
        //    //Debug.Log("isPush : " + isPush);
        //}
    }
}

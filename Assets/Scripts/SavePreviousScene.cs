using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePreviousScene : MonoBehaviour
{

    public static int PreviousLevel { get; private set; }
    GameObject noah;

    private void OnDestroy()
    {
        PreviousLevel = gameObject.scene.buildIndex;
    }

    private void Start()
    {
        noah = BaseCanvas._baseCanvas.noahPlayer;
        
        if(PreviousLevel==3)
        {
            noah.transform.position = new Vector3(-261.13f, 0.915751f, 669.4411f);
            noah.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        

        switch(PreviousLevel)
        {
            case 3: // 엔진실이면 
                {
                    noah.transform.position = new Vector3(-261.13f, 0.915751f, 669.4411f);
                    noah.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                }
            case 5: // 생활공간이면
                {
                    noah.transform.position = new Vector3(-261.13f, 0.915751f, 691.5332f);
                    noah.transform.eulerAngles = new Vector3(0, 180, 0);
                    break;
                }
        }


    }
}

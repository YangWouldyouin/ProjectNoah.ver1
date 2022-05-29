using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePreviousScene : MonoBehaviour
{

    public static string PreviousLevel { get; private set; }
    GameObject noah;

    private void OnDestroy()
    {
        PreviousLevel = gameObject.scene.name;
    }

    private void Start()
    {
        noah = BaseCanvas._baseCanvas.noahPlayer;
        if(PreviousLevel=="new engineRoom")
        {
            noah.transform.position = new Vector3(-261.13f, 0.915751f, 669.4411f);
            noah.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}

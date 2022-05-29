using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePreviousScene : MonoBehaviour
{

    public static string PreviousLevel { get; private set; }
    private void OnDestroy()
    {
        PreviousLevel = gameObject.scene.name;
    }
}

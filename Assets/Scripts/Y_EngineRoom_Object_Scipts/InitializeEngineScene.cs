using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeEngineScene : MonoBehaviour
{
    public GameObject FA_fuelabsorberfixPart;
    public GameObject FA_fuelabsorberBody;
    // Start is called before the first frame update
    void Start()
    {
        GameData intialGameData = SaveSystem.Load("save_001");

        if (intialGameData.IsFuelabsorberFixed_E_E1)
        {
            FA_fuelabsorberfixPart.SetActive(false);
            FA_fuelabsorberBody.SetActive(false);
        }
    }

}

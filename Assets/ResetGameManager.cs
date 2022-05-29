using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameManager : MonoBehaviour
{
    /* �� ������ ���� �ʱ�ȭ */
    public PortableObjectData controlData;
    public PortableObjectData workData;
    public PortableObjectData engineData;
    public PortableObjectData livingData;

    void ResetPortableObject()
    {
        for(int i=0; i<59; i++)
        {
            controlData.IsObjectActiveList[i] = false;
            workData.IsObjectActiveList[i] = false;
            engineData.IsObjectActiveList[i] = false;
            livingData.IsObjectActiveList[i] = false;
        }

        /* ������ �ʱ�ȭ */
        controlData.IsObjectActiveList[0] = true;
        controlData.IsObjectActiveList[1] = true;

        /* ������ �ʱ�ȭ */
        engineData.IsObjectActiveList[3] = true;
        engineData.IsObjectActiveList[5] = true;
        engineData.IsObjectActiveList[6] = true;
        engineData.IsObjectActiveList[8] = true;
        engineData.IsObjectActiveList[9] = true;
        engineData.IsObjectActiveList[39] = true;
        engineData.IsObjectActiveList[40] = true;
        engineData.IsObjectActiveList[58] = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Fuelabsorber : MonoBehaviour
{
    public GameObject fuelabsorberBody_FA;
    public GameObject fuelabsorberfixPart_FA;
    public GameObject fuelabsorber_FA;

    ObjData fuelabsorberBodyData_FA;
    ObjData fuelabsorberfixPartData_FA;
    ObjData fuelabsorberData_FA;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1)
        {
            // �÷ο���Ʈ ó�� ���� �� �ְ� ���� ������� �ִ´�.  
        }

        fuelabsorberBodyData_FA = fuelabsorberBody_FA.GetComponent<ObjData>();
        fuelabsorberfixPartData_FA = fuelabsorberfixPart_FA.GetComponent<ObjData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelabsorberBodyData_FA.IsPushOrPress && fuelabsorberfixPartData_FA.IsBite)
        {
            Invoke("fuelabsorberDone", 1.5f);
        }
    }

    public void fuelabsorberDone()
    {
        //���� �ִ� fitPart ���� ���� -> bool false
        fuelabsorberfixPartData_FA.IsBite = false;

        fuelabsorberfixPartData_FA.GetComponent<Rigidbody>().isKinematic = false;
        fuelabsorberfixPartData_FA.transform.parent = null;

        //fitPart ��ġ HM�� �ڵ� ����
        fuelabsorberfixPartData_FA.transform.position = new Vector3(-1.82f, 0.509f, 0.25f);
        fuelabsorberfixPartData_FA.transform.rotation = Quaternion.Euler(0, 90, 90);

        //�� �� ���� �ϸ� ���̻� fitPart ��ȣ�ۿ� �Ұ� ������Ʈ�� ���� -> interaction ��ũ��Ʈ ����
        fuelabsorberfixPartData_FA.IsNotInteractable = true;
        fuelabsorberBodyData_FA.IsNotInteractable = true;
        //FuelabsorberData.IsNotInteractable = false;

        //������Ʈ ����
        fuelabsorber_FA.SetActive(true);
        fuelabsorberfixPart_FA.SetActive(false);
        fuelabsorberBody_FA.SetActive(false);

        GameManager.gameManager._gameData.IsFuelabsorberFixed_E_E1 = true;
        SaveSystem.Save(GameManager.gameManager._gameData, "save_001");
    }
}

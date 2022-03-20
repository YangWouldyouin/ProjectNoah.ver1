using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpUp : MonoBehaviour
{
    //�ش� ��ũ��Ʈ�� M_C2_FindEnginespaceKey���Ͽ��� �������� å��� ��ƿ��� �浹 ������Ʈ�� �����ϴ� �ڵ��̴�.
    // ���� ���� �ö� �� �̿��� �� �ִ� �ڵ��̴�.
    // �ش� �ڵ带 �ö󰡰� ���� ������Ʈ�� ������ �ְ�, ��ư� �ö󰡰� ���� ���� ������Ʈ�� �ε����� -> �װ� �ε��� ���� �����Ѵ�.

    public GameObject Table; // �ڵ忡�� �ö󰡰� ���� ��ü�� �������� ����������� �ȴ�. ����Ƽ �ν����Ϳ��� �ö󰡰� ���� ������Ʈ�� �� �ȿ� ������ �ȴ�.

    private void OnTriggerEnter(Collider other) //��ƿ� �ݶ��̴� Other(�ö󰡰� ���� ������Ʈ)���� �浹���� �����̴�.
    {
        ObjData TableData = Table.GetComponent<ObjData>();  // �ö󰡰� ����(å��)�� ObjData�� �����´�.

        

        if (other.gameObject.tag == "Player") // ��ư� ���������� �±׷� �����ϰڴٴ� �ڵ��̴�.
        {
            TableData.IsCollision = true; //��ƿ� å���� �ε����� �����ϸ� å���� ObjData�� IsCollision�� üũ�� ���ְڴٴ� �ڵ��̴�.
            Debug.Log("���� �ε�����"); // Ȯ�ο� �����
        }
            


    }

    private void OnTriggerExit(Collider other)
    {
        ObjData TableData = Table.GetComponent<ObjData>();  // å���� ObjData�� �����´�.

       

        if (other.gameObject.tag == "Player") // ��ư� ���������� �±׷� �����ϰڴٴ� �ڵ��̴�.
        {
            TableData.IsCollision = false; //���̰� �ȵǾ� ��ƿ� å���� �ε����� �������� ���ϰ� �Ǹ� å���� ObjData�� IsCollision�� üũ�� �������ְڴٴ� ���̴�. 
            Debug.Log("���� �� �ε���"); // Ȯ�ο� �����
        }
            
    }
}

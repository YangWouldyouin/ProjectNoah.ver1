using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Fadeinout : MonoBehaviour
{
    public GameObject Intro_GUI;
    public Text introtext;

    // Start is called before the first frame update
    void Start()
    {
        Intro_GUI.SetActive(true);
        Invoke("nextText2", 4f);
    }

    public void nextText2()
    {
        introtext.text = "�̿� ���� ��å���� �η��� ���� ��, ��Ȱ�� ���ַ� ���� ���Ȱ�"+ "\n" +"�������� ���� ������������ ���η� �Ͽ� �������� ���� Ž�簡 ���۵Ǿ���.";
        Invoke("nextText3", 4f);
    }


    public void nextText3()
    {
        introtext.text = "������������ ���� ������ ��ȯ���� ���� ���⵿������ �Ʒý��� ����Ž���ڷ� ��Ź�Ͽ���," + "\n" + "�����Ͽ� ������� �������� ���� ������� ȣ���� �����.";
        Invoke("nextText4", 4f);
    }

    public void nextText4()
    {
        introtext.text = "������������ Ű���� �ְ��� õ��� ���no.113��" + "\n" + "��Ȧ�� Ž���ϴ� ������Ʈ ���� 113��° Ž����̴�.";
        Invoke("introEnd", 4f);
    }
    public void introEnd()
    {
        Intro_GUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

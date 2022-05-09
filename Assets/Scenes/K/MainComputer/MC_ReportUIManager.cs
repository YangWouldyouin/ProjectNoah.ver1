using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MC_ReportUIManager : MonoBehaviour
{
    /* ������Ʈ */
    // �¿� ��ư
    public GameObject RightButton_Rep;
    public GameObject LeftButton_Rep;

    public string[] Title_Rep; // ����
    public string[] Writer_Rep; // �ۼ���
    public string[] Day_Rep; // �ۼ�����
    public string[] Detail_Rep; // ����

    public Text TitleText_Rep;
    public Text WriterText_Rep;
    public Text DayText_Rep;
    public Text DetailText_Rep;
    public Text PageNum_Rep; // �������ѹ�

    public int r = 0;

    void Start()
    {
        /* ���� */
        Title_Rep[0] = "[�Ĺ� ���� ������ ����]";
        Title_Rep[1] = "[��Ȯ�� ������ ���Ե� � �߰�]";
        Title_Rep[2] = "[��ü ���� �ּ�ȭ �๰]";
        Title_Rep[3] = "[ȯ�� ���� ���� �๰]";

        /* �ۼ��� */
        Writer_Rep[0] = "�ۼ���: ����� �׷���_ RVS30020";
        Writer_Rep[1] = "�ۼ���: ���� Ʈ������_RVS30004";
        Writer_Rep[2] = "�ۼ���: ����� �׷���_ RVS30020";
        Writer_Rep[3] = "�ۼ���: ����� �׷���_ RVS30020";

        /* �ۼ����� */
        Day_Rep[0] = "�ۼ� ����: 2XXX.XX.XX";
        Day_Rep[1] = "�ۼ� ����: 2XXX.XX.XX";
        Day_Rep[2] = "�ۼ� ����: 2XXX.XX.XX / ���� ���� ����: 2XXX.XX.XX";
        Day_Rep[3] = "�ۼ� ����: 2XXX.XX.XX / ���� ���� ����: 2XXX.XX.XX";

        /* ���� */
        Detail_Rep[0] = "�̹� Ž�縦 ���� �߰��� ��ǰ X�� ���� �߰� ������ �����ؾ� �Ѵ�. ������ �Ĺ� ���� ������ Y�� ��ǰ X�� ����\n���� ��ü�� ��������, ������ ���� ���ǿ��� �� 5�� ���� ���� �ӵ��� ������ �����̴�.\n��� �� �߰��� ������ �Ǽ����� ź���ߴ�. ��ǰ X�� ������ ���������, ���� �����ǿ� ���Ե� ��ǰ Z�� ���� �����̴�. ��ӵǴ� ö�߿� �� ��ǰ�� ����� �������� ���ϰ� ȥ���ϰ� ���Ҵ�.\n�������� ����� ���ͼ� �����̴�. �ƴϾ��ٸ� Ʈ�����ϰ� ���� �ż��� ��å���� ���̴�.";
        Detail_Rep[1] = "�� XXȸ Ž�翡�� ä���� �-��Ī KK001-���� ��Ȯ�� ���� ����.\n��� ������ �浵�� ���, Ÿ ��� �������� ������ �߰��� ������ ���ٴ� Ư¡�� ����.\n���� �ڼ��� ������ ��Ȯ�� ������ Ȱ�� ��� ����� ���� ����� �׷��̿��� ���� ��û\nKK001�� ���� ����� �׷��̰� ���� �� ���� ���� ��.";
        Detail_Rep[2] = "Ʈ�����ϰ� ������ ��û�Ͽ� �Բ� ������ ���� ���̴�.\n���Ӱ� ä���� � KK001���� �а迡 ������� ���� ������ ����Ǿ���.\n�ش� ������ ������ �� ���� �Ĺ� ���� �������� ȥ������ ��ȫ���� �๰�� �ϼ��Ǿ���.\n�̸� �Ĺ��� �����Ͽ� ������ ���� ����� �ߴ�.\n\n������ ����, ����ü�� �޼ӵ��� �õ�� �̳� ����Ͽ���.\n����ü�� ������� ���� ���� ���÷� ������ ������ �������߰ڴ�.\n\n���� �� 3���� ����ߴ�.\n����� �����!\nƲ������ ����� �̸����� ������ ����ü�� ������ ���⸦ ��ã���� �ᱹ�� ���� ���� ������� �ǻ�Ƴ���.\n�Ĺ��� �ƴ� �ٸ� �������Ե� ���� ������ ���ñ�?";
        Detail_Rep[3] = "����� �߰ߵ� �������� ������ ���� �ռ� ������ �����ϴ� ���� ������ �๰�� �����´�.\n���� �� ���� ������ ����ũ�� ��ȭ�� �ش� �๰�� ����Ű�� ȯ�� ������ ������.\n�������� �� �ð� ������ ������ ����ũ�� ü������ �ش� ������ ��� ��ȭ�Ǿ� ������� �ʾҴ�.\n�ٸ� ������ ������ ȣ���ϴ� ���̴�.\n���� �ο��� ���� ��� ����� �������� ���� ���� �����̴�.\n����� �ǹ̷� �����ϰ� ����ũ�� ������ �þ� ��� ���ֱ�� �Ͽ���.\n\n����ũ�� ������ �������� �����غ��ǵ� ���� ����� �� �๰�� ȯ�� ������ �����ϴ� ���༺ ������ �� ����.\n������ ��� ����� �Һи��Ͽ� �켱 �����ϰ� ���ܵξ���.\n�ٸ� ���� ��ħ �ٽ� Ȯ���غ��� �๰ �ϳ��� ����� �ִ�.\n������ ���ܵ� �ɱ\n�Ҿ��� ������ ���ú��� �ص��� ������ ����� �Ͽ���.\n\n�ص� ����� ã�Ҵ�.";


        TitleText_Rep.text = Title_Rep[0];
        WriterText_Rep.text = Writer_Rep[0];
        DayText_Rep.text = Day_Rep[0];
        DetailText_Rep.text = Detail_Rep[0];

        PageNum_Rep.text = "1 / 4";
    }



    void Update()
    {
        if (r == 0)
        {
            LeftButton_Rep.SetActive(false);
        }
        else
        {
            LeftButton_Rep.SetActive(true);
        }
        if (r == 3)
        {
            RightButton_Rep.SetActive(false);
        }
        else
        {
            RightButton_Rep.SetActive(true);
        }
    }



    public void OnClickRightButton() // ������ ��ư�� ���� ��
    {
        if (Title_Rep.Length > r)
        {
            PageNum_Rep.text = (r + 2).ToString() + " / 4"; // ������ �ѹ�

            TitleText_Rep.text = Title_Rep[r + 1];
            WriterText_Rep.text = Writer_Rep[r + 1];
            DayText_Rep.text = Day_Rep[r + 1];
            DetailText_Rep.text = Detail_Rep[r + 1];

            r++;
        }
    }

    public void OnClickLeftButton() // ���� ��ư�� ���� ��
    {
        if (0 < r)
        {
            PageNum_Rep.text = (r).ToString() + " / 4"; // ������ �ѹ�

            TitleText_Rep.text = Title_Rep[r - 1];
            WriterText_Rep.text = Writer_Rep[r - 1];
            DayText_Rep.text = Day_Rep[r - 1];
            DetailText_Rep.text = Detail_Rep[r - 1];

            r--;
        }
    }
}

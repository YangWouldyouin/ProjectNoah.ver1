using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� Ŭ�������� ��ӵ� Ŭ������ �ٸ� ���� ������Ʈ�� ���� �� ����
public abstract class Actions : MonoBehaviour
{
    // abstract ���ǰ� ���� �޼���� �ٵ� �ڵ带 �� �� ����\
    // �׷��� �� Ŭ������ ����� ��� Ŭ�������� �ݵ�� �� �޼��带 ������ �־�� �ϳ� ���Ǵ� �ٸ��� �� �� �־ 
    // �پ��� actions �� ���� �� �ִ�. 
    public abstract void Act();
}

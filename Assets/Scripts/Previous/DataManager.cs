//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DataManager : MonoBehaviour
//{
//    public static DataManager Instance { get; private set; }
//    // �ٸ� ��ũ��Ʈ���� Inventory �� ���� ������ �� ������, ���� ������ �� ����
//    public Inventory Inventory { get { return inventory; } }

//    [SerializeField] Inventory inventory;

//    //public event System.Action OnSave = delegate { };
//    //public event System.Action OnLoad = delegate { };

//    public string PrevSceneName { get; private set; }
//    public LevelManager LevelManager { get; private set; }

//    //private int saveDataId = 0;
//    //private List<SaveData> saveDatas = new List<SaveData>();
//    /* �̱��� ���� */
//    // ������ �Ŵ��� �ڽŰ�, �� Ŭ������ ������ �ִ� ������Ʈ�� 
//    private void Awake() // �ٸ� ��ũ��Ʈ���� ����Ǳ� ���� �ʱ�ȭ
//    {
//        if(Instance == null) // �ƹ��� Instance Ű���带 ������� �ʾ�����
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            // ���࿡ ��1�� ��2 �Ѵ� ������ �Ŵ����� �����Ѵٸ�, ��2�� �̵��� �� ��1�� �����͸Ŵ����� ������Ŵ
//            Destroy(gameObject); 

//        }

//        LevelManager = GetComponentInChildren<LevelManager>();
//    }

//    /* ���� ���� �ٲ𶧸��� ������Ʈ ���ִ� �޼��� */
//    public void SetPrevScene(string name)
//    {
//        PrevSceneName = name; // ���� ������ �̵��� �÷��̾� ���� ��ġ�� ����� ����
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor; // Editor Ŭ������ ��ӹ������� �ʿ���

//[CustomEditor(typeof(Inventory))]
//public class InventoryEditor : Editor
//{
//    Inventory source;
//    SerializedProperty s_inventory, s_itemDatabase;
//    int itemId;
//    /* �ʱ�ȭ�� ���� �ʿ� */
//    private void OnEnable()
//    {
//        source = (Inventory)target;

//        s_inventory = serializedObject.FindProperty("inventory");
//        s_itemDatabase = serializedObject.FindProperty("itemDatabase");
//    }
//    /* �ν����͸� �׸��� �� */
//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        EditorGUILayout.PropertyField(s_itemDatabase);

//        if (source.ItemDatabase != null)
//        {
//            // �� �˾��� �ٲ� ������ ���ο� itemId �� itemId �� �������ش� 
//            itemId = EditorGUILayout.Popup(itemId, source.ItemDatabase.ItemsNames.ToArray()); // ItemNames �� list of string �̹Ƿ� array �� ��ȯ���ش�

//            if (GUILayout.Button("Add Item"))
//            {
//                Item newItem = Extensions.CopyItem(source.ItemDatabase.GetItem(itemId));
//                source.AddItem(newItem);
//            }

//            for (int i = 0; i < s_inventory.arraySize; i++)
//            {
//                //draw every item entry
//                //DrawItemEntry(s_inventory.GetArrayElementAtIndex(i), i);
//                DrawItemEntry(s_inventory.GetArrayElementAtIndex(i), i);
//            }
//        }

//        serializedObject.ApplyModifiedProperties();
//    }
//    /* ������ ��Ʈ���� �׷��ִ� �޼��� */
//    void DrawItemEntry(SerializedProperty item, int id) // ������ �� ������ �ʿ��� ( item.arraySize )
//    {
//        GUILayout.BeginVertical("box");

//        GUILayout.BeginHorizontal();

//        // �����ϰ� ���� �����Ƿ� static Inspector �� �Ǳ� ���� LabelField ���, PropertyField �� ����ϸ� �ν����Ϳ��� �� ���� ����
//        EditorGUILayout.LabelField("Item Id:" + item.FindPropertyRelative("itemId").intValue, GUILayout.Width(75f)); // Q. FindPropertyRelative??
//        EditorGUILayout.LabelField("Item Name: " + item.FindPropertyRelative("itemName").stringValue); // �κ��丮������ ������ �̸� ��ü�� �ٲ� ���� ����     /**/

//        if (GUILayout.Button("X", GUILayout.Width(20f)))
//        {
//            //delete the item  : access  s_items and delete the entry
//            s_inventory.DeleteArrayElementAtIndex(id); // �迭 ���� �ٽ� �ϰ� �;���, �迭�� ���� ���� ��� ���...

//            return;
//        }

//        GUILayout.EndHorizontal();

//        EditorGUILayout.LabelField("Item Description: " + item.FindPropertyRelative("itemDescription").stringValue, GUILayout.Height(70f));

//        GUILayout.BeginHorizontal();

//        var spriteViewer = AssetPreview.GetAssetPreview(item.FindPropertyRelative("itemSprite").objectReferenceValue); // ������Ʈ�� ���۷��� ����� ������ (���⼭�� ��������Ʈ)
//        GUILayout.Label(spriteViewer);  // Label �� �ؽ�Ʈ �Ӹ� �ƴ϶� �ؽ��ĵ� ������ �� �ִ�

//        if (item.FindPropertyRelative("allowMultiple").boolValue) // 1���� ���� �� �ִ� �������̸� (allowMultiple == false) �������� ���� ������ �ʿ� ����
//            EditorGUILayout.PropertyField(item.FindPropertyRelative("amount")); // �������� ���� ������

//        GUILayout.EndHorizontal();

//        GUILayout.EndVertical();
//    }
//}

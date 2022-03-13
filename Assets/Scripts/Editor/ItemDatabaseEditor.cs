//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//// �޸� : ���� ������Ʈ�� ��ƾ� �ҵ� 
//[CustomEditor(typeof(ItemDatabase))] // typeof( Inspector class ) 
//public class ItemDatabaseEditor : Editor
//{
//    // ItemDatabase = AddItem �޼��带 ���� ���� �ʿ�
//    ItemDatabase source;
//    SerializedProperty s_items, s_itemsName;

//    private void OnEnable() // Q. OnEnable ?? 
//    {
//        source = (ItemDatabase)target;
//        s_items = serializedObject.FindProperty("items"); // ItemDatabase ���� ������ �̸���� �־���
//        s_itemsName = serializedObject.FindProperty("itemsNames");
//    }

//    public override void OnInspectorGUI()
//    {
//        // ��ȭ�� ����� ���� �����ӿ� �ٷ� �ݿ� ( Add Item ��ư ������ ����� ���� �ʾƵ� �ν����Ϳ� �ٷ� �ݿ� )
//        serializedObject.Update();

//        //base.OnInspectorGUI();
//        if (GUILayout.Button("Add Item"))
//        {
//            Item newItem = new Item(s_items.arraySize, "", "", null,  false);    // s_items.arraySize : ItemID
//            source.AddItem(newItem);    // ���ο� �������� ������(newItem) �̰��� ItemDatabase �� List<Item> items �� ����
//        }

//        for (int i = 0; i < s_items.arraySize; i++)
//        {
//            // draw the item entry
//            DrawItemEntry(s_items.GetArrayElementAtIndex(i)); // SerializeField �̹Ƿ� GetArrayAtIndex �� �����
//        }
//        // Editor ���� GUI Ŭ������ �����ؼ� �ν����Ϳ� �ٲ� ���� ������ true �� ��ȯ�ϰ� ��
//        if(GUI.changed) // ��ȭ�� ������ �� s_itemsName �� �ٲ��� �ʴ� �� �ذ�
//        {
//            ReCaluculateID();
//        }

//        serializedObject.ApplyModifiedProperties(); // SerializedProperty �� ����ϹǷ� �־���� 
//    }

//    /* ������ ��Ʈ���� �׷��ִ� �޼��� */
//    void DrawItemEntry(SerializedProperty item) // ������ �� ������ �ʿ��� ( item.arraySize )
//    {
//        GUILayout.BeginVertical("box");

//        GUILayout.BeginHorizontal();

//        // �����ϰ� ���� �����Ƿ� static Inspector �� �Ǳ� ���� LabelField ���(������ ID = �迭���� �ε����� �ٲ� �� ����), PropertyField �� ����ϸ� �ν����Ϳ��� �� ���� ����
//        EditorGUILayout.LabelField("Item Id: "+ item.FindPropertyRelative("itemId").intValue, GUILayout.Width(75f)); // Q. FindPropertyRelative?? "itemId : Item Ŭ������ �����Ѵ�� ����
//        EditorGUILayout.PropertyField(item.FindPropertyRelative("itemName")) ;

//        if(GUILayout.Button("x", GUILayout.Width(20f)))
//        {
//            // delete the item : access  s_items and delete the entry
//            s_itemsName.DeleteArrayElementAtIndex(item.FindPropertyRelative("itemId").intValue); // �迭 ���� �ٽ� �ϰ� �;���, �迭�� ���� ���� ��� ���...
//            s_items.DeleteArrayElementAtIndex(item.FindPropertyRelative("itemId").intValue); // s_itemsNames �� s_items �� �ε��� ������ ���Ƽ� �״�� ���� ��
            
//            ReCaluculateID(); // ID �� �ϳ� �����ϸ� ID �� �ٽ� ����ؾ� ��
//            return;

//        }

//        GUILayout.EndHorizontal();

//        EditorGUILayout.PropertyField(item.FindPropertyRelative("itemDescription"));

//        GUILayout.BeginHorizontal();
//        // �ν����Ϳ��� ��������Ʈ �̹����� �����ֱ� ���� ObjectField ���
//        item.FindPropertyRelative("itemSprite").objectReferenceValue = EditorGUILayout.ObjectField("Item Sprite: ",
//            item.FindPropertyRelative("itemSprite").objectReferenceValue, typeof(Sprite), false); 
//        // ��������Ʈ �̹����� ���� �������� ������ ���̱� ������ false
//        EditorGUILayout.PropertyField(item.FindPropertyRelative("allowMultiple")); // ��� ��ư ��/����
//        GUILayout.EndHorizontal();

//        GUILayout.EndVertical();
//    }

//    /* �������� �����ϸ� ������ �����۵��� ID �� �ٽ� ������ְ� ItemName�� �ٽ� �־��ִ�  �޼��� */
//    void ReCaluculateID() /* �迭 ������ �����ؼ� �ٽ� �����ؼ� �˰��� �ٽ�¥��~~~ */
//    {
//        for(int i=0; i<s_items.arraySize; i++)
//        {
//            s_items.GetArrayElementAtIndex(i).FindPropertyRelative("itemId").intValue = i;
//            // �ε����� �ڵ������� �̵������� �ٸ� �͵��� �ڵ����� �ٲ��� �����Ƿ� ItemId �� i, �ε��� ���� ����
//            s_itemsName.GetArrayElementAtIndex(i).stringValue =
//                s_items.GetArrayElementAtIndex(i).FindPropertyRelative("itemName").stringValue;
//        }

//    }

//}


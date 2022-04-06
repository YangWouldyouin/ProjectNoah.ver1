//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor; // Editor 클래스를 상속받으려면 필요함

//[CustomEditor(typeof(Inventory))]
//public class InventoryEditor : Editor
//{
//    Inventory source;
//    SerializedProperty s_inventory, s_itemDatabase;
//    int itemId;
//    /* 초기화를 위해 필요 */
//    private void OnEnable()
//    {
//        source = (Inventory)target;

//        s_inventory = serializedObject.FindProperty("inventory");
//        s_itemDatabase = serializedObject.FindProperty("itemDatabase");
//    }
//    /* 인스펙터를 그리는 곳 */
//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        EditorGUILayout.PropertyField(s_itemDatabase);

//        if (source.ItemDatabase != null)
//        {
//            // 이 팝업을 바꿀 때마다 새로운 itemId 를 itemId 에 배정해준다 
//            itemId = EditorGUILayout.Popup(itemId, source.ItemDatabase.ItemsNames.ToArray()); // ItemNames 가 list of string 이므로 array 로 변환해준다

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
//    /* 아이템 엔트리를 그려주는 메서드 */
//    void DrawItemEntry(SerializedProperty item, int id) // 아이템 총 개수가 필요함 ( item.arraySize )
//    {
//        GUILayout.BeginVertical("box");

//        GUILayout.BeginHorizontal();

//        // 수정하고 싶지 않으므로 static Inspector 가 되기 위해 LabelField 사용, PropertyField 를 사용하면 인스펙터에서 값 수정 가능
//        EditorGUILayout.LabelField("Item Id:" + item.FindPropertyRelative("itemId").intValue, GUILayout.Width(75f)); // Q. FindPropertyRelative??
//        EditorGUILayout.LabelField("Item Name: " + item.FindPropertyRelative("itemName").stringValue); // 인벤토리에서는 아이템 이름 자체가 바뀔 일이 없음     /**/

//        if (GUILayout.Button("X", GUILayout.Width(20f)))
//        {
//            //delete the item  : access  s_items and delete the entry
//            s_inventory.DeleteArrayElementAtIndex(id); // 배열 공부 다시 하고 싶어짐, 배열의 원소 삭제 방법 등등...

//            return;
//        }

//        GUILayout.EndHorizontal();

//        EditorGUILayout.LabelField("Item Description: " + item.FindPropertyRelative("itemDescription").stringValue, GUILayout.Height(70f));

//        GUILayout.BeginHorizontal();

//        var spriteViewer = AssetPreview.GetAssetPreview(item.FindPropertyRelative("itemSprite").objectReferenceValue); // 오브젝트의 레퍼런스 밸류를 리턴함 (여기서는 스프라이트)
//        GUILayout.Label(spriteViewer);  // Label 은 텍스트 뿐만 아니라 텍스쳐도 보여줄 수 있다

//        if (item.FindPropertyRelative("allowMultiple").boolValue) // 1개만 가질 수 있는 아이템이면 (allowMultiple == false) 아이템의 양을 보여줄 필요 없음
//            EditorGUILayout.PropertyField(item.FindPropertyRelative("amount")); // 아이템의 양을 보여줌

//        GUILayout.EndHorizontal();

//        GUILayout.EndVertical();
//    }
//}

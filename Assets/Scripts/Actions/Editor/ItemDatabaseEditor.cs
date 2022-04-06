//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//// 메모 : 게임 오브젝트를 담아야 할듯 
//[CustomEditor(typeof(ItemDatabase))] // typeof( Inspector class ) 
//public class ItemDatabaseEditor : Editor
//{
//    // ItemDatabase = AddItem 메서드를 쓰기 위해 필요
//    ItemDatabase source;
//    SerializedProperty s_items, s_itemsName;

//    private void OnEnable() // Q. OnEnable ?? 
//    {
//        source = (ItemDatabase)target;
//        s_items = serializedObject.FindProperty("items"); // ItemDatabase 에서 정의한 이름대로 넣어줌
//        s_itemsName = serializedObject.FindProperty("itemsNames");
//    }

//    public override void OnInspectorGUI()
//    {
//        // 변화가 생기면 다음 프레임에 바로 반영 ( Add Item 버튼 누르면 디버그 하지 않아도 인스펙터에 바로 반영 )
//        serializedObject.Update();

//        //base.OnInspectorGUI();
//        if (GUILayout.Button("Add Item"))
//        {
//            Item newItem = new Item(s_items.arraySize, "", "", null,  false);    // s_items.arraySize : ItemID
//            source.AddItem(newItem);    // 새로운 아이템이 들어오면(newItem) 이것을 ItemDatabase 의 List<Item> items 에 저장
//        }

//        for (int i = 0; i < s_items.arraySize; i++)
//        {
//            // draw the item entry
//            DrawItemEntry(s_items.GetArrayElementAtIndex(i)); // SerializeField 이므로 GetArrayAtIndex 를 써야함
//        }
//        // Editor 안의 GUI 클래스에 접근해서 인스펙터에 바뀐 것이 있으면 true 를 반환하게 함
//        if(GUI.changed) // 변화가 생겼을 때 s_itemsName 이 바뀌지 않는 것 해결
//        {
//            ReCaluculateID();
//        }

//        serializedObject.ApplyModifiedProperties(); // SerializedProperty 를 사용하므로 넣어야함 
//    }

//    /* 아이템 엔트리를 그려주는 메서드 */
//    void DrawItemEntry(SerializedProperty item) // 아이템 총 개수가 필요함 ( item.arraySize )
//    {
//        GUILayout.BeginVertical("box");

//        GUILayout.BeginHorizontal();

//        // 수정하고 싶지 않으므로 static Inspector 가 되기 위해 LabelField 사용(아이템 ID = 배열에서 인덱스는 바뀔 일 없음), PropertyField 를 사용하면 인스펙터에서 값 수정 가능
//        EditorGUILayout.LabelField("Item Id: "+ item.FindPropertyRelative("itemId").intValue, GUILayout.Width(75f)); // Q. FindPropertyRelative?? "itemId : Item 클래스에 정의한대로 쓰기
//        EditorGUILayout.PropertyField(item.FindPropertyRelative("itemName")) ;

//        if(GUILayout.Button("x", GUILayout.Width(20f)))
//        {
//            // delete the item : access  s_items and delete the entry
//            s_itemsName.DeleteArrayElementAtIndex(item.FindPropertyRelative("itemId").intValue); // 배열 공부 다시 하고 싶어짐, 배열의 원소 삭제 방법 등등...
//            s_items.DeleteArrayElementAtIndex(item.FindPropertyRelative("itemId").intValue); // s_itemsNames 와 s_items 의 인덱스 순서가 같아서 그대로 쓰면 됨
            
//            ReCaluculateID(); // ID 를 하나 삭제하면 ID 를 다시 계산해야 함
//            return;

//        }

//        GUILayout.EndHorizontal();

//        EditorGUILayout.PropertyField(item.FindPropertyRelative("itemDescription"));

//        GUILayout.BeginHorizontal();
//        // 인스펙터에서 스프라이트 이미지를 보여주기 위해 ObjectField 사용
//        item.FindPropertyRelative("itemSprite").objectReferenceValue = EditorGUILayout.ObjectField("Item Sprite: ",
//            item.FindPropertyRelative("itemSprite").objectReferenceValue, typeof(Sprite), false); 
//        // 스프라이트 이미지를 에셋 폴더에서 가져올 것이기 때문에 false
//        EditorGUILayout.PropertyField(item.FindPropertyRelative("allowMultiple")); // 토글 버튼 참/거짓
//        GUILayout.EndHorizontal();

//        GUILayout.EndVertical();
//    }

//    /* 아이템을 삭제하면 나머지 아이템들의 ID 를 다시 계산해주고 ItemName도 다시 넣어주는  메서드 */
//    void ReCaluculateID() /* 배열 삭제법 관련해서 다시 공부해서 알고리즘 다시짜기~~~ */
//    {
//        for(int i=0; i<s_items.arraySize; i++)
//        {
//            s_items.GetArrayElementAtIndex(i).FindPropertyRelative("itemId").intValue = i;
//            // 인덱스는 자동적으로 이동하지만 다른 것들은 자동으로 바뀌지 않으므로 ItemId 에 i, 인덱스 값을 대입
//            s_itemsName.GetArrayElementAtIndex(i).stringValue =
//                s_items.GetArrayElementAtIndex(i).FindPropertyRelative("itemName").stringValue;
//        }

//    }

//}


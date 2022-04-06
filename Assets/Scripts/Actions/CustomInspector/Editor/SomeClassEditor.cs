using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/* SomeClass가 인스펙터에 보이는 모습들을 수정할 수 있는 스크립트 */
// 상속?? SomeClass 안에 있는  변수들 중 필요한 것만 모아서 원하는 인스펙터 만들기?
[CustomEditor(typeof(SomeClass))] // SomeClass 를 위한 Custom Inspector 를 만들 것이다.
public class SomeClassEditor : Editor // SomeClassEditor 는 Editor 클래스에서 파생된 클래스임
{
    SomeClass source;

    // serializeField 변수들을 가지고 커스텀 인스펙터 만들기
    SerializedProperty playerName, speed, playerPosition, playerPrefabs; // SerializeField 변수들은 Private 변수들이기 때문에 필요함

    private void OnEnable()
    {
        // source 는 type of subclass, target 은 object 이기 때문에  cast object to someclass or add a typecasting 필요함
        source = (SomeClass)target; // target : object being inspected, // 필드 선언 & 초기화하면 커스텀 인스펙터를 만들 수 있다. 

        /* SerializeField 변수들은 사실 Private 변수들이기 때문에 초기화가 필요함 */
        playerName = serializedObject.FindProperty("s_playerName");
        speed = serializedObject.FindProperty("s_speed");
        playerPosition = serializedObject.FindProperty("s_playerPosition");
        playerPrefabs = serializedObject.FindProperty("s_playerPrefabs");
    }

    /* 커스텀 인스펙터 만들기 */
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();    // base : 기본 인스펙터

        /* 커스텀 인스펙터 만들기 1 : public 변수들을 가지고  커스텀 인스펙터 만들기 */
        GUILayout.BeginVertical("box"); // box : 인스펙터의 변수들을 박스로 그룹지어줌
        source.playerName = EditorGUILayout.TextField("Player Name : ", source.playerName); // Public 변수들은 초기화 없이 바로 가능
        source.speed = EditorGUILayout.FloatField("speed : ", source.speed);
        source.playerPosition = EditorGUILayout.Vector3Field("playerPosition : ", source.playerPosition);
        // GameObject 로 casting 해줌, sprite 와 stuff 도 마찬가지,  true 이면 씬 안의 오브젝트도 끌어올 수 있고 false 이면 asset 폴더 안에 있는 오브젝트만 끌어올 수 있음 
        source.playerPrefabs = (GameObject)EditorGUILayout.ObjectField("GameObject: ", source.playerPrefabs, typeof(GameObject), true);
        GUILayout.EndVertical(); // 여기까지가 인스펙터 한 그룹임 


        /* 커스텀 인스펙터 만들기 2 : SerializeField  변수들을 가지고  커스텀 인스펙터 만들기 */
        GUILayout.BeginVertical("box");
        EditorGUILayout.PropertyField(playerName, new GUIContent("Player Name: ")); // new GUIContent : 인스펙터의 프로퍼티 앞에 레이블을 붙여줌
        EditorGUILayout.PropertyField(speed, new GUIContent("Player Speed: ")); // Q. PropertyField ?? 
        EditorGUILayout.PropertyField(playerPosition, new GUIContent("Player Position: "));
        EditorGUILayout.PropertyField(playerPrefabs, new GUIContent("Player Prefabs: "));
        GUILayout.EndVertical();

        // 인스펙터에 버튼도 만들 수 있음
        if (GUILayout.Button("Randomize Speed"))
        {
            source.speed = Random.Range(5f, 25f);
            //speed.floatValue = Random.Range(5f, 25f); // serializedProperty 의 speed 변수 바꾸기
        }

        serializedObject.ApplyModifiedProperties(); // SerializedProperty 를 쓰면 아래 문장을 써야 인스펙터 상에 변화가 생겨도 안전함
    }
}

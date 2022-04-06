using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/* SomeClass�� �ν����Ϳ� ���̴� ������� ������ �� �ִ� ��ũ��Ʈ */
// ���?? SomeClass �ȿ� �ִ�  ������ �� �ʿ��� �͸� ��Ƽ� ���ϴ� �ν����� �����?
[CustomEditor(typeof(SomeClass))] // SomeClass �� ���� Custom Inspector �� ���� ���̴�.
public class SomeClassEditor : Editor // SomeClassEditor �� Editor Ŭ�������� �Ļ��� Ŭ������
{
    SomeClass source;

    // serializeField �������� ������ Ŀ���� �ν����� �����
    SerializedProperty playerName, speed, playerPosition, playerPrefabs; // SerializeField �������� Private �������̱� ������ �ʿ���

    private void OnEnable()
    {
        // source �� type of subclass, target �� object �̱� ������  cast object to someclass or add a typecasting �ʿ���
        source = (SomeClass)target; // target : object being inspected, // �ʵ� ���� & �ʱ�ȭ�ϸ� Ŀ���� �ν����͸� ���� �� �ִ�. 

        /* SerializeField �������� ��� Private �������̱� ������ �ʱ�ȭ�� �ʿ��� */
        playerName = serializedObject.FindProperty("s_playerName");
        speed = serializedObject.FindProperty("s_speed");
        playerPosition = serializedObject.FindProperty("s_playerPosition");
        playerPrefabs = serializedObject.FindProperty("s_playerPrefabs");
    }

    /* Ŀ���� �ν����� ����� */
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();    // base : �⺻ �ν�����

        /* Ŀ���� �ν����� ����� 1 : public �������� ������  Ŀ���� �ν����� ����� */
        GUILayout.BeginVertical("box"); // box : �ν������� �������� �ڽ��� �׷�������
        source.playerName = EditorGUILayout.TextField("Player Name : ", source.playerName); // Public �������� �ʱ�ȭ ���� �ٷ� ����
        source.speed = EditorGUILayout.FloatField("speed : ", source.speed);
        source.playerPosition = EditorGUILayout.Vector3Field("playerPosition : ", source.playerPosition);
        // GameObject �� casting ����, sprite �� stuff �� ��������,  true �̸� �� ���� ������Ʈ�� ����� �� �ְ� false �̸� asset ���� �ȿ� �ִ� ������Ʈ�� ����� �� ���� 
        source.playerPrefabs = (GameObject)EditorGUILayout.ObjectField("GameObject: ", source.playerPrefabs, typeof(GameObject), true);
        GUILayout.EndVertical(); // ��������� �ν����� �� �׷��� 


        /* Ŀ���� �ν����� ����� 2 : SerializeField  �������� ������  Ŀ���� �ν����� ����� */
        GUILayout.BeginVertical("box");
        EditorGUILayout.PropertyField(playerName, new GUIContent("Player Name: ")); // new GUIContent : �ν������� ������Ƽ �տ� ���̺��� �ٿ���
        EditorGUILayout.PropertyField(speed, new GUIContent("Player Speed: ")); // Q. PropertyField ?? 
        EditorGUILayout.PropertyField(playerPosition, new GUIContent("Player Position: "));
        EditorGUILayout.PropertyField(playerPrefabs, new GUIContent("Player Prefabs: "));
        GUILayout.EndVertical();

        // �ν����Ϳ� ��ư�� ���� �� ����
        if (GUILayout.Button("Randomize Speed"))
        {
            source.speed = Random.Range(5f, 25f);
            //speed.floatValue = Random.Range(5f, 25f); // serializedProperty �� speed ���� �ٲٱ�
        }

        serializedObject.ApplyModifiedProperties(); // SerializedProperty �� ���� �Ʒ� ������ ��� �ν����� �� ��ȭ�� ���ܵ� ������
    }
}

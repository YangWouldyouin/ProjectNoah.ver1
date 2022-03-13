using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MessageAction))]
public class MessageActionEditor : Editor
{
    SerializedProperty s_messages, s_enableDialog, s_yesText, s_noText, s_yesActions, s_noActions;

    private void OnEnable()
    {
        s_messages = serializedObject.FindProperty("messages");
        s_enableDialog = serializedObject.FindProperty("enableDialog");
        s_yesText = serializedObject.FindProperty("yesText");
        s_noText = serializedObject.FindProperty("noText");
        s_yesActions = serializedObject.FindProperty("yesActions");
        s_noActions = serializedObject.FindProperty("noActions");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        //show add message
        if (GUILayout.Button("Add Message"))
        {
            s_messages.InsertArrayElementAtIndex(s_messages.arraySize);
        }

        //loop thru our message list
        for (int i = 0; i < s_messages.arraySize; i++)
        {
            DrawMessagesEntry(s_messages.GetArrayElementAtIndex(i), "Message " + (i + 1), i);
        }

        //show enableDialog toggle, if enabled, then show the dialog properties
        GUILayout.BeginVertical("box");

        EditorGUILayout.PropertyField(s_enableDialog, new GUIContent("Enable Dialog:"));

        if (s_enableDialog.boolValue)
        {
            EditorGUILayout.PropertyField(s_yesText, new GUIContent("Yes Button Label"), GUILayout.Height(30f));
            EditorExtensions.DrawActionsArray(s_yesActions, "Yes Actions");

            EditorGUILayout.PropertyField(s_noText, new GUIContent("No Button Label"), GUILayout.Height(30f));
            EditorExtensions.DrawActionsArray(s_noActions, "No Actions");
        }

        GUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }

    void DrawMessagesEntry(SerializedProperty messageEntry, string label, int id)
    {
        GUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        EditorGUILayout.PropertyField(messageEntry, new GUIContent(label), GUILayout.Height(50f));

        if (GUILayout.Button("x", GUILayout.Width(20f)))
        {
            s_messages.DeleteArrayElementAtIndex(id);
        }

        GUILayout.EndHorizontal();

        GUILayout.EndVertical();
    }
}

using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(UIText))]
public class UITextInspector : TextEditor
{
    private SerializedProperty m_DisableWordWrap;

    protected override void OnEnable()
    {
        base.OnEnable();
        m_DisableWordWrap = serializedObject.FindProperty("m_DisableWordWrap");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(m_DisableWordWrap);

        serializedObject.ApplyModifiedProperties();
    }

}

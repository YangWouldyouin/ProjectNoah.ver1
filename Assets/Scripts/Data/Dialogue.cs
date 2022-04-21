using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue
{
    //[Tooltip("��� ID")]
    //public int ID;
    [Tooltip("��� ����")]
    public string[] contexts;


}
[System.Serializable]
public class DialogueEvent
{
    public string name;

    public Vector2 line; // x��° ������ y��° ������ ����
    public Dialogue[] dialogues;
}
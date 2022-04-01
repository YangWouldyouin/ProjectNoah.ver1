using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Dialogue 
{
    [Tooltip("대사 치는 캐릭터 이름")]
    public string name;

    [Tooltip("대사 내용")]
    public string[] contexts;
}
[System.Serializable]
public class DialogueEvent
{
    public string name;

    public Vector2 line; // x번째 대사부터 y번째 대사까지 추출
    public Dialogue[] dialogues;
}

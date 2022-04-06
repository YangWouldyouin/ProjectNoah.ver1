using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeClass : MonoBehaviour
{
    /* public ���� ������ */
    public string playerName;
    public float speed;
    public Vector3 playerPosition;
    public GameObject playerPrefabs;

    /* SerializeField ���� ������ */
    [SerializeField] string s_playerName;
    [SerializeField] float s_speed;
    [SerializeField] GameObject s_playerPrefabs;
    [SerializeField] Vector3 s_playerPosition;
}

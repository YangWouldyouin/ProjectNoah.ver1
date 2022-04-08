using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insert_CardKey : MonoBehaviour, IInsertController
{
    public Animator noahCardKeyAnim;
    public GameObject cardKey;

    public void InsertSomething()
    {
        Invoke("ChangeInsertAnimTrue", 0.5f);
        Invoke("ChangeInsertAnimfalse", 1f);
    }

    void ChangeInsertAnimTrue()
    {
        noahCardKeyAnim.SetBool("IsInsertingAnim", true);
        cardKey.transform.position = new Vector3(14.17f, 34.449f, -5.684f); // 카드키 위치, 각도 바꿔
        cardKey.transform.rotation = Quaternion.Euler(90, 0, 0);
        cardKey.transform.parent = null;


    }

    void ChangeInsertAnimfalse()
    {
        noahCardKeyAnim.SetBool("IsInsertingAnim", false);
    }

}

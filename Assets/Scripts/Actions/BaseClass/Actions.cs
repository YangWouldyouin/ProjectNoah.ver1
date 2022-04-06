using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 클래스에서 상속된 클래스만 다른 게임 오브젝트에 붙일 수 있음
public abstract class Actions : MonoBehaviour
{
    // abstract 정의가 붙은 메서드는 바디 코드를 쓸 수 없다\
    // 그러나 이 클래스를 상속한 모든 클래스들은 반드시 이 메서드를 가지고 있어야 하나 정의는 다르게 할 수 있어서 
    // 다양한 actions 을 만들 수 있다. 
    public abstract void Act();
}

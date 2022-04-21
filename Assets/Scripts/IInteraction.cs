using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteraction
{
    void OnBark();
    void OnSniff();
    void OnBiteDestroy();
    void OnPushOrPress();
    void OnEat();
    void OnObserve();
    void OnUp();
    void OnInsert();
}

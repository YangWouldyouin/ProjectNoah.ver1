//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SceneCameraControl : MonoBehaviour
//{
//    public Camera maincamera;

//    [SerializeField] Transform CockpitView;
//    [SerializeField] Transform WorkView;
//    //[SerializeField] Transform LivingView;
//    //[SerializeField] Transform EngineView;

//    [SerializeField] GameObject noahPlayer;

//    private void Update()
//    {
//        if (noahPlayer.transform.position.x > 25)
//        {
//            changeView(WorkView);
//        }

//        if (noahPlayer.transform.position.x <= 24)
//        {
//            changeView(CockpitView);
//        }
//    }

//    void changeView(Transform view)
//    {
//        maincamera.transform.position = view.position;
//        maincamera.transform.rotation = view.rotation;
//    }
//}

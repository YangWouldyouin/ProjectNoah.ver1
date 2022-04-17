using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLookAT : MonoBehaviour
{
    public Transform target;
    public Transform canvas;
    private Camera camera;

    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = camera.WorldToScreenPoint(new Vector3(target.localPosition.x + offsetX, target.localPosition.y + offsetY, target.localPosition.z + offsetZ));

        transform.position = new Vector3(screenPos.x, screenPos.y, transform.position.z);
    }
}

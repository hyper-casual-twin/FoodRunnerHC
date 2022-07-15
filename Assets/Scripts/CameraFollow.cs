using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;
    Vector3 offSet;
    void Start()
    {
        offSet = new Vector3(0, 2.34f, -2.36f);
    }

    void Update()
    {
       transform.position = followObject.position + offSet;
    }
}

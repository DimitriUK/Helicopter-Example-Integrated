using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * 10);
    }
}

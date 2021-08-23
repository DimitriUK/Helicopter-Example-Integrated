using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericLerp : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Target.position.x, Target.position.y, -10), Time.deltaTime * 10);
    }
}

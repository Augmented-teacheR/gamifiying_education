using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBlocker : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MovementType
{
    time, velocity
}

public class Car : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector3 position;

    private float distance;
    private float time;
    private float velocity;
    private MovementType state;

    public void Go(float distance, float time, float velocity)
    {
        if (distance == 0) 
            this.distance = 15;
        if (time == 0) 
            this.time = 10;
        if (velocity == 0) 
            this.velocity = 5;

        switch (state)
        {
            case MovementType.velocity:

                break;
        }
    }
}

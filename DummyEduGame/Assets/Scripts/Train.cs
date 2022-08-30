using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrainState
{
    running, finished
}
public class Train : MonoBehaviour
{

    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private TrainState state = TrainState.finished;

    private void Update()
    {
        if (state != TrainState.finished)
        {
            float x = transform.position.x + speed * Time.deltaTime;
            float y = transform.position.y;
            float z = transform.position.z;

            transform.position = new Vector3(x, y, z);
            if (x > 10) state = TrainState.finished;
        }
    }

    internal void Begin()
    {
        state = TrainState.running;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Entered");
        state = TrainState.finished;
    }
}
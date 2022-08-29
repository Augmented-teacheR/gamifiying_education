using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Car car;
    [SerializeField]
    private Train train;
    [SerializeField]
    private CodeBlock codeBlock;
    [SerializeField]
    private float speed;

    public Car Car { get => car; set => car = value; }
    public Train Train { get => train; set => train = value; }
    public CodeBlock CodeBlock { get => codeBlock; set => codeBlock = value; }

    public void play()
    {
        car.Go(50,5,0);
        train.Begin();
        Debug.Log("Button clicked");
    }
}

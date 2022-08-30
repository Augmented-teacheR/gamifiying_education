using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField]
    private Car car;
    [SerializeField]
    private Train train;
    [SerializeField]
    private CodeBlock codeBlock;

    [Separator]
    [Header("Car Variables")]
    [SerializeField]
    private float carTime;
    [SerializeField]
    private float carDistance;
    [SerializeField]
    private float carVelocity;

    public Car Car { get => car; set => car = value; }
    public Train Train { get => train; set => train = value; }
    public CodeBlock CodeBlock { get => codeBlock; set => codeBlock = value; }


    public void Play()
    {
        SetCarValues();
        car.Go(carDistance, carTime, carVelocity);
        train.Begin();
        Debug.Log("Button clicked");
    }

    private void SetCarValues()
    {
        codeBlock.ReadValues();
        this.carDistance = codeBlock.GetDistance();
        this.carTime = codeBlock.GetTime();
        this.carVelocity = codeBlock.GetVelocity();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
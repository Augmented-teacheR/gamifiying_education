using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    private GameManager _gameManager;
    [SerializeField]
    private GameObject car;
    private Car _car;
    private bool isCarSet = false;
    private float startingCarPosition;
    private bool playStarted = false;

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public float StartingCarPosition { get => startingCarPosition; set => startingCarPosition = value; }
    public bool PlayStarted { get => playStarted; set => playStarted = value; }

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameManager = gameManager.GetComponent<GameManager>();
        _gameManager.CarInteraction = this;
        StartCoroutine(_gameManager.StartCar());
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    /*    private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Car") && !isCarSet)
            {
                this.car = other.gameObject;
                this._car = this.car.GetComponent<Car>();
                StartingCarPosition = this.car.transform.position.z;
                isCarSet = true;
            }
        }*/
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindCar();
        }
    }
    void FindCar()
    {
        visibleTargets.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            if (targetsInViewRadius[i].gameObject.tag.Equals("Car") && !isCarSet)
            {
                this.car = targetsInViewRadius[i].gameObject;
                this._car = this.car.GetComponent<Car>();
                StartingCarPosition = this.car.transform.position.z;
                isCarSet = true;
            }
        }
    }

    private void Update()
    {
        if (isCarSet)
        {
            if ((car.transform.position.z < StartingCarPosition + 1)
            && (car.transform.position.z > StartingCarPosition - 5)
            && !PlayStarted)
            {
                car.transform.position
                = new Vector3(car.transform.position.x, car.transform.position.y, this.transform.position.z);
            }
            if (car.transform.position.z < StartingCarPosition - 4)
            {
                PlayStarted = true;
            }
        }
    }


}

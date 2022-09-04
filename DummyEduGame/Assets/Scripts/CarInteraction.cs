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
    [SerializeField]
    private GameObject target;
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
        Debug.Log("Corutine started find target");
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
                StartingCarPosition = this.car.transform.localPosition.z;
                isCarSet = true;
                Debug.Log("Car found");
            }
        }
    }

    private void Update()
    {
        if (isCarSet)
        {
            if ((car.transform.localPosition.z < StartingCarPosition + 3)
            && (car.transform.localPosition.z > StartingCarPosition - 5)
            && !PlayStarted)
            {
                float zPos = target.transform.position.z;
                float zPosMapped = Map(zPos, -0.06f, -0.017f, -50, -34);
                var step = 1000 * Time.deltaTime; // calculate distance to move
                car.transform.localPosition = Vector3.MoveTowards(car.transform.localPosition, new Vector3(car.transform.localPosition.x, car.transform.localPosition.y, zPosMapped), step);

                //car.transform.localPosition
                //= new Vector3(car.transform.localPosition.x, car.transform.localPosition.y, zPos);
            }
            if (car.transform.localPosition.z < StartingCarPosition - 4)
            {
                PlayStarted = true;
            }
        }
    }


    public static float Map(float value, float fromSource, float toSource, float fromTarget, float toTarget)
    {
        return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
    }


}

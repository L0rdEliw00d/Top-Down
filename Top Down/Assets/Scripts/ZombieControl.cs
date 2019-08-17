using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieControl : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D myRigidbody2D;

    private bool moving;

    public float timeBetweenMove;
    private float TimeBetweenMoveCounter;
    public float TimeToMove;
    private float TimeToMoveCounter;
    private Vector3 moveDirection;

    public float waitToReload;
    private bool reloading;
    private GameObject Player;
    private Vector3 previousPos;
    private float angle;

    // Start is called before the first frame update
    private void Awake()
    {
       previousPos = transform.position;
    }

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        //TimeBetweenMoveCounter = timeBetweenMove;
        //TimeToMoveCounter = TimeToMove;

        TimeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        TimeToMoveCounter = Random.Range(TimeToMove * 0.75f, TimeToMove * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {

            TimeToMoveCounter -= Time.deltaTime;
            myRigidbody2D.velocity = moveDirection;

            if (TimeToMoveCounter < 0f)
            {
                moving = false;
                //TimeBetweenMoveCounter = timeBetweenMove;
                TimeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        
        }
        else
        {
            TimeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody2D.velocity = Vector2.zero;

            if (TimeBetweenMoveCounter < 0f)
            {
                moving = true;
                //TimeToMoveCounter = TimeToMove;
                TimeToMoveCounter = Random.Range(TimeToMove * 0.75f, TimeToMove * 1.25f);

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                Player.SetActive(true);

            }
        }
        Vector3 dic = transform.position - previousPos;

        if(dic != Vector3.zero)
        {
            angle = Mathf.Atan2(dic.y, dic.x) * Mathf.Rad2Deg;

            Quaternion newRotation = Quaternion.AngleAxis((angle), Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 1f);
        }
        previousPos = transform.position;
        //transform.LookAt(myRigidbody2D.velocity + myRigidbody2D.position, new Vector3 (0,0,1));
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            Player = other.gameObject;
        }

    }
}

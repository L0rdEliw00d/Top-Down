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

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();

        TimeBetweenMoveCounter = timeBetweenMove;
        TimeToMoveCounter = TimeToMove;
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
                TimeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            TimeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody2D.velocity = Vector2.zero;

            if (TimeBetweenMoveCounter < 0f)
            {
                moving = true;
                TimeToMoveCounter = TimeToMove;

                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
    }
}

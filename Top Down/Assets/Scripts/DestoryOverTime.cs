using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOverTime : MonoBehaviour
{

    public float timeToDestory;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestory -= Time.deltaTime;

        if (timeToDestory <= 0)
        {
            Destroy(gameObject);
        }
    }
}

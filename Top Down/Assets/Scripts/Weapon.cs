using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firepoint;
    private int damage = 10;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        


        //RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, firepoint.forward);

        //    if(hitinfo)
        //{
        //    ZombieControl enemy = hitinfo.transform.GetComponent<ZombieControl>();
        //    if (enemy != null)
        //    {
        //        //enemy.takeDamage(damage);
        //        Debug.Log(hitinfo);


        //        Instantiate(impactEffect, hitinfo.point, Quaternion.identity);

        //        lineRenderer.SetPosition(0, firepoint.position);
        //        lineRenderer.SetPosition(1, hitinfo.point);
        //    }
        //    else
        //    {
        //        lineRenderer.SetPosition(0, firepoint.position);
        //        lineRenderer.SetPosition(1, firepoint.position + firepoint.forward * 100);
        //    }
        //}

    }
    void takeDamage()
    {

    }
}

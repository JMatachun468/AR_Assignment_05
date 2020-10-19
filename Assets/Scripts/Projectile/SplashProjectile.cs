using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashProjectile : Projectile
{
    public GameObject direction;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    void shoot()
    {
        rb.velocity = speed * direction.gameObject.transform.forward;  
    }
        
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject target;
    public float speed;
    public int damage;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, 3);
    }
    void Update()
    {
        TrackEnemy();
    }

    void TrackEnemy()
    {
        Vector3 direction = Vector3.zero;

        direction = target.transform.position - transform.position;

        rb.velocity = direction.normalized * speed;
    }

    protected void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}

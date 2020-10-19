using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();

        Path = TDManager.Instance.enemyPath;
    }

    // Update is called once per frame
    void Update()
    {
        Pathing();

        if (health <= 0)
        {
            Die();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : Enemy
{
    
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();

        isFlying = false;
        Path = TDManager.Instance.enemyPath;
    }
    void Update()
    {
        Pathing();

        if (health <= 0)
        {
            Die();
        }
    }
}

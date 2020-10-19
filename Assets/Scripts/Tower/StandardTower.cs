using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardTower : Tower
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count > 0 && enemies[0] == null)
        {
            enemies.RemoveAt(0);
        }
        attackEnemy();
    }

    public override void attackEnemy()
    {
        if (enemies.Count > 0)
        {
            attackTimer += Time.deltaTime * attackSpeed;

            if (attackTimer >= 1)
            {
                Rigidbody clone;
                clone = Instantiate(projectile, transform.position, transform.rotation);

                clone.gameObject.GetComponent<Projectile>().target = enemies[0];
                clone.gameObject.GetComponent<Projectile>().damage = attackDamage;
                clone.gameObject.GetComponent<Projectile>().speed = projectileSpeed;

                attackTimer = 0;
            }
        }
    }
}

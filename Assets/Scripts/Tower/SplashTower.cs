using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashTower : Tower
{
    public List<GameObject> directionals;

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
                foreach(GameObject go in directionals)
                {
                    Rigidbody clone;
                    clone = Instantiate(projectile, go.transform.position, go.transform.rotation);

                    clone.gameObject.GetComponent<SplashProjectile>().damage = attackDamage;
                    clone.gameObject.GetComponent<SplashProjectile>().speed = projectileSpeed;
                    clone.gameObject.GetComponent<SplashProjectile>().direction = go;

                }
                attackTimer = 0;
            }
        }
    }
}

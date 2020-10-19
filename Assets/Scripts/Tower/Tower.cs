using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public List<GameObject> enemies;
    public Rigidbody projectile;
    public GameObject rangeindicator;

    public float projectileSpeed;
    public float attackSpeed;
    public float attackTimer;
    public int attackDamage;
    public int towerCost;

    public virtual void attackEnemy()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            enemies.Remove(other.gameObject);
        }
    }
}

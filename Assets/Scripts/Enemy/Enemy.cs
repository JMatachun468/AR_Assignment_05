using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    protected Transform trans;
    public Rigidbody rb;

    int index = 0;
    public List<GameObject> Path;

    public float health;
    public bool isFlying;
    public float speed;

    void Start()
    {
        trans = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();

        Path = TDManager.Instance.enemyPath;
    }

    public void Pathing()
    {
        trans.position = Vector3.MoveTowards(trans.position,Path[index].transform.position + new Vector3(0,0.5f,0), Time.deltaTime*speed);

        if(trans.position == Path[index].transform.position + new Vector3(0, 0.5f, 0))
        {
            index++;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        Destroy(gameObject);
        TDManager.Instance.enemyDeath(gameObject);
    }
}

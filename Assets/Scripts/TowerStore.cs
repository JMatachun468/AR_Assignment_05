using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStore : MonoBehaviour
{

    public GameObject standardTower;
    public GameObject splashTower;
    public GameObject towerBase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyStandard()
    { 
        if(TDManager.Instance.playerMoney >= 10)
        {
            Instantiate(standardTower, towerBase.transform.position + new Vector3(0,0.3f,0), towerBase.transform.rotation);
            TDManager.Instance.playerMoney -= 10;
            gameObject.SetActive(false);
        }

    }

    public void buySplash()
    {
        if (TDManager.Instance.playerMoney >= 20)
        {
            Instantiate(splashTower, towerBase.transform.position + new Vector3(0, 0.3f, 0), towerBase.transform.rotation);
            TDManager.Instance.playerMoney -= 20;
            gameObject.SetActive(false);
        }

    }

}

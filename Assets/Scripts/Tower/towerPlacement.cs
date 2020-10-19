using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerPlacement : MonoBehaviour
{
    public GameObject towerStore;
    public Camera camera;
    void Start()
    {
        
    }

    void Update()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray ray = camera.ScreenPointToRay(Input.GetTouch(i).position);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                { 
                    if(hit.collider.gameObject.GetComponent<towerPlacement>())
                    {
                        towerStore.SetActive(true);
                        towerStore.GetComponent<TowerStore>().towerBase = hit.collider.gameObject;
                    }
                }
            }
        }
    }
}

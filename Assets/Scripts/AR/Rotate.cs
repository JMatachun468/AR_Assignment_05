using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public GameObject ARCamera;
    public float rotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotation = GetComponent<Slider>().value;

        ARCamera.transform.eulerAngles = new Vector3(0, rotation, 0);
    }
}

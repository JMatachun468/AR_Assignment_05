using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    public GameObject ARCamera;
    public float scale;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scale = GetComponent<Slider>().value;

        ARCamera.transform.localScale = new Vector3(scale, scale, scale);
    }
}

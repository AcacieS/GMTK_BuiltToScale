using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundThing : MonoBehaviour
{
    private float length, startposX, startposY;
    [SerializeField] public GameObject cam;
    [SerializeField] private float parallaxIntensity;
    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
        length = transform.Find("0").GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame for both X and Y
    void Update()
    {
        float tempX = cam.transform.position.x*(1-parallaxIntensity);
        float distX = cam.transform.position.x*parallaxIntensity;
        float distY = cam.transform.position.y*parallaxIntensity;

        transform.position = new Vector3(startposX + distX, startposY + distY , transform.position.z);

        if (tempX > startposX + length) startposX += length;
        else if (tempX < startposX - length) startposX -= length;
    }
}

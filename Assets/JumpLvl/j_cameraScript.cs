using System;
using UnityEngine;

public class j_cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera myCamera;
    public GameObject player;
    //private float cameraX;
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float cameraY = player.transform.position.y;
        if (cameraY < -2.2f)
        {
            cameraY = -2.2f;
        }
        
        GameObject limitTop = GameObject.FindWithTag("limitTop");

        if (limitTop) {
            Debug.Log("I am here");
            Transform limitTopTransform = limitTop.GetComponent<Transform>();

            float maxCameraY = limitTopTransform.position.y - 25;
            Debug.Log(maxCameraY);
            cameraY = Math.Min(cameraY, maxCameraY);
        }

        myCamera.transform.position = new Vector3(1.200001f, cameraY, -15f);
    }

}


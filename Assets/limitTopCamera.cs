using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitTopCamera : MonoBehaviour
{
    public static bool hasCollide = false;
    public static float limitTop;
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "limitTop"){
            hasCollide = true;
            limitTop = col.gameObject.transform.position.y;
        }
    }
}

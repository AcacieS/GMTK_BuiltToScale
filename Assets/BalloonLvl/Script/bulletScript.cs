using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
    }
}

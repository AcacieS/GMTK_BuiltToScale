using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
       // rb.velocity = transform.forward;
       // new Vector2(speed, rb.velocity.x);
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "wall"){
            Destroy(gameObject);
        }
    }
}

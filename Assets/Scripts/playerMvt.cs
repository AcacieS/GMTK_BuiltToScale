using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class playerMvt : MonoBehaviour
{
    public float speed;
    public float velocityJump;
    public bool isMoving;
    public logicScript logic;
    public SpawnCoinScript coinS;
    private Rigidbody2D body;
    public Animator anim;
    private CircleCollider2D circleCol;
    private BoxCollider2D boxCol;
    [SerializeField] private AudioClip coinSound;


    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        coinS = GameObject.FindGameObjectWithTag("spawnCoin").GetComponent<SpawnCoinScript>();
        circleCol = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        boxCol = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (logic.numbLvl==0)
        {
            body.gravityScale = 0;
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;
            circleCol.enabled = true;
            boxCol.size = new Vector2(boxCol.size.y,boxCol.size.y);
        }
        else if(logic.numbLvl==1){
            boxCol.size = new Vector2(3,boxCol.size.y);
            circleCol.enabled = false;
            boxCol.enabled = true;
            body.gravityScale = 1;
            bool fallingVelocity = body.velocity.y < 0f;
            //set animator parameters
            anim.SetBool("isFalling", fallingVelocity);
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }else if(logic.numbLvl==2){
            boxCol.size = new Vector2(3,boxCol.size.y);
            circleCol.enabled = false;
            boxCol.enabled = true;
            body.gravityScale = 1;
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }else{

        }
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        

        //bool fallingVelocity = body.velocity.y<0f;
        //set animator parameters
        // anim.SetBool("isFalling", fallingVelocity);
        //Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        //transform.position = transform.position + horizontal * Time.deltaTime;
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "knife")
        {
            Destroy(gameObject);
        }else if(col.gameObject.tag == "coin"){
            Destroy(col.gameObject);
            logic.addCoin();
            SoundManagerScript.instance.PlaySound(coinSound);
            logic.lvlCoin ++;
            coinS.isCoin = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "tong"){
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * velocityJump;
            //SoundManagerScript.instance.PlaySound(bouncingSound);
        }

    }
}

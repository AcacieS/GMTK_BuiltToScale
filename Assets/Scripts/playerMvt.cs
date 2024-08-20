using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private CapsuleCollider2D capCol;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip jumpSound;


    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        coinS = GameObject.FindGameObjectWithTag("spawnCoin").GetComponent<SpawnCoinScript>();
        circleCol = GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>();
        boxCol = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        capCol = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (logic.getNumbLvl(2))
        {
            body.gravityScale = 0;
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;
            circleCol.enabled = true;
            boxCol.size = new Vector2(boxCol.size.y, boxCol.size.y);
        }
        else if (logic.getNumbLvl(1))
        {

            circleCol.enabled = false;
            boxCol.enabled = false;
            capCol.enabled = true;
            body.gravityScale = 1;
            bool fallingVelocity = body.velocity.y < 0f;
            anim.SetBool("isFalling", fallingVelocity);
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

            if (body.velocity.y < -25)
            {
                anim.SetBool("isDeadFall", true);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y - 0.5f);
            }
        }
        else if (logic.getNumbLvl(3))
        {
            boxCol.size = new Vector2(3, boxCol.size.y);
            circleCol.enabled = false;
            boxCol.enabled = true;
            body.gravityScale = 1;
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        }
        else
        {

        }
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        //transform.position = transform.position + horizontal * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "knife")
        {
            Destroy(gameObject);
            logic.gameOver("player_balloonEndState");
        }
        else if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            logic.addCoin();
            SoundManagerScript.instance.PlaySound(coinSound);
            logic.lvlCoin++;
            coinS.isCoin = false;
        }
         else if (col.gameObject.tag == "gameOverBar")
        {
            logic.addNumbLvl();
            
        }
        else if (col.gameObject.tag == "endWall")
        {
            logic.addNumbLvl();
            StartCoroutine(logic.NewScene(logic.thirdScene, logic.lvl3Scene, logic.timeScene));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "tong")
        {
            SoundManagerScript.instance.PlaySound(jumpSound);
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * velocityJump;
        }
        else if (collision.collider.tag == "endG" && anim.GetBool("isDeadFall") == true)
        {
            //logic.gameOver("player_cEndState");
            anim.SetBool("isDead", true);
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

    }
}

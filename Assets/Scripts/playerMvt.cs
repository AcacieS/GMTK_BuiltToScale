
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
        float playerVelocity = body.velocity.y;
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (logic.getNumbLvl(1)) //jump
        {
            Debug.Log("???");
            //collider
            circleCol.enabled = false;
            boxCol.enabled = false;
            capCol.enabled = true;

            body.gravityScale = 1;

            //movement
            bool fallingVelocity = body.velocity.y < 0f;
            anim.SetBool("isFalling", fallingVelocity);
            
            //dying & movement
           
            if (playerVelocity < -25)
            {
                Debug.Log("sadaf");
                anim.SetBool("isDeadFall", true);
                playerVelocity-=0.5f;
            }
            body.velocity = new Vector2(horizontalInput * speed, playerVelocity);
        }
        else if (logic.getNumbLvl(2)) //balloon
        {
            Debug.Log("aaaaa");
            //collider
            circleCol.enabled = true;
            circleCol.radius=2.634082f;
            boxCol.size = new Vector2(boxCol.size.y, boxCol.size.y);

            body.gravityScale = 0;

            //movement
            Vector3 horizontal = new Vector3(horizontalInput * speed, Input.GetAxis("Vertical") * speed, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;
        }
        
        else if (logic.getNumbLvl(3)) //lion
        {
            //collider
            boxCol.size = new Vector2(3, boxCol.size.y);
            circleCol.enabled = false;
            boxCol.enabled = true;

            body.gravityScale = 1;

            //movement
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
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
        //coin
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            logic.addCoin();
            SoundManagerScript.instance.PlaySound(coinSound);
            coinS.isCoin = false;
        }

        //dying balloon
        if (col.gameObject.tag == "knife") 
        {
            anim.SetBool("isDead", true);
        }
        //winning for jump and lion
        else if (col.gameObject.tag == "endWall")
        {
            logic.addNumbLvl();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "tong") //jump
        {
            Debug.Log("Jumped");
            SoundManagerScript.instance.PlaySound(jumpSound);
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.up * velocityJump;
        }
        else if (col.collider.tag == "endG" && anim.GetBool("isDeadFall") == true) //dying jump
        {
            anim.SetBool("isDead", true);
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

    }
}

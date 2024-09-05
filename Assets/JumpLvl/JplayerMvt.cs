using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JplayerMvt : MonoBehaviour
{
    public float speed;
    public float velocityJump;
    public GameObject tuto1;
     public GameObject NPC_dialogue;
    public SpawnCoinScript coinS;
    private Rigidbody2D body;
    public Animator anim;
    public Text coinText;
    private float playerSPosY;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip coinSound;


    void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("coinT").GetComponent<Text>();
        playerSPosY = transform.position.y;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coinS = GameObject.FindGameObjectWithTag("spawnCoin").GetComponent<SpawnCoinScript>();
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
         coinText.text = globalScript.lvlCoin.ToString();
        
        if (anim.GetBool("isShoot")==true)
        {
            NPC_dialogue.SetActive(false);
            float playerVelocity = body.velocity.y;
            float horizontalInput = Input.GetAxis("Horizontal");

            //movement
            if (anim.GetBool("isShoot") == true)
            {
                bool fallingVelocity = body.velocity.y < 0f;
                anim.SetBool("isFalling", fallingVelocity);
            }

            //dying & movement

            if (playerVelocity < -25)
            {
                anim.SetBool("isDeadFall", true);
                playerVelocity -= 0.5f;
            }
            body.velocity = new Vector2(horizontalInput * speed, playerVelocity);


            if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }else{
            transform.position = new Vector3(transform.position.x, playerSPosY, transform.position.z);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //coin
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            SoundManagerScript.instance.PlaySound(coinSound);
            globalScript.addCoin();
            coinS.isCoin = false;
        }

        //winning for jump and lion
        else if (col.gameObject.tag == "endWall")
        {
            globalScript.addNumbLvl();
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "tong") //jump
        {
            tuto1.SetActive(false);
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


using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class lionPlayerMvt : MonoBehaviour
{
    public float speed;
    public bool isMoving;
    public l_spawnCoinScript coinS;
    private Rigidbody2D body;
    public Animator anim;
    public Animator tigerAnim;
    private tigerLogicScript tigerLogic;
    [SerializeField] private AudioClip coinSound;
    private Vector3 localS;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coinS = GameObject.FindGameObjectWithTag("spawnCoin").GetComponent<l_spawnCoinScript>();
        body = GetComponent<Rigidbody2D>();
        tigerLogic = GameObject.FindGameObjectWithTag("tigerLogic").GetComponent<tigerLogicScript>();
        tigerAnim = GameObject.FindGameObjectWithTag("tiger").GetComponent<Animator>();
        localS = transform.localScale;
    }


    void Update()
    {
        if(globalScript.lvlCoin>=6){
            globalScript.addNumbLvl();
        }
        float horizontalInput = Input.GetAxis("Horizontal");

        //movement
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(localS.x, localS.y, localS.z);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-localS.x, localS.y, localS.z);
        }
        //float vx = Input.GetAxis("Horizontal") * 5;
        //body.velocity = new Vector2(vx, 0);
        if (horizontalInput == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }
        if (!tigerLogic.shouldPlayerMove() && horizontalInput != 0)
        {
            anim.SetBool("isDead", true);
            tigerAnim.SetBool("isDead", true);

            StartCoroutine(Restart(3));
        }
    }
    public IEnumerator Restart(int secs)
    {
        yield return new WaitForSeconds(secs);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //coin
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            globalScript.addCoin();
            SoundManagerScript.instance.PlaySound(coinSound);
            coinS.SpawnNewCoin();
        }
    
    }
}


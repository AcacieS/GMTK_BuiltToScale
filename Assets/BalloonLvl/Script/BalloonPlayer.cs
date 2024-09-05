using UnityEngine;
using UnityEngine.SceneManagement;
public class BalloonPlayer : MonoBehaviour
{
    public float speed;
    public b_spawnCoinScript coinS;
    public GameObject SpawnBullet;
    public GameObject B_logic;
    private Rigidbody2D body;
    public Animator anim;
    private Vector3 localS;
    [SerializeField] private AudioClip coinSound;


    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coinS = GameObject.FindGameObjectWithTag("spawnCoin").GetComponent<b_spawnCoinScript>();
        body = GetComponent<Rigidbody2D>();
        localS = transform.localScale;
    }


    void Update()
    {
        if(globalScript.tutoActive==true){
            anim.SetBool("isTutoActive", true);
            SpawnBullet.SetActive(true);
            B_logic.SetActive(true);
            float horizontalInput = Input.GetAxis("Horizontal");

            //movement
            Vector3 horizontal = new Vector3(horizontalInput * speed, Input.GetAxis("Vertical") * speed, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;
            

            if (horizontalInput > 0.01f)
            {
                transform.localScale = new Vector3(localS.x, localS.y, localS.z);
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-localS.x, localS.y, localS.z);
            }
        }else{

        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //coin
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            globalScript.addCoin();
            SoundManagerScript.instance.PlaySound(coinSound);
            coinS.isCoin = false;
        }

        //dying balloon
        if (col.gameObject.tag == "knife")
        {
            anim.SetBool("isDead", true);
        }
    }

}


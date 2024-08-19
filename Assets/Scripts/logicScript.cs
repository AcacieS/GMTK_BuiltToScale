using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public GameObject player;
    public GameObject SpawnBulletP;
    public Animator anim;
    public int numbLvl;
    public int lvlCoin = 0;
    public static int numbCoin = 0;
    public int lvlShoot = 0;
    public int lvlJump = 0;
    public Text coinText;
    public bool isShootLvlS = false;
    public bool isJumpLvlS = false;
    [SerializeField] private AudioClip inflateSound;
    // Update is called once per frame

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    void Update()
    {
        numbLvl = SceneManager.GetActiveScene().buildIndex;
        coinText.text = numbCoin.ToString();
        if (numbLvl == 0)
        {
            if (isShootLvlS)
            {
                SoundManagerScript.instance.PlaySound(inflateSound);
                IsShootF();
            }

            if (lvlCoin >= 3)
            {
                nextLvl();
                isJumpLvlS = true;
            }
        }
        else if (numbLvl == 1)
        {
            SpawnBulletP.SetActive(false);
            if (isJumpLvlS)
            {
                IsJumpF();
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_canoonShoot"))
            {
                player.GetComponent<Rigidbody2D>().velocity = player.transform.up * 20;
            }
            if(lvlCoin>=10){
            
            }
        }else if(numbLvl == 2){
            
        }

    }
    public void addCoin(){
      numbCoin++;  
    }
    private void IsShootF()
    {
        lvlCoin = 0;
        isShootLvlS = false;
        lvlShoot++;
        player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        SpawnBulletP.SetActive(true);
        anim.SetFloat("numbLvl", numbLvl);
    }
    private void IsJumpF()
    {
        lvlCoin = 0;
        isJumpLvlS = false;
        lvlJump++;
        anim.SetFloat("numbLvl", numbLvl);
    }
    public void nextLvl()
    {
        numbLvl++;
        SceneManager.LoadScene(numbLvl);
    }
}

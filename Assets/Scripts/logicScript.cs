using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class logicScript : MonoBehaviour
{
    public GameObject player;
    public GameObject SpawnBulletP;
    public GameObject introScene;
    public GameObject firstScene;
    public GameObject lvl1Scene;
    public GameObject secondScene;
    public GameObject lvl2Scene;
    public GameObject thirdScene;
    public GameObject lvl3Scene;
    public GameObject zeroScene;
    public GameObject lvl0Scene;
    public newSceneScript newSceneS;
    public Animator anim;
    public static int numbLvl;
    public int lvlCoin = 0;
    public static int numbCoin = 0;
    public int lvlShoot = 0;
    public int lvlJump = 0;
    public Text coinText;
    public static bool is1S = false;
    public static bool is2S = false;
    public static bool is3S = false;
    public static bool is0S = false;
    public static bool oneTime = false;
    public static bool isIntro = true;
    private int timeScene = 3;
    [SerializeField] private AudioClip inflateSound;
    [SerializeField] private AudioClip isShootSound;
    public Animator animCanoon;
    // Update is called once per frame

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    void Update()
    {
        if (isIntro)
        {
            if (Input.GetKeyDown("e"))
            {
                newScene(introScene, zeroScene, 0);
                isIntro = false;
                is0S = true;
            }
        }
        else
        {
            numbLvl = SceneManager.GetActiveScene().buildIndex;
            coinText.text = numbCoin.ToString();
            //balloon
            if (numbLvl == 1)
            {
                if (is1S)
                {
                    newScene(firstScene, lvl1Scene, timeScene);
                    SoundManagerScript.instance.PlaySound(inflateSound);
                    IsShootF();
                }

                if (lvlCoin >= 3)
                {
                    nextLvl();
                    is1S = true;
                }
            }
            //jump
            else if (numbLvl == 0)
            {
                SpawnBulletP.SetActive(false);
                if (is0S)
                {
                    newScene(zeroScene, lvl0Scene, timeScene);
                    SoundManagerScript.instance.PlaySound(isShootSound);
                    IsJumpF();
                }
                if (animCanoon.GetCurrentAnimatorStateInfo(0).IsName("canoonState"))
                {
                    anim.SetBool("isShoot", true);
                    if (oneTime == false)
                    {
                        player.GetComponent<Rigidbody2D>().velocity = player.transform.up * 40;
                        oneTime = true;
                    }
                }
            }
            //tiger
            else if (numbLvl == 2)
            {
                if(is2S){
                    newScene(secondScene, lvl2Scene, timeScene);
                }
            //bycle
            }else{
                if(is3S){
                    newScene(thirdScene, lvl3Scene, timeScene);
                }
            }
        }

    }
    public bool getNumbLvl(int numCompare)
    {
        return numbLvl == numCompare;
    }
    public void addCoin()
    {
        numbCoin++;
    }
    private void IsShootF()
    {
        lvlCoin = 0;
        is2S = false;
        lvlShoot++;
        player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        SpawnBulletP.SetActive(true);
        anim.SetFloat("numbLvl", numbLvl);
    }
    private void IsJumpF()
    {
        lvlCoin = 0;
        is0S = false;
        lvlJump++;
        anim.SetFloat("numbLvl", numbLvl);
    }
    public void nextLvl()
    {
        numbLvl++;
        SceneManager.LoadScene(numbLvl);
    }
    public void gameOver(string endState)
    {
        anim.SetBool("isDead", true);
        //Debug.Log(anim.GetCurrentAnimatorStateInfo(0).IsName(endState));
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(endState))
        {
            //Debug.Log("Gameeeee");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
     
        IEnumerator newScene(GameObject thisScene, GameObject nxtScene,int secs)
    {
        yield return new WaitForSeconds(secs);
        thisScene.SetActive(false);
        nxtScene.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting.Dependencies.NCalc;
using System.Runtime.CompilerServices;

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
    public static int numbLvl = 0;
    public static int numbDiff = 0;
    public int lvlCoin = 0;
    public static int numbCoin = 0;
    public int lvlShoot = 0;
    public int lvlJump = 0;
    public Text coinText;
    public static bool is1S = false;
    public static bool is2S = false;
    public static bool is3S = false;
    public static bool is0S = false;
    
    private bool oneTimeShoot = false;
    public static bool isIntro = true;
    public int timeScene = 3;
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
        
            numbLvl = SceneManager.GetActiveScene().buildIndex;
            coinText.text = numbCoin.ToString();

            //jump
            if (numbLvl == 1)
            {
                if(anim.GetBool("isOneTime")==false){
                    anim.SetBool("isOneTime",true);
                    StartCoroutine(NewScene(zeroScene, lvl0Scene, timeScene));
                }
                if (anim.GetBool("isFinishAnim")==true)
                {
                    IsJumpF();
                }
                if (animCanoon.GetCurrentAnimatorStateInfo(0).IsName("canoonState"))
                {
                    anim.SetBool("isShoot", true);
                    if (oneTimeShoot == false)
                    {
                        player.GetComponent<Rigidbody2D>().velocity = player.transform.up * 40;
                        oneTimeShoot = true;
                    }
                }
                
            }

            //balloon
            else if (numbLvl == 2)
            {   
               if(anim.GetBool("isOneTime")==false){
                    anim.SetBool("isOneTime",true);
                    StartCoroutine(NewScene(firstScene, lvl1Scene, timeScene));
                }

                if (anim.GetBool("isFinishAnim")==true)
                {
                    SoundManagerScript.instance.PlaySound(inflateSound);
                    IsShootF();
                }

                if (lvlCoin >= 7) //win way for balloon
                {
                    addNumbLvl();
                }
            }
            
            //tiger
            else if (numbLvl == 3)
            {
               if(anim.GetBool("isOneTime")==false){
                    anim.SetBool("isOneTime",true);
                    StartCoroutine(NewScene(secondScene, lvl2Scene, timeScene));
                }
                if (anim.GetBool("isFinishAnim")==true)
                {}
            //bycle
            }else{
                if(anim.GetBool("isOneTime")==false){
                    anim.SetBool("isOneTime",true);
                    StartCoroutine(NewScene(thirdScene, lvl3Scene, timeScene));
                }
                if (anim.GetBool("isFinishAnim")==true){

                }
            }
        

    }
    public void addDiff(){
        numbDiff++;
    }
    
    /*public bool inverseBool(bool varBool){
        return !varBool;
    }*/
    public bool getDiff(int numCompare){
        return numbDiff == numCompare;
    }
    public bool getNumbLvl(int numCompare)
    {
        return numbLvl == numCompare;
    }
    public void addNumbLvl(){
        numbLvl = numbLvl+1;
        anim.SetBool("isOneTime",false);
        if(numbLvl>=4){
            addDiff();
            numbLvl=numbLvl%4;
        }
        //anim.SetInteger("numbLvl",numbLvl);
        
        SceneManager.LoadScene(numbLvl);
    }
    public void addCoin()
    {
        numbCoin++;
    }
    private void IsJumpF()
    {
        SoundManagerScript.instance.PlaySound(isShootSound);
        lvlCoin = 0;
        anim.SetBool("isFinishAnim", false);
        anim.SetFloat("numbLvl", numbLvl);
    }
    private void IsShootF()
    {
        lvlCoin = 0;
        anim.SetBool("isFinishAnim", false);
        //player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        SpawnBulletP.SetActive(true);
        anim.SetFloat("numbLvl", numbLvl);
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
     
        public IEnumerator NewScene(GameObject thisScene, GameObject nxtScene,int secs)
    {
        yield return new WaitForSeconds(secs);
        thisScene.SetActive(false);
        nxtScene.SetActive(true);
        anim.SetBool("isFinishAnim", true);
    }
}

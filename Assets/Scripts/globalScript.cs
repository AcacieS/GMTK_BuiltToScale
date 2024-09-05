using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class globalScript : MonoBehaviour
{
    public static int numbLvl = 1;
    public static int numbDiff = 0;
    public static int lvlCoin = 0;
    public static int numbCoin = 0;
    public static bool tutoActive = false;
    public static bool isIntro = true;
    public Animator animCanoon;
    // Update is called once per frame

    void Start()
    {
        //anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    void Update()
    {
        numbLvl = SceneManager.GetActiveScene().buildIndex;
        
    }
    public void addDiff()
    {
        numbDiff++;
    }

    public bool getDiff(int numCompare)
    {
        return numbDiff == numCompare;
    }
    public bool getNumbLvl(int numCompare)
    {
        return numbLvl == numCompare;
    }
    public int getWhatLvl()
    {
        return numbLvl;
    }
    public static void addNumbLvl()
    {
        numbLvl = SceneManager.GetActiveScene().buildIndex;
        numbLvl++;
        lvlCoin=0;
        tutoActive=false;
        SceneManager.LoadScene(numbLvl);
    }
    public static void addCoin()
    {
        lvlCoin++;
        Debug.Log("lvlCoin"+lvlCoin);
        //numbCoin++;
    }

   /* public void gameOver(string endState)
    {
        anim.SetBool("isDead", true);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(endState))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }*/
}

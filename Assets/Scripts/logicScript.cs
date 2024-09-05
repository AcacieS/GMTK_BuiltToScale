using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class logicScript : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public static int numbLvl = 1;
    public static int numbDiff = 0;
    public int lvlCoin = 0;
    public static int numbCoin = 0;
    public int lvlShoot = 0;
    public int lvlJump = 0;
    public Text coinText;
    public static bool isIntro = true;
    public int timeScene = 3;
    private bool isPlayerHere = false;
    public Animator animCanoon;
    // Update is called once per frame

    void Start()
    {
        //anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    void Update()
    {
        coinText = GameObject.FindGameObjectWithTag("coinT").GetComponent<Text>();
        numbLvl = SceneManager.GetActiveScene().buildIndex;
        coinText.text = numbCoin.ToString();
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
    public void addNumbLvl()
    {
        Debug.Log("Sop");
        numbLvl++;
        anim.SetBool("isOneTime", false);
        /*if(numbLvl==6){
            addDiff();
            numbLvl=numbLvl%5;
        }*/
        Debug.Log(anim.GetBool("numbLvl"));
        SceneManager.LoadScene(numbLvl);
    }
    public void addCoin()
    {
        lvlCoin++;
        numbCoin++;
    }
    public void isOneTimeF(GameObject canvaScene, GameObject lvlScene, float positionX, float positionY)
    {
        SpawnPlayer(positionX, positionY);
        if (anim.GetBool("isOneTime") == false)
        {
            anim.SetBool("isOneTime", true);
            StartCoroutine(NewScene(canvaScene, lvlScene));
        }
    }
    public void SpawnPlayer(float positionX, float positionY)
    {
        if (isPlayerHere == false && numbLvl != 1)
        {
            Instantiate(player, new Vector3(positionX, positionY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            anim.SetFloat("numbLvl", getWhatLvl());
            isPlayerHere = true;
        }
    }

    public void gameOver(string endState)
    {
        anim.SetBool("isDead", true);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(endState))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    public IEnumerator NewScene(GameObject thisScene, GameObject nxtScene)
    {
        yield return new WaitForSeconds(3);
        thisScene.SetActive(false);
        nxtScene.SetActive(true);
        anim.SetBool("isFinishAnim", true);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class B_logic_script : MonoBehaviour
{
    public GameObject player;
    public GameObject SpawnBulletP;
    public Animator anim;
    public Text coinText;
    [SerializeField] private AudioClip inflateSound;
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        SoundManagerScript.instance.PlaySound(inflateSound);
        globalScript.lvlCoin = 0;
    }
    void Update()
    {
        if (globalScript.lvlCoin >= 12) //win way for balloon
        {
            globalScript.addNumbLvl();
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("player_balloonEndState"))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        //player.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        //SpawnBulletP.SetActive(true);
    }
}

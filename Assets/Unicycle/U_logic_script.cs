using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class U_logic_script : MonoBehaviour
{
    public GameObject player;
    public GameObject canvaScene;
    public GameObject lvlScene;
    public Animator anim;
    public int lvlCoin = 0;
    public int numbCoin = 0;
    public Text coinText;
    [SerializeField] private AudioClip inflateSound;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    void Update()
    {
        //logic.isOneTimeF(canvaScene, lvlScene);
        /* if (anim.GetBool("isFinishAnim")==true)
        {}*/
        
    
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class L_logic_script : MonoBehaviour
{
    public GameObject player;
    public GameObject canvaScene;
    public GameObject lvlScene;
    public GameObject SpawnBulletP;
    public logicScript logic;
    public Animator anim;
    public int lvlCoin = 0;
    public int numbCoin = 0;
    public Text coinText;
    [SerializeField] private AudioClip inflateSound;

}

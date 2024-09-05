using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class J_logic_script : MonoBehaviour
{
    public GameObject player;
    public GameObject tuto1;
    public Text decountText;
    public GameObject decountGO;
    public Animator anim;
    private bool oneTimeShoot = false;
    [SerializeField] private AudioClip isShootSound;
    public Animator animCanoon;
    public static int NumbDecount = 3;
private bool isWaiting = false;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        IsJumpF();
    }
    void Update()
    {
        if(globalScript.tutoActive==true){
            if(!isWaiting){
                decountGO.SetActive(true);
                StartCoroutine(Decount(3));
                isWaiting = true;
            }
            
        }
        decountText.text = NumbDecount.ToString();
        if(NumbDecount == 0){
            
            decountGO.SetActive(false);
            animCanoon.SetBool("isReady", true);
            if (animCanoon.GetCurrentAnimatorStateInfo(0).IsName("canoonState"))
            {
                if (oneTimeShoot == false)
                {
                    tuto1.SetActive(true);
                    player.GetComponent<Rigidbody2D>().velocity = player.transform.up * 40;
                    anim.SetBool("isShoot", true);
                    oneTimeShoot = true;
                }
            }
        }
    }
    private void IsJumpF()
    {
        SoundManagerScript.instance.PlaySound(isShootSound);
        globalScript.lvlCoin = 0;
        anim.SetBool("isFinishAnim", false);
    }
    public IEnumerator Decount(int second){
       
       for(int i = second; i >= 0; i--)
        {
            NumbDecount = i;
            yield return new WaitForSeconds(1);
                
        }
    }
}

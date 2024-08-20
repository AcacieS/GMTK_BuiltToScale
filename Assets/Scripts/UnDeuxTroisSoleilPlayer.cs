using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class UnDeuxTroisSoleilPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public logicScript logic;
    public Animator anim;
    private tigerLogicScript tigerLogic;
    private Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        tigerLogic = GameObject.Find("tigerLogic").GetComponent<tigerLogicScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vx = Input.GetAxis("Horizontal") * 5;
        body.velocity = new Vector2(vx, 0);
        if(vx==0){
            anim.SetBool("isMoving",false);
        }else{
            anim.SetBool("isMoving",true);
        }
        if (!tigerLogic.shouldPlayerMove() && vx != 0)
        {
            Debug.Log("haha you ded");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            //logic.gameOver("player_123soleilEndState");
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tigerLogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    private float timeAwake;
    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(timer>timeAwake){
            timer = 0;
            anim.SetBool("isAwake",true);

        } 

        
    }
}

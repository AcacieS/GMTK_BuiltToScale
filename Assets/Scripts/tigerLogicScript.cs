using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tigerLogicScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    private float waitTime;
    private float timer;
    void Start()
    {
        anim = GameObject.Find("Tiger").GetComponent<Animator>();
    }

    private bool isAwake = false;

    public bool shouldPlayerMove()
    {
        return !anim.GetCurrentAnimatorStateInfo(0).IsName("enemy_awake");
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer < waitTime)
        {
            return;
        }
        else
        {
            timer = 0;
            waitTime = Random.Range(3, 7);
        }

        if (isAwake)
        {
            anim.SetBool("isAwake", false);
            isAwake = false;
        }
        else
        {
            anim.SetBool("isAwake", true);
            isAwake = true;
        }
    }
}

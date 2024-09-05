using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickCollider : MonoBehaviour
{
    [SerializeField] private AudioClip coinSound;



    void OnTriggerEnter2D(Collider2D col)
    {
        //coin
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
            SoundManagerScript.instance.PlaySound(coinSound);
            globalScript.addCoin();
        }

        //winning for jump and lion
        else if (col.gameObject.tag == "endWall")
        {
            globalScript.addNumbLvl();
        }
    }

}

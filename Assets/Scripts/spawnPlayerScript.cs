using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        Instantiate(player, new Vector3(-14.59f, -10.77f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        
    }
   
}

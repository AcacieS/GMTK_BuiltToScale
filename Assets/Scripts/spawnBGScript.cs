using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnBGScript : MonoBehaviour
{
    public GameObject player;
    public GameObject BG;
    public GameObject newBG;
    public GameObject endBG;
    public float posY;
    private bool isEndLvl = false;
    
    void Update()

    {
        if (globalScript.lvlCoin <=6)
        {
            if (player.transform.position.y > BG.transform.position.y-(26.84f/2))
            {
                BG = Instantiate(newBG, new Vector3(BG.transform.position.x, BG.transform.position.y + 26.84f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
        }
        else
        {
            if (!isEndLvl)
            {
                BG = Instantiate(endBG, new Vector3(BG.transform.position.x, BG.transform.position.y + 10.8f + 21.60527f, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
                isEndLvl = true;
                posY = BG.transform.position.y;
            }
        }
    }
}

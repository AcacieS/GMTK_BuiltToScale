using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCoinScript : MonoBehaviour
{
    public bool isCoin = false;
    public logicScript logic;
    public GameObject coin;
    
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(logic.getNumbLvl(1)){
            Debug.Log("hey?");
            if(isCoin==false){
                float coinPosY = Random.Range(-15.5f,10.5f);
                float coinPosX = Random.Range(-22.5f,23.5f);
                addCoin(coinPosY, coinPosX);
                isCoin=true;
            }
        }
    }
    public void addCoin(float coinPosX, float coinPosY){
        Instantiate(coin, new Vector3(coinPosX, coinPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    
}

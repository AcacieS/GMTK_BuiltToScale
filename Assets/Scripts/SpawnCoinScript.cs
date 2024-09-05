using UnityEngine;

public class SpawnCoinScript : MonoBehaviour
{
    public bool isCoin = false;
    public GameObject coin;

    public void addCoin(float coinPosX, float coinPosY){
        Instantiate(coin, new Vector3(coinPosX, coinPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    
}

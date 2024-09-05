using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class l_spawnCoinScript : MonoBehaviour
{
    private bool shouldSpawnCoin = true;
    public GameObject coin;
    public Vector3 limit;
    public Text coinText;

    private GameObject limitF;
    private GameObject limitS;

    public void SpawnNewCoin()
    {
        shouldSpawnCoin = true;
    }

    void Start()
    {
        limitF = GameObject.Find("firstScene/limitF");
        limitS = GameObject.Find("firstScene/limitS");
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldSpawnCoin)
        {
            float coinPosY = -9.5f;
            float coinPosX = Random.Range(limitF.transform.position.x + 10, limitS.transform.position.x - 10);
            addCoin(coinPosX, coinPosY);
            shouldSpawnCoin = false;
        }

        coinText = GameObject.FindGameObjectWithTag("coinT").GetComponent<Text>();
        coinText.text = globalScript.lvlCoin.ToString();
    }
    public void addCoin(float coinPosX, float coinPosY)
    {
        Instantiate(coin, new Vector3(coinPosX, coinPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

}

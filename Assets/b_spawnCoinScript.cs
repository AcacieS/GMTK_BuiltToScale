using UnityEngine;
using UnityEngine.UI;

public class b_spawnCoinScript : MonoBehaviour
{
    public bool isCoin = false;
    public GameObject coin;
    public Vector3 limit;
    public Text coinText;
    private int numbWall = 1;

    

    // Update is called once per frame
    void Update()
    {
        if (isCoin == false)
        {
            float coinPosY = Random.Range(whichWall(1, "y") + 2.5f, whichWall(2, "y") - 2.5f);
            float coinPosX = Random.Range(whichWall(4, "x") + 2.5f, whichWall(3, "x") - 2.5f);
            addCoin(coinPosX, coinPosY);
            isCoin = true;
        }
        coinText = GameObject.FindGameObjectWithTag("coinT").GetComponent<Text>();
        int coinNb = globalScript.lvlCoin/2;
        coinText.text = coinNb.ToString();
    }
    public float whichWall(int wall, string pos)
    {
        numbWall = wall;
        limit = GameObject.Find("lvlScene/Square" + numbWall).transform.position;
        if (pos == "x")
        {
            return limit.x;
        }
        else
        {
            return limit.y;
        }
    }
    public void addCoin(float coinPosX, float coinPosY)
    {
        Instantiate(coin, new Vector3(coinPosX, coinPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

}

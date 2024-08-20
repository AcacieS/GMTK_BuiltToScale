using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnTongScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tongMid;
    public GameObject limitNeg;
    public GameObject limitPos;
    public SpawnCoinScript spawnCoin;
    private float limitNegP;
    private float limitPosP;
    private float limitDistance;
    private float sizeMidTong;
    private float distance = 19.5f - 7.5f;
    private float tongPosX;
    private float tongPosY;
    private int tongFS;
    public GameObject[] cloneTongs;
    public GameObject cloneProj;
    public Animator anim;
    private float maxTong = 3;
    public int numbTong = 0;
    private int numIndex = 0;
    private bool oneTime = true;
    private bool isShootFall = false;
    private int side = 0;
    void Start()
    {
        //cloneTongs = new GameObject[3];
        sizeMidTong = tongMid.GetComponent<BoxCollider2D>().size.x;///2;
        spawnCoin = GameObject.FindGameObjectWithTag("spawnCoin").GetComponent<SpawnCoinScript>();
        limitPosP = limitPos.transform.position.x;
        limitNegP = limitNeg.transform.position.x;
        limitDistance = limitPosP - limitNegP;

    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("player_cFall")){
            isShootFall=true;
        }
        if(isShootFall==true){
            if (numbTong < 0)
            {
                numbTong = 0;
            }
            if (numbTong < maxTong)
            {
                numbTong++;
                spawnTongF();
            }
        }
    }


    void spawnTongF()
    {
        side++;

        bool leftSide = side % 2 == 0;
        tongPosX = Random.Range(limitNeg.transform.position.x, limitPos.transform.position.x / 2);
        if (oneTime == true)
        {
            tongPosY = 50f;
            oneTime = false;
        }
        else
        {
            tongPosY = Random.Range(cloneProj.transform.position.y + 8, cloneProj.transform.position.y + distance);
        }
        if (leftSide)
        {
            float x = Random.Range(limitNegP+sizeMidTong, limitNegP + limitDistance / 3);
            addTong(x, tongPosY);

        }
        else
        {
            float x = Random.Range(limitPosP - limitDistance / 3, limitPosP - sizeMidTong);
            addTong(x, tongPosY);
        }
    }
    void addTong(float tongPosX, float tongPosY)
    {
        int chooseFish = Random.Range(1,4);
        tongMid = GameObject.Find("fish"+chooseFish);
        cloneProj = Instantiate(tongMid, new Vector3(tongPosX, tongPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        spawnCoin.addCoin(cloneProj.transform.position.x, cloneProj.transform.position.y + 2);
        //cloneTongs[numIndex] = cloneProj;
        numIndex = (numIndex + 1) % 2;
    }
}

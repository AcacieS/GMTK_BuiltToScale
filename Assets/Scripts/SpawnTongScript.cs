using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

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
    private float maxTong = 3;
    public int numbTong = 0;
    private int numIndex = 0;
    private bool oneTime = true;
    private bool isSecondTime = true;
    private int side = 0;
    void Start()
    {
        cloneTongs = new GameObject[3];
        sizeMidTong = tongMid.GetComponent<BoxCollider2D>().size.x * 10;///2;
        spawnCoin = GameObject.FindGameObjectWithTag("spawnCoin").GetComponent<SpawnCoinScript>();
        limitPosP = limitPos.transform.position.x;
        limitNegP = limitNeg.transform.position.x;
        limitDistance = limitPosP - limitNegP;

    }

    // Update is called once per frame
    void Update()
    {
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


    void spawnTongF()
    {
        side++;

        bool leftSide = side % 2 == 0;
        tongPosX = Random.Range(limitNeg.transform.position.x, limitPos.transform.position.x / 2);
        if (oneTime == true)
        {
            tongPosY = -17.63f;
            oneTime = false;
        }
        else
        {
            tongPosY = Random.Range(cloneProj.transform.position.y + 8, cloneProj.transform.position.y + distance);
        }
        if (leftSide)
        {
            float x = Random.Range(limitNegP, limitNegP + limitDistance / 3);
            Debug.Log(tongPosX);
            addTong(x, tongPosY);

        }
        else
        {
            float x = Random.Range(limitPosP - limitDistance / 3, limitPosP - sizeMidTong);
            addTong(x, tongPosY);
        }
        /*  int numIndexN = (numIndex+1)%2;
          int numIndexP = numIndex - 1;
          if(numIndexP<0){
              numIndexP=2;
          }

          float indexPX = cloneTongs[numIndexP].transform.position.x;
          if(!isSecondTime){
              float indexNX = cloneTongs[numIndexN].transform.position.x;
          }
          bool isGoodPos = false;
          while(isGoodPos==false){
              tongPosX = Random.Range(limitNegP + sizeMidTong, limitPosP - sizeMidTong);
              float tongPosXF = tongPosX-cloneTongs[numIndex].GetComponent<BoxCollider2D>().size.x;
              float tongPosXS = tongPosX+cloneTongs[numIndex].GetComponent<BoxCollider2D>().size.x;
              float indexNX = cloneTongs[numIndexN].transform.position.x;
              if(isSecondTime){
                  if((tongPosXF<indexPX&&indexPX<tongPosXS)){

                  }else{
                      isGoodPos=true;
                      isSecondTime=false;
                  }
              }

              if((tongPosXF<indexNX&&indexNX<tongPosXS)||(tongPosXF<indexPX&&indexPX<tongPosXS)){
              }else{
                  isGoodPos=true;
              }
          }*/
        //float nextNumb = numIndex;
        //float prevNumb = numbIndex-2;
        /*float cProjX = cloneProj.transform.position.x;
        float distanceF = cProjX - limitNegP - sizeMidTong - 5;
        float distanceS = limitPosP - cProjX - sizeMidTong - 5;

        if (distanceF < 0)
        {
            tongPosX = secondPartSpawn(cProjX);
        }
        else if (distanceS < 0)
        {
            tongPosX = firstPartSpawn(cProjX);
        }
        else
        {
            tongFS = Random.Range(0, 2);
            if (tongFS == 0)
            {
                tongPosX = firstPartSpawn(cProjX);
            }
            else
            {
                tongPosX = secondPartSpawn(cProjX);
            }
        }
        tongPosY = Random.Range(cloneProj.transform.position.y + 8, cloneProj.transform.position.y + distance);
        addTong(tongPosX, tongPosY);*/
    }
    void addTong(float tongPosX, float tongPosY)
    {
        cloneProj = Instantiate(tongMid, new Vector3(tongPosX, tongPosY, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
        spawnCoin.addCoin(cloneProj.transform.position.x, cloneProj.transform.position.y + 2);
        cloneTongs[numIndex] = cloneProj;
        numIndex = (numIndex + 1) % 2;
    }
    float firstPartSpawn(float cProjX)
    {
        return Random.Range(limitNegP + sizeMidTong, cProjX - sizeMidTong - 5);
    }
    float secondPartSpawn(float cProjX)
    {
        return Random.Range(cProjX + sizeMidTong + 5, limitPos.transform.position.x - sizeMidTong);
    }
}

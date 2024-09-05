using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class cloudSpawn_script : MonoBehaviour
{
    public int chooseCloud;
    public GameObject oldCloud;
    public static int numbCloud = 0;
    private int maxCloud = 6;
    private float limitPosXL;
    private float limitPosXR;
    private float limitPosYH = 14;
    private float limitPosYD = 6;
    private float oldCloudY;
    private float distance = 8;


    void Start()
    {
        limitPosXL = GameObject.Find("lvlScene/limitL").transform.position.x;
        limitPosXR = GameObject.Find("lvlScene/limitR").transform.position.x;
        oldCloud = Instantiate(RandCloud(), new Vector3(RandPosX(), 57.9f, 10), Quaternion.Euler(new Vector3(0, 0, 0)));
        oldCloudY = oldCloud.transform.position.y;
        addNbCloud();
    }

    void Update()
    {
        if (addNbCloud() == true)
        {
            oldCloud = Instantiate(RandCloud(), new Vector3(RandPosX(), RandPosY(oldCloudY), 10), Quaternion.Euler(new Vector3(0, 0, 0)));
            oldCloudY = oldCloud.transform.position.y;
        }
    }
    private GameObject RandCloud()
    {
        chooseCloud = Random.Range(1, 4);
        return GameObject.Find("Cloud/cloud" + chooseCloud);
    }
    private float RandPosX()
    {
        return Random.Range(limitPosXL + distance, limitPosXR - distance);
    }
    private float RandPosY(float prevCloudY)
    {
        return Random.Range(prevCloudY + limitPosYD, prevCloudY + limitPosYH);
    }
    private bool addNbCloud()
    {
        if (maxCloud <= numbCloud)
        {
            return false;
        }
        else
        {
            numbCloud++;
            return true;
        }
    }
    public static void removeNbCloud()
    {
        numbCloud--;
    }


}

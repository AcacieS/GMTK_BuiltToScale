using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public logicScript logic;
    public Camera camera;
    public GameObject player;
    private float posY;
    public Transform limitCameraF;
    public Transform limitCameraS;
    public spawnBGScript spawnBG;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.getNumbLvl(2))
        {
            camera.transform.position = new Vector3(1.200001f, -2.2f, -10f);
        }
        else if (logic.getNumbLvl(1))
        {
            
            float cameraY = player.transform.position.y;
            if (cameraY < -2.2f)
            {
                cameraY = -2.2f;
            }/*else if(cameraY>spawnBG.posY+spawnBG.posY/2){
                cameraY = spawnBG.posY+spawnBG.posY/2;
            }*/
            camera.transform.position = new Vector3(1.200001f, cameraY, -10f);
        }
        else if (logic.getNumbLvl(3))
        {
            float cameraX = player.transform.position.x;
            if (cameraX < limitCameraF.position.x)
            {
                cameraX = limitCameraF.position.x;
            }
            else if (cameraX > limitCameraS.position.x)
            {
                cameraX = limitCameraS.position.x;
            }
            else
            {
                camera.transform.position = new Vector3(cameraX, camera.transform.position.y, camera.transform.position.z);
            }
        }
    }
}

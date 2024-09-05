
using UnityEngine;

public class l_cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera myCamera;
    public GameObject player;
    public Transform limitCameraF;
    public Transform limitCameraS;
    public GameObject tiger;
    public Animator anim;
    private float cameraX;
    //private float cameraX;
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetBool("isDead")==false){
            cameraX = player.transform.position.x;
            if (cameraX < limitCameraF.position.x)
            {
                cameraX = limitCameraF.position.x;
            }
            else if (cameraX > limitCameraS.position.x)
            {
                cameraX = limitCameraS.position.x;
            }
            else{}
            
        }else{
            cameraX = 23.4f;
        }
        myCamera.transform.position = new Vector3(cameraX, myCamera.transform.position.y, myCamera.transform.position.z);
    }
}


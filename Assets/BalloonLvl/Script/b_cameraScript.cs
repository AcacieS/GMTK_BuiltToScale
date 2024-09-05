
using UnityEngine;

public class b_cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera myCamera;
    public spawnBGScript spawnBG;
    //private float cameraX;
    void Start()
    {
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        myCamera.transform.position = new Vector3(1.200001f, -2.2f, -10f);
    }
}


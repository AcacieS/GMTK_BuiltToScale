using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletP : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0;
    public float speedS = 10f;
    public float timeInterval = 2;
    //private Rigidbody2D body;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeInterval)
        {
            timer = 0;
            SpawnBP();
        }
    }
    void SpawnBP()
    {
        int whichWall = Random.Range(1, 5);
        float shootPosX;
        float shootPosY;
        float velocityX;
        float velocityY;
        float rotationZ = 0;
        float rotationX = 0;
        //shootPos;
        if (whichWall == 1 || whichWall == 3)
        {
            shootPosY = Random.Range(-16, 11);
            velocityY = 0;
            if (whichWall == 1)
            {
                shootPosX = -23f;
                velocityX = 1;
                rotationZ = 180;
                rotationX = 180;
            }
            else
            {
                shootPosX = 24f;
                velocityX = -1;
            }
        }
        else
        {
            shootPosX = Random.Range(-23, 24);
            velocityX = 0;
            if (whichWall == 2)
            {
                shootPosY = 11f;
                velocityY = -1;
                rotationZ = 90;
            }
            else
            {
                shootPosY = -15f;
                velocityY = 1;
                rotationZ = 270;
            }
        }

        GameObject cloneProj = Instantiate(projectile, new Vector3(shootPosX, shootPosY, 0), Quaternion.Euler(new Vector3(rotationX, 0, rotationZ)));
        //cloneProj.transform.SetParent(transform);
        Rigidbody2D rbCloneProj = cloneProj.GetComponent<Rigidbody2D>();
        rbCloneProj.velocity = new Vector2(velocityX * speedS, velocityY * speedS);

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class deleteTongScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SpawnTongScript spawnTong;
    public GameObject player;
    void Start()
    {
        spawnTong = GameObject.Find("SpawnTong").GetComponent<SpawnTongScript>();
    }
    void Update(){
        transform.position = new Vector3(transform.position.x, player.transform.position.y-30f, transform.position.z);
    }
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="tong"){
            Destroy(col.gameObject);
            spawnTong.numbTong--;
            Debug.Log("numb Tong");
            Debug.Log(spawnTong.numbTong);
            //spawnTong.cloneTongs.RemoveAt(0);
        }
        if(col.gameObject.tag=="coin"){
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "cloud"){
            Debug.Log("CLoudddd");
            Destroy(col.gameObject);
            cloudSpawn_script.removeNbCloud();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteTutoScript : MonoBehaviour
{
   //public GameObject Tuto;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(globalScript.tutoActive);
        if(globalScript.tutoActive==true){
            GameObject.FindGameObjectWithTag("npc")?.SetActive(false);
            Debug.Log("??");
            GameObject.FindGameObjectWithTag("tuto")?.SetActive(false);
            
        }
    }
}

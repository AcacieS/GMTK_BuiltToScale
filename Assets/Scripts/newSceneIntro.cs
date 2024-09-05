using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newSceneIntro : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firstIntro;
    public GameObject secondIntro;
    private bool isIntro = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isIntro)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                firstIntro.SetActive(false);
                secondIntro.SetActive(true);
                isIntro = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SceneManager.LoadScene(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SceneManager.LoadScene(5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SceneManager.LoadScene(7);
            }
        }
        else if (!isIntro)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                globalScript.addNumbLvl();
            }
        }
    }
}

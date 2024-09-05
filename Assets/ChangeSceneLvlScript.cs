using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeSceneLvlScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string lvlScene;
    void Start()
    {
        StartCoroutine(NewScene(lvlScene));
        
    }
     public IEnumerator NewScene(string lvlScene)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(lvlScene);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCanva : MonoBehaviour
{
   public void IsOneTimeF(string canvaScene,string lvlScene)
    {
        SceneManager.LoadScene(canvaScene);
        
    }
   
}

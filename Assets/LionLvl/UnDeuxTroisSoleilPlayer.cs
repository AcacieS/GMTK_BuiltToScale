using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnDeuxTroisSoleilPlayer : MonoBehaviour
{
     public IEnumerator Restart(int secs)
    {
        yield return new WaitForSeconds(secs);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleSceneTransition : MonoBehaviour
{
    public void ChangeScene5Seconds(string sceneName)
    {
        StartCoroutine(Waiting(sceneName, 5));
    }
    public void ChangeScene12Seconds(string sceneName)
    {
        StartCoroutine(Waiting(sceneName, 12));
    }

    IEnumerator Waiting(string sceneName, int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(sceneName);
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

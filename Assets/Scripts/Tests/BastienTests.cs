using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BastienTests : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        StartCoroutine("Waiting", sceneName);
    }

    IEnumerator Waiting(string sceneName)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}

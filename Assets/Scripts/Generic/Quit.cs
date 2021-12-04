using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    [SerializeField] private Animator loadScreenAnimator;

    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    IEnumerator QuitGameCoroutine()
    {
        if (loadScreenAnimator != null) { loadScreenAnimator.SetTrigger("Start"); }
        yield return new WaitForSeconds(0.333f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
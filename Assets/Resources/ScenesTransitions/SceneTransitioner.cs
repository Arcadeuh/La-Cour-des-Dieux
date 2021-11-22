using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneTransitioner : MonoBehaviour
{


    public Animator transition;
    public Animator transition2;
    public float transitionTime = 1f;
   

    
    //StartCoroutine(sceneTransition(int idScene))
    

    IEnumerator SceneTransition(string nomScene)
    {
        
            transition.SetTrigger("Start");
            transition2.SetTrigger("StartLoading");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(nomScene);
        
    }
}

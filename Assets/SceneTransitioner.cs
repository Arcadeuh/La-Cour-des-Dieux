using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneTransitioner : MonoBehaviour
{


    public Animator transition;
    public Animator transition2;
    public float transitionTime = 1f;

    void Update(){
        var gamepad = Gamepad.current;
        if(gamepad.rightTrigger.wasPressedThisFrame)
        {
            transition.SetTrigger("Start");
            transition2.SetTrigger("StartLoading");
        }
    }
    //StartCoroutine(sceneTransition(int idScene))

    IEnumerator SceneTransition(int idDestinationScene)
    {
        transition.SetTrigger("Start");
        transition2.SetTrigger("StartLoading");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(idDestinationScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GoToFight : MonoBehaviour
{
    public CardTokenHolder cardTokenHolder;
    public string SceneToLoad;
    public GameObject videoPlayer;
    public float timeVideoStop;
    public GameObject canvasButtons;
    public SceneTransitioner ST;
    public GameObject imageTransition;
    private bool flag = false;
    [SerializeField] private UnityEvent onSceneTransition = new UnityEvent();

    void LoadNewScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }

   

    // Update is called once per frame
    void Update()
    {
        
        if (cardTokenHolder.HasToken(1) && cardTokenHolder.HasToken(2))
        {
            imageTransition.SetActive(true);
            ST.StartCoroutine("SceneTransition", "FightSceneWithLoad");

            if (!flag)
            {
                flag = true;
                onSceneTransition.Invoke();
            }

            if (videoPlayer == null)
            {
                //LoadNewScene();
            }
            else
            {
                //ST.StartCoroutine("Quentin2");
                //videoPlayer.SetActive(true);
                Destroy(canvasButtons);
                //Destroy(videoPlayer, timeVideoStop);
            }
            
        }
        
    }


}

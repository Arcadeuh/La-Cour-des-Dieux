using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToFight : MonoBehaviour
{
    public CardTokenHolder cardTokenHolder;
    public string SceneToLoad;
    public GameObject videoPlayer;
    public float timeVideoStop;
    public GameObject canvasButtons;


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
            
            
            if (videoPlayer == null)
            {
                LoadNewScene();
            }
            else
            {
                videoPlayer.SetActive(true);
                Destroy(canvasButtons);
                Destroy(videoPlayer, timeVideoStop);
            }
            
        }
        
    }


}

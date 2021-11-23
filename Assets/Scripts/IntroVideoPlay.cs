using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideoPlay : MonoBehaviour
{
    [SerializeField] private UnityEngine.Video.VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += EndIntro;
    }


    public void EndIntro(UnityEngine.Video.VideoPlayer vp)
    {
        videoPlayer.Stop();
        SceneManager.LoadScene("MainMenu");
    }

    public void SkipIntro()
    {
        videoPlayer.Stop();
        SceneManager.LoadScene("MainMenu");
    }
}
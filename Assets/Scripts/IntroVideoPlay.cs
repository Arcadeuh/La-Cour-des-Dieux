using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroVideoPlay : MonoBehaviour
{
    [SerializeField] private UnityEngine.Video.VideoPlayer videoPlayer;
    private AudioManager audioManager;

    private void Start()
    {
        videoPlayer.loopPointReached += EndIntro;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.Play("IntroMusic");
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
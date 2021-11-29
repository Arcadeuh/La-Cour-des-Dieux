using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardTokenHolder : MonoBehaviour
{
 
    public GameObject visuelTokenp1;
    public Token tokenPlayerOne = null;

    public GameObject visuelTokenp2;
    public Token tokenPlayerTwo = null;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if(audioManager == null)
        {
            Debug.LogError("No AudioManager found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HasToken(1)){ visuelTokenp1.gameObject.SetActive(true); }
        else{ visuelTokenp1.gameObject.SetActive(false); }

        if(HasToken(2)){ visuelTokenp2.gameObject.SetActive(true); }
        else{ visuelTokenp2.gameObject.SetActive(false); }
    }

    public bool HasToken(int playerId){
        switch(playerId){
            case 1:
                return tokenPlayerOne != null;
            case 2:
                return tokenPlayerTwo != null;
            default:
                Debug.LogError("playerId is not 1 or 2");
                return false;
        };
    }


    public Token RemoveToken(int playerId)
    {
        Token removedToken = null;
        switch (playerId)
        {
            case 1:
                removedToken = tokenPlayerOne;
                tokenPlayerOne = null;
                break;
            case 2:
                removedToken = tokenPlayerOne;
                tokenPlayerTwo = null;
                break;
            default:
                Debug.LogError("playerId is not 1 or 2");
                break;
        };
        audioManager.Play("DeleteToken");
        return removedToken;
    }

    public void AddToken(Token newToken, int playerId)
    {
        switch (playerId)
        {
            case 1:
                tokenPlayerOne = newToken;
                break;
            case 2:
                tokenPlayerTwo = newToken;
                break;
            default:
                break;
        }
        audioManager.Play("AddToken");
    }
}

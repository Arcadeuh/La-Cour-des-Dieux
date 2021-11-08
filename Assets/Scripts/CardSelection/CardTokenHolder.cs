using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTokenHolder : MonoBehaviour
{
 
    public GameObject visuelTokenp1;
    public Token tokenPlayerOne = null;

    public GameObject visuelTokenp2;
    public Token tokenPlayerTwo = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HasToken()){
            visuelTokenp1.gameObject.SetActive(true);
        }else{
            visuelTokenp1.gameObject.SetActive(false);
        }
    }

    public bool HasToken(){
        return tokenPlayerOne != null;
    }


    public Token RemoveToken(){
        Token removedToken = tokenPlayerOne;
        tokenPlayerOne = null;
        return removedToken;
    }

    public void AddToken(Token newToken){
        tokenPlayerOne = newToken;

    }
}

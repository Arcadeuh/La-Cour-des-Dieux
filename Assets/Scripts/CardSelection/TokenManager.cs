using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TokenManager : MonoBehaviour
{
    public int tokensNumber = 4;
    public int playerId;

    private void Start()
    {
        GetComponentInChildren<TMPro.TMP_Text>().SetText(playerId.ToString());
    }

    public void Interact(InputAction.CallbackContext context){

        if(!context.performed){return;}

        Debug.Log("Interact");
        RaycastHit hit;
        Vector3 origin = transform.position;
        Vector3 direction = transform.up * -1;
        float range = 20.0f;
        Vector3 end = origin + direction * range;


        Debug.DrawLine(origin, end, Color.red,0.5f);

        if(Physics.Raycast(origin, direction,out hit,range) ){
            Debug.Log(hit.transform.name) ;

            if(hit.transform.GetComponentInParent<CardTokenHolder>() != null ){      // est-ce une carte ?

                CardTokenHolder card = hit.transform.GetComponentInParent<CardTokenHolder>();
                if(card.HasToken(playerId)){
                    RetrieveToken(card, playerId);
                }else if(tokensNumber>0){
                    PlaceToken(card, playerId);
                }
            }
            
        }
    }




    public void PlaceToken(CardTokenHolder card, int playerId){
        card.AddToken(new Token(), playerId);
        tokensNumber --;
    }

    public void RetrieveToken(CardTokenHolder card, int playerId)
    {
        card.RemoveToken(playerId);
        tokensNumber ++;
    }
}

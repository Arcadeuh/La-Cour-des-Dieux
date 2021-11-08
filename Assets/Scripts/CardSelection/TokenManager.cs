using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TokenManager : MonoBehaviour
{
    public int tokensNumber = 4 ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                if(card.HasToken()){
                    RetrieveToken(card);
                }else if(tokensNumber>0){
                    PlaceToken(card);
                }
            }
            
        }
    }




    public void PlaceToken(CardTokenHolder card){
        card.AddToken(new Token());
        tokensNumber --;
    }

    public void RetrieveToken(CardTokenHolder card){
        card.RemoveToken();
        tokensNumber ++;
    }
}

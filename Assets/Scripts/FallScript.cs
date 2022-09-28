using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    [SerializeField] PlayerActions playerActions;
    PlayerHealth playerHealth;
    Vector2 startPosition;
    Animator myAnim;

    private void Start() {
        startPosition=playerActions.transform.position;
        myAnim=GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            playerHealth=other.GetComponent<PlayerHealth>();
            other.transform.position=startPosition;
            playerHealth.TakeLife();
        }
    }
}

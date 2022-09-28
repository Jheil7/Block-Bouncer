using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    // BoxCollider2D bC;
    // SpriteRenderer sR;
    // [SerializeField] PlayerHealth playerRespawning;
    // bool localisRespawning;
    // Animator myAnim;

    // void Start()
    // {
    //     bC=GetComponent<BoxCollider2D>();
    //     sR=GetComponent<SpriteRenderer>();
    //     myAnim=GetComponent<Animator>();
    //     bC.enabled=false;
    //     sR.enabled=false;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     localisRespawning=playerRespawning.GetRespawn();
    //     if(localisRespawning){
    //         bC.enabled=true;
    //         sR.enabled=true;
    //         localisRespawning=false;
    //         //myAnim.SetTrigger("Fading");
    //         StartCoroutine(PlatformWait());
    //     }
    // }
    
    // IEnumerator PlatformWait(){
    //     yield return new WaitForSeconds(playerRespawning.GetRespawnTimer());
    //     bC.enabled=false;
    //     sR.enabled=false;
    // }
}

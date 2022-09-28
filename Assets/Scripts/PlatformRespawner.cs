using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRespawner : MonoBehaviour
{
    [SerializeField] GameObject respawnPlatform;
    [SerializeField] PlayerHealth playerHealth;
    Animator myAnim;
    float platformTimer=3.0f;
    GameObject platformInstance;

    void Start()
    {
        myAnim=respawnPlatform.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.isRespawning){
            if(platformInstance!=null){
                Destroy(platformInstance);
            }
            else{
                platformInstance=Instantiate(respawnPlatform, transform.position, transform.rotation);
                playerHealth.isRespawning=false;
                Destroy (platformInstance, platformInstance.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
            }

        }
    }

    IEnumerator PlatformFade(){
        yield return new WaitForSeconds(platformTimer);
        Destroy(platformInstance);
    }
}

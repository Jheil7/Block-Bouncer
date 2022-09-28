using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    Rigidbody2D bulletRb;
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"){
            Rigidbody2D playerRb=other.GetComponent<Rigidbody2D>();
            playerHealth=other.GetComponent<PlayerHealth>();
            Destroy(gameObject);
            playerRb.AddForce(bulletRb.velocity*playerHealth.HitPercentage());
            
            
        }
    }
}

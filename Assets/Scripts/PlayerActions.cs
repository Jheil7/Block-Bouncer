using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public bool isSlamming;
    Rigidbody2D rb;
    [SerializeField] float downSpeed;
    BlockBehavior blockBehavior;
    [SerializeField] GameObject regenBlock;
    private BoxCollider2D myCollider;
    public int playerAmmo=0;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletExit;
    [SerializeField] float bulletSpeed;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        myCollider=GetComponent<BoxCollider2D>();
        
    }

    private void Awake() {
        isSlamming=false;
    }

    void Update()
    {
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            isSlamming=false;}
    }
    //Slam the block
    void OnSlam(InputValue value){
        if(!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            if(value.isPressed&&!isSlamming){
                Vector2 downSlamVelocity=new Vector2(0.0f, downSpeed);
                rb.AddForce(-transform.up*downSpeed);
                isSlamming=true;
            }
        }
    }
    //Regen the block
    void OnSecondary(InputValue value){
        if(value.isPressed){
            GameObject throwBlock=Instantiate(regenBlock, rb.transform.position, rb.transform.rotation);
            Rigidbody2D throwBlockRb=throwBlock.GetComponent<Rigidbody2D>();
            throwBlockRb.AddForce(-transform.up*downSpeed);
        }
    }

    void OnFire(InputValue value){
        if(value.isPressed&&playerAmmo>0){
            playerAmmo--;
            GameObject spawnedBullet=Instantiate(bulletPrefab,bulletExit.transform.position, bulletExit.transform.rotation);
            Rigidbody2D spawnedBulletRb=spawnedBullet.GetComponent<Rigidbody2D>();
            Vector2 bulletVector= new Vector2(-1f*Mathf.Sign(transform.localScale.x),0);
            spawnedBulletRb.AddForce(bulletVector*bulletSpeed);
        }
    }

    //check BlockBehavior for more interactions
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Block"&&isSlamming){
            blockBehavior=other.GetComponent<BlockBehavior>();
            StartCoroutine(WaitSlam());

        }
    }

    public bool GetSlam(){
        return isSlamming;
    }

    IEnumerator WaitSlam(){
        yield return new WaitForSeconds(0.1f);
        //isSlamming=false;
        playerAmmo++;
    }

    public int GetAmmo(){
        return playerAmmo;
    }

}

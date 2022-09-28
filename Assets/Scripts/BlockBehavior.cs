using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BlockBehavior : MonoBehaviour
{
    bool isSlamming;
    //CapsuleCollider2D blockCollider;
    BoxCollider2D blockCollider;
    CompositeCollider2D compositeCollider;
    SpriteRenderer blockSprite;
    Color blockSpriteColor;
    bool activeCheck=true;
    [SerializeField] float bounceSpeed;
    [SerializeField] float blockAlpha=0.2f;
    Platforms platforms;

    void Start()
    {
        
        blockSprite=GetComponent<SpriteRenderer>();
        blockSpriteColor=blockSprite.color;
        //blockCollider=GetComponent<CapsuleCollider2D>();
        blockCollider=GetComponent<BoxCollider2D>();
        platforms=FindObjectOfType<Platforms>();
        compositeCollider=GetComponent<CompositeCollider2D>();
    }

    private void Awake() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player"&&activeCheck){
            PlayerActions playerActions=other.GetComponent<PlayerActions>();
            isSlamming=playerActions.GetSlam();
            if(isSlamming){
                AddBounce(other);
                RemoveCollider();
                BlockSearch();
            }
        }

        else if(other.tag=="RegenBlock"){
            AddCollider();
            BlockSearch();
            Destroy(other.gameObject);
        }
    }

    public bool ActiveCheck(){
        return activeCheck;
    }

    IEnumerator RegenCompositeCollider(){
        yield return new WaitForEndOfFrame();
        compositeCollider.GenerateGeometry();
    }

    public void AddCollider(){
        blockSprite.color=blockSpriteColor;
        blockCollider.enabled=true;
        activeCheck=true;
        StartCoroutine(RegenCompositeCollider());
    }
    
    public void RemoveCollider(){
        blockSprite.color=new Color(blockSpriteColor.r, blockSpriteColor.g, blockSpriteColor.b, blockAlpha);
        blockCollider.enabled=false;
        activeCheck=false;
        StartCoroutine(RegenCompositeCollider());
    }

    void AddBounce(Collider2D playerCollider){
        Rigidbody2D playerRb=playerCollider.GetComponent<Rigidbody2D>();
        playerRb.velocity= new Vector2(0,0);
        playerRb.AddForce(transform.up*bounceSpeed);
    }

    void BlockSearch(){
        Vector3 blockPosition=blockSprite.transform.position;
        if(platforms.segmentOne.Any(x => x.transform.position==blockPosition)){
            int index= platforms.segmentOne.Select((block,index) => (block,index)).First(x => x.block.transform.position==blockPosition).index;
            int segmentLength=platforms.segmentOne.Count();
            int mirroredIndex=segmentLength-1-index;
            if(!activeCheck){
                platforms.segmentTwo.ToList()[mirroredIndex].RemoveCollider();
            }
            else{
                platforms.segmentTwo.ToList()[mirroredIndex].AddCollider();
            }

            return;
        }

        if(platforms.segmentTwo.Any(x => x.transform.position==blockPosition)){
            int index= platforms.segmentTwo.Select((block,index) => (block,index)).First(x => x.block.transform.position==blockPosition).index;
            int segmentLength=platforms.segmentTwo.Count();
            int mirroredIndex=segmentLength-1-index;
            if(!activeCheck){
                platforms.segmentOne.ToList()[mirroredIndex].RemoveCollider();
            }
            else{
                platforms.segmentOne.ToList()[mirroredIndex].AddCollider();
            }
            return;
        }
    }
}

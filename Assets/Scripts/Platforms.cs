using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    List<BlockBehavior> blockList;
    public IEnumerable<BlockBehavior> segmentOne;
    public IEnumerable<BlockBehavior> segmentTwo;
    //[SerializeField] Transform platformMain;
    void Start()
    {
        blockList= new List<BlockBehavior>();
        TryingShit();
        //Debug.Log(gameObject.transform.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TryingShit(){
        int totalCount=gameObject.transform.childCount;
        for(int i=0; i<totalCount; i++){
            Transform child=gameObject.transform.GetChild(i);
            BlockBehavior newthing=child.GetComponent<BlockBehavior>();
            blockList.Add(newthing);
        }
        
        segmentOne=blockList.GetRange(0,totalCount/2);
        segmentTwo=blockList.GetRange(totalCount/2,totalCount/2);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerLives;
    float respawnTime=3.0f;
    private bool _isRespawning;
    public int hitPercentage;
    [SerializeField] int hitMod=10;
    
    private void Start() {
        hitPercentage=0;
    }

    public int HitPercentage(){
        hitPercentage+=hitMod;
        return hitPercentage;
    }

    public void TakeLife(){
        playerLives--;
        isRespawning=true;
        hitPercentage=0;
        //StartCoroutine(RespawnTimer());
    }

    IEnumerator RespawnTimer(){
        yield return new WaitForSeconds(respawnTime);
        isRespawning=false;
    }

    public float GetRespawnTimer(){
        return respawnTime;
    }
    
    public int GetLives(){
        return playerLives;
    }
    
    [SerializeField]    
    public bool isRespawning{
        get{return _isRespawning;}
        set{_isRespawning=value;}  
    }

}

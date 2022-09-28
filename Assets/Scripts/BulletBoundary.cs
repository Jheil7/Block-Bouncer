using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoundary : MonoBehaviour
{

private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag=="Bullet"){
        Destroy(other.gameObject);
    }
}
}

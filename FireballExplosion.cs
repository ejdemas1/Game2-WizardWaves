using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Border" || coll.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}

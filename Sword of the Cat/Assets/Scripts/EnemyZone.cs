using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZone : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        GameObject go = collision.gameObject;
        // Check if the entity entering the zone is a player
        if (go.tag == "Player") {
            // Loop all child-gameobjects and check if they are enemies
            foreach(Transform childTransform in this.transform) {
                GameObject child = childTransform.gameObject;
                if (child.tag == "Enemy") {
                    // Make all enemies in the zone start attacking
                    child.GetComponent<EnemyController>().hasAggro = true;
                }
            }
        }
    }

    void OnCollisionExit(Collision collision) {
        GameObject go = collision.gameObject;
        // Check if the entity entering the zone is a player
        if (go.tag == "Player") {
            // Loop all child-gameobjects and check if they are enemies
            foreach(Transform childTransform in this.transform) {
                GameObject child = childTransform.gameObject;
                if (child.tag == "Enemy") {
                    // Make all enemies in the zone stop attacking
                    child.GetComponent<EnemyController>().hasAggro = false;
                }
            }
        }
    }
}

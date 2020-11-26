using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyBehavior behavior;
    public GameObject corpsePrefab;
    public Transform[] players;
    Transform closestPlayer;
    Rigidbody rb;
    NavMeshAgent nav;
    Vector3 lastLocation;
    public float hp;
    public AttackController.TagMask entityTag;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        hp = behavior.maxHealth;
    }

    Transform GetClosestPlayer()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in players)
        {
            float dist = Vector3.Distance(t.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
    }


    void FixedUpdate()
    {
        closestPlayer = GetClosestPlayer();
        switch (behavior.intelligence)
        {
            case 1:
                nav.destination = closestPlayer.position;
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }

    public void ReduceHealth(float amount)
    {
        hp -= amount;
    }
}

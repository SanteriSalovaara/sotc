using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public EnemyAttack attack;
    public enum TagMask
    {
        Player = 0,
        Simple = 1,
        Melee = 2,
        Harrier = 3,
        Tank = 4,
        Support = 5,
        Leader = 6,
        Berzerker = 7,
        Ranged = 8,
        Sniper = 9,
        Charger = 10,
        Turret = 11,
        Beacon = 12,
        Ambusher = 13,
    }
    public TagMask[] damageTargets;
    public LayerMask raycastMask;
    public int raycastResolution;
    public Vector3 raycastOffset;

    //RaycastHit hit;
    //public RaycastHit[] RaycastSweep(Vector3 origin, Vector3 direction, float distance, LayerMask layerMask, float leftAngle, float rightAngle, int resolution, Vector3 offset)
    //{
    //    RaycastHit[] hitlist = new RaycastHit[0];
    //    float gapAngle = (leftAngle + rightAngle) / resolution;
    //    for (float i = -leftAngle; i <= rightAngle; i += gapAngle)
    //    {
    //        Debug.DrawRay(origin + offset, Quaternion.AngleAxis(i, transform.up) * (direction * distance), color: Color.white, duration: 10f, depthTest: false);
    //        if (Physics.Raycast(origin + offset, Quaternion.AngleAxis(i, transform.up) * (direction * distance), out hit, maxDistance: distance, layerMask: layerMask))
    //        {
    //            Array.Resize(ref hitlist, hitlist.Length + 1);
    //            hitlist.Append(hit);
    //        }

    //    }

    //    return hitlist;
    //}

    public void Attack(bool isPlayer)
    {
        //RaycastHit[] hits = RaycastSweep(transform.position, direction: transform.forward, distance: attack.maxRange, layerMask: raycastMask, leftAngle: attack.angle / 2, rightAngle: attack.angle / 2, resolution: raycastResolution, offset: raycastOffset);
        //foreach (RaycastHit i in hits)
        //{
        //    if (i.collider)
        //    {
        //        Debug.Log("debug");
        //        i.collider.gameObject.GetComponent<EnemyController>().ReduceHealth(attack.damage);
        //    }
        //}
        if (isPlayer)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in enemies)
            {
                if ((i.transform.position - transform.position).magnitude <= attack.maxRange)
                {
                    if (Vector3.Angle(i.transform.position - transform.position, transform.forward) <= attack.angle)
                    {
                        i.GetComponent<EnemyController>().ReduceHealth(attack.damage);
                    }
                }
            }
        } 
        else
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject i in players)
            {
                if ((i.transform.position - transform.position).magnitude <= attack.maxRange)
                {
                    if (Vector3.Angle(i.transform.position - transform.position, transform.forward) <= attack.angle)
                    {
                        i.GetComponent<PlayerStatsController>().Damage(attack.damage);
                    }
                }
            }
        }
    }
}

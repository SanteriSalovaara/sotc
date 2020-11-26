using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[CreateAssetMenu(fileName = "New Enemy Phase Asset", menuName = "Enemy Phase Asset")]
public class EnemyPhase : ScriptableObject
{
    [Range(1, 100)]
    public int attackRollMinimum;

    public float accuracyModifier;
    public float attackWindup;
    public float attackCooldown;
    public EnemyAttack[] preferredAttacks;
    public AudioClip[] idleSounds;
}
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Behavior Asset", menuName = "Enemy Behavior Asset")]
public class EnemyBehavior : ScriptableObject
{
    public string enemyID;
    [Space(10)]
    public string classTag;
    public string targetTag;
    
    [Range(0.00f, 1.00f)]
    public float baseAccuracy;

    public float speed;
    public int maxHealth;
    public float aggroRange;
    public float awakeRange;

    [Range(1, 6)]
    public int intelligence;

    public EnemyPhase[] phases;

    [Space(10)]
    [Header("Audio")]
    public AudioClip footstepSound;
    public AudioClip hurtSound;
    public AudioClip fallbackAttackSound;
    public AudioClip fallbackIdleSound;
}
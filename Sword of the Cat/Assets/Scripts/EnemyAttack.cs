using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Attack Asset", menuName = "Enemy Attack Asset")]
public class EnemyAttack : ScriptableObject
{
    public EnemyProjectiles projectiles;
    public float maxRange;
    public float preferredRange;

    [Range(0, 360)]
    public float angle;

    public float damage;
    public float lifetime;
    public bool useWorldSpace;

    public ParticleEmitter attackParticles;
    public ParticleEmitter hitPlayerParticles;
    public ParticleEmitter hitOtherParticles;
}

[Serializable]
public class EnemyProjectiles
{
    public bool enableProjectiles;
    public GameObject projectile;
    public int projectileCount;
    public float projectileSpeed;
    public float accuracyModifier;

    [Range(0, 5)]
    public int bounceCount;

    public AudioClip fireSound;
}

[Serializable]
public class ParticleEmitter
{
    public ParticleSystem particleSystem;
    public int particleCount;
    public int particleRepetitionCount;
    public int particleRepetitionInterval;
    public Quaternion particleOrientation;
}
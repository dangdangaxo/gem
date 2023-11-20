using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Enemy", menuName = "Enemy" )]
public class Enemy : ScriptableObject
{
    [SerializeField] int Health;
    [SerializeField] int Damage;

    [SerializeField] int Speed;
    public int GetHealth()
    {
        return Health;
    }

    public int GetDamage()
    {
        return Damage;
    }

    public int GetSpeed()
    {
        return Speed;
    }
}

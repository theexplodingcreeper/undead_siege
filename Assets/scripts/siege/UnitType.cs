using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="unit", fileName ="new unit")]
public class UnitType : ScriptableObject
{
    public RuntimeAnimatorController animations;

    public float range = 1;
    public float speed = 2;

    public float attackSpeed;
    public int damage;
    public int health;
    public float bodyRecoveryChance;
}

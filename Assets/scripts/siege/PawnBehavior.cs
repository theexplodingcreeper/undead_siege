using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PawnBehavior : MonoBehaviour
{
    [SerializeField]private UnitType unit;

    [Header("stats")]
    private float range;
    private float speed;
    private float attackSpeed;
    private int damage;
    private int health;
    private float bodyRecoveryChance;

    private NavMeshAgent agent;
    private EnemyDesignation comander;

    private SpriteRenderer design;
    private NavMeshAgent nav;
    [Header("monitor")]
    [SerializeField]private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        range= unit.range;
        speed= unit.speed;
        attackSpeed= unit.attackSpeed;
        damage= unit.damage;
        health= unit.health;
        bodyRecoveryChance= unit.bodyRecoveryChance;

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        nav.stoppingDistance = range-1;

        AimConstraint constraint = GetComponentInChildren<AimConstraint>();
        Debug.Log(constraint.name);


        ConstraintSource source = new ConstraintSource();
        source.sourceTransform = Camera.main.transform;
        source.weight = 1;

        // Set the new source to the AimConstraint (you can use index 0 or another index if needed)
        constraint.SetSource(0, source);


        design = GetComponentInChildren<SpriteRenderer>();
        comander = gameObject.GetComponentInParent<EnemyDesignation>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject army = comander.GetEnemy();
        Transform aim = null;
        foreach (Transform T in army.GetComponentInChildren<Transform>())
        {
            if (aim == null)
            {
                aim = T;
            }
        }
        if (transform.position.x > aim.position.x)
        {
            design.flipX = false;
        }
        else
        {
            design.flipX = true;
        }
        target = aim;
        agent.destination = aim.position;
    }
}

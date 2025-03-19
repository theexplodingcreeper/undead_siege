using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PawnBehavior : MonoBehaviour
{
    [SerializeField]public UnitType unit;

    private float range;
    private float speed;
    private float attackSpeed;
    private int damage;
    private int maxHealth;
    private float bodyRecoveryChance;
    private int health;


    private NavMeshAgent agent;
    private EnemyDesignation comander;

    private SpriteRenderer design;
    private NavMeshAgent nav;
    [Header("monitor")]
    [SerializeField]private Transform target;
    [SerializeField] private float distance;

    private float timesincelastattack;
    private Animator animator;
    public bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        range= unit.range;
        speed= unit.speed;
        attackSpeed= unit.attackSpeed;
        damage= unit.damage;
        health = unit.health;
        maxHealth = unit.health;
        bodyRecoveryChance = unit.bodyRecoveryChance;

        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
        nav.stoppingDistance = range-1;
        animator = GetComponentInChildren<Animator>();

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

    public void takeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            animator.SetInteger("anim state", 3);
            isdead = true;
            Debug.Log(comander.victorycheack());
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!isdead)
        {
            animator.SetInteger("anim state", 0);
            GameObject army = comander.GetEnemy();
            Transform aim = null;
            foreach (Transform T in army.GetComponentInChildren<Transform>())
            {

                if (!T.GetComponent<PawnBehavior>().isdead)
                {
                    if (aim == null)
                    {
                        aim = T;
                    }
                }

            }

            
            if (aim != null)
            {
                if (transform.position.x > aim.position.x)
                {
                    design.flipX = false;
                }
                else
                {
                    design.flipX = true;
                }

                if ((transform.position - aim.position).magnitude >= range)
                {
                    animator.SetInteger("anim state", 1);
                }
                

                target = aim;
                distance = (transform.position - aim.position).magnitude;
                agent.destination = aim.position;
                timesincelastattack += Time.deltaTime;
                if (timesincelastattack >= attackSpeed && (transform.position - aim.position).magnitude <= range)
                {
                    animator.SetInteger("anim state", 2);
                    Debug.Log("hit");
                    aim.GetComponent<PawnBehavior>().takeDamage(damage);
                }
            }

            
        }
        else
        {
            agent.destination = transform.position;
        }
    }
        
}

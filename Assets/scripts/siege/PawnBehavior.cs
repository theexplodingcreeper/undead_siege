using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class PawnBehavior : MonoBehaviour
{

    private NavMeshAgent agent;
    private EnemyDesignation comander;

    private SpriteRenderer design;
    [SerializeField]private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        

        AimConstraint constraint = GetComponentInChildren<AimConstraint>();
        Debug.Log(constraint.name);
        ConstraintSource source = new ConstraintSource();
        Debug.Log(Camera.main.transform);
        source.sourceTransform = Camera.main.transform;
        source.weight = 1;
        constraint.SetSource(1,source);

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

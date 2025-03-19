using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyDesignation : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject troop;
    public GameObject GetEnemy()
    {
        return Enemy;
    }

    public bool victorycheack()
    {
        bool vicory = true;
        foreach (Transform T in GetComponentInChildren<Transform>())
        {
            if (T.GetComponent<PawnBehavior>())
            {
                if (!T.GetComponent<PawnBehavior>().isdead)
                {
                    vicory = false;
                }
            }
        }
        return vicory;
    }
    public void sendbetalian(armyDesignation army)
    {
        foreach(armyDesignation.unit unit in army.units)
        {
            for (int i = 0; i < unit.amount; i++)
            {
                GameObject trooper = Instantiate(troop, transform);
                trooper.AddComponent<PawnBehavior>().unit = unit.type;
                trooper.transform.localPosition = new Vector3(0,0,0);
                trooper.GetComponentInChildren<Animator>().runtimeAnimatorController = unit.type.animations;
            }
        }

    }
}

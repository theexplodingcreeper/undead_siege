using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDesignation : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;

    public GameObject GetEnemy()
    {
        return Enemy;
    }

}

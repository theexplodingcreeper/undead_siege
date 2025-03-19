using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiegeControler : MonoBehaviour
{
    public armyDesignation humanArmy;
    public armyDesignation undeadArmy;

    [SerializeField]private EnemyDesignation humans;
    [SerializeField]private EnemyDesignation undead;

    // Start is called before the first frame update
    void Start()
    {
        BeguinSiege();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeguinSiege()
    {
        humans.sendbetalian(humanArmy);
        undead.sendbetalian(undeadArmy);
    }
}

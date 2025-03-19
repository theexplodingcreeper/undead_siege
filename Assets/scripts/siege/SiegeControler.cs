using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void endsiege()
    {
        int corpses = humans.retreat();
        int sacrifices = undead.retreat();

        gamescript.available_undead += corpses - sacrifices;
        if(gamescript.current_research != null)
            gamescript.current_research.Reseach_progress += gamescript.reseachers;

        SceneManager.LoadScene("camp");
    }
    public void BeguinSiege()
    {
        humans.sendbetalian(humanArmy);
        undead.sendbetalian(undeadArmy);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new army", menuName ="create army")]
public class armyDesignation : ScriptableObject
{
    [System.Serializable]
    public struct unit
    {
        public int amount;
        public UnitType type;
        
    }

    [SerializeField]public List<unit> units;
}

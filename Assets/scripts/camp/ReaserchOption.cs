using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new reseach option",menuName = "new research")]
public class ReaserchOption : ScriptableObject
{
    [SerializeField]private int point_needed;

    [SerializeField]private ReaserchOption[] requierments;

    public int Reseach_progress;

    private bool is_compleat;

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowUndead : MonoBehaviour
{
    private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
        int current_undead = gamescript.available_undead - gamescript.reseachers - gamescript.gatheres - gamescript.forge;
        text.text = $"{current_undead}/{gamescript.available_undead}"; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int current_undead = gamescript.available_undead - gamescript.reseachers - gamescript.gatheres - gamescript.forge;
        text.text = $"{current_undead}/{gamescript.available_undead}";
    }
}

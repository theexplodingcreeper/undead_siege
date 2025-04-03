using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [System.Serializable]
    public struct formationRow
    {
        public UnitType[] unit;
    }

    public List<unit> units;

    public formationRow[] formation = new formationRow[10];
    private void Awake()
    {
        int f = 0;
        foreach(formationRow row in formation )
        {
            formation[f].unit = new UnitType[6]; 
            f++;
        }
    }
}
[CustomPropertyDrawer(typeof(armyDesignation.formationRow))]
public class armyDesignationdraw : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        
        int len = 50;
        foreach(SerializedProperty attribute in property)
        {
            if(attribute.propertyType != SerializedPropertyType.ArraySize)
            {
                var amountRect = new Rect(position.x + len, position.y, position.height, position.height);
                EditorGUI.PropertyField(amountRect, attribute, GUIContent.none);
                len += 30;
            }

        }

        EditorGUI.EndProperty();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ensemble", fileName = "List_Scriptable")]
public class ListScript : ScriptableObject
{
    public List<Object> pokelist = new List<Object>();
    
    public void Add(Object script)
    {
        pokelist.Add(script);
    }
}
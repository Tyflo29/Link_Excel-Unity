using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "List", fileName = "List_Scriptable")]
public class LISTscript : ScriptableObject
{
    public List<ScriptableObject> pokelist = new List<ScriptableObject>();

    public void Add(ScriptableObject script)
    {
        pokelist.Add(script);
    }
}
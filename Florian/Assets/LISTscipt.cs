using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LISTscript : ScriptableObject
{
    public List<Object> pokelist;

    public void Add(Object script)
    {
        pokelist.Add(script);
    }
}
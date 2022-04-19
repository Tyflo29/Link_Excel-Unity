using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MyClass
{
    public List<MyStructDe> ms;
}

[System.Serializable]
public struct MyStructDe
{
    public int numero;
    public string nomfr;
    public string nomang;
    public string type;
    public int pv;
    public int att;
    public int def;
    public int vit;
}
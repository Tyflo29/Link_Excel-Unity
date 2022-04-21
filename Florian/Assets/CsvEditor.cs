using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Excel", fileName = "Export_Excel")]
public class CsvEditor : ScriptableObject
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

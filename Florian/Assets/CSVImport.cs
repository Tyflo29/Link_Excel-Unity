using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CSVImport
{
    public static class CSVGenetator
    {
        
        [MenuItem("CSVImport/Generate Data from CSV")]
        public static void GenerateCSV()
        {
            if (Selection.activeObject == null) return;

            string path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), AssetDatabase.GetAssetPath(Selection.activeObject));

            if(!IsCSVFile(path))
            {
                Debug.LogError("Not a CSV File");
                return;
            }

            List<Dictionary<string, object>> rawCSVData = CSVReading.CSVReader.Read(path);

            if(rawCSVData.Count > 0)
            {
                bool confirmed = EditorUtility.DisplayDialog("Mass Generate Pokemon", $"Are you sure you want to create {rawCSVData.Count} " +
                    $"entries? This may take while."
                    , "Yes!", "No.");

                if (confirmed) PerfornGeneration(rawCSVData);
            }
            else 
            {
                Debug.LogError("No entries read from CSV ?");
                return;
            }
        }

        private static void PerfornGeneration(List<Dictionary<string, object>> csvData)
        {
            if (!System.IO.Directory.Exists("Assets/Script")) System.IO.Directory.CreateDirectory("Assets/Script");

            var pokelist = ScriptableObject.CreateInstance<LISTscript>();
            AssetDatabase.CreateAsset(pokelist, $"Assets/Script/Liste/Liste_Pokemon.asset");

            for (int i = 0; i < csvData.Count; i++)
            {
                Dictionary<string, object> _potentialPoke = csvData[i];

                //Debug.Log($"Poke Number: {_potentialPoke["#"]} {_potentialPoke["français"]} {_potentialPoke["anglais"]} {_potentialPoke["Type"]} {_potentialPoke["PV"]} {_potentialPoke["Attaque"]} {_potentialPoke["Defense"]} {_potentialPoke["Vitesse"]}");

                int numero;string français;string anglais; string type;int pv;int attaque;int defense; int vitesse;

                //nombre
                numero = int.Parse(_potentialPoke["#"].ToString());
                pv = int.Parse(_potentialPoke["PV"].ToString());
                attaque = int.Parse(_potentialPoke["Attaque"].ToString());
                defense = int.Parse(_potentialPoke["Defense"].ToString());
                vitesse = int.Parse(_potentialPoke["Vitesse"].ToString());
                //text
                français = _potentialPoke["français"].ToString();
                anglais = _potentialPoke["anglais"].ToString();
                type = _potentialPoke["Type"].ToString();

                CsvEditor fichePoke = ScriptableObject.CreateInstance<CsvEditor>();
                AssetDatabase.CreateAsset(fichePoke, $"Assets/Script/{numero}_{français}.asset");

                fichePoke.numero = numero;
                fichePoke.nomfr = français;
                fichePoke.nomang = anglais;
                fichePoke.type = type;
                fichePoke.pv = pv;
                fichePoke.att = attaque;
                fichePoke.def = defense;
                fichePoke.vit = vitesse;

                AssetDatabase.SaveAssets();

                //pokelist.Add(Resources.Load($"{numero}_{français}.asset"));

                if (i > 10) break;
            }
            AssetDatabase.SaveAssets();
        }

        /*
        private static void CreatePoke(int numero, string français, string anglais, string type, int pv, int attaque, int defense, int vitesse, LISTscript pokelist)
        {

            var fichePoke = ScriptableObject.CreateInstance<CsvEditor>();

            fichePoke.numero = numero;
            fichePoke.nomfr = français;
            fichePoke.nomang = anglais;
            fichePoke.type = type;
            fichePoke.pv = pv;
            fichePoke.att = attaque;
            fichePoke.def = defense;
            fichePoke.vit = vitesse;


            AssetDatabase.CreateAsset(fichePoke, $"Assets/Script/{numero}_{français}.asset");
            AssetDatabase.SaveAssets();
        }*/

        private static bool IsCSVFile(string fullPath)
        {
            return fullPath.ToLower().EndsWith(".csv");
        }
    }
}

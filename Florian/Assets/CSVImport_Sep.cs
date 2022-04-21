using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CSVImport_sep
{
    public static class CSVGenetator_sep
    {
        
        [MenuItem("CSVImport/Generate Data from CSV to separate")]
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

            for (int i = 0; i < csvData.Count; i++)
            {
                Dictionary<string, object> _potentialPoke = csvData[i];

                //Debug.Log($"Poke Number: {_potentialPoke["#"]} {_potentialPoke["fran�ais"]} {_potentialPoke["anglais"]} {_potentialPoke["Type"]} {_potentialPoke["PV"]} {_potentialPoke["Attaque"]} {_potentialPoke["Defense"]} {_potentialPoke["Vitesse"]}");

                int numero;string fran�ais;string anglais; string type;int pv;int attaque;int defense; int vitesse;

                //nombre
                numero = int.Parse(_potentialPoke["#"].ToString());
                pv = int.Parse(_potentialPoke["PV"].ToString());
                attaque = int.Parse(_potentialPoke["Attaque"].ToString());
                defense = int.Parse(_potentialPoke["Defense"].ToString());
                vitesse = int.Parse(_potentialPoke["Vitesse"].ToString());
                //text
                fran�ais = _potentialPoke["fran�ais"].ToString();
                anglais = _potentialPoke["anglais"].ToString();
                type = _potentialPoke["Type"].ToString();

                CreatePoke(numero, fran�ais, anglais, type,  pv,  attaque,  defense, vitesse);

                if (i > 10) break;
            }
            AssetDatabase.SaveAssets();
        }


        private static void CreatePoke(int numero, string fran�ais, string anglais, string type, int pv, int attaque, int defense, int vitesse)
        {

            CsvEditor fichePoke = ScriptableObject.CreateInstance<CsvEditor>();

            fichePoke.numero = numero;
            fichePoke.nomfr = fran�ais;
            fichePoke.nomang = anglais;
            fichePoke.type = type;
            fichePoke.pv = pv;
            fichePoke.att = attaque;
            fichePoke.def = defense;
            fichePoke.vit = vitesse;


            AssetDatabase.CreateAsset(fichePoke, $"Assets/Script/{numero}_{fran�ais}.asset");
            AssetDatabase.SaveAssets();
        }

        private static bool IsCSVFile(string fullPath)
        {
            return fullPath.ToLower().EndsWith(".csv");
        }
    }
}

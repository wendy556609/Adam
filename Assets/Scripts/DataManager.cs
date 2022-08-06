using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static AnimalData animal = null;
#if UNITY_EDITOR
    [MenuItem ("Tool/ExportData")]
    private static void ExportData ()
    {
        Object allText = Resources.Load ("AnimalData");
        string content = allText.ToString ();
        string [] line = content.Split ('\n');

        animal = ScriptableObject.CreateInstance<AnimalData> ();
        animal.CreateData (line);

        AssetDatabase.CreateAsset (animal, "Assets/Data/AnimalData.asset");        
    }
#endif

    public AnimalData.Data QueryData (int id)
    {
        return animal.QueryData (id);
    }

    public AnimalData.Data FindMixAnimal (int mix1, int mix2)
    {
        return animal.FindMixAnimal (mix1, mix2);
    }
}

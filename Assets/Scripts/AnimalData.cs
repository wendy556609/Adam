using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalData : ScriptableObject
{
    [SerializeField]
    private Dictionary <int, Data> AllAnimalList = new Dictionary <int, Data> ();

    [System.Serializable]
    public class Data
    {
        public int ID = 0;
        public string Name = "";
        public string Prefab = "";
        public HashSet<int> MixIds = new HashSet<int> ();
    }

    public void CreateData (string[] line)
    {
        AllAnimalList.Clear ();
        for (int i = 1; i < line.Length; i++) {
            string[] data = line [i].Split (',');
            Data animalData = new Data ();
            animalData.ID = int.Parse (data [0]);
            animalData.Name = data [1];
            animalData.Prefab = data [2];
            animalData.MixIds.Add (int.Parse (data [3]));
            animalData.MixIds.Add (int.Parse (data [4]));

            AllAnimalList.Add (animalData.ID, animalData);
        }
    }

    public Data QueryData (int id)
    {
        if (AllAnimalList.ContainsKey (id)) {
            return AllAnimalList [id];
        }

        return null;
    }

    public Data FindMixAnimal (int mix1, int mix2)
    {
        foreach (var data in AllAnimalList)
        {
            if (data.Value.MixIds.Contains (mix1) && data.Value.MixIds.Contains (mix2)) {
                return data.Value;
            }
        }

        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static DataManager _instance;

    static public DataManager Instance
    {
        get
        {
            if (_instance == null)
            {
               
                _instance = FindObjectOfType(typeof(DataManager)) as DataManager;

                if (_instance == null)  // if not found
                {
                    GameObject go = new GameObject("_MyClass");
                    DontDestroyOnLoad(go); 
                    _instance = go.AddComponent<DataManager>(); 
                }
            }
            return _instance;
        }
    }

    public string curUserName;
    [HideInInspector]
    public string curUserLastDecTime;
    [HideInInspector]
    public float curUserPetEnergy;

    public int curUserScore;
    public int curUserCoins;

    public int rank1;
    public int rank2;
    public int rank3;
    public int rank4;
}


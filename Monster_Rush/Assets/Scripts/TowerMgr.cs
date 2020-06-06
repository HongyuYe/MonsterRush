using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMgr : MonoBehaviour {

    public static TowerMgr Instance;
    [HideInInspector]
    public List<Vector3> towerPos = new List<Vector3>();

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CheckPos(Vector3 p)
    {
        foreach(Vector3 a in towerPos)
        {
            if(a == p)
            {
                return false;
            }
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankMgr : MonoBehaviour {

    public Text rank1;
    public Text rank2;
    public Text rank3;
    public Text rank4;

    // Use this for initialization
    void Start () {
        rank1.text = DataManager.Instance.rank1.ToString();
        rank2.text = DataManager.Instance.rank2.ToString();
        rank3.text = DataManager.Instance.rank3.ToString();
        rank4.text = DataManager.Instance.rank4.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}

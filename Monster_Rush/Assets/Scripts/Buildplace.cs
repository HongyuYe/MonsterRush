using UnityEngine;
using System.Collections;

public class Buildplace : MonoBehaviour
{
    // The Tower that should be built
    public GameObject towerPrimary;
    public GameObject towerIntermediate;
    public GameObject towerAdvance;
    public GameObject towerNightmare;

    void OnMouseUpAsButton()
    {
        // Build Tower above Buildplace
        if (TowerMgr.Instance.CheckPos(transform.position + Vector3.up))
        {
            if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.primary && ScoreMgr.instance.ScoreDecrease(5))
            {
                GameObject g = (GameObject)Instantiate(towerPrimary);
                g.transform.position = transform.position + Vector3.up;
                TowerMgr.Instance.towerPos.Add(transform.position + Vector3.up);
            }
            else if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.intermediate && ScoreMgr.instance.ScoreDecrease(15))
            {
                GameObject g = (GameObject)Instantiate(towerIntermediate);
                g.transform.position = transform.position + Vector3.up;
                TowerMgr.Instance.towerPos.Add(transform.position + Vector3.up);
            }
            else if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.advance && ScoreMgr.instance.ScoreDecrease(25))
            {
                GameObject g = (GameObject)Instantiate(towerAdvance);
                g.transform.position = transform.position + Vector3.up;
                TowerMgr.Instance.towerPos.Add(transform.position + Vector3.up);
            }
            else if (StoreMgr.Instance.towerSpecise == StoreMgr.TowerSpecise.nightmare && ScoreMgr.instance.ScoreDecrease(35))
            {
                GameObject g = (GameObject)Instantiate(towerNightmare);
                g.transform.position = transform.position + Vector3.up;
                TowerMgr.Instance.towerPos.Add(transform.position + Vector3.up);
            }
        }
    }
}

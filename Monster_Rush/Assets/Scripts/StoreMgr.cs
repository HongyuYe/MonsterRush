using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMgr : MonoBehaviour
{
    public static StoreMgr Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum TowerSpecise
    {
        primary,
        intermediate,
        advance,
        nightmare
    }

    public TowerSpecise towerSpecise = TowerSpecise.primary;

    public void primary()
    {
        towerSpecise = TowerSpecise.primary;
    }

    public void intermediate()
    {
        towerSpecise = TowerSpecise.intermediate;
    }

    public void advance()
    {
        towerSpecise = TowerSpecise.advance;
    }

    public void nightmare()
    {
        towerSpecise = TowerSpecise.nightmare;
    }
}

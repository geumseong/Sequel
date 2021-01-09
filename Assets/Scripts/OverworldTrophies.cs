using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldTrophies : MonoBehaviour
{
    public SpriteRenderer graviree;
    public SpriteRenderer aimAndFire;
    public SpriteRenderer spacewordetsu;
    public SpriteRenderer stationJump;
    public SpriteRenderer shipBoom;
    public SpriteRenderer spaceDefence;
    void Start()
    {
        if (TrophyManager.Instance.gravireee_Trophy == true)
        {
            graviree.enabled = true;
        }
        if (TrophyManager.Instance.aimAndFire_Trophy == true)
        {
            aimAndFire.enabled = true;
        }
        if (TrophyManager.Instance.spacewordetsu_Trophy == true)
        {
            spacewordetsu.enabled = true;
        }
        if (TrophyManager.Instance.stationJump_Trophy == true)
        {
            stationJump.enabled = true;
        }
        if (TrophyManager.Instance.shipBoom_Trophy == true)
        {
            shipBoom.enabled = true;
        }
        if (TrophyManager.Instance.spaceDefence_Trophy == true)
        {
            spaceDefence.enabled = true;
        }
    }
}

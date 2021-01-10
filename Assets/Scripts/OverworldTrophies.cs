using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldTrophies : MonoBehaviour
{
    public GameObject graviree_tr;
    public GameObject aimAndFire_tr;
    public GameObject spacewordetsu_tr;
    public GameObject stationJump_tr;
    public GameObject shipBoom_tr;
    public GameObject spaceDefence_tr;

    public GameObject graviree_fl;
    public GameObject aimAndFire_fl;
    public GameObject spacewordetsu_fl;
    public GameObject stationJump_fl;
    public GameObject shipBoom_fl;
    public GameObject spaceDefence_fl;

    public TriggerEnter lsjTrigger;

    public int trophycounter;

    void Start()
    {
        trophycounter = 0;
        if (TrophyManager.Instance.gravireee_Trophy == true)
        {
            graviree_tr.SetActive(true);
            graviree_fl.SetActive(true);
            trophycounter++;
        }

        if (TrophyManager.Instance.aimAndFire_Trophy == true)
        {
            aimAndFire_tr.SetActive(true);
            aimAndFire_fl.SetActive(true);
            trophycounter++;
        }

        if (TrophyManager.Instance.spacewordetsu_Trophy == true)
        {
            spacewordetsu_tr.SetActive(true);
            spacewordetsu_fl.SetActive(true);
            trophycounter++;
        }

        if (TrophyManager.Instance.stationJump_Trophy == true)
        {
            stationJump_tr.SetActive(true);
            stationJump_fl.SetActive(true);
            trophycounter++;
        }

        if (TrophyManager.Instance.shipBoom_Trophy == true)
        {
            shipBoom_tr.SetActive(true);
            shipBoom_fl.SetActive(true);
            trophycounter++;
        }

        if (TrophyManager.Instance.spaceDefence_Trophy == true)
        {
            spaceDefence_tr.SetActive(true);
            spaceDefence_fl.SetActive(true);
            trophycounter++;
        }

        if (trophycounter == 6)
        {
            lsjTrigger.lsj = false;
        }

    }
}

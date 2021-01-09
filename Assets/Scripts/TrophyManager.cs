using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyManager : MonoBehaviour
{
    public bool gravireee_Trophy; //1
    public bool aimAndFire_Trophy; //2
    public bool spacewordetsu_Trophy; //3
    public bool stationJump_Trophy; //4
    public bool shipBoom_Trophy; //5
    public bool spaceDefence_Trophy; //6
    private static TrophyManager _instance;

    public static TrophyManager Instance
    {
        get { return _instance; }
    }

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            //Debug.Log("Duplicate Deleted:: SceneLoader - There can only be one. Ignore this if the same scene was loaded.");
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GetTrophy(int level)
    {
        switch (level)
        {
            case 1:
                gravireee_Trophy = true;
                break;
            case 2:
                aimAndFire_Trophy = true;
                break;
            case 3:
                spacewordetsu_Trophy = true;
                break;
            case 4:
                stationJump_Trophy = true;
                break;
            case 5:
                shipBoom_Trophy = true;
                break;
            case 6:
                spaceDefence_Trophy = true;
                break;
            default:
                break;
        }
    }
}

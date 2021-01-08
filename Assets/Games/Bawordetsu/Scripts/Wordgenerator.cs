using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wordgenerator : MonoBehaviour
{
    private static string[] wordList = {"spaceship", "scifi", "science", "technology", "robots", "clones", "android", "galaxy", "space", "planet", "andromeda", "zodiac", "captain",
    "orbit", "satellite", "aliens", "mars", "musk", "moon", "saturn", "asteroid", "invaders", "probe", "oxygen", "stars", "cyborg", "crater", "technocracy", "lightsaber", "disintegration",
    "terraforming", "artificial", "kardashev", "seti", "extraterrestrial", "energy", "sun", "lucas", "asimov", "banks", "electric", "astrophysics", "stargate", "dune", "odyssey", "universe",
    "expansion", "bowie", "starman", "starlord", "ringworld", "continuum", "life", "singularity", "ai", "curvature", "speed", "lightyear", "moore", "transhuman", "bioengineering", "genetic",
    "nootropic", "noosphere", "exponential", "shift", "hyperbolic", "circuit", "algorithm", "consciousness", "revolution", "technology", "neuroenhancement", "uploading", "global", "future",
    "simulation", "intelligence", "nanotechnology", "bytes", "exosphere", "cognitive", "digital", "meteorite", "existential", "humanity", "ridley", "samus", "freedom", "humankind", "union",
    "hawking", "chemistry"};

    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        string randomWord = wordList[randomIndex];
        return randomWord; 
    }
}

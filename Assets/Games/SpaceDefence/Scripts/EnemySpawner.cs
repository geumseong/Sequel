using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject meteorite;
    public GameObject smallAliens;
    public GameObject mediumAliens;
    public GameObject bossAliens;
    public List<GameObject> spawnPoints;
    public GameObject gameStateManagerObj;

    // Start is called before the first frame update
    public void StartSpawnEnemy(int waveCount, int phase)
    {
        StartCoroutine(SpawnEnemy(waveCount, phase));
    }

    void Start() {
        gameStateManagerObj = GameObject.Find("GameStateManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy(int waveCount, int phase) {
        if(waveCount > 5) {

        }
        else if(waveCount == 1) {
            int meteoriteCount = 0;
            int maxMeteoriteCount = 10 * phase;
            while(meteoriteCount < maxMeteoriteCount) {
                yield return new WaitForSeconds(2 / phase);
                int spawnPoint = Random.Range(0, 14);
                GameObject selectedSpawn = spawnPoints[spawnPoint];
                Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                GameObject newEnemy = Instantiate(meteorite, spawnPosition, transform.rotation);
                newEnemy.GetComponent<Meteorite>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                meteoriteCount++;
            }
            gameStateManagerObj.GetComponent<GameStateManager>().waveStatus = false;
            yield return null;
        }
        else if(waveCount == 2) {
            int meteoriteCount = 0;
            int smallAlienCount = 0;
            int maxMeteoriteCount = 10 * phase;
            int maxSmallAlienCount = 5 * phase;
            int totalSpawn = 0;
            while(totalSpawn < (maxMeteoriteCount + maxSmallAlienCount)) {
                int random = Random.Range(0, 3);
                yield return new WaitForSeconds((float) 2f / phase);
                if(random < 2) {
                    if(meteoriteCount < maxMeteoriteCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(meteorite, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<Meteorite>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        meteoriteCount++;
                        totalSpawn++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                        totalSpawn++;
                    }
                }
                else if(random == 2) {
                    if(smallAlienCount < maxSmallAlienCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                        totalSpawn++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(meteorite, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<Meteorite>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        meteoriteCount++;
                        totalSpawn++;
                    }
                }
            }
            gameStateManagerObj.GetComponent<GameStateManager>().waveStatus = false;
            yield return null;
        }
        else if(waveCount == 3) {
            int mediumAlienCount = 0;
            int smallAlienCount = 0;
            int maxMediumAlienCount = 5 * phase;
            int maxSmallAlienCount = 10 * phase;
            int totalSpawn = 0;
            while(totalSpawn < (maxMediumAlienCount + maxSmallAlienCount)) {
                int random = Random.Range(0, 3);
                yield return new WaitForSeconds(2 / phase);
                if(random == 2) {
                    if(mediumAlienCount < maxMediumAlienCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(mediumAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<MediumAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        mediumAlienCount++;
                        totalSpawn++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                        totalSpawn++;
                    }
                }
                else if(random < 2) {
                    if(smallAlienCount < maxSmallAlienCount) {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(smallAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<SmallAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        smallAlienCount++;
                        totalSpawn++;
                    }
                    else {
                        int spawnPoint = Random.Range(0, 14);
                        GameObject selectedSpawn = spawnPoints[spawnPoint];
                        Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                        GameObject newEnemy = Instantiate(mediumAliens, spawnPosition, transform.rotation);
                        newEnemy.GetComponent<MediumAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                        mediumAlienCount++;
                        totalSpawn++;
                    }
                }
            }
            gameStateManagerObj.GetComponent<GameStateManager>().waveStatus = false;
            yield return null;
        }
        else if(waveCount == 4) {
            int mediumAlienCount = 0;
            int maxMediumAlienCount = 15 * phase;
            while(mediumAlienCount < maxMediumAlienCount) {
                yield return new WaitForSeconds(2 / phase);
                int spawnPoint = Random.Range(0, 14);
                GameObject selectedSpawn = spawnPoints[spawnPoint];
                Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                GameObject newEnemy = Instantiate(mediumAliens, spawnPosition, transform.rotation);
                newEnemy.GetComponent<MediumAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                mediumAlienCount++;
            }
            gameStateManagerObj.GetComponent<GameStateManager>().waveStatus = false;
            yield return null;
        }
        else if(waveCount == 5) {
            int maxBossAlienCount = 1 * phase;
            int bossAlienCount = 0;
            while(bossAlienCount < maxBossAlienCount) {
                yield return new WaitForSeconds(2 / phase);
                int spawnPoint = Random.Range(0, 14);
                GameObject selectedSpawn = spawnPoints[spawnPoint];
                Vector3 spawnPosition = new Vector3(selectedSpawn.transform.position.x, selectedSpawn.transform.position.y, selectedSpawn.transform.position.z);
                GameObject newEnemy = Instantiate(bossAliens, spawnPosition, transform.rotation);
                newEnemy.GetComponent<BossAlien>().direction = (GameObject.Find("earth").transform.position - spawnPosition);
                bossAlienCount++;
            }

            gameStateManagerObj.GetComponent<GameStateManager>().waveStatus = false;
            yield return null;
        }
        yield return null;
    }
}

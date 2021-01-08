using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerMenu : MonoBehaviour
{
    public string direction;
    public GameObject car;
    public List<GameObject> spawnPoints = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CarSpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CarSpawnCoroutine() {
        while(true) {
            int random = Random.Range(1, 9);
            Vector3 spawnPoint = new Vector3(spawnPoints[random-1].transform.position.x, spawnPoints[random-1].transform.position.y, spawnPoints[random-1].transform.position.z);
            GameObject newCar = Instantiate(car);
            newCar.transform.position = spawnPoint;
            if(random == 1 || random == 2) {
                newCar.GetComponent<CarMovementMenu>().xAxis = true;
                newCar.GetComponent<CarMovementMenu>().direction = 1;
                newCar.GetComponent<CarMovementMenu>().face = "right";
            }
            else if(random == 3 || random == 4) {
                newCar.GetComponent<CarMovementMenu>().xAxis = false;
                newCar.GetComponent<CarMovementMenu>().direction = -1;
                newCar.GetComponent<CarMovementMenu>().face = "down";
            }
            else if(random == 5 || random == 6) {
                newCar.GetComponent<CarMovementMenu>().xAxis = true;
                newCar.GetComponent<CarMovementMenu>().direction = -1;
                newCar.GetComponent<CarMovementMenu>().face = "left";
            }
            else {
                newCar.GetComponent<CarMovementMenu>().xAxis = false;
                newCar.GetComponent<CarMovementMenu>().direction = 1;
                newCar.GetComponent<CarMovementMenu>().face = "up";
            }

            int newRandom = Random.Range(1, 9);
            while(newRandom == random) {
                newRandom = Random.Range(1, 9);
            }
            spawnPoint = new Vector3(spawnPoints[newRandom-1].transform.position.x, spawnPoints[newRandom-1].transform.position.y, spawnPoints[newRandom-1].transform.position.z);
            newCar = Instantiate(car);
            newCar.transform.position = spawnPoint;
            if(newRandom == 1 || newRandom == 2) {
                newCar.GetComponent<CarMovementMenu>().xAxis = true;
                newCar.GetComponent<CarMovementMenu>().direction = 1;
                newCar.GetComponent<CarMovementMenu>().face = "right";
            }
            else if(newRandom == 3 || newRandom == 4) {
                newCar.GetComponent<CarMovementMenu>().xAxis = false;
                newCar.GetComponent<CarMovementMenu>().direction = -1;
                newCar.GetComponent<CarMovementMenu>().face = "down";
            }
            else if(newRandom == 5 || newRandom == 6) {
                newCar.GetComponent<CarMovementMenu>().xAxis = true;
                newCar.GetComponent<CarMovementMenu>().direction = -1;
                newCar.GetComponent<CarMovementMenu>().face = "left";
            }
            else {
                newCar.GetComponent<CarMovementMenu>().xAxis = false;
                newCar.GetComponent<CarMovementMenu>().direction = 1;
                newCar.GetComponent<CarMovementMenu>().face = "up";
            }

            yield return new WaitForSeconds(5);
        }
    }
}
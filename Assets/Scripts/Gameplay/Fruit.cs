using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minPos;
    [SerializeField] float maxPos;

    public Timer Timer;

    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    IEnumerator FruitSpawn()
    {
        while(Timer.timerIsRunning == true) //Loop until timer is not running
        {
            var wanted = Random.Range(minPos, maxPos); //Set up a local variable to hold a value between a random range between the minTras and MaxTras values 
            var position = new Vector3(wanted, transform.position.y); //Set a local variable for a position
            GameObject gameObject = Instantiate(fruitPrefab[Random.Range(0, fruitPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 1.75f);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class InteractionManager : MonoBehaviour
{

    public static InteractionManager instance;
    public GameObject[] spawnLocations;
    public GameObject spawnItem;
    public Text test;

    public void SetText(string value)
    {
        instance.test.text = value;
    }

    private void Start()
    {
        instance = this;
        SpawnItem();
    }

    private void SpawnItem()
    {
        int spawnPoint = Random.Range(0, spawnLocations.Length);
        Instantiate(spawnItem, spawnLocations[spawnPoint].transform.position, Quaternion.identity);
    }
}

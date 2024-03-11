using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    //==== FIELDS ====
    List<Zombie> zombies = new List<Zombie>();
    [SerializeField] Zombie zombiePrefab;

    float spawnCounter;
    
    //==== START ====
    void Start()
    {
        spawnCounter = 0;
    }

    //==== UPDATE ====
    void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter > 5 && zombies.Count <= 2)
        {
            SpawnZombie();
            spawnCounter = 0;
            Debug.Log("Zombie Should Spawn Now");
        }
    }

    //==== METHODS ====
    void SpawnZombie()
    {
        Vector3 spawnPos = new Vector3(11, Random.Range(-4.5f, 4.5f), 0);
        Zombie newZombie = Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
        zombies.Add(newZombie);
        Debug.Log("Zombie Spawned");
    }
    public void DestroyZombie(Zombie zombie)
    {
        zombies.Remove(zombie);
        GameObject.Destroy(zombie);
    }
}

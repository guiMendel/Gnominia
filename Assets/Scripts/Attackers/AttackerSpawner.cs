// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
  // Amount of time the player has before plants start spawning
  [SerializeField] float startingSlack = 4f;
  [SerializeField] float minSpawnTime = 3f;
  [SerializeField] float maxSpawnTime = 8f;

  // The enemy to be spawned
  [SerializeField] Attacker[] attackerPrefabs;

  // state
  bool spawning = true;
  int numberOfEnemies = 0;

  // INTERFACE

  public void StopSpawning() { spawning = false; }

  public int GetNumberOfEnemies() { return numberOfEnemies; }

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(SpawnEnemies());
  }

  IEnumerator SpawnEnemies()
  {
    // Wait initial slack
    yield return new WaitForSeconds(startingSlack);

    while (spawning)
    {
      // Wait for next spawn
      yield return new WaitForSeconds(NextSpawnTime());

      Spawn();
    }
  }

  // Returns the amount of seconds to wait until the next spawn
  private float NextSpawnTime()
  {
    return Random.Range(minSpawnTime, maxSpawnTime);
  }

  private void Spawn()
  {
    // Get a lane
    Transform lane = GetRandomLane();

    // Get an attacker's prefab
    Attacker attackerPrefab = GetRandomAttackerPrefab();

    // Create attacker
    Attacker attacker = Instantiate(
      attackerPrefab,
      lane.position,
      Quaternion.identity
    ) as Attacker;

    // Set it's parent
    attacker.transform.parent = lane;

    // Count this enemy
    numberOfEnemies++;

    // Listen for it's death to discount it
    attacker.GetComponent<Health>().OnDeath(() => numberOfEnemies--);
  }

  private Attacker GetRandomAttackerPrefab()
  {
    return attackerPrefabs[Random.Range(0, attackerPrefabs.Length)];
  }

  private Transform GetRandomLane()
  {
    return transform.Find("Lane " + Random.Range(0, 5));
  }
}

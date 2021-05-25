// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
  [SerializeField] float minSpawnTime = 1f;
  [SerializeField] float maxSpawnTime = 5f;

  // The enemy to be spawned
  [SerializeField] Attacker attackerPrefab;

  bool spawning = true;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(SpawnEnemies());
  }

  IEnumerator SpawnEnemies()
  {
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
    Instantiate(
      attackerPrefab,
      GetSpawnPosition(attackerPrefab.GetRowOffset()),
      Quaternion.identity
    );
  }

  private Vector3 GetSpawnPosition(float offset)
  {
    return new Vector3(
      // Use X from spawner
      transform.position.x,
      // Pick a random row, apply offset
      Random.Range(0, 5) + offset,
      transform.position.y
    );
  }
}

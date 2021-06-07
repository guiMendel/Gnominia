using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  [SerializeField] GameObject winScreen;
  [SerializeField] float winScreenDuration = 2f;
  [SerializeField] float startingSlack = 2f;
  
  // state
  GameTimer gameTimer;
  AttackerSpawner attackerSpawner;
  LevelLoader levelLoader;

  private void Start()
  {
    // hide win screen
    winScreen.SetActive(false);
    
    gameTimer = FindObjectOfType<GameTimer>();
    attackerSpawner = FindObjectOfType<AttackerSpawner>();
    levelLoader = FindObjectOfType<LevelLoader>();

    StartCoroutine(StartSpawning());
  }

  IEnumerator StartSpawning() {
    yield return new WaitForSeconds(startingSlack);
    
    StartCoroutine(attackerSpawner.SpawnEnemies());
    StartCoroutine(gameTimer.CountTime());

    // Listen for timeout
    gameTimer.OnTimeout(FinishSpawning);
  }

  private void FinishSpawning()
  {
    // Stop spawning
    attackerSpawner.StopSpawning();

    // prepare to end level
    StartCoroutine(EndOfLevel());
  }

  private IEnumerator EndOfLevel()
  {
    // Wait until enemies are all dead
    yield return new WaitUntil(() => attackerSpawner.GetNumberOfEnemies() == 0);

    // Play win sound
    GetComponent<AudioSource>().Play();

    // Show win screen
    winScreen.SetActive(true);
    yield return new WaitForSeconds(winScreenDuration);

    // Advance to next level
    levelLoader.NextLevel();
  }
}

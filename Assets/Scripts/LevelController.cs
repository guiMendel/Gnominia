using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
  [SerializeField] int healthPoints = 3;
  
  [SerializeField] GameObject winScreen;
  [SerializeField] float winScreenDuration = 2f;
  [SerializeField] GameObject loseScreen;
  [SerializeField] float loseScreenDuration = 2f;

  [SerializeField] float startingSlack = 2f;
  
  // state
  GameTimer gameTimer;
  AttackerSpawner attackerSpawner;
  LevelLoader levelLoader;

  public int GetHealthPoints() { return healthPoints; }

  private void Start()
  {
    // hide win & lose screen
    winScreen.SetActive(false);
    loseScreen.SetActive(false);
    
    gameTimer = FindObjectOfType<GameTimer>();
    attackerSpawner = FindObjectOfType<AttackerSpawner>();
    levelLoader = FindObjectOfType<LevelLoader>();

    // Observe attacker collision with base
    FindObjectOfType<BaseCollider>().OnCollide(AttackerCollision);

    StartCoroutine(StartSpawning());
  }

  private void AttackerCollision(Attacker attacker)
  {
    // Take damage
    healthPoints--;

    // Die
    if (healthPoints <= 0) StartCoroutine(Die());
  }

  IEnumerator Die()
  {
    // Play lose sound
    // GetComponent<AudioSource>().Play();

    // Stop game
    Time.timeScale = 0;

    // Show lose screen
    loseScreen.SetActive(true);
    yield return new WaitForSecondsRealtime(loseScreenDuration);

    // Restart game
    levelLoader.LoadStartMenu();

    // Resume game
    Time.timeScale = 1;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  [Tooltip("Indicates whether to load the start menu after the Loading Time has elapsed")]
  [SerializeField] bool loadStartMenu = false;
  [SerializeField] int loadingTime = 3;

  // Start is called before the first frame update
  void Start()
  {
    if (loadStartMenu) StartCoroutine(LoadStartMenu());
  }

  // Waits 3 seconds and then loads start menu
  IEnumerator LoadStartMenu()
  {
    yield return new WaitForSeconds(loadingTime);

    SceneManager.LoadScene(1);
  }

  public void NextLevel() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); }
  public void Exit() { Application.Quit(); }
}

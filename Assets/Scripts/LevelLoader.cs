using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
  [SerializeField] int loadingTime = 3;
  
  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(LoadStartMenu());
  }

  // Waits 3 seconds and then loads start menu
  IEnumerator LoadStartMenu()
  {
    yield return new WaitForSeconds(loadingTime);

    SceneManager.LoadScene(1);
  }
}

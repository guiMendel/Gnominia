using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
  TextMeshProUGUI textMesh;

  // stored refs
  LevelController levelController;

  private void Start()
  {
    textMesh = GetComponent<TextMeshProUGUI>();
    levelController = FindObjectOfType<LevelController>();
  }

  private void Update()
  {
    textMesh.text = levelController.GetHealthPoints().ToString();
  }
}

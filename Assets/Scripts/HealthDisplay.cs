using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
  TextMeshProUGUI textMesh;

  // stored refs
  BaseCollider baseCollider;

  private void Start()
  {
    textMesh = GetComponent<TextMeshProUGUI>();
    baseCollider = FindObjectOfType<BaseCollider>();
  }

  private void Update()
  {
    textMesh.text = baseCollider.GetHealthPoints().ToString();
  }
}

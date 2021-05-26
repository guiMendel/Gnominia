using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
  [SerializeField] Defender defenderPrefab;
  
  // stored refs
  SpriteRenderer spriteRenderer;
  DefenderSpawner defenderSpawner;
  
  private void Start() {
    spriteRenderer = GetComponent<SpriteRenderer>();
    defenderSpawner = FindObjectOfType<DefenderSpawner>();
  }
  
  private void OnMouseDown()
  {
    // Deselect all other buttons
    var buttons = FindObjectsOfType<DefenderButton>();
    foreach (var button in buttons) button.Deselect();
    
    Select();
  }

  private void Select()
  {
    spriteRenderer.color = Color.white;
    defenderSpawner.SelectDefender(defenderPrefab, this);
  }

  public void Deselect() {
    spriteRenderer.color = Color.gray;
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  [SerializeField] float walkSpeed = 1f;
  
  // When this attacker is spawned, applies this offset to his Y position
  [SerializeField] float rowOffset = 0.2f;

  public float GetRowOffset() { return rowOffset; }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [SerializeField] Projectile projectile;
  [SerializeField] Transform launchPosition;

  // Stored refs
  Transform lane;

  Animator animator;

  private void Start() {
    // Get reference to lane
    Transform spawner = FindObjectOfType<AttackerSpawner>().transform;

    // Get animation parameters
    animator = GetComponent<Animator>();

    for (int i = 0; i < spawner.childCount; i++ ) {
      // We use epsilon here because they might be a little bit different
      if (VeryClose(spawner.GetChild(i).position.y, transform.position.y)) {
        lane = spawner.GetChild(i);
        break;
      }  
    }
  }

  private void Update() {
    if (lane.childCount > 0) animator.SetBool("IsAttacking", true);
    else animator.SetBool("IsAttacking", false);
  }

  private bool VeryClose(float a, float b) {
    return Mathf.Abs(a - b) < Mathf.Epsilon;
  }

  public void Shoot() {
    Projectile instance = Instantiate(projectile, launchPosition.position, launchPosition.rotation) as Projectile;
    instance.transform.parent = transform;
  }
  
}

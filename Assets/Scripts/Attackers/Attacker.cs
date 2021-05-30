using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  [SerializeField] float walkSpeed = 1f;

  // When this attacker is spawned, applies this offset to his Y position
  [SerializeField] float rowOffset = 0.2f;

  GameObject currentTarget;
  float defaultWalkSpeed;

  public float GetRowOffset() { return rowOffset; }

  private void Awake() {
    defaultWalkSpeed = walkSpeed;
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);
  }

  public void Attack(GameObject target) {
    // Start animation
    GetComponent<Animator>().SetBool("IsAttacking", true);

    currentTarget = target;
  }

  public void SetMoveSpeed(float speed)
  {
    walkSpeed = speed;
  }

  public void ResetMoveSpeed()
  {
    walkSpeed = defaultWalkSpeed;
  }
}

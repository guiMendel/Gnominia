using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
  [SerializeField] float walkSpeed = 1f;

  // Damage dealt on each strike
  [SerializeField] int damage = 20;

  GameObject currentTarget;
  float defaultWalkSpeed;

  private void Awake()
  {
    defaultWalkSpeed = walkSpeed;
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);
  }

  public void StartAttacking(GameObject target)
  {
    // Only attack if target has health
    Health targetHealth = target.GetComponent<Health>();

    if (!targetHealth) return;
    currentTarget = target;

    // Start animation
    GetComponent<Animator>().SetBool("IsAttacking", true);

    // Observe target's death
    targetHealth.OnDeath(StopAttacking);
  }

  private void StopAttacking()
  {
    GetComponent<Animator>().SetBool("IsAttacking", false);
  }

  public void StrikeCurrentTarget()
  {
    if (!currentTarget) return;

    Health targetHealth = currentTarget.GetComponent<Health>();

    if (targetHealth) targetHealth.TakeDamage(damage);
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

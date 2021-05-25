using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
  [SerializeField] int health = 100;
  [SerializeField] GameObject deathVFX;
  [SerializeField] float VFXDuration = 4f;


  public void TakeDamage(int damage)
  {
    health -= damage;
    if (health <= 0) Die();
  }

  private void Die()
  {
    // FX
    if (deathVFX) {
      var vfx = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
      Destroy(vfx, VFXDuration);
    }

    Destroy(gameObject);
  }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  [SerializeField] float speed;
  [SerializeField] int damage = 30;
  [SerializeField] GameObject hitVFX;
  [SerializeField] float VFXDuration = 2f;
  [SerializeField] Vector3 VFXRotation;

  // Start is called before the first frame update
  void Start()
  {
    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
  }

  private void Update()
  {
    Debug.Log(
      GetComponent<Rigidbody2D>().velocity
    );
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    Debug.Log(other);

    // Apply hit if other is an attacker
    Attacker attacker = other.GetComponent<Attacker>();
    Health health = other.GetComponent<Health>();

    if (attacker && health) Hit(health);
  }

  private void Hit(Health health)
  {
    // Apply damage
    health.TakeDamage(damage);

    // FX
    if (hitVFX)
    {
      var vfx = Instantiate(hitVFX, transform.position, Quaternion.Euler(VFXRotation)) as GameObject;
      Destroy(vfx, VFXDuration);
    }

    // Destroy self
    Destroy(gameObject);
  }
}

// 2025/11/15 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f; // Maximum health of the object

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    private void OnTriggerEnter(Collider other)
    {
        AttackArea attackArea = other.GetComponent<AttackArea>();
        if (attackArea != null)
        {
            TakeDamage(attackArea.damage);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Took {damage} damage, current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Character has died.");
        // Add death logic here (e.g., play animation, disable character, etc.)
        gameObject.SetActive(false);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // ==================== HANDLE ===================
    // ======================================================

    // ==================== HANDLE STRENGTH ===================
    private float strength = 0f;

    public void SetStrength(float newStrength)
    {
        strength = newStrength;
    }

    public float GetStrength()
    {
        return strength;
    }

    public void IncreaseStrength(float addStrength)
    {
        strength += addStrength;
    }

    public void DecreaseStrength(float lostStrength)

    {
        strength -= lostStrength;
    }
    // ======================================================

    // ==================== HANDLE SPEED ===================
    private float speed = 0f;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void IncreaseSpeed(float addSpeed)
    {
        speed += addSpeed;
    }

    public void DecreaseSpeed(float lostSpeed)
    {
        speed -= lostSpeed;
    }

    // ======================================================

    // ================== HANDLE HEALTH ======================
    private float maxHealth = 0;
    private float currentHealth = 0;

    public void SetUpMaxHealth(float newHealth)
    {
        maxHealth = newHealth;
        currentHealth = maxHealth;
    }

    public void TakeDamge(float lostHealth)
    {
        currentHealth -= lostHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // ======================================================

    // =============== HANDLE STATE ========================
    public enum State
    {
        NonDetech,
        Detech
    }
    public State currentState;
    // ======================================================
}

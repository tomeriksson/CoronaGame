using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Target : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public float health = 50f;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}

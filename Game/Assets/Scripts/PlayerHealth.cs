using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public float HealthMax=100f;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private float damageCooldown = 1f;
    private float damageTime = 0;
    public float attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        Health=100f;
        slider.maxValue=Health;
        slider.value=Health;
        fill.color=gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        Heal(0.05f);
        slider.value=Health;
        fill.color=gradient.Evaluate(slider.normalizedValue);
    }

    void Damage(float amount)
    {
        Health-=amount;
        fill.color=gradient.Evaluate(slider.normalizedValue);
        if(Health<=0){
            Die();
        }
    }
    void Heal(float amount){
        if(Health<HealthMax){
            Health+=amount;
        }
    }
    void Die(){
        Destroy(gameObject);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy" && ShouldDamage())
        {
            Damage(attackDamage);
            damageTime = Time.time + damageCooldown;
        }
    }
        private bool ShouldDamage()
    {
        return Time.time >= damageCooldown;
    }
}

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
    public Animator animator;
    private bool isAlive = true;
    public CharacterController controller;
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
        if (isAlive)
        {
            Heal(0.05f);
        }
            slider.value = Health;
            fill.color = gradient.Evaluate(slider.normalizedValue);
       
        
    }

    public void Damage(float amount)
    {
        Health-=amount;
        fill.color=gradient.Evaluate(slider.normalizedValue);
        if(Health<=0){
            Die();
            isAlive = false;
        }
    }
    void Heal(float amount){
        if(Health<HealthMax){
            Health+=amount;
        }
    }
    void Die(){
        //Destroy(gameObject);
        animator.SetBool("isDead", true);
        controller.enabled = false;
    }

    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.tag == "Enemy" && ShouldDamage())
    //    {
    //        Damage(attackDamage);
    //        damageTime = Time.time + damageCooldown;
    //    }
    //}
        private bool ShouldDamage()
    {
        return Time.time >= damageCooldown;
    }
}

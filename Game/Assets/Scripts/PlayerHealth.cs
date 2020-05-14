using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public float HealthMax=100f;
    // Start is called before the first frame update
    void Start()
    {
        Health=100f;
    }

    // Update is called once per frame
    void Update()
    {
        Heal(0.01f);
    }

    void Damage(float amount)
    {
        Health-=amount;
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
/*    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Enemy"){
            Damage(5f);

      }
    }
    */
    void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.gameObject.tag == "Enemy"){
            Damage(5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float CurrentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        CurrentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, startingHealth);
        if (CurrentHealth > 0)
        {
            //anim.SetTrigger("hurt");
        }
        else
        {
            //player dead
            if (!dead) {
                anim.SetTrigger("die");
                GetComponent<player>().enabled= false;
                dead= true;
            }
          
        }
    }
    public void AddHealth(float _value)
    {
        CurrentHealth=Mathf.Clamp(CurrentHealth+_value, 0, startingHealth);
    }
    /// Update is called once per frame
    
}

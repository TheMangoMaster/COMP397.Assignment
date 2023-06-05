using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    private Animator anim;
    
    public float MaxHealth = 100;
    public float CurHealth = 100;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        CurHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);        
    }

    public void TakeDamage(float amount)
    {
        anim.SetTrigger("Take Damage");
        CurHealth -= amount;
        healthBar.SetHealth(CurHealth);

        if (CurHealth <= 0)
        {
            anim.SetTrigger("Die");
            Death();
        }
    }

    IEnumerator Death()
    {
        //randomSpeed = 0;
        gameObject.tag = "DeadEnemy";
        GameManager._gameManagerInstance.plyrScore += 10;
        GameManager.Money += 25;
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 100;
    public Animator animator;
    public Slider helthbar;
    void Start()
    {
        animator = transform.Find("enemyModel").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        helthbar.value = HP;   
    }
    public void TakeDamage(int damage)
    {
        if(HP > damage)
        {
            HP -= damage;
            animator.SetTrigger("Damage");
        }
        else
        {
            HP = 0;
            animator.SetTrigger("Death");
            GetComponent <Collider>().enabled = false;
            helthbar.gameObject.SetActive(false);
        }
    }
}

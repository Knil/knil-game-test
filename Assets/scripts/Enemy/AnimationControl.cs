using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Transform attackpoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private PlayerAnim player;
    private Animator anim;
    private Skeleton skeleton;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerAnim>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void PlayAnim(int value)
    {
        anim.SetInteger("Transition", value);
    }

    public void Attack()
    {
        if (!skeleton.isDead)
        {
            Collider2D hit = Physics2D.OverlapCircle(attackpoint.position, radius, playerLayer);

            if (hit != null)
            {
                //esqueleto detecta colisão com o player
                player.OnHit();
            }
        }  
    }

    public void OnHit()
    {
        if(skeleton.currentHealth <= 0)
        {
            skeleton.isDead = true;
            anim.SetTrigger("Death");

            Destroy(skeleton.gameObject, 1f);
        }
        else
        {
            anim.SetTrigger("Hit");
            skeleton.currentHealth--;

            skeleton.healthBar.fillAmount = skeleton.currentHealth / skeleton.totalHealth;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackpoint.position, radius);
    }
}

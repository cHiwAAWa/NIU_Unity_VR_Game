// 2025/11/19 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

// 2025/11/15 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component
    private Animator ani;
    public float updateInterval = 0.5f;
    private float updateTimer = 0f;
    private string parMove = "移動數值", parAttack = "觸發攻擊";
    private bool isAttacking;
    [SerializeField, Range(0f, 10f), Header("攻擊冷卻")]
    private float attackCD = 3.5f;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        navMeshAgent.SetDestination(player.position);
    }

    private void Update()
    {
        updateTimer += Time.deltaTime;
        if (updateTimer >= updateInterval)
        {
            updateTimer = 0f;
            UpdateAgentDestination();
        }
    }

    private void UpdateAgentDestination()
    {
        if (player != null && navMeshAgent != null)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                Attack();
            }
            else
            {
                navMeshAgent.SetDestination(player.position);
                ani.SetFloat(parMove, navMeshAgent.velocity.magnitude);
            }
        }
    }

    private void Attack()
    {
        if (isAttacking) return;
        ani.SetTrigger(parAttack);
        ani.SetFloat(parMove, 0);
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackCD);
        isAttacking = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Breather_pteroactyl_Move : MonoBehaviour
{
    public Transform player; 
    public Transform pterodactyl;
    public float speed = 2f; 
    public float attackDistance = 1f; 
    public float detectionDistance = 15f; 
    public float attackInterval = 2f; 
    public float wanderIntervalMin = 5f; 
    public float wanderIntervalMax = 6f; 
    public float wanderDistance = 5f; 

    private Coroutine attackCoroutine; 
    private Coroutine wanderCoroutine; 

    private void OnEnable()
    {
        wanderCoroutine = StartCoroutine(Wander());
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        float distance = Vector3.Distance(pterodactyl.position, player.position);

        if (distance < detectionDistance)
        {
            if (distance > attackDistance)
            {
                Vector3 direction = (player.position - pterodactyl.position).normalized;
                pterodactyl.position += direction * speed * Time.deltaTime;

                if (attackCoroutine == null)
                {
                    attackCoroutine = StartCoroutine(Attack());
                }
            }
            else
            {
                if (attackCoroutine != null)
                {
                    StopCoroutine(attackCoroutine);
                    attackCoroutine = StartCoroutine(Attack());
                }
            }
        }
        else
        {
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            Debug.Log("Attaque !");
            yield return new WaitForSeconds(attackInterval); 
        }
    }


    public Vector3 targetPosition;
    public Vector3 currentPosition;
    private IEnumerator Wander()
    {
        while (true)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-wanderDistance, wanderDistance), Random.Range(-wanderDistance, wanderDistance), Random.Range(-wanderDistance, wanderDistance));
             targetPosition = pterodactyl.position + randomDirection;

            while (Vector3.Distance(pterodactyl.position, targetPosition) > 0.1f)
            {
                pterodactyl.position = Vector3.MoveTowards(pterodactyl.position, targetPosition, speed * Time.deltaTime);
                currentPosition = pterodactyl.position;
                yield return new WaitForEndOfFrame(); 
            }

            float waitTime = Random.Range(wanderIntervalMin, wanderIntervalMax);
            yield return new WaitForSeconds(waitTime); 
            yield return new WaitForEndOfFrame();
        }
    }
}
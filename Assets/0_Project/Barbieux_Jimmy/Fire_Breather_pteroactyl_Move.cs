using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Breather_pteroactyl_Move : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public Transform pterodactyl;
    public float speed = 2f; // Vitesse de déplacement
    public float attackDistance = 1f; // Distance à laquelle l'ennemi attaque
    public float detectionDistance = 150f; // Distance de détection du joueur
    public float attackInterval = 2f; // Intervalle entre les attaques

    private Coroutine attackCoroutine; // Coroutine pour gérer l'attaque

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        // Calculer la distance au joueur
        float distance = Vector3.Distance(pterodactyl.position, player.position);

        // Vérifier si le joueur est dans la portée de détection
        if (distance < detectionDistance)
        {
            // Si l'ennemi est suffisamment loin, il se déplace vers le joueur
            if (distance > attackDistance)
            {
                Vector3 direction = (player.position - pterodactyl.position).normalized;
                pterodactyl.position += direction * speed * Time.deltaTime;

                // Démarrer la coroutine d'attaque si elle n'est pas déjà en cours
                if (attackCoroutine == null)
                {
                    attackCoroutine = StartCoroutine(Attack());
                }
            }
            else
            {
                // Arrêter la coroutine d'attaque si elle est en cours
                if (attackCoroutine != null)
                {
                    StopCoroutine(attackCoroutine);
                    attackCoroutine = StartCoroutine(Attack());
                }
            }
        }
        else
        {
            // Si le joueur s'éloigne, arrêter la coroutine d'attaque
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
            // Logique d'attaque (par exemple, infliger des dégâts, jouer une animation, etc.)
            Debug.Log("Attaque !");
            yield return new WaitForSeconds(attackInterval); // Attendre l'intervalle avant la prochaine attaque
        }
    }
}

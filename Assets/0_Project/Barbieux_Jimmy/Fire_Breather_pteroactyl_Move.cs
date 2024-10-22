using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Breather_pteroactyl_Move : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public float speed = 2f; // Vitesse de déplacement
    public float attackDistance = 1f; // Distance à laquelle l'ennemi attaque
    public float detectionDistance = 150f; // Distance de détection du joueur

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        // Calculer la distance au joueur
        float distance = Vector3.Distance(transform.position, player.position);

        // Vérifier si le joueur est dans la portée de détection
        if (distance < detectionDistance)
        {
            // Si l'ennemi est suffisamment loin, il se déplace vers le joueur
            if (distance > attackDistance)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                // Ici, tu peux ajouter la logique d'attaque
                Attack();
            }
        }
    }

    private void Attack()
    {
        // Logique d'attaque (par exemple, infliger des dégâts, jouer une animation, etc.)
        Debug.Log("Attaque !");
    }
}
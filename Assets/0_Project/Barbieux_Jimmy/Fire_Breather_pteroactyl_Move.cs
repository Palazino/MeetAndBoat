using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Breather_pteroactyl_Move : MonoBehaviour
{
    public Transform player; // R�f�rence au joueur
    public Transform pterodactyl;
    public float speed = 2f; // Vitesse de d�placement
    public float attackDistance = 1f; // Distance � laquelle l'ennemi attaque
    public float detectionDistance = 150f; // Distance de d�tection du joueur
    

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        // Calculer la distance au joueur
        float distance = Vector3.Distance(pterodactyl.position, player.position);

        // V�rifier si le joueur est dans la port�e de d�tection
        if (distance < detectionDistance)
        {
            // Si l'ennemi est suffisamment loin, il se d�place vers le joueur
            if (distance > attackDistance)
            {
                Vector3 direction = (player.position - pterodactyl.position).normalized;
                pterodactyl.position += direction * speed * Time.deltaTime;
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
        // Logique d'attaque (par exemple, infliger des d�g�ts, jouer une animation, etc.)
        Debug.Log("Attaque !");
    }
}
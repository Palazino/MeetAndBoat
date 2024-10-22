using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayerCollider : MonoBehaviour
{
    public Transform[] respawnPoints; // Points de respawn
    public string collisionTag = "RespawnTrigger"; // Tag à vérifier pour le respawn
    private Transform lastRespawnPoint; // Dernier point de respawn utilisé

    // Détecte les collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(collisionTag))
        {
            Debug.Log("Collision détectée avec : " + collision.collider.name);
            Respawn();
        }
    }

    // Respawn l'objet au point de respawn défini
    [ContextMenu("Respawn")]
    public void Respawn()
    {
        Transform newRespawnPoint = GetRandomRespawnPosition();
        if (newRespawnPoint != null)
        {
            Debug.Log("Respawn au point : " + newRespawnPoint.name);
            transform.position = newRespawnPoint.position;

            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                Debug.Log("Vélocité réinitialisée pour : " + gameObject.name);
            }

            lastRespawnPoint = newRespawnPoint; // Met à jour le dernier point de respawn utilisé
        }
        else
        {
            Debug.LogWarning("Aucun point de respawn défini!");
        }
    }

    // Retourne une position de respawn aléatoire qui n'est pas la même que la précédente
    private Transform GetRandomRespawnPosition()
    {
        List<Transform> availableRespawnPoints = new List<Transform>(respawnPoints);

        // Supprime le dernier point de respawn utilisé de la liste des points disponibles
        if (lastRespawnPoint != null)
        {
            availableRespawnPoints.Remove(lastRespawnPoint);
        }

        // Vérifier que des points de respawn sont disponibles
        if (availableRespawnPoints.Count == 0 && respawnPoints.Length > 0)
        {
            // Si tous les points ont été utilisés, réinitialiser la liste pour éviter de se bloquer
            availableRespawnPoints = new List<Transform>(respawnPoints);
            Debug.LogWarning("Tous les points de respawn ont été utilisés, réinitialisation.");
            availableRespawnPoints.Remove(lastRespawnPoint);
        }

        if (availableRespawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, availableRespawnPoints.Count);
            Debug.Log("Point de respawn choisi : " + availableRespawnPoints[randomIndex].name);
            return availableRespawnPoints[randomIndex];
        }
        else
        {
            Debug.LogWarning("Aucun point de respawn disponible!");
            return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayerCollider : MonoBehaviour
{
    public Transform[] respawnPoints; // Points de respawn
    public string collisionTag = "RespawnTrigger"; // Tag � v�rifier pour le respawn
    private Transform lastRespawnPoint; // Dernier point de respawn utilis�

    // D�tecte les collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(collisionTag))
        {
            Debug.Log("Collision d�tect�e avec : " + collision.collider.name);
            Respawn();
        }
    }

    // Respawn l'objet au point de respawn d�fini
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
                Debug.Log("V�locit� r�initialis�e pour : " + gameObject.name);
            }

            lastRespawnPoint = newRespawnPoint; // Met � jour le dernier point de respawn utilis�
        }
        else
        {
            Debug.LogWarning("Aucun point de respawn d�fini!");
        }
    }

    // Retourne une position de respawn al�atoire qui n'est pas la m�me que la pr�c�dente
    private Transform GetRandomRespawnPosition()
    {
        List<Transform> availableRespawnPoints = new List<Transform>(respawnPoints);

        // Supprime le dernier point de respawn utilis� de la liste des points disponibles
        if (lastRespawnPoint != null)
        {
            availableRespawnPoints.Remove(lastRespawnPoint);
        }

        // V�rifier que des points de respawn sont disponibles
        if (availableRespawnPoints.Count == 0 && respawnPoints.Length > 0)
        {
            // Si tous les points ont �t� utilis�s, r�initialiser la liste pour �viter de se bloquer
            availableRespawnPoints = new List<Transform>(respawnPoints);
            Debug.LogWarning("Tous les points de respawn ont �t� utilis�s, r�initialisation.");
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

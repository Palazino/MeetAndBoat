using UnityEngine;

public class RespawnPlayerColliderEnemy : MonoBehaviour
{
   
    public Transform[] respawnPoint;

    public string collisionTag = "RespawnTrigger";

    // When a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with has the specified tag
        if (collision.collider.CompareTag(collisionTag)) Respawn();
        
    }

    // Respawn the object at the defined respawn point
    [ContextMenu("Respawn")]
    public void Respawn()
    {
        // Reset the object's position to the respawn point
        Transform RandomRespawnPoint = GetRandomRespawnPosition();

        //transform.position = respawnPoint[].position;

        Rigidbody rb = GetComponent<Rigidbody>();
        
        if (RandomRespawnPoint != null) transform.position = RandomRespawnPoint.position;
        
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private Transform GetRandomRespawnPosition()
    {

        if (respawnPoint.Length > 0)
        {
            int randomIndex = Random.Range(0, respawnPoint.Length);
            return respawnPoint[randomIndex];
        }
        else
        {
            Debug.LogWarning("Aucun point de respawn défini!");
            return null;
        }
    }
}
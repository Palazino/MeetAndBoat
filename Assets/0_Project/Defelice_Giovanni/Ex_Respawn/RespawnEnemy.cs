using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{

    public GameObject m_perfab;
    public Transform[] m_respawnPoint;
    public Transform m_parent;

    
    [ContextMenu("Create Prefab")]
    public void CreatePrefab()
    {
        if (m_perfab==null)
        {
            return;
        }
        // Reset the object's position to the respawn point
        Transform randomRespawnPoint = GetRandomRespawnPosition();
        GameObject created = GameObject.Instantiate(m_perfab, randomRespawnPoint.position, randomRespawnPoint.rotation, m_parent);

    }

    private Transform GetRandomRespawnPosition()
    {

        if (m_respawnPoint.Length > 0)
        {
            int randomIndex = Random.Range(0, m_respawnPoint.Length);
            return m_respawnPoint[randomIndex];
        }
        else
        {
            Debug.LogWarning("Aucun point de respawn défini!");
            return null;
        }
    }
}
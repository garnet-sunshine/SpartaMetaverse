using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;

    public static string nextSpawnID = "";
    public static bool useSpawnPosition = false;

    [SerializeField] private string defaultSpawnID = "Default";

    private void Start()
    {
        string spawnIDToUse = useSpawnPosition ? nextSpawnID : defaultSpawnID;

        Transform spawnPoint = FindSpawnPointByID(spawnIDToUse);
        if (spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"SpawnPoint with ID '{spawnIDToUse}' not found.");
            Instantiate(playerPrefab, Vector2.zero, Quaternion.identity); // fallback
        }

        useSpawnPosition = false;
        nextSpawnID = "";
    }

    private Transform FindSpawnPointByID(string id)
    {
        foreach (var sp in FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None))
        {
            if (sp.spawnID == id)
                return sp.transform;
        }
        return null;
    }
}



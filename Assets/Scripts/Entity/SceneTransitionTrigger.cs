using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private string targetSpawnID;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool useSpawnPosition = true;




    public void StartTransition()
    {
        if (useSpawnPosition && spawnPoint != null)
        {
            PlayerSpawnManager.useSpawnPosition = true;
            PlayerSpawnManager.nextSpawnID = targetSpawnID;
            SceneManager.LoadScene(targetSceneName);
        }

        SceneManager.LoadScene(targetSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSpawnManager.useSpawnPosition = true;
            PlayerSpawnManager.nextSpawnID = targetSpawnID;
            SceneManager.LoadScene(targetSceneName);
        }
    }
}

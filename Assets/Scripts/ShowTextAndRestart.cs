using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnEnable : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(RestartAfterDelay());
    }

    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSecondsRealtime(3f); // Ignores Time.timeScale
        Time.timeScale = 1f; // Reset time scale before reloading
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

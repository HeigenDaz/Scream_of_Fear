using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject loadingscreen;
    public string sceneName;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void playGame()
    {
        loadingscreen.SetActive(true);
        StartCoroutine(LoadLevel()); // Menggunakan coroutine (opsional)
    }

    IEnumerator LoadLevel() // Coroutine untuk loading scene (opsional)
    {
        yield return new WaitForSeconds(10f); // Jeda waktu simulasi loading
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        #if UNITY_EDITOR
            Debug.Log("This will quit the game, only works in actual build, not in Unity editor.");
        #else
            Application.Quit();
        #endif
    }
}


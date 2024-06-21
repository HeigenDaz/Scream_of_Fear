using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneTrigger : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pickupLetter.stonescollected >= 8) // Periksa apakah 8 batu sudah terkumpul
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.Log("Collect all 8 stones to finish the game!");
            }
        }
    }
}

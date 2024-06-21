using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupLetter : MonoBehaviour
{
    public GameObject collectTextObj, intText, escapeTrigger, escapeText; 
    public AudioSource pickupSound, ambianceLayer1, ambianceLayer2, ambianceLayer3, ambianceLayer4, ambianceLayer5, ambianceLayer6, ambianceLayer7, ambianceLayer8;
    public bool interactable;
    public static int stonescollected;
    public Text collectText;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera detected in trigger.");
            intText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("MainCamera exited trigger.");
            intText.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if (interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E key pressed while interactable.");

                stonescollected += 1;
                collectText.text = stonescollected + "/8 stones";
                collectTextObj.SetActive(true);
                pickupSound.Play();
                PlayAmbianceLayer(stonescollected);

                intText.SetActive(false);
                this.gameObject.SetActive(false);
                interactable = false;

                Debug.Log("Item picked up. stones collected: " + stonescollected);
            }
        }
    }

    void PlayAmbianceLayer(int layer)
    {
        switch (layer)
        {
            case 1:
                ambianceLayer1.Play();
                break;
            case 2:
                ambianceLayer2.Play();
                break;
            case 3:
                ambianceLayer3.Play();
                break;
            case 4:
                ambianceLayer4.Play();
                break;
            case 5:
                ambianceLayer5.Play();
                break;
            case 6:
                ambianceLayer6.Play();
                break;
            case 7:
                ambianceLayer7.Play();
                break;
            case 8:
                ambianceLayer8.Play();
                escapeText.SetActive(true);
                escapeTrigger.SetActive(true);
                break;
        }
        intText.SetActive(false);
        this.gameObject.SetActive(false);
        interactable = false;
    }
}

using UnityEngine;

public class SoundTrackingMonster : MonoBehaviour
{
    public float hearingRange = 10f;
    public float rotationSpeed = 5f;
    public LayerMask soundSourceLayer;

    void Update()
    {
        // Raycast for sound sources
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, hearingRange, soundSourceLayer))
        {
            // Calculate direction to sound source
            Vector3 targetDirection = hit.point - transform.position;

            // Rotate towards sound source
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move forward
            transform.position += transform.forward * Time.deltaTime;
        }
    }
}

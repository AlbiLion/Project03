using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float rotationSpeed = 125.0f;
    public AudioSource pickUpSound;

    private void Update()
    {
        // Rotate the coin slowly in place
        transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            // If there is a pick-up sound, instantiate the sound then destroy it when finished
            if (pickUpSound != null)
            {
                AudioSource newPickUpSound = Instantiate(pickUpSound, transform.position, Quaternion.identity);
                Destroy(newPickUpSound.gameObject, newPickUpSound.clip.length);
            }

            //Calls HasPoints script and CoinCollected Method, Point allocation is handled there
            HasPoints hasPoints = FindObjectOfType<HasPoints>();
            hasPoints.coinCollected();
        }
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float rotationSpeed = 125.0f;
    public GameObject pickupSound;
    public ParticleSystem coinBurst;

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
            coinBurst.Play();
            if (pickupSound != null)
            {
                Instantiate(pickupSound, other.transform.position, Quaternion.identity);
            }

            //Calls HasPoints script and CoinCollected Method, Point allocation is handled there
            HasPoints hasPoints = FindObjectOfType<HasPoints>();
            hasPoints.coinCollected();
        }
    }
}

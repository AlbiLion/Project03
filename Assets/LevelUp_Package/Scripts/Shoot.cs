using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;
    [SerializeField] AudioSource shootSound;
    [SerializeField] GameObject spawnPoint;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }
    private void Shooting()
    {
        // If there is a shoot sound, instantiate the sound then destroy it when finished
        if (shootSound != null)
        {
            AudioSource newShootSound = Instantiate(shootSound, transform.position, Quaternion.identity);
            Destroy(newShootSound.gameObject, newShootSound.clip.length);
        }
        // If there is a bullet prefab, instantiate the bullet and move it forward according to bulletSpeed
        if (bulletPrefab != null)
        {
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = spawnPoint.transform.forward * bulletSpeed;

            Destroy(newBullet, bulletLifetime);
        }
    }
}

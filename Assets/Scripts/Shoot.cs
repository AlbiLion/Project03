using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject BulletSpawnPoint;
    public float bulletSpeed;
    public float bulletLifetime;
    private LayerMask _layersToShoot = -1;
    public ParticleSystem _impactParticle;
    public AudioSource _shootSound;
    public GameObject spawnPoint;
    public AudioClip laserFireSFX;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shooting();
        }
    }
    private void Shooting()
    {
        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Instantiate(laserFireSFX, newBullet.transform.position, newBullet.transform.rotation);
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;

        Destroy(newBullet, bulletLifetime);
    }
}

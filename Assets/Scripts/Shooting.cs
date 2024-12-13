using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
   [Header("Bullet Variables")]
   public float bulletSpeed;
    public float fireRate, bulletDamage;

   [Header("Initial Setup")]
   public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private float timer;

    public AudioSource source;
    public AudioClip clip;

    private void Update() {

        if(timer > 0)
            timer -= Time.deltaTime;
        

        if(Input.GetButton("Fire1") && timer <= 0)
            Shoot();
        

        if(this.transform.localRotation.x < 0)
            this.transform.Rotate(1, 0, 0);
       
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<BulletController>().damage = bulletDamage;

        this.transform.Rotate(-35, 0, 0);

        // Play shooting sound
        source.PlayOneShot(clip);
        timer = fireRate;
    }
}

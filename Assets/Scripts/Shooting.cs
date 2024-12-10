using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Shooting : MonoBehaviour
{
   [Header("Bullet Variables")]
   public float bulletSpeed;
    public float fireRate, bulletDamage;
   public bool isAuto;

   [Header("Initial Setup")]
   public Transform bulletSpawnTransform;
    public GameObject bulletPrefab;

    private float timer;

    private void Update() {
        if(timer > 0 ) {
            timer -= Time.deltaTime;
        }

        if (isAuto){
            if(Input.GetButton("Fire1") && timer <=0) {
                fireRate = 0.1f;
                Shoot();
            }
        }
        else {
            if(Input.GetButtonDown("Fire1") && timer <=0 ) {
                fireRate = 0.5f;
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAuto = !isAuto;
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("WorldObjectHolder").transform);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnTransform.forward * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<BulletController>().damage = bulletDamage;

        timer = fireRate;
    }
}

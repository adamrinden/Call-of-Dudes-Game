using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float damage;
    public float lifeTime =3;

    public GameObject spark;
    public GameObject player;

    private void Update() {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0) 
            Destroy(gameObject);
        
    }

    private void OnTriggerEnter(Collider other){
        
        if(other.tag == "Player")
           return;
        if(other.GetComponent<Target>() != null)
            other.GetComponent<Target>().health -= damage;
            

        Vector3 collision_pos = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        Instantiate(spark, collision_pos, Quaternion.LookRotation(player.transform.position));

        Destroy(gameObject);
    }
}

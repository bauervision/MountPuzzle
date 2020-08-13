using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
    public float bulletSpeed = 60;
    public GameObject bullet;


    void Fire()
    {
        Rigidbody bulletClone = Instantiate(bullet.GetComponent<Rigidbody>(), transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
            Fire();
    }
}
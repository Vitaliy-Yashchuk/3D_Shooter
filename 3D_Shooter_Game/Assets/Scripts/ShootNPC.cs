using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootNPC : MonoBehaviour
{
    public Camera cam;
    public float range = 100f, force=200f;
    public int damage = 25;
    public GameObject muzzleFlashPrefab;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<TakeDamageNPC>().DamageTaken(damage);
            }
            else
            {
                PlayEffect(hit.point);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(Vector3.up*force);
            }
            Debug.Log(hit.transform.gameObject.name);
        }
    }
    void PlayEffect(Vector3 position)
    {
        
        GameObject effect = Instantiate(muzzleFlashPrefab, position, Quaternion.identity);
        Destroy(effect, 0.31f); 
    }
}

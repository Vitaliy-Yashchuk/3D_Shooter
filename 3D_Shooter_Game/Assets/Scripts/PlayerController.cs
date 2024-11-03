using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private PhotonView _photonView;
    public float speed=5f, rotateSpeed=5f;
    public int _attackDamage = 25;
    private int _health=100;

    private void Awake()
    {
        _photonView=GetComponent<PhotonView>();
        _rb = GetComponent<Rigidbody>();

        if (!_photonView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }

    private void FixedUpdate()
    {
        
        if(!_photonView.IsMine)
            return;
        MovePlayer();
    }

    private void Update()
    {
        if(!_photonView.IsMine)
            return;
        RotatePlayer();

        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = transform.GetChild(0)?.GetComponent<Camera>();
            if (cam == null)
            {
                Debug.LogError("Camera не знайдена!");
                return;
            }

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    PlayerController enemyController = hit.collider.GetComponent<PlayerController>();
                    if (enemyController != null)
                    {
                        enemyController.Damage(_attackDamage);
                    }
                    else
                    {
                        Debug.LogError("Об'єкт, на який ви стріляєте, не є гравцем!");
                    }
                }
            }
        }
    }

    private void Damage(int damage)
    {
        _photonView.RPC("PunDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void PunDamage(int damage)
    {
        if (!_photonView.IsMine)
            return;
        _health -= damage;
        if (_health <= 0)
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }

    private void RotatePlayer()
    {
        
        transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal"));
    }

    private void MovePlayer()
    {
        _rb.MovePosition(transform.position + (transform.forward * Time.fixedDeltaTime * speed* Input.GetAxis("Vertical")));
    }
}

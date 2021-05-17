using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public BulletData _bulletData;
    private void Start()
    {
        Destroy(gameObject, 5);
    }

    
  public void Shooting(Vector3 direction)
    {
        direction.Normalize();
       transform.forward = direction;
        GetComponent<Rigidbody>().velocity = direction * _bulletData.Speed;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
             Destroy(gameObject);
        } 
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{  
    private void Start()
    {
        Destroy(gameObject, 5);
    }   

    public void Shooting(Vector3 direction)
    {
        //  direction.Normalize();
        //  transform.forward = direction;      
        //  GetComponent<Rigidbody>().velocity = direction * _bulletData.Speed;
    }
    private void FixedUpdate()
    {
        var nearestEnemy = EnemyTransform.FindClosestEnemy(transform.position);
        if (nearestEnemy != null)
        {            
            transform.LookAt(nearestEnemy.transform);          
            transform.position = Vector3.MoveTowards(transform.position, nearestEnemy.transform.position + new Vector3(0, 1f, 0), 30 * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
   
   
   
   
   
   
}

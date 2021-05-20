using UnityEngine;

public class EnemyMovement : MonoBehaviour
{  
    //Simple Enemy Movement Forward until they see the Player
    private Rigidbody Rb;
    public SpawnManagerScriptableObject _enemydata;
    public int _speed;   
   
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        _speed = _enemydata.Speed;
    }
    private void Update()
    {
        if (CamController.isCameraAnimating)
        {   
            //we dont want the enemies move until The Countdown and Camera animation is completed
            return;
        }
        Vector3 tempVect = new Vector3(0, 0, -1);
        tempVect = tempVect.normalized * _speed * Time.deltaTime;
        Vector3 moveVector = transform.position;
        moveVector.x = Mathf.Clamp(moveVector.x, -6, 1.85f);
        Rb.MovePosition(moveVector + tempVect);
        if (gameObject.transform.position.y>=2)
        {
            Destroy(gameObject);
        }
    }
}

   


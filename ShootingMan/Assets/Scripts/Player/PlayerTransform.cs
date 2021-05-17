using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour

{
    public readonly static HashSet<PlayerTransform> Pool = new HashSet<PlayerTransform>(); //You're going to want to add your ally to your enemy's list too. So that both can find each other.
    private void OnEnable()
    {
        PlayerTransform.Pool.Add(this); //Keep it consistent, obviously again.  :)
    }
    private void OnDisable()
    {
        PlayerTransform.Pool.Remove(this);
    }
    public static PlayerTransform FindClosestAlly(Vector3 pos) //This public static will be read by your enemy script, it makes sense to name it this, to find the closest ally
    {
        PlayerTransform result = null;
        float dist = float.PositiveInfinity;
        var e = PlayerTransform.Pool.GetEnumerator();
        while (e.MoveNext())
        {
            float d = (e.Current.transform.position - pos).sqrMagnitude;
            if (d < dist)
            {
                result = e.Current;
                dist = d;
            }
        }
        return result;
    }
    void FixedUpdate() //This is the key part of the code, do not change anything here to "Ally" (in this case, you could have named it something else than ally). If this script is attached to your ally, this part of the code is responsible for finding the closest enemy. We can leave this part alone
    {
        var nearestEnemy = EnemyTransform.FindClosestEnemy(transform.position); 
        if (nearestEnemy!=null)
        {
       //  Debug.Log(nearestEnemy.name);            
        transform.LookAt(nearestEnemy.transform);
           
        }                                                             
      
    }
}


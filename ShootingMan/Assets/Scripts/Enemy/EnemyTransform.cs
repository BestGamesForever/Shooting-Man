using UnityEngine;
using System.Collections.Generic;

public class EnemyTransform : MonoBehaviour
{
    //we want to put all enemies in a pool and know the transforms of'em induvidually
    public readonly static HashSet<EnemyTransform> Pool = new HashSet<EnemyTransform>();

    private void OnEnable()
    {
        Pool.Add(this);
    }

    private void OnDisable()
    {
      Pool.Remove(this);
    }

    public static EnemyTransform FindClosestEnemy(Vector3 pos)
    {
        EnemyTransform result = null;
        float dist = float.PositiveInfinity;
        var e = EnemyTransform.Pool.GetEnumerator();
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
   
}

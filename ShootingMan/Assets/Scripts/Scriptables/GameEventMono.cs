using System;
using UnityEngine;

public class GameEventMono : MonoBehaviour
{
    public event Action onBullettheEnemy;
    public void BulletHitEnemy()
    {
        if (onBullettheEnemy != null)
        {
            onBullettheEnemy();
        }
    }
}

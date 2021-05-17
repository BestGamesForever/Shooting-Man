using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public static int ShootingCounter;
    [SerializeField] NewSave _newsave;
    public BulletData _bulletData;
    [SerializeField] Bullet _bulletPrefab;
    public Transform SpawnPoint;
    float TimeInterval;
    [SerializeField] private int damage = 1;
    private float Starttime;
    private float AnimationDuration = 2f;
  
    [SerializeField]
    private ParticleSystem Muzzle;

    private void Start()
    {       
        Starttime = Time.time;
        HealthManager.killedEnemy = 0;
    }
    void LateUpdate()
    {
        if (Time.time - Starttime < AnimationDuration)
        {
            return;
        }
        if (HealthManager.killedEnemy == GetComponent<Spawner>().TotalEnemy)
        {
            
            var statusUpdate = GetComponent<UIManager>();
            statusUpdate.UpdateGameStatuswin();
          
            return;
        }
        // ones per in seconds
        TimeInterval += Time.deltaTime;
        if (TimeInterval >= .3f)
        {
            TimeInterval = 0;
            SpawnBullet(_bulletPrefab);           
        }
    }
   void SpawnBullet(Bullet bullet)
    {       
        Debug.DrawRay(SpawnPoint.position, SpawnPoint.forward * 100, Color.red, 2f);
        Ray ray = new Ray(SpawnPoint.position, SpawnPoint.forward);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo, 20,9))
        {
            ShootingCounter++;
            var ShootingCounterUpdate = GetComponent<UIManager>();
            ShootingCounterUpdate.UpdateShooterCount();
            _newsave.Save();
            SpawnPoint.position = new Vector3(SpawnPoint.position.x, 1, SpawnPoint.position.z);
            var _bullet = Instantiate(_bulletPrefab, SpawnPoint.position,Quaternion.identity);            
            _bullet.Shooting(transform.forward);

           
            Muzzle.Play();
            SoundManager.instance.Shoot();
            var health=hitinfo.collider.GetComponent<HealthManager>();
            if (health!=null)
            {
                health.DamageTaken(damage);
            }
           
        }
    }
}

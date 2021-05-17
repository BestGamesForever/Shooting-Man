using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip ShootingFX;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null) Destroy(gameObject);       
    }
    private void Start()
    {
        //_audioSource.GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        _audioSource.PlayOneShot(ShootingFX);
    }
}

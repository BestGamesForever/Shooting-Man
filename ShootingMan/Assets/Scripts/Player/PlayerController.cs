using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static CharacterController controller;
    private const float Turn_speed = 0.7f;

    public PlayerSlower[] playerSlower;
    public float PlayerSpeed;
    private bool isDead = false;
    private float Starttime;
    Vector3 direction;
    Vector3 MoveVector;

    Vector2 startTouchPosition, endTouchPosition;
    private bool moveRight, moveLeft;
    private float AnimationDuration = 2.5f;

    private void Awake()
    {
        for (int i = 0; i < playerSlower.Length; i++)
        {
            playerSlower[i].OnHitWall += PlayerSlower_OnHitWall;
        }
        
    }

    private void PlayerSlower_OnHitWall(float obj)
    {
        obj = .5f;
        PlayerSpeed -= obj;
        StartCoroutine(SpeedBack());
        Debug.Log("PlayerSpeed" + PlayerSpeed);
    }
    IEnumerator SpeedBack()
    {
        yield return new WaitForSeconds(2);
        PlayerSpeed = 2;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Starttime = Time.time;
        FinishingGame.isfinishGame = false;
    }

    void Update()
    {
        if (FinishingGame.isfinishGame)
            return;
        if (Time.time - Starttime < AnimationDuration)
        {
            controller.Move(Vector3.forward * -PlayerSpeed * Time.deltaTime);
            return;
        }
       
        //Touch The Left Side Of Screen
        if (TouchScreen.isLeft)
        {
            direction = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
            direction.x = Mathf.Clamp(direction.x, -7f, 2.5f);
            TouchScreen.isLeft = false;
        }
        //Touch The Right Side Of Screen
        if (TouchScreen.isRight)
        {
            direction = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
            direction.x = Mathf.Clamp(direction.x, -7f, 2.5f);
            TouchScreen.isRight = false;
        }


        MoveVector = Vector3.zero;
        MoveVector.x = (direction - transform.position).x * PlayerSpeed * 1.5f;
        MoveVector.y = 0;
        MoveVector.z = -PlayerSpeed;
        controller.Move(MoveVector * Time.deltaTime);       
    }  //finish update     
}



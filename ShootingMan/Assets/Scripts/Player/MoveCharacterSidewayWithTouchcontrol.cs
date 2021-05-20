using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacterSidewayWithTouchcontrol : MonoBehaviour
{
    public PlayerSlower[] playerSlower;
    public float PlayerSpeed;
    [Range(.5f,1.5f)]
    [SerializeField] float SlowAnount;
    private Touch touch;
    Rigidbody Rb;
    Vector3 Pos;
    [SerializeField] float moveSideDelta;
    private void Awake()
    {
        for (int i = 0; i < playerSlower.Length; i++)
        {
            playerSlower[i].OnHitWall += PlayerSlower_OnHitWall;
        }
    }
    private void PlayerSlower_OnHitWall(float obj)
    {
        obj = SlowAnount;
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
        FinishingGame.isfinishGame = false;
        Rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Vector3 tempVector = Vector3.back;
        tempVector = tempVector.normalized * PlayerSpeed * Time.fixedDeltaTime;
        Rb.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z + tempVector.z));
    }
    void Update()
    {
        if (FinishingGame.isfinishGame)
            return; //For Stopping GameActivities to load Win or Lose Panel

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    Pos = transform.position;
                    Pos.x = Mathf.Clamp(Pos.x, -6.5f, 2.1f);
                    transform.position = new Vector3(Pos.x - touch.deltaPosition.x * moveSideDelta, Pos.y, Pos.z);

                }
            }

        }
    //finish update  

    //  private void OnControllerColliderHit(ControllerColliderHit hit)
    //  {
    //      if (hit.point.z > transform.position.z + controller.radius && hit.normal.y < 0.2 && (hit.gameObject.tag == "Zombie"))
    //      {            
    //          Handheld.Vibrate();
    //      }
    //  }
}


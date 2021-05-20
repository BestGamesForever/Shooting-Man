using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {
    public static bool isCameraAnimating;
    Transform Player;
    Vector3 offset;
    private Vector3 Movevector;
    private float Transition = 0.0f;
    private float AnimationDuration = 2f;
    private Vector3 AnimationOffset = new Vector3(5, 8, 0);

    //Rotation
    private Vector3 currentAngle;
    private Vector3 targetAngle;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = (transform.position - Player.position);
        currentAngle = transform.eulerAngles;
        targetAngle = new Vector3(22f, 115f, 29);
    }
	
	
	void Update ()
    {
        Movevector = Player.position + offset;       
        Movevector.x = -18;
        Movevector.y = 8;

        if (Transition > 1.5f)
        {
            transform.position = Movevector;
            currentAngle = new Vector3(
          Mathf.LerpAngle(currentAngle.x, targetAngle.x, Transition),
          Mathf.LerpAngle(currentAngle.y, targetAngle.y, Transition));
            transform.eulerAngles = currentAngle;
            isCameraAnimating = false;
        }
        else
        {
            isCameraAnimating = true;
            transform.position = Vector3.Lerp(Movevector+AnimationOffset, Movevector, Transition);
            Transition += Time.deltaTime * 1 / AnimationDuration;
            transform.LookAt (Player.position + Vector3.right);
        }      
	}
}

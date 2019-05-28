using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : ControlerBase
{
    public enum Behavor { Pasive, Defensive, Offecive };

    [Header("AI")]
    public Behavor behavor = Behavor.Pasive;
    public float sightRange = 15f;
    public float aim = 0.4f;

    [Header("Movments")]

    public float movementSpeed = 2.5f;
    public float turnSpeed = 40f;
    public float speedChangeTime = 1f;
    public float turnChangeTime = 0.2f;
    public float turnAnimationChangeTime = .15f;
    public float turnMinimumPart = 0.2f;
    public float turnAnimMultiplier = 30f;
    public Transform hull;

    private float forwardAcceleration = 0f;

    private float rotationAcceleration = 0f;

    private float turnAnim = 0f;
    private float rotationAnimationVelocity = 0f;

    private float rot = 0f;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void AIUpdate()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < sightRange)
        {
            if (behavor == Behavor.Pasive)
            {
                if (transform.position.x - player.transform.position.x > 0)
                {
                    InputHorizontal = Mathf.Min(Mathf.Max((Vector2.Angle(transform.position, player.transform.position) + (transform.rotation.eulerAngles.z-360)) / 10f, -1), 1);
                }
                else
                {
                    InputHorizontal = -Mathf.Min(Mathf.Max((Vector2.Angle(transform.position, player.transform.position) - transform.rotation.eulerAngles.z) / 10f, -1), 1);
                }
                InputVertical = 1f;
            }
            else if (behavor == Behavor.Defensive)
            {
                if (transform.position.x - player.transform.position.x > 0)
                {
                    InputHorizontal = Mathf.Min(Mathf.Max((Vector2.Angle(transform.position, player.transform.position) +90 + (transform.rotation.eulerAngles.z - 360)) / 10f, -1), 1);
                }
                else
                {
                    InputHorizontal = -Mathf.Min(Mathf.Max((Vector2.Angle(transform.position, player.transform.position) +90 - transform.rotation.eulerAngles.z) / 10f, -1), 1);
                }
                InputVertical = 1f;
            }
            else if (behavor == Behavor.Offecive)
            {
                if (transform.position.x - player.transform.position.x > 0)
                {
                    InputHorizontal = Mathf.Min(Mathf.Max((Vector2.Angle(transform.position, player.transform.position) - 90 + (transform.rotation.eulerAngles.z - 360)) / 10f, -1), 1);
                }
                else
                {
                    InputHorizontal = -Mathf.Min(Mathf.Max((Vector2.Angle(transform.position, player.transform.position) + 90 - transform.rotation.eulerAngles.z) / 10f, -1), 1);
                }

                InputVertical = Mathf.Abs(InputHorizontal);
                if (InputVertical < 1)
                    InputVertical = 0;
            }
            
        }
        else
        {
            InputVertical = 0.8f;
            InputHorizontal = 0;
        }
    }

    public float InputVertical = 0.8f;
    public float InputHorizontal = 0;

    void Update()
    {
        AIUpdate();


        {
            rotationVelocity = Mathf.SmoothDamp(rotationVelocity, InputHorizontal, ref rotationAcceleration, turnChangeTime);
            float factor = turnMinimumPart + (forwardVelocity / movementSpeed) * (1f - turnMinimumPart);
            rot -= rotationVelocity * Time.deltaTime * turnSpeed * factor;

            turnAnim = Mathf.SmoothDamp(turnAnim, turnAnimMultiplier * (forwardVelocity / movementSpeed) * rotationVelocity, ref rotationAnimationVelocity, turnAnimationChangeTime);

            transform.localEulerAngles = new Vector3(0f, 0f, rot);
            hull.localEulerAngles = new Vector3(0f, 0f, -turnAnim);
        }
        forwardVelocity = Mathf.SmoothDamp(forwardVelocity, InputVertical < 0f ? movementSpeed * InputVertical * 0.02f : movementSpeed * InputVertical, ref forwardAcceleration, speedChangeTime);
        transform.localPosition += transform.up * forwardVelocity * Time.deltaTime;

    }
}

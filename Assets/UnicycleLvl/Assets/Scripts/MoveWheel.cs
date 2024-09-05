using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using Unity.Mathematics;

using UnityEngine;
public class MoveWheel : MonoBehaviour, IColliderTrigger
{
    [SerializeField] private float motorForce;
    [SerializeField] private Rigidbody2D seat;
    [SerializeField] private GameObject stick;
    [SerializeField] private Sprite fallingClown;
    [SerializeField] public int stickSize;
    [SerializeField] public bool isDead = false;
    [SerializeField] public bool hasSucceded;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private AudioSource soundPlayer;
    [SerializeField] private AudioSource bikeSound;
    [SerializeField] private AudioClip landingSound;
    [SerializeField] private AudioClip jumpingSound;
    [SerializeField] private AudioClip fallingSound;
    [SerializeField] private AudioClip booSound;
    [SerializeField] private AudioClip congratSound;
    private Animator animate;
    private float jumpCountdown;
    private float oldSpeed;
    private float currentSpeed;
    private float canMove;

    private Rigidbody2D wheel;
    private WheelJoint2D wheelJoint;

    private int collisionCount = 0;

    // Start is called before the first frame update

    IEnumerator changeSize(float size)
    {
        yield return new WaitForSeconds(0.1f);
        stick.transform.localScale = new Vector3(stick.transform.localScale.x, size, stick.transform.localScale.z);
    }
    void Start()
    {
        wheelJoint = GetComponentInParent<WheelJoint2D>();
        animate = seat.GetComponent<Animator>();
        wheelJoint.useMotor = true;
        wheel = GetComponentInParent<Rigidbody2D>();
        StartCoroutine(changeSize(stickSize));
    }

    // Update is called once per frame
    void Update()
    {
        canMove += Time.deltaTime;
        if (wheelJoint && canMove > 0.3)
        {
            oldSpeed = currentSpeed;
            currentSpeed = wheel.velocity.y;
            // Setting the motor speed based of seat tilt
            JointMotor2D motor = wheelJoint.motor;
            animate.speed = math.abs(Input.GetAxis("Horizontal"));
            motor.motorSpeed = Input.GetAxis("Horizontal") * 200 * motorForce;
            if (bikeSound.isPlaying == false && math.abs(Input.GetAxis("Horizontal")) > 0)
            {
                bikeSound.Play();
                bikeSound.pitch = 0.6f + math.abs(Input.GetAxis("Horizontal")) / 2;
            }
            else if (math.abs(Input.GetAxis("Horizontal")) == 0)
            {
                bikeSound.Stop();
            }
            wheelJoint.motor = motor;

            jumpCountdown += Time.deltaTime;

            // Very basic jump system
            // seat.AddRelativeForce(new Vector2(Input.GetAxisRaw("Horizontal") * motorForce, 0));
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                if (collisionCount > 0 && jumpCountdown > jumpCooldown)
                {
                    jumpCountdown = 0;
                    soundPlayer.PlayOneShot(jumpingSound, 0.1f);
                    seat.AddRelativeForce(new Vector2(0, 2000));
                    seat.AddForce(new Vector2(0, 250));
                }
            }

            // Very barebones way to check if the wheel should break
            if (seat.transform.position.y < -25)
            {
                StartCoroutine(DeclareDead());
            }
            if (globalScript.lvlCoin == 12 && hasSucceded == false)
            {
                Debug.Log("???");
                hasSucceded = true;
                
                soundPlayer.PlayOneShot(congratSound, 0.1f);
                globalScript.addNumbLvl();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(DeclareDead());
            }
        }
        else
        {
            if (animate)
            animate.speed = 0;
        }
    }

    IEnumerator DeclareDead()
    {
        Destroy(wheelJoint);
        Destroy(seat.GetComponent<FixedJoint2D>());
        Destroy(seat.GetComponent<Animator>());
        seat.velocity = new Vector2(0,10);
        seat.angularVelocity = 500;
        seat.GetComponent<SpriteRenderer>().sprite = fallingClown;
        // Debug.Log("Wheel broke");
        isDead = true;
        Destroy(seat.GetComponent<BoxCollider2D>());
        Destroy(GetComponent<BoxCollider2D>());
        Destroy(stick.GetComponent<BoxCollider2D>());
        soundPlayer.PlayOneShot(fallingSound, 0.2f);
        yield return new WaitForSeconds(5);
        soundPlayer.PlayOneShot(booSound, 0.2f);
        if (isDead)
        {
            //Debug.Log("Dead");
            Destroy(transform.parent.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // Debug.Log("Grounded");
            collisionCount++;
            if (oldSpeed < -5)
            {
                soundPlayer.PlayOneShot(landingSound, (-oldSpeed) / 70);
            }

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (wheelJoint)
        {
            if (collision.gameObject.tag == "Ground")
            {
                //Debug.Log("Not Grounded");
                StartCoroutine(DelayCollsion());
            }
        }
    }

    IEnumerator DelayCollsion()
    {

        {
            yield return new WaitForSeconds(0.2f);
            collisionCount--;
        }

    }

    public void OnTrigger()
    {
        StartCoroutine(DeclareDead());
    }
}

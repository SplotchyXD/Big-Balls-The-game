using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class BallControl : MonoBehaviour
{
    //lisättiin kaksi kohdetta jotka pitää projektissa lisätä(yleisesti jokopelaaja/kamera ja lattia/spawnkohta)
    public Transform Target1;
    public Transform Target2;

    //lisättiin minimi ja max valuutat kameran zoomaukselle
    public float minOrhtographicDistance = 5f;
    public float sensetivity = 1f;
    public float maxOrthographicSize = 10f;

    //lisättiin kamera jota koodi kutsuu ja myös minimi valuutta
    public Camera thisCam;
    float min = 5f;

    //pelaaajan kontrollit
    public GameObject Player;
    public float power = 25f;
    public float maxDrag = 5f;
    float maxVelocity = 100;
    public GameObject DeathAnimation;
    public Rigidbody2D rb;
    public LineRenderer lr;
    Vector3 dragStartpos;
    Touch touch;
    public AudioClip DeathSound;
    public AudioClip Bounce;
    public ScoreManager Score;


    //asetetaan kameran minimi valuutta pelin sisällä
    private void Start()
    {
        if(Player.activeInHierarchy == false)
        {
            Player.SetActive(true);
        }
        min = thisCam.orthographicSize;
        Time.timeScale = 1f;
    }

    //update:ssa on skripti laskemaan minimi ja max valuutat ja katsotaan myös mihin on asetettu target kohdat
    //update:ssa on myös pelaajan kontrollit
    private void Update()
    {
        thisCam.orthographicSize = min + Mathf.Clamp((Vector2.Distance(Target1.position, Target2.position) - minOrhtographicDistance) * sensetivity, 0f, maxOrthographicSize);

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
    }
    void DragStart()
    {
        dragStartpos = Camera.main.ScreenToWorldPoint(touch.position);
        dragStartpos.z = 0f;
        lr.positionCount = 1;
        lr.SetPosition(0, dragStartpos);
    }
    void Dragging()
    {
        Vector3 draggingPos = Camera.main.ScreenToWorldPoint(touch.position);
        draggingPos.z = 0f;
        lr.positionCount = 2;
        lr.SetPosition(1, draggingPos);
        Time.timeScale = 0.1f;
        Time.fixedDeltaTime = Time.timeScale * .01f;
        rb.velocity = new Vector3(0, 0, 0);
        /*if (rb.velocity.x >= 0f)
            rb.velocity = new Vector3(15, 5, 0);
        else if (rb.velocity.x <= 0f)
            rb.velocity = new Vector3(-15, 5, 0);
        else if(rb.velocity.x >= 0f ||rb.velocity.x >= rb.velocity.y)
            rb.velocity = new Vector3(2, 15, 0);
        else if (rb.velocity.x <= 0f || rb.velocity.x >= rb.velocity.y)
            rb.velocity = new Vector3(-2, 15, 0);*/
    }
    void DragRelease()
    {
        lr.positionCount = 0;
        Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint(touch.position);
        dragReleasePos.z = 0f;

        Vector3 force = dragStartpos - dragReleasePos;
        Vector3 clampedForce = Vector3.ClampMagnitude(force, maxDrag) * power;

        rb.AddForce(clampedForce, ForceMode2D.Impulse);

        Time.timeScale = 1f;
    }
    void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.CompareTag("Enemies"))
        {
            Player.SetActive(false);
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = Time.timeScale * .01f;
            LevelManager.instance.GameOver();
            Analytics.CustomEvent("DeathByEnemy");
        }
        else if(collision2D.collider.CompareTag("Lava"))
        {
            Player.SetActive(false);
            AudioSource.PlayClipAtPoint(DeathSound, transform.position);
            Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = Time.timeScale * .01f;
            LevelManager.instance.GameOver();
            Analytics.CustomEvent("DeathBylava");
        }
        else if(collision2D.collider.CompareTag("Level"))
        {
            AudioSource.PlayClipAtPoint(Bounce, transform.position);
        }else if(collision2D.collider.CompareTag("Neutrals"))
        {
            Score.IncreaseScore();
            Analytics.CustomEvent("HitPoint");
        }
        else if(collision2D.collider.CompareTag("BigMoney"))
        {
            int multiply = 0;
            while(multiply < 10)
            {
                multiply ++;
                Score.IncreaseScore();
            }
            Analytics.CustomEvent("HitExtraPoint");
        }
    }
}

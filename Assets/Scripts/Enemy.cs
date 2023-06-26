using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Attributes")]

    public int minSpeed = 10;
    public int maxSpeed = 25;
    public int randomSpeed;
    public float MaxHealth = 100;
    public float CurHealth = 100;

    [Header("References")]
    private Animator anim;
    public Canvas healthSystem;
    public HealthBar healthBar;
    private Transform target;

    private int waypointIndex = 0; //the index of the waypoint we are pursuing

    private void Awake()
    {
        randomSpeed = Random.Range(minSpeed, maxSpeed);
    }

    void Start()
    {
        target = Waypoints.points[0]; //going to the first waypoint
        healthSystem = GetComponentInChildren<Canvas>(healthSystem);
        anim = GetComponent<Animator>();
        CurHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    void Update()
    {
        Move();

        //Next 3 line set the direction they are facing to the direction they are going
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void Move()
    {
        Vector3 dir = target.position - transform.position; //getting direction vector by subtracting current position and target pos

        transform.Translate(dir.normalized * randomSpeed * Time.deltaTime, Space.World);
    }

    public void TakeDamage(float amount)
    {
        CurHealth -= amount;
        healthBar.SetHealth(CurHealth);

        if (CurHealth <= 0 && this.tag == "Enemy")
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        this.tag = "DeadEnemy";
        healthSystem.enabled = false;
        GameManager._gameManagerInstance.plyrScore += 10;
        GameManager.Money += 25;
        anim.SetTrigger("Die");
        randomSpeed = 0;
        Debug.Log("Getting richer! Slay Queen!");
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}

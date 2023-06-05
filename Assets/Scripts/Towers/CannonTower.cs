using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]

    public float range = 15f;
    public float fireRate = 1f; //shooting speed
    private float fireCountdown = 0f; //how quickly we can shoot again

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform gun;
    public float turnSpeed = 10f;

    public GameObject cannonballPrefab;
    public Transform firePoint;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //searches for a target 2x a second
    }

    void UpdateTarget() //searching for target
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); //puts all enemies in scene in array to be looped through
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) //looping through enemies in array 
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance) //closest enemy found
            {
                shortestDistance = distanceToEnemy; //sets that enemy
                nearestEnemy = enemy; //sets that enemy to target enemy
            }
        }

        if (nearestEnemy != null && shortestDistance <= range) 
        {
            target = nearestEnemy.transform;//targets the above found enemy
        }
        else
        {
            target= null;   
        }
    }
        
    void Update()
    {
        if (target == null)
        {
            return;
        }
        //target lock on logic
        Vector3 dir = target.position - transform.position; //where the gun should point
        Quaternion lookRotation = Quaternion.LookRotation(dir); //stores the quaternion we need to look at
        Vector3 rotation = Quaternion.Lerp(gun.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //converts that quaternion to euler angles (x,y,z) and smooths the look speed
        gun.rotation = Quaternion.Euler(0f, rotation.y, 0f); //ensures gun only roate around the Y AXIS

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject cannonballGO = (GameObject)Instantiate (cannonballPrefab, firePoint.position, firePoint.rotation); //casting to game oject
        Cannonball cannonball = cannonballGO.GetComponent<Cannonball>();

        if (cannonball != null) 
        {
            cannonball.Seek(target);
        }
    }

    void OnDrawGizmosSelected() //Displays wireframe of the range we specified
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);    
    }
}

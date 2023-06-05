using UnityEngine;

public class Cannonball : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float speed = 70f;
    public float explosionRadius = 0;
    public GameObject impactEffect;
    public float damage = 40f;
    public void Seek(Transform _target) //bullet is now finding the target
    {
        target = _target;
    }
    void Update()
    {
        if (target == null) //if no target, destroy cannonball
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position; //where does bullet have to go
        float distanceThisFrame = speed * Time.deltaTime;   //how fast gonna move this frame

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World); //if not hit, keep going
    }

    void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 2f);

        if (explosionRadius > 0f) //dmg in a radius
        {
            Explode();
        }
        else
        {
            target.GetComponent<Enemy>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    void Explode() //radial damage
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders) 
        {
            if (collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().TakeDamage(damage);
            }            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }



}

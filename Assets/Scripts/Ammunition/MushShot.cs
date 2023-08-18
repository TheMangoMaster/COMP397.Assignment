using UnityEngine;

public class MushShot : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float speed = 70f;
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

        if (dir.magnitude < distanceThisFrame)
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
        //Destroy(target.gameObject);
        target.GetComponent<enemy>().TakeDamage(damage);


        Destroy(gameObject);
    }
          
    

}

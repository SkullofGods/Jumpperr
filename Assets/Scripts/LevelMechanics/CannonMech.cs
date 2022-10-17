using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMech : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject projectile;
    public Transform spawnPosition;
    [Header("ShootingSettings")] 
    public float force;
    public float delay;
    public float lifetime;

    private bool _shouldShoot = true;
    
    void Update()
    {
        if (_shouldShoot)
        {
            _shouldShoot = false;
            StartCoroutine(Shoot());
        }
        
        
    }

    private IEnumerator Shoot()
    {
        var proj = Instantiate(projectile, spawnPosition.position, this.transform.rotation);
        proj.GetComponent<Rigidbody>().velocity = proj.transform.TransformDirection(Vector3.right) * force;
        proj.GetComponent<CannonBall>().lifetime = lifetime;

        yield return new WaitForSeconds(delay);
        _shouldShoot = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMech : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject projectile;
    public Transform spawnPosition;
    [Header("ShootingSettings")]
    public float force, delay, lifetime;

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
        projectile = Instantiate(projectile, spawnPosition.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = Vector3.right*force;
        projectile.GetComponent<CannonBall>().lifetime = lifetime;
        
        
        yield return new WaitForSeconds(delay);
        _shouldShoot = true;
    }

}

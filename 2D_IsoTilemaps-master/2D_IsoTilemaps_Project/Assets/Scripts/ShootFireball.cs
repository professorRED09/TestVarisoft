using UnityEngine;

public class ShootFireball : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform shootPos;
    public float fireSpeed;

    public void Shoot()
    {
        GameObject _fireball = Instantiate(fireballPrefab, shootPos.position, shootPos.rotation);
        Rigidbody2D fbRb = _fireball.GetComponent<Rigidbody2D>();
        fbRb.linearVelocity = fireSpeed * shootPos.up;
    }
}

using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject bullet;
    public bool isFacingRight = true;
    public float fireRate = 0.2f;
    float timeUntillFire;
    float angle;
    public Transform firingPoint;
    RangedEnemy re;

    void Start(){
        re = FindObjectOfType<RangedEnemy>();
    }

    void Update(){
        
    }

    public void Fire()
    {
        if (timeUntillFire < Time.time)
        {
            angle = isFacingRight ? 0f : 180f;
            Instantiate(bullet, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            timeUntillFire = Time.time + fireRate;
        }
    }
}

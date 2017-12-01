using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    [DllImport("Library")]
    private static extern float RandomAngle();

    public float speed = 1.0F;
    public Vector2 enemy;
    private Bullet bullet;
    private CircleCollider2D circleCollider2D;

    void Start()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(RandomDirection());
        bullet = Resources.Load<Bullet>("Bullet");
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MonoBehaviour unit = collider.GetComponent<MonoBehaviour>();

        if (unit && unit.tag != "Bullet" && !unit.tag.Contains("Blue") && !unit.tag.Contains("Locator"))
        {
            enemy.x = unit.transform.position.x;
            enemy.y = unit.transform.position.y;
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet newBullet = Instantiate(bullet, PointOfBulletSpawn(), bullet.transform.rotation) as Bullet;
        newBullet.parent = gameObject;
        newBullet.Fire(DirectionOfShoot());
    }

    private Vector2 DirectionOfShoot()
    {
        Vector2 shootDirection;
        shootDirection = enemy - (Vector2)transform.position;
        shootDirection = shootDirection.normalized;
        return shootDirection;

    }

    private Vector2 RandomDirection()
    {
        float randomAngle = RandomAngle(); //Random.Range(0, 2 * Mathf.PI);
        Vector2 randomDirection = RotationOfPoint(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 0.0f), randomAngle);
        randomDirection *= speed;
        return randomDirection;
    }

    private Vector2 RotationOfPoint(Vector2 point, Vector2 centre, float angle)
    {
        Vector2 resultPoint;
        resultPoint.x = centre.x + (point.x - centre.x) * Mathf.Cos(angle) - (point.y - centre.y) * Mathf.Sin(angle);
        resultPoint.y = centre.y + (point.y - centre.y) * Mathf.Cos(angle) + (point.x - centre.x) * Mathf.Sin(angle);
        return resultPoint;
    }

    private float AngleBetweenVectors(Vector2 v1, Vector2 v2)
    {
        float ang = Vector2.Angle(v1, v2);
        Vector3 cross = Vector3.Cross(v1, v2);
        if (cross.z < 0) ang = 360 - ang;
        ang *= Mathf.Deg2Rad;
        return ang;
    }

    private Vector2 PointOfBulletSpawn()
    {
        float angleRotatioin = AngleBetweenVectors(new Vector2(1.0f, 0.0f), DirectionOfShoot());
        Vector2 pointOfBulletSpawn = RotationOfPoint(new Vector2(transform.position.x + circleCollider2D.bounds.extents.x * 1.01f, transform.position.y), transform.position, angleRotatioin);
        return pointOfBulletSpawn;
    }
}


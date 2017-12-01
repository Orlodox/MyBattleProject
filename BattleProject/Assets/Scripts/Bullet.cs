using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject parent;
    public float speed = 10.0f;

    private void Start()
    {
    }
    public void Fire (Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction*speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Component unit = collider.GetComponent<Component>();

        if (unit && unit.gameObject != parent && unit.tag!="Locator")
        {
            Destroy(gameObject);
            if (unit.tag!="Border")
                Destroy(unit.gameObject);
        }
    }
}

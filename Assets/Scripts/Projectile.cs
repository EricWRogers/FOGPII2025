using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30.0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += transform.right * 30.0f;
    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 30.0f;
    public float selfDestruct = 5.0f;

    void Start()
    {
        Destroy(gameObject, selfDestruct);
    }

    void FixedUpdate()
    {
        transform.position += transform.right * 30.0f * Time.fixedDeltaTime;
    }
}

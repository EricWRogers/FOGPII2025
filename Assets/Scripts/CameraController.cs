using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Rigidbody2D m_targetRigidbody;
    private Vector3 startingOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_targetRigidbody = target.GetComponent<Rigidbody2D>();
        startingOffset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + startingOffset;
    }
}

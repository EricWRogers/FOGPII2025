using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent2D : MonoBehaviour
{
    public UnityEvent onTrigger;
    public string targetTag;
    public bool destroyAfter = false;
    private bool m_eventFired = false;
    public void OnTriggerEnter2D(Collider2D _collider)
    {
        if (destroyAfter && m_eventFired)
            return;

        if (_collider.gameObject.tag == targetTag)
        {
            m_eventFired = true;
            onTrigger.Invoke();

            if (destroyAfter)
                Destroy(gameObject);
        }
    }
}
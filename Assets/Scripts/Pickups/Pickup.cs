using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string targetTag;
    private bool m_onTriggeredCalled = false;
    public virtual void Use(GameObject _player)
    {

    }

    public void OnTriggerEnter2D(Collider2D _collider)
    {
        if (m_onTriggeredCalled)
            return;

        if (targetTag == _collider.gameObject.tag)
        {
            m_onTriggeredCalled = true;
            Use(_collider.gameObject);
            Destroy(gameObject);
        }
    }
}

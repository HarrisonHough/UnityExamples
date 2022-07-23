using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public class CollisionTrigger : MonoBehaviour
{
    public UnityEvent triggerEvents;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        triggerEvents.Invoke();
    }
}

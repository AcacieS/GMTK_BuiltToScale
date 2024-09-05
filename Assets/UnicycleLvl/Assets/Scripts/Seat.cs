using Unity.VisualScripting;
using UnityEngine;

public class Seat: MonoBehaviour {

    [SerializeField] private GameObject wheel;

    private void OnCollisionEnter2D(Collision2D collision) {
        // with ground
        if (collision.gameObject.CompareTag("Ground")) {
            wheel.TryGetComponent<IColliderTrigger>(out var trigger);
            trigger?.OnTrigger();
        }
    }
}
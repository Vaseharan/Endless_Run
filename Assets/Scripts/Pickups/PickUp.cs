using UnityEngine;

public abstract  class PickUp : MonoBehaviour
{
    const string playerString = "Player";
    [SerializeField] float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }
    protected abstract void OnPickup();
}

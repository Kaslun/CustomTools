using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class InteractBase : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<SphereCollider>().isTrigger = true;
    }
    public abstract void DoInteract();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Found player");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Lost player");
        }
    }
}

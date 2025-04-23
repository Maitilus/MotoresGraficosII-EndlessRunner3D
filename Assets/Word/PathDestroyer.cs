using UnityEngine;

public class PathDestroyer : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }

}

using UnityEngine;

public class WorldMovement : MonoBehaviour
{

    [SerializeField] float WorldSpeed;

    void Update()
    {
        transform.Translate(Vector3.forward * WorldSpeed * Time.deltaTime);
    }
}

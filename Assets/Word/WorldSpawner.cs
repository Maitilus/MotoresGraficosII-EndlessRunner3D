using UnityEngine;

public class WorldSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Chunks;
    public Transform Spawnpoint;

    public float Cooldown;
    public float CurrentCD;

    void Update()
    {
        CurrentCD -= Time.deltaTime;

        if(CurrentCD <= 0)
        {
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        int RNG = Random.Range(0, Chunks.Length);
        GameObject Chunk = Instantiate(Chunks[RNG], Spawnpoint.position, Quaternion.identity);
        Chunk.transform.SetParent(transform);

        CurrentCD = Cooldown;
    }
}

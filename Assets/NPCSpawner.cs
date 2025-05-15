using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;
    public int maxNPCs = 5;
    private int currentNPCs = 0;
    public float spawnDistance = 5f;
    public float spawnHeight = 1f;

    void Start()
    {
        SpawnNPCs();
    }

    void SpawnNPCs()
    {
        // Use the correct name of your camera rig
        GameObject cameraRig = GameObject.Find("[BuildingBlock] Camera Rig");
        if (cameraRig == null)
        {
            Debug.LogError("Could not find [BuildingBlock] Camera Rig in the scene!");
            return;
        }
        Vector3 playerPos = cameraRig.transform.position;
        for (int i = 0; i < maxNPCs; i++)
        {
            float angle = i * (360f / maxNPCs);
            Vector3 spawnPos = playerPos + Quaternion.Euler(0, angle, 0) * Vector3.forward * spawnDistance;
            spawnPos.y = spawnHeight;
            Instantiate(npcPrefab, spawnPos, Quaternion.identity);
            currentNPCs++;
        }
        Debug.Log("Spawned " + currentNPCs + " NPCs");
    }
}
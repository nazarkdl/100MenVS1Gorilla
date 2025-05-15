using UnityEngine;

public class NPCController : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 2f;
    private bool isDead = false;
    public int maxHealth = 2;
    private int currentHealth;
    private Renderer npcRenderer;
    private Rigidbody rb;

    void Start()
    {
        // Find the camera rig
        GameObject cameraRig = GameObject.Find("[BuildingBlock] Camera Rig");
        if (cameraRig == null)
        {
            Debug.LogError("Could not find [BuildingBlock] Camera Rig in the scene!", this);
            return;
        }
        player = cameraRig.transform;
        Debug.Log("NPC found camera rig at: " + player.position, this);

        currentHealth = maxHealth;
        npcRenderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (isDead || player == null) return;

        // Calculate direction to player's current position
        Vector3 direction = (player.position - transform.position).normalized;
        Debug.Log("NPC moving toward: " + player.position, this);

        // Move using Rigidbody
        Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);

        // Face the player
        transform.LookAt(player);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        if (npcRenderer != null)
        {
            npcRenderer.material.color = Color.red;
            Invoke("ResetColor", 0.2f);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    private void ResetColor()
    {
        if (npcRenderer != null)
        {
            npcRenderer.material.color = Color.white;
        }
    }
}
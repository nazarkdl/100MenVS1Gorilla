using UnityEngine;

public class HandAttack : MonoBehaviour
{
    public int damage = 1; // Damage per hit
    public OVRInput.Button attackButton = OVRInput.Button.One; // A button on right controller, X on left

    void Update()
    {
        // Optional: Add debug log to confirm button detection
        if (OVRInput.GetDown(attackButton))
        {
            Debug.Log("Attack button pressed on " + gameObject.name);
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Only deal damage if the attack button is pressed
        if (OVRInput.Get(attackButton))
        {
            NPCController npc = other.GetComponent<NPCController>();
            if (npc != null)
            {
                npc.TakeDamage(damage);
            }
        }
    }
}
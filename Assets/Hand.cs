using UnityEngine;

public class Hand : MonoBehaviour
{
    public OVRInput.RawButton hittingButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(hittingButton))
        {
            hit();
        }
        
    }

    public void hit()
    {
        Debug.Log("HIT");
    }
}

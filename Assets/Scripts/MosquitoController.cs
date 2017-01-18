using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class MosquitoController : MonoBehaviour
{

    // Target destination of the mosquito
    public GameObject target;

    // Speed of the mosquito
    public float speed = 0.5f;

    // Distance when it stops
    float minDistance = 0.3f;

    // Flag to check whether it's moving
    bool isMoving = true;

    // VR interactive object component
    private VRInteractiveItem m_InteractiveItem;

    // Use this for initialization
    void Start()
    {
        // @TODO: use rigid body not transform
        // Look at the target
        transform.LookAt(target.transform);
    }

    // Update is called once per frame
    // @TODO: use rigid body not transform
    void Update()
    {

        // Check if it's moving
        if (isMoving)
        {
            // Calculate distance from target
            float distance = Vector3.Distance(transform.position, target.transform.position);

            // Check the minimum distance
            if (distance <= minDistance)
            {
                // Stop moving
                isMoving = false;
            }

            else
            {
                // Set for the current frame (speed = distance / time --> distance = speed * time)
                float step = speed * Time.deltaTime;

                // Move towards the target
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            }
        }
    }

    void Awake()
    {
        m_InteractiveItem = GetComponent<VRInteractiveItem>();
    }

    void OnEnable()
    {
        m_InteractiveItem.OnClick += HandleClick;
    }

    void HandleClick()
    {
        if(isMoving)
        {
            isMoving = false;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = true;

            // @TODO: hit it with a force

            // @TODO: use rigid body not transform
            transform.Rotate(Vector3.forward, 180);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MimicHead : MonoBehaviour
{
    [Tooltip("The GameObject that should mimic this object's position")]
    public GameObject MimicObject;

    [Tooltip("The preferred Z distance of the mimic object")]
    public float MimicOffsetZ;

    private Vector3 MimicPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            MimicPosition.x = transform.position.x;
            MimicPosition.y = transform.position.y;
            MimicPosition.z = transform.position.z + MimicOffsetZ;
            MimicObject.transform.position = MimicPosition;

            transform.hasChanged = false;
        }
    }
}

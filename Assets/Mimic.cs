using System;
using UnityEngine;
using Valve.VR;

public class Mimic : MonoBehaviour
{
    [Tooltip("The GameObject that should mimic this object's position")]
    public GameObject MimicObject;

    [Tooltip("The preferred Z distance of the mimic object")]
    public float MimicOffsetZ;

    private Vector3 MimicPosition;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SteamVR_Behaviour_Pose>().onTransformChanged.AddListener(SyncMimicPosition);
    }

    public void SyncMimicPosition(SteamVR_Behaviour_Pose pose, SteamVR_Input_Sources fromSource)
    {
        MimicPosition.x = transform.position.x;
        MimicPosition.y = transform.position.y;
        MimicPosition.z = transform.position.z + MimicOffsetZ;
        MimicObject.transform.position = MimicPosition;
    }
}

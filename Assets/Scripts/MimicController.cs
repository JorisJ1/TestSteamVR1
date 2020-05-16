using UnityEngine;

public class MimicController : MonoBehaviour {
    [Tooltip("The GameObject that should mimic this object's position")]
    public GameObject MimicObject;

    [Tooltip("The GameObject that when collided with will will add a point")]
    public GameObject TargetObject;

    private Vector3 MimicPosition;

    private void Start() {
        MimicPosition = MimicObject.transform.position;
    }

    void Update() {
        if (transform.hasChanged) {
            MimicPosition.x = transform.position.x;
            MimicPosition.y = transform.position.y;
            MimicObject.transform.position = MimicPosition;
            transform.hasChanged = false;
        }
    }
}

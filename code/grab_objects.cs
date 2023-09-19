public class ObjectGrabber : MonoBehaviour {

    public float grabDistance = 2f; 
    public LayerMask grabbableLayer; 

    private GameObject objectBeingGrabbed; 

    void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, grabDistance, grabbableLayer)) {
                objectBeingGrabbed = hit.collider.gameObject;
                objectBeingGrabbed.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.E)) {
            if (objectBeingGrabbed != null) {
                objectBeingGrabbed.GetComponent<Rigidbody>().isKinematic = false;
                objectBeingGrabbed = null;
            }
        }
        if (objectBeingGrabbed != null) {
            objectBeingGrabbed.transform.position = transform.position;
        }
    }
}

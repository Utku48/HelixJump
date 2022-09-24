using UnityEngine;

public class CameraFoloow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float smoothSpeed = 0.04f;

    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Lerp() 0 => Bir noktadan diğer bir noktaya belirli bir ölçekte gitmemizi sağlar.
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);//Kamera takibinin daha smooth bir şekilde yapılmasını istiyoruz
        transform.position = newPosition;
    }
}

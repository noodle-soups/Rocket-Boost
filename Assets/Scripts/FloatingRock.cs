using UnityEngine;

public class FloatingRock : MonoBehaviour
{

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float xRotation;
    [SerializeField] private float yRotation;
    [SerializeField] private float zRotation;
    public float contactDamage;

    void Start()
    {
        
    }

    void FixedUpdate()
    {

        Vector3 _rotationVector = new Vector3(xRotation, yRotation, zRotation);
        transform.Rotate(_rotationVector * rotationSpeed * Time.fixedDeltaTime);

    }
}

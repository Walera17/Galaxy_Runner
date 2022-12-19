using UnityEngine;

public class Tile : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        startPosition = transform.localPosition;
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ResetTile(Material material)
    {
        meshRenderer.material = material;

        if (transform.localPosition != startPosition)
        {
            transform.localPosition = startPosition;
            transform.localRotation = Quaternion.identity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
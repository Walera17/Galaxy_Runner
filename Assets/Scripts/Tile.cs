using UnityEngine;

public class Tile : MonoBehaviour
{
    private Material[] materials;
    private Vector3 startPosition;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;

    void Awake()
    {
        materials = Resources.LoadAll<Material>("Materials");
        startPosition = transform.localPosition;
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        //ResetTile();
    }

    public void ResetTile()
    {
        Material material = materials[Random.Range(0, materials.Length)];
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
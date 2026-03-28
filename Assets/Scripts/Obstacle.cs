using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int ColorIndex { get; private set; }
    private Transform playerTransform;


    public void Setup(Material[] materials, Transform playerRef)
    {
        ColorIndex = Random.Range(0, materials.Length);
        GetComponent<Renderer>().material = materials[ColorIndex];

        playerTransform = playerRef;
    }

    private void Update()
    {
        if (playerTransform != null && transform.position.z < playerTransform.position.z - 10f)
        {
            Destroy(gameObject);
        }
    }
}
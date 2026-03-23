using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 15f;
    public float speedMultiplier = 1.05f; 

    [Header("Color Settings")]
    public Material[] colors;
    private int currentColorIndex;
    private Renderer playerRenderer;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        ChangeColor(0);
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameOver) return;

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);


        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            ChangeColor(currentColorIndex);
        }
    }

    private void ChangeColor(int index)
    {
        playerRenderer.material = colors[index];
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Obstacle obstacle = other.GetComponent<Obstacle>();

            if (obstacle != null && obstacle.ColorIndex == currentColorIndex)
            {
                GameManager.Instance.AddScore(1);
                forwardSpeed *= speedMultiplier; 
                Destroy(other.gameObject); 
            }
            else
            {
                GameManager.Instance.EndGame();
            }
        }
    }
}
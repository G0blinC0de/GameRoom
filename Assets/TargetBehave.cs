
using UnityEngine;
using UnityEngine.UI;

public class TargetBehave : MonoBehaviour
{
    public float targetSpeed = 1f;

    public TargetSpawner targetSpawner;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * targetSpeed) * Time.deltaTime;
    }

    private void OnMouseDown()
    {
        IncreaseScore();
        Destroy(gameObject);
    }

    private void IncreaseScore()
    {
        targetSpawner.gameScore++;
        targetSpawner.ScoreUI.text = "Score: " + targetSpawner.gameScore.ToString();
    }
}

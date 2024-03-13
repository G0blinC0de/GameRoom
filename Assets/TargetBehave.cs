
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TargetBehave : MonoBehaviour
{
    public float targetSpeed = 1f;

    public AudioClip TargetDestroyed;

    public int outofBounds = 2;

    public TargetSpawner targetSpawner;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.up * targetSpeed) * Time.deltaTime;
        if (transform.position.y > outofBounds)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        IncreaseScore();
        AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
        audioSource.PlayOneShot(TargetDestroyed);
        Destroy(gameObject);

    }

    private void IncreaseScore()
    {
        targetSpawner.gameScore++;
        targetSpawner.ScoreUI.text = "Score: " + targetSpawner.gameScore.ToString();
    }
}

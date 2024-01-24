
using UnityEngine;

public class TargetBehave : MonoBehaviour
{
    public float targetSpeed = 1f;

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
        Destroy(gameObject);
    }
}

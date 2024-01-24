
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject TargetObj;
    public float delay = 2f;
    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < delay)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnTarget();
            timer = 0;
        }
    }

    void SpawnTarget()
    {

        var position = new Vector3(Random.Range(-3f, 3f), -3, 0);
        Instantiate(TargetObj, position, Quaternion.identity);
    }
}

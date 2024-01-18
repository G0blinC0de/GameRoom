
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    private Vector3 originPosition;
    public GameObject TargetObj;
    public float delay = 0f;


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 5; i++)
        {
            var position = new Vector3(Random.Range(-3f, 3f), -3, 0);
            TargetObj = Instantiate(TargetObj, position, Quaternion.identity);
            Debug.Log("TargetObj created");

        }
        new WaitForSeconds(delay);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

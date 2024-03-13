
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    public GameObject TargetObj;
    public float delay = 2f;
    private float timer = 0;

    private float targetCount = 0;

    public int gameScore;
    public Text ScoreUI;

    public bool GameStarted = false;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;



    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartButton()
    {
        GameStarted = true;
        targetCount = 0;
        gameScore = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameStarted == true)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            if (targetCount < 5)
            {
                if (timer < delay)
                {
                    timer += Time.deltaTime;

                }
                else
                {
                    SpawnTarget();
                    targetCount++;
                    timer = 0;
                }
            }
            // else { display end screen + main menu button + change mouse icon back }

        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    void SpawnTarget()
    {

        {
            var position = new Vector3(Random.Range(-3f, 3f), -3, 0);
            var target = Instantiate(TargetObj, position, Quaternion.identity);
            var behave = target.GetComponent<TargetBehave>();
            behave.targetSpawner = this;

        }
    }
}

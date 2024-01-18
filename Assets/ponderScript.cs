using UnityEngine;
using UnityEngine.UI;

public class PonderButtonScript : MonoBehaviour
{
    public Text displayText; // Reference to the Text component

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn == null)
        {
            Debug.LogError("Button component not found on the GameObject");

        }
        btn.onClick.AddListener(OnPonderButtonClick);
    }

    void OnPonderButtonClick()
    {
        int randomChoice = Random.Range(1, 9); // Generate a random number between 1 and 8

        string result = "";
        switch (randomChoice)
        {
            case 1:
                result = "It is a certainty.";
                break;
            case 2:
                result = "The chorus of fate wills it to be so.";
                break;
            case 3:
                result = "It is unlikely.";
                break;
            case 4:
                result = "The vision is cloudy, consult another seer.";
                break;
            case 5:
                result = "Improbable, but not impossible.";
                break;
            case 6:
                result = "You may pursue this destiny at your own peril.";
                break;
            case 7:
                result = "A fortuitous destiny lies ahead on this path.";
                break;
            case 8:
                result = "The spirits urge you to reconsider this path.";
                break;
        }

        if (displayText != null)
        {
            displayText.text = result;
        }
        else
        {
            Debug.LogError("Display Text component not assigned");
        }
    }
}


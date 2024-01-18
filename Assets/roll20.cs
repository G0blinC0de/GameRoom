using UnityEngine;
using UnityEngine.UI; // Import this namespace to work with UI components

public class Roll20 : MonoBehaviour
{
    public Text resultText;
    private Button btn;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        // Get the Button component from this GameObject
        Button btn = GetComponent<Button>();

        // Ensure the Button component is found
        if (btn == null)
        {
            Debug.LogError("Button component not found on the GameObject");
            return;
        }

        btn.onClick.AddListener(OnButtonClick);

    }

    // This method is called when the button is clicked
    void OnButtonClick()
    {
        // Generate a random number between 1 and 20
        int randomNumber = Random.Range(1, 21);

        // Determine success or failure
        string resultMessage = randomNumber >= 14 ? "You have slain the Dagron" : "You have been Burninated";

        // Check if the displayText is assigned
        if (resultText != null)
        {
            // Update the Text component with the random number and the result message
            resultText.text = randomNumber + " - " + resultMessage;
        }
        else
        {
            Debug.LogError("Display Text component not assigned");
        }

        gameObject.SetActive(false);
    }
}

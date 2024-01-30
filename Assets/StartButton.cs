using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        Button btn = GetComponent<Button>();

        // Ensure the Button component is found
        if (btn == null)
        {
            Debug.LogError("Button component not found on the GameObject");
            return;
        }

        btn.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void OnButtonClick()
    {
        gameObject.SetActive(false);
    }
}

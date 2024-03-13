using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private List<int> playerTaskList = new List<int>(); // Pattern Generated
    private List<int> playerSequenceList = new List<int>(); // Pattern Returned by Player

    public List<AudioClip> buttonSoundList = new List<AudioClip>();
    // List of Lists - buttonColors is Prime List, within that list are 2 values for highlighted vs unhighlighted color
    // so referencing buttonColors is List, and then 0 value or 1 value color within Prime List
    public List<List<Color32>> buttonColors = new List<List<Color32>>();

    public List<Button> clickableButtons;
    public AudioClip loseSound;
    public AudioSource audioSource;
    public CanvasGroup buttons;

    public GameObject startButton;

    public void Awake()
    {
        //                          Regular State of Color, Highlighted State of Color
        buttonColors.Add(new List<Color32> { new Color32(255, 100, 100, 255), new Color32(255, 0, 0, 255) }); // red
        buttonColors.Add(new List<Color32> { new Color32(255, 187, 109, 255), new Color32(255, 136, 0, 255) }); // orange
        buttonColors.Add(new List<Color32> { new Color32(162, 255, 124, 255), new Color32(72, 248, 0, 255) }); // green
        buttonColors.Add(new List<Color32> { new Color32(57, 111, 255, 255), new Color32(0, 70, 255, 255) }); // blue
        for (int i = 0; i < 4; i++)
        {
            clickableButtons[i].GetComponent<Image>().color = buttonColors[i][0];
        }
    }

    public void AddToPlayerSequenceList(int buttonID)
    {
        playerSequenceList.Add(buttonID);
        StartCoroutine(HighlightButton(buttonID));
        for (int i = 0; i < playerSequenceList.Count; i++)
        {
            if (playerTaskList[i] == playerSequenceList[i])
            {
                continue;
            }
            else
            {
                StartCoroutine(GameOver()); // eventually replace with 'Game Over' pop-up
                return;
            }
        }
        if (playerSequenceList.Count == playerTaskList.Count)
        {
            StartCoroutine(StartNextRound()); // so long as player pattern matches task pattern, begin next task-sequence
        }

    }
    public void StartGame()
    {
        StartCoroutine(StartNextRound());
        startButton.SetActive(false);
    }

    public IEnumerator HighlightButton(int buttonID)
    {
        clickableButtons[buttonID].GetComponent<Image>().color = buttonColors[buttonID][1];
        audioSource.PlayOneShot(buttonSoundList[buttonID]);
        yield return new WaitForSeconds(0.5f);
        clickableButtons[buttonID].GetComponent<Image>().color = buttonColors[buttonID][0];
        yield return new WaitForSeconds(0.5f);
    }

    public IEnumerator GameOver()
    {
        audioSource.PlayOneShot(loseSound);
        playerSequenceList.Clear();
        playerTaskList.Clear();
        yield return new WaitForSeconds(3f);
        startButton.SetActive(true);
    }
    public IEnumerator StartNextRound()
    {
        playerSequenceList.Clear();
        buttons.interactable = false;
        yield return new WaitForSeconds(1f);
        playerTaskList.Add(Random.Range(0, 4)); // even though it says 4, last value is excluded, thus 0-3
        foreach (int index in playerTaskList)
        {
            yield return StartCoroutine(HighlightButton(index));
        }
        buttons.interactable = true;
        yield return null;
    }
}

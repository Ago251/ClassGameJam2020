using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour {
    public int index;
    public List<string> texts;
    public TextMeshProUGUI TextUI;
    public AudioSource audio;
    public Image image;
    public Sprite maze, monster;
    public Coroutine coroutine;
    public bool completed;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && !completed) {
            NextText();
        } 
    }

    private void NextText() {
        if (index < texts.Count - 1) {
            index++;
            TextUI.text = texts[index];
            return;
        }

        if (coroutine == null) {
            completed = true;
            coroutine = StartCoroutine(Scream());
        }
    }

    IEnumerator Scream() {
        TextUI.enabled = false;
        image.color = Color.white;
        image.sprite = maze;
        yield return new WaitForSecondsRealtime(2f);
        audio.Play();
        image.sprite = monster;
        yield return new WaitForSeconds(4f);
        Application.Quit();
    }
}

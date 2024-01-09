using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Animator animator;

    public Text nameText;
    public Text dialogueText;

    public enum DIALOGUE_STATE
    {
        IN_PROGRESSE,
        FINISH
    }

    public static DIALOGUE_STATE _STATE;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _STATE = DIALOGUE_STATE.IN_PROGRESSE;
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        
        DisplayNextSentence();
    }

    private void Update()
    {
        if(_STATE == DIALOGUE_STATE.IN_PROGRESSE)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DisplayNextSentence();
            }
        }
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }

    }

    void EndDialogue()
    {
        _STATE = DIALOGUE_STATE.FINISH;
        animator.SetBool("isOpen", false);
        ObjectiveManager.OnObjectiveFinish.Invoke();
    }

}

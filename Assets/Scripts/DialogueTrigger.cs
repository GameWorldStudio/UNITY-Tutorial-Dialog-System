using UnityEditorInternal;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerDialogue();
        }
    }

    //Cette méthode sert a lancer un dialogue. Dans le tutoriel, nous l'appelons en cliquant sur un bouton, cependant, nous pouvons l'appeler de plein
    //D'autres manières différentes comme par exemple si le joueur entre dans un champs, meurt, ou autre 
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        gameObject.SetActive(false);
    }
}

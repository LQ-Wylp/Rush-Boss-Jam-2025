using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteZone : MonoBehaviour
{
    // Liste pour suivre les notes présentes dans la zone
    public List<GameObject> notesInZone = new List<GameObject>();

    // Lorsque quelque chose entre dans le trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet a le tag "Note"
        if (collision.CompareTag("Note"))
        {
            // Ajoute l'objet à la liste
            notesInZone.Add(collision.gameObject);
        }
    }

    // Lorsque quelque chose sort du trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Vérifie si l'objet a le tag "Note"
        if (collision.CompareTag("Note"))
        {
            // Retire l'objet de la liste
            notesInZone.Remove(collision.gameObject);
        }
    }

    // Pour vérifier les notes présentes dans la zone
    public NoteCollectible GetNotesInZone()
    {
        if(notesInZone.Count > 0){
            if(notesInZone[0]){
                return notesInZone[0].GetComponentInParent<NoteCollectible>();
            }
            else{
                notesInZone.Remove(notesInZone[0]);
            }
        }
        return null;
    }
}

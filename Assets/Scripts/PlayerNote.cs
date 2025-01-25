using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNote : MonoBehaviour
{
    public List<NoteCollectible> notes = new List<NoteCollectible>(); // Liste des notes
    public float speedRotate = 1f; // Vitesse de rotation
    public float radius = 2f; // Rayon du cercle sur lequel les notes tournent
    public GameObject axeRotate; // Point central pour la rotation
    public GameObject stockageNotes; // Parent pour stocker les notes
    public Camera mainCamera; // Référence à la caméra
    public NoteZone noteZone;

    void Update()
    {
        // Faire tourner les notes autour du point central
        RotateNotes();
    }

    public void AddNote(NoteCollectible note)
    {
        // Ajoute une note à la liste
        notes.Add(note);
        // Réorganise les positions des notes
        ReorganizeNotes();
        // Active le visuel 2D de la note
        note.visuel2D.SetActive(true);
        // Définit le parent de la note
        note.gameObject.transform.SetParent(stockageNotes.transform);
    }

    public void RemoveNote(NoteCollectible note)
    {
        // Supprime une note de la liste
        notes.Remove(note);
        // Réorganise les positions des notes
        ReorganizeNotes();
    }

    private void RotateNotes()
    {
        // Vérifie si la liste n'est pas vide
        if (notes.Count == 0) return;

        // Faire tourner chaque note autour du point central
        foreach (var note in notes)
        {
            if (note != null)
            {
                // Rotation autour de l'axe de rotation
                note.transform.RotateAround(axeRotate.transform.position, new Vector3(0, 0, 1), speedRotate * Time.deltaTime);
                // Assurez-vous que la note reste orientée vers la caméra
                note.transform.LookAt(mainCamera.transform);
            }
        }
    }

    private void ReorganizeNotes()
    {
        if (notes.Count == 0) return;

        // Calcule l'angle entre chaque note
        float angleStep = 360f / notes.Count;
        for (int i = 0; i < notes.Count; i++)
        {
            if (notes[i] != null)
            {
                // Calcule la position sur le cercle
                float angle = i * angleStep * Mathf.Deg2Rad; // Convertit en radians
                Vector3 newPos = new Vector3(
                    Mathf.Cos(angle) * radius, // Position X
                    Mathf.Sin(angle) * radius, // Position Y
                    0 // Position Z
                );

                // Définit la position relative au centre de rotation
                notes[i].transform.position = axeRotate.transform.position + newPos;

                // Oriente la note pour qu'elle regarde vers la caméra
                notes[i].transform.LookAt(mainCamera.transform);

                // Annule la rotation sur l'axe Z pour que l'objet reste droit
                notes[i].transform.rotation = Quaternion.Euler(0, notes[i].transform.rotation.eulerAngles.y, 0);
            }
        }
    }

    public void OnUseNote()
    {
        NoteCollectible noteUsed = noteZone.GetNotesInZone();
        if(noteUsed)
        {
            noteUsed.Effect();
        }
    }
}

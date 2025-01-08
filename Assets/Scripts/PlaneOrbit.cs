using UnityEngine;

public class PlaneOrbit : MonoBehaviour
{
    [Header("Planes Settings")]
    public GameObject planePrefab; // Préfabriqué du plane
    public int planeCount = 5; // Nombre de planes
    public float orbitRadius = 5f; // Rayon de l'orbite
    public float orbitSpeed = 20f; // Vitesse de rotation

    private GameObject[] planes;

    void Start()
    {
        CreatePlanes();
    }

    void Update()
    {
        RotatePlanes();
    }

    private void CreatePlanes()
    {
        planes = new GameObject[planeCount];
        float angleStep = 360f / planeCount;

        for (int i = 0; i < planeCount; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 position = new Vector3(
                Mathf.Cos(angle) * orbitRadius, // Calcul sur X pour incliner l'orbite
                0f, // Y reste fixe
                Mathf.Sin(angle) * orbitRadius // Calcul sur Z
            );

            GameObject plane = Instantiate(planePrefab, transform.position + position, Quaternion.identity);
            plane.transform.SetParent(transform);

            // Tourner chaque plane pour qu'il fasse face au centre
            plane.transform.LookAt(transform.position);

            planes[i] = plane;
        }
    }

    private void RotatePlanes()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            // Rotation autour de l'axe vertical
            planes[i].transform.RotateAround(transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        }
    }
}

using UnityEngine;
using UnityEngine.VFX;

public class OnHitSparks : MonoBehaviour
{
    public void OnHit(Vector3 otherPosition, GameObject otherVFX)
    {
        // RaycastHit hit;
        // if (Physics.Raycast(transform.position, (otherPosition - transform.position).normalized, out hit))
        // {
        //     Vector3 vfxPosition = hit.point;

        //     Vector3 offset = hit.normal * 0.1f; // Adjust the multiplier as needed

        GameObject vfxHitInstance = Instantiate(otherVFX, transform.position, Quaternion.identity);
        VisualEffect vfxHit = vfxHitInstance.GetComponentInChildren<VisualEffect>();

        vfxHit.Play();
        // }
    }
}
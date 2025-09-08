using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Target")]
    public Transform Player;

    [Header("Follow Settings")]
    public float SmoothSpeed = 0.125f;
    public Vector3 Offset = new Vector3(0, 0, -10);



    [Header("Sanity System")]
    [Range(0, 100)]
    public float Sanity = 100f;

    [Header("Camera Effects")]
    public Volume PostProcessVolume; // Drag your Global Volume here
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;
    private LensDistortion lensDistortion;
    private ColorAdjustments colorAdjustments;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        // Get references to effects
        if (PostProcessVolume!= null && PostProcessVolume.profile != null)
        {
            PostProcessVolume.profile.TryGet(out vignette);
            PostProcessVolume.profile.TryGet(out chromaticAberration);
            PostProcessVolume.profile.TryGet(out lensDistortion);
            PostProcessVolume.profile.TryGet(out colorAdjustments);
        }
    }

    void LateUpdate()
    {
        if (Player == null) return;

        // Base desired position
        Vector3 desiredPosition = new Vector3(
            Player.position.x + Offset.x,
            Player.position.y + Offset.y,
            Offset.z
        );

        // Smooth follow
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, SmoothSpeed);

        // Apply Sanity shake
        smoothedPosition += GetSanityShake();

        transform.position = smoothedPosition;

        // Apply Sanity visual effects
        ApplySanityEffects();
    }

    private Vector3 GetSanityShake()
    {
        float intensity = 0f;

        if (Sanity <= 70 && Sanity > 40) intensity = 0.05f;
        else if (Sanity <= 40 && Sanity > 15) intensity = 0.1f;
        else if (Sanity <= 15) intensity = 0.2f;

        if (intensity > 0f)
        {
            return new Vector3(
                Random.Range(-intensity, intensity),
                Random.Range(-intensity, intensity),
                0
            );
        }

        return Vector3.zero;
    }

    private void ApplySanityEffects()
    {
        float SanityFactor = (100 - Sanity) / 100f; // 0 = full Sanity, 1 = no Sanity

        if (vignette != null)
            vignette.intensity.value = Mathf.Lerp(0.2f, 0.6f, SanityFactor);

        if (chromaticAberration != null)
            chromaticAberration.intensity.value = Mathf.Lerp(0f, 1f, SanityFactor);

        if (lensDistortion != null)
            lensDistortion.intensity.value = Mathf.Lerp(0f, -0.2f, SanityFactor);

        if (colorAdjustments != null)
        {
            // Desaturate gradually (0 = full color, -100 = grayscale)
            colorAdjustments.saturation.value = Mathf.Lerp(0f, -100f, SanityFactor);

            // Optional: slight tint toward blue/green when low Sanity
            if (Sanity < 30)
                colorAdjustments.colorFilter.value = Color.Lerp(Color.white, new Color(0.8f, 0.9f, 1f), SanityFactor);
            else
                colorAdjustments.colorFilter.value = Color.white;
        }
    }
}

using UnityEngine;

public class BatSwing : MonoBehaviour
{
    [SerializeField] private Collider swingCollider;
    [SerializeField] private Transform shotDirection;
    [SerializeField] private float swingDuration = 0.22f;
    [SerializeField] private float timingWindow = 0.45f;
    [SerializeField] private MatchManager matchManager;

    private float swingStartedAt = -10f;
    private bool swinging;

    private void Start()
    {
        if (swingCollider == null) swingCollider = GetComponent<Collider>();
        if (swingCollider != null) swingCollider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Swing();

        if (swinging && Time.time - swingStartedAt >= swingDuration)
        {
            swinging = false;
            if (swingCollider != null) swingCollider.enabled = false;
        }
    }

    // Can be called by a Unity UI Button on Android.
    public void Swing()
    {
        if (swinging) return;
        swinging = true;
        swingStartedAt = Time.time;
        if (swingCollider != null) swingCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!swinging) return;

        CricketBall ball = other.GetComponent<CricketBall>();
        if (ball == null || ball.HasBeenHit) return;

        float elapsed = Time.time - swingStartedAt;
        float quality = 1f - Mathf.Clamp01(
            Mathf.Abs(elapsed - swingDuration * 0.5f) / timingWindow
        );

        Vector3 direction = shotDirection != null
            ? shotDirection.forward + Vector3.up * 0.35f
            : transform.forward + Vector3.up * 0.35f;

        ball.ApplyBatHit(direction, quality);
        if (matchManager != null) matchManager.RegisterHit(quality);
    }
}

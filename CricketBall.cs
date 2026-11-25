using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CricketBall : MonoBehaviour
{
    [SerializeField] private float hitForce = 18f;
    private Rigidbody body;
    private bool hasBeenHit;

    public bool HasBeenHit => hasBeenHit;

    private void Awake() => body = GetComponent<Rigidbody>();

    public void Launch(Vector3 velocity)
    {
        hasBeenHit = false;
        body.isKinematic = false;
        body.velocity = velocity;
        body.angularVelocity = Vector3.zero;
    }

    public void ApplyBatHit(Vector3 direction, float timingQuality)
    {
        if (hasBeenHit) return;

        hasBeenHit = true;
        float quality = Mathf.Clamp01(timingQuality);
        float power = hitForce * Mathf.Lerp(0.65f, 1.35f, quality);
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.AddForce(direction.normalized * power, ForceMode.VelocityChange);
        body.AddTorque(Random.insideUnitSphere * 3f, ForceMode.Impulse);
    }
}

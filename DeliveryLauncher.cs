using UnityEngine;

public class DeliveryLauncher : MonoBehaviour
{
    [SerializeField] private CricketBall ballPrefab;
    [SerializeField] private Transform releasePoint;
    [SerializeField] private Transform target;
    [SerializeField] private float deliverySpeed = 22f;
    [SerializeField] private MatchManager matchManager;

    private CricketBall currentBall;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) Bowl();
        if (Input.GetKeyDown(KeyCode.R)) ResetDelivery();
    }

    // Can be called by a Unity UI Button on Android.
    public void Bowl()
    {
        if (ballPrefab == null || releasePoint == null || target == null) return;
        ResetDelivery();

        currentBall = Instantiate(ballPrefab, releasePoint.position, Quaternion.identity);
        Vector3 direction = (target.position - releasePoint.position).normalized;
        currentBall.Launch(direction * deliverySpeed);

        if (matchManager != null) matchManager.RegisterDelivery();
    }

    public void ResetDelivery()
    {
        if (currentBall != null) Destroy(currentBall.gameObject);
    }
}

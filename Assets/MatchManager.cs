using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private int runs;
    [SerializeField] private int wickets;
    [SerializeField] private int legalBalls;

    public int Runs => runs;
    public int Wickets => wickets;
    public int LegalBalls => legalBalls;

    public void RegisterDelivery()
    {
        legalBalls++;
        Debug.Log($"Over: {legalBalls / 6}.{legalBalls % 6} | Score: {runs}/{wickets}");
    }

    public void RegisterHit(float timingQuality)
    {
        int awardedRuns = timingQuality >= 0.85f ? 4 : timingQuality >= 0.55f ? 2 : 1;
        runs += awardedRuns;
        Debug.Log($"Shot timing: {timingQuality:P0} | +{awardedRuns} runs | Score: {runs}/{wickets}");
    }

    public void RegisterWicket()
    {
        wickets++;
        Debug.Log($"WICKET! Score: {runs}/{wickets}");
    }

    public void ResetInnings()
    {
        runs = 0;
        wickets = 0;
        legalBalls = 0;
    }
}

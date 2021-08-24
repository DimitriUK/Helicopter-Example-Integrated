using UnityEngine;

public class CrashDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.EndGame(false, 0);
    }
}

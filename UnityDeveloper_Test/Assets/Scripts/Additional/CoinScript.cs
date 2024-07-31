using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private TimerScript timerScript;

    void Start()
    {
        timerScript = FindObjectOfType<TimerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.CollectCoin();
            Destroy(gameObject);
        }
    }
}

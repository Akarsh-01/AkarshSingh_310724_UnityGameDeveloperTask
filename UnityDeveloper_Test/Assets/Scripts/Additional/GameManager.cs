using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerScript timerScript;

    void Start()
    {
        if (timerScript == null)
        {
            timerScript = FindObjectOfType<TimerScript>();
        }
    }

    public void CollectCoin()
    {
        if (timerScript != null)
        {
            timerScript.CollectCoin();
        }
    }
}

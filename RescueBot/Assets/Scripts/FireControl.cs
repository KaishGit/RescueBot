using UnityEngine;

public class FireControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {        
            GameObject victim = collision.GetComponent<HookControl>().GetVictim();

            if ((victim != null))
            {
                victim.GetComponent<VictimControl>().Burn();
            }
        }

        if (collision.gameObject.CompareTag("Robot"))
        {
            collision.GetComponent<JumpControl>().Burn();
        }
    }
}
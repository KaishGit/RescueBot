using UnityEngine;

public class HookControl : MonoBehaviour
{
    private GameObject _victim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public bool HookVictim(GameObject victim)
    {
        if(_victim == null)
        {
            _victim = victim;

            if (victim.name.Contains("A") || victim.name.Contains("B"))
            {
                AudioManager.Instance.PlaySfxHelp();
            }
            else if (victim.name.Contains("C"))
            {
                AudioManager.Instance.PlaySfxCry();
            }
            else if (victim.name.Contains("D"))
            {
                AudioManager.Instance.PlaySfxBark();
            }

            return true;
        }

        return false;
    }

    public void DropVictim()
    {
        _victim = null;
    }

    public GameObject GetVictim()
    {
        return _victim;
    }
}
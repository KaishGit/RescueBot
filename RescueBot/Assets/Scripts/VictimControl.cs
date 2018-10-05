using UnityEngine;

public class VictimControl : MonoBehaviour
{
    private bool _isHooked;
    private bool _isSaved;
    public GameObject BurningPrefab;
    private GameObject _burning;
    private GameObject _hook;

    void Start()
    {

    }

    void Update()
    {
        if (_isHooked)
        {
            transform.position = _hook.transform.position;
            transform.rotation = _hook.transform.rotation;

            if (_burning != null)
            {
                _burning.transform.position = transform.position;
                //_burning.transform.rotation = transform.rotation;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isSaved && !_isHooked)
        {
            if (collision.gameObject.CompareTag("Hook"))
            {
                _hook = collision.gameObject;
                bool canHook = _hook.GetComponent<HookControl>().HookVictim(gameObject);

                if (canHook)
                {
                    _isHooked = true;
                }
            }
        }

        if (_isHooked)
        {
            if (collision.gameObject.CompareTag("Base"))
            {
                _isHooked = false;
                _isSaved = true;
                _hook.GetComponent<HookControl>().DropVictim();
                AudioManager.Instance.PlaySfxSaveVictim();
                GameManager.Instance.DescVictimNumber();
            }
        }

    }

    public void Burn()
    {
        _burning = Instantiate(BurningPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject, 2);
        Destroy(_burning, 2);
        _hook.GetComponent<HookControl>().DropVictim();

        if(GameManager.Instance.VictimNumber == 1)
        {
            GameManager.Instance.NotCelebrete = true;
        }

        GameManager.Instance.DescVictimNumber();
    }
}
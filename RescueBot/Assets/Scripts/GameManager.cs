using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int VictimNumber;
    public bool NotCelebrete;
    private bool _gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        if (VictimNumber == 0 && !_gameOver)
        {
            _gameOver = true;

            if (!NotCelebrete)
            {
                AudioManager.Instance.PlaySfxVictory();
            }

            StartCoroutine(WaitForRestart());
        }
    }

    public void DescVictimNumber()
    {
        VictimNumber--;
    }

    public void RobotDestroyed()
    {
        StartCoroutine(WaitForRestart());
    }

    private IEnumerator WaitForRestart()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
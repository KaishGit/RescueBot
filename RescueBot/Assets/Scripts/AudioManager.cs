using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    //Musica
    [SerializeField] AudioSource AudioSourceBackground;
    [SerializeField] AudioClip[] ClipsBackground;
    //SFX
    [SerializeField] AudioSource AudioSourceSFX;
    [SerializeField] AudioClip Impulse;
    [SerializeField] AudioClip Help;
    [SerializeField] AudioClip SaveVictim;
    [SerializeField] AudioClip Victory;


    [SerializeField] AudioClip Bark;
    [SerializeField] AudioClip Cry;
    [SerializeField] AudioClip VitoriaFase;
    [SerializeField] AudioClip DerrotaFase;
    [SerializeField] AudioClip BotaoUi;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        AudioSourceBackground.clip = ObterClipBackground();
        AudioSourceBackground.Play();
    }

    private AudioClip ObterClipBackground()
    {
        return ClipsBackground[Random.Range(0, ClipsBackground.Length)];
    }

    public void PlaySfxImpulse()
    {
        AudioSourceSFX.PlayOneShot(Impulse);
    }

    public void PlaySfxHelp()
    {
        AudioSourceSFX.PlayOneShot(Help);
    }

    public void PlaySfxSaveVictim()
    {
        AudioSourceSFX.PlayOneShot(SaveVictim);
    }

    public void PlaySfxVictory()
    {
        AudioSourceSFX.PlayOneShot(Victory);
    }


    public void PlaySfxBark()
    {
        AudioSourceSFX.PlayOneShot(Bark);
    }

    public void PlaySfxCry()
    {
        AudioSourceSFX.PlayOneShot(Cry);
    }

    public void PlaySfxVitoriaFase()
    {
        AudioSourceSFX.PlayOneShot(VitoriaFase);
    }

    public void PlaySfxDerrotaFase()
    {
        AudioSourceSFX.PlayOneShot(DerrotaFase);
    }

    public void PlaySfxBotaoUi()
    {
        AudioSourceSFX.PlayOneShot(BotaoUi);
    }

    public void PausarMusica()
    {
        AudioSourceBackground.Pause();
    }

    public void DespausarMusica()
    {
        AudioSourceBackground.Play();
    }
}
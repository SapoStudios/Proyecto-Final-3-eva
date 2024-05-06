// ---------------------------------------------------------------------------------
// SCRIPT PARA LA GESTI�N DE AUDIO (vinculado a un GameObject vac�o "AudioManager")
// ---------------------------------------------------------------------------------
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class AudioManager : MonoBehaviour
{

    
    // Instancia �nica del AudioManager (porque es una clase Singleton) STATIC
    public static AudioManager instance;

    // Se crean dos AudioSources diferentes para que se puedan
    // reproducir los efectos y la m�sica de fondo al mismo tiempo
    [Header("SFX")]
    [SerializeField]public GameObject sfxSource;
    [SerializeField]AudioSource sfx;// Componente AudioSource para efectos de sonido
    [SerializeField] public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    [Header("Music")]
    [SerializeField]public GameObject musicSource; // Componente AudioSource para la m�sica de fondo
    
    [SerializeField]AudioSource music;

    // En vez de usar un vector de AudioClips (que podr�a ser) vamos a utilizar un Diccionario
    // en el que cargaremos directamente los recursos desde la jerarqu�a del proyecto
    // Cada entrada del diccionario tiene una string como clave y un AudioClip como valor
    
   [SerializeField] public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    // M�todo Awake que se llama al inicio antes de que se active el objeto. �til para inicializar
    // variables u objetos que ser�n llamados por otros scripts (game managers, clases singleton, etc).
    private void Awake()
    {

        // ----------------------------------------------------------------
        // AQU� ES DONDE SE DEFINE EL COMPORTAMIENTO DE LA CLASE SINGLETON
        // Garantizamos que solo exista una instancia del AudioManager
        // Si no hay instancias previas se asigna la actual
        // Si hay instancias se destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        // ----------------------------------------------------------------

        // No destruimos el AudioManager aunque se cambie de escena
        DontDestroyOnLoad(gameObject);

        // Cargamos los AudioClips en los diccionarios
        LoadSFXClips();
        LoadMusicClips();

    }

    // M�todo privado para cargar los efectos de sonido directamente desde las carpetas
    private void LoadSFXClips()
    {
        // Los recursos (ASSETS) que se cargan en TIEMPO DE EJECUCI�N DEBEN ESTAR DENTRO de una carpeta denominada /Assets/Resources/SFX
        sfxClips["shotp"] = Resources.Load<AudioClip>("SFX/shotp");
        sfxClips["shotas"] = Resources.Load<AudioClip>("SFX/shotas");
        sfxClips["explosion"] = Resources.Load<AudioClip>("SFX/explosion");
        sfxClips["lose"] = Resources.Load<AudioClip>("SFX/lose");
        sfxClips["win"] = Resources.Load<AudioClip>("SFX/win");
    }

    // M�todo privado para cargar la m�sica de fondo directamente desde las carpetas
    private void LoadMusicClips()
    {
        // Los recursos (ASSETS) que se cargan en TIEMPO DE EJECUCI�N DEBEN ESTAR DENTRO de una carpeta denominada /Assets/Resources/Music
        musicClips["main"] = Resources.Load<AudioClip>("Music/main");
    }

    // M�todo de la clase singleton para reproducir efectos de sonido
    public void PlaySFX(string clipName)
    {
        if (sfxClips.ContainsKey(clipName))
        {
            sfx = sfxSource.AddComponent<AudioSource>();
            sfx.clip = sfxClips[clipName];
            sfx.Play();
            float tiempo = sfx.clip.length;
            StartCoroutine(borrarSourceSFX(tiempo));

        }
        else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de sfxClips.");
    }

    // M�todo de la clase singleton para reproducir m�sica de fondo
    public void PlayMusic(string clipName)
    {
         if (musicClips.ContainsKey(clipName))
        {
            music = musicSource.AddComponent<AudioSource>();
            music.clip = musicClips[clipName];
            music.Play();
            music.loop = true;

        }
        else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de musicClips.");
    }

    IEnumerator borrarSourceSFX(float tiempo)
    {
        AudioSource borrarsfx = sfx;
        yield return new WaitForSeconds(tiempo);
        
        Destroy(borrarsfx);
        StopCoroutine("borrarSourceSFX");
    }
    IEnumerator borrarSourceMusic(float tiempo)
    {
        AudioSource borrarsfx = sfx;
        yield return new WaitForSeconds(tiempo);

        Destroy(borrarsfx);

        StopCoroutine("borrarSourceSFX");
    }
}

using UnityEngine;

public class PDSensor : MonoBehaviour
{
    //[Header("Estos coeficientes sirven para agrandar el objeto para saber que está funcionando")]
    //public int upScaleCoeficient;
    //public int downScaleCoeficient;

    public LibPdInstance pdPatch;

    //public GameObject cylinder;
    public AudioSource PDSound;

    public float Speed;

    [Range(0,1)]
    [Header("Volumen de inicio del AudioSource")]
    public float startVolume;

    public static PDSensor instance;

    // Cada vez que iniciemos haremos que la instancia sea el pdSensor de la escena
    private void Awake() {
        instance = this;
        GetComponent<AudioSource>().volume = 0.3f;// 0.5f;
    }

    // Nota: No se sabe quien llama a los métodos

    //public void VolumenUp()
    //{
    //    PDSound.volume += Time.deltaTime * Speed;
    //}

    public void SoundUp()
    {
        // Se agranda solamente para saber que está funcionando
        //cylinder.transform.localScale = new Vector3(upScaleCoeficient, upScaleCoeficient, upScaleCoeficient) * Time.deltaTime;
        pdPatch.SendFloat("proximity", 2);
    }

    //public void increaseUp()
    //{
    //    upScaleCoeficient++;
    //}

    public void SoundDown() 
    {
        //cylinder.transform.localScale = new Vector3(downScaleCoeficient, downScaleCoeficient, downScaleCoeficient) * Time.deltaTime;
        pdPatch.SendFloat("proximity", 1);
    }


}

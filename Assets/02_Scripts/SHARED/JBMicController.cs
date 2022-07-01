using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JBMicController : MonoBehaviour
{
    public static JBMicController instance;

    [Range(-5, 5)]
    public float mThreshold = 2.5f;

    private AudioClip mAudioStream = null;
    private Coroutine mCurrentSmoke = null;

    [Header("Indicar nombre del microfono en el sistema operativo")]
    public string micName;

    [Header("Nombres de los microfonos, para no buscarlos continuamente")]
    public string jbMicName;
    public string VRMicName;
    public string HeadphonesBTName;

    void Awake() {

        if (instance == null) {
            instance = this;
        }

        #region Devices
        List<string> mMicrophones = new List<string>();

        mMicrophones.AddRange(Microphone.devices);

        Debug.Log("Available Devices: ");

        foreach (string deviceName in mMicrophones)
            print(deviceName);
        #endregion

        #region Frequencies
        int minimum = 0;
        int maximum = 0;
        
        Microphone.GetDeviceCaps(micName, out minimum, out maximum);

        print("Minimum: " + minimum);
        print("Maximum: " + maximum);
        #endregion
    }

    void Start() {
        // 44.1 kHz per second
        mAudioStream = Microphone.Start(micName, true, 3, 44100);

    }

    private void Update() {
        if (TestForAudioInput()) {
            RvInputs.mic_Input = true;
        }
        else {
            RvInputs.mic_Input = false;
        }
    }

    public bool TestForAudioInput() {
        // Set the max amount of samples, which will be 44100
        int length = mAudioStream.samples * mAudioStream.channels;
        float[] samples = new float[length];

        // Get the data
        mAudioStream.GetData(samples, 0);

        // Average 
        float averageSample = samples.Average() * 10000;

        // If within threshold
        bool isInput = averageSample < mThreshold ? true : false;

        if (isInput) { Debug.Log("Input de microfono detectado!"); }
        else { Debug.Log("Input de microfono NO detectado"); }

        return isInput;
    }

    private void TestAudio() {
        while (!(Microphone.GetPosition(micName) > 0)) {
            // Wait
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = mAudioStream;
        audioSource.Play();
    }
}

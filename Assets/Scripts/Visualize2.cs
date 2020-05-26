using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Visualize2 : MonoBehaviour
{
    //Micro input
    public AudioClip audioClip;
    public bool useMic;
    public string selectedDevice;
    public AudioMixerGroup mixerMic, mixerMaster;

    public Toggle toggle;
    public Slider slider;
    public AudioSource _audioSource;
    private float maxFrequence;

    public static float[] samples = new float[512];

    float[] freqBand = new float[8];
    float[] bandBuffer = new float[8];

    
    float[] freqBandHighest = new float[8];
    private float[] bufferDecrease = new float[8];

    public static float[] audioBandBuffer = new float[8];
    public static float[] audioBand = new float[8];

    public static float amplitude, amplitudeBuffer;
    float amplitudeHighest;

    void Start () {
        _audioSource = GetComponent<AudioSource>();

        string[] mics = Microphone.devices;
        selectedDevice = Microphone.devices[0].ToString();

        if(useMic){
            _audioSource.outputAudioMixerGroup = mixerMic;
            StartMicListener();
        } else {
            _audioSource.outputAudioMixerGroup = mixerMaster;
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }
	
	
	void Update () {
        if(useMic)
            _audioSource.outputAudioMixerGroup = mixerMic;
        else
            _audioSource.outputAudioMixerGroup = mixerMaster;

        if(slider != null)
            maxFrequence = slider.value;
        else
            maxFrequence = 4;

        CheckToggle();
        if(!_audioSource.isPlaying)
            StartMicListener();

        GetSpectrumAS();
        MakeFreqBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }

    void CheckToggle(){
        if(toggle == null)
            return;
        if(toggle.isOn && !useMic){
            _audioSource.Stop();
            useMic = true;
        } else if(!toggle.isOn && useMic){
            useMic = false;
            _audioSource.Stop();
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    }

    void StartMicListener(){
        _audioSource.clip = Microphone.Start(selectedDevice, true, 10, AudioSettings.outputSampleRate);
        while(!(Microphone.GetPosition(selectedDevice) > 0)){}
        _audioSource.Play();
    }

    //get frequency data
    void GetSpectrumAS()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    //devides the frequency spectrum into 8 parts
    void MakeFreqBands()
    {
        int count = 0;
       
        for (int i = 0; i < 8; i++)
        {
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            float average = 0;

            if (i == 7)
            {
                sampleCount += 2;
            }

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }

            average /= count;
            freqBand[i] = average * 10;
        }
    }

    //creates buffer value and smooths out the movement
    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if(freqBand [i] > bandBuffer[i])
            {
                bandBuffer[i] = freqBand[i];
                bufferDecrease [i]= 0.005f;
            }

            if (freqBand[i] < bandBuffer[i])
            {
                bandBuffer[i] -= freqBand[i];
                bufferDecrease[i] *= 1.2f;
            }

        }
    }

    //turns output to value 0-1
    void CreateAudioBands()
    {
        for (int i = 0; i<8; i++)
        {
            freqBandHighest[i] = maxFrequence;
            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void GetAmplitude(){
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;
        for (int i = 0; i < 8; i++)
        {
            currentAmplitude += audioBand[i];
            currentAmplitudeBuffer += audioBandBuffer[i];
        }
        amplitudeHighest = maxFrequence;
        
        amplitude = currentAmplitude / amplitudeHighest;
        amplitudeBuffer = currentAmplitudeBuffer / amplitudeHighest;

    }

}



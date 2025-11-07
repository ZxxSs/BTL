/*
Code nhận/chuyển đổi âm thanh thành hình ảnh
*/
using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class MicInput : MonoBehaviour
{
    public GameObject but;
    public TextMeshProUGUI text;
    public TextMeshProUGUI vT;
    public int sampleWindow = 64;
    public float mutx;
    private AudioClip microphoneClip;
    public float sen;
    public float duocTao;
    public float rate;
    public int n;
    private bool s;
    public SpriteRenderer[] sp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MicToClip();
    }
    public void MicToClip()
    {
        string mic = Microphone.devices[0];
        microphoneClip = Microphone.Start(mic, true, 20, AudioSettings.outputSampleRate);
    }
    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
            return 0;

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //compute loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness ;
    }


    // Update is called once per frame
    private void Update()
    {
        AudioSource source = GetComponent<AudioSource>();
        float CurrentVolume = GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip) * mutx;
        if (Time.time > duocTao&&s)
        {
            if (n >= sp.Length)
            {
                n = 0;
                s = false;
                return;
            }
            duocTao = Time.time + rate;
            if (CurrentVolume > sen)
            {
                sp[n].color = Color.black;
            }
            else
            {
                sp[n].color = Color.white;
            }

            n++;
        }
        vT.text=(int)CurrentVolume+"/"+sen;
    }
    public void BatDau()
    {
        StartCoroutine(StartR());
    }
    IEnumerator StartR()
    {
        but.SetActive(false);
        text.gameObject.SetActive(true);
        text.text = "3";
        yield return new WaitForSeconds(1);
        text.text = "2";
        yield return new WaitForSeconds(1);
        text.text = "1";
        yield return new WaitForSeconds(1);
        text.gameObject.SetActive(false);
        yield return new WaitForSeconds(rate);
        s = true;

    }
    public void ChangeS(int id)
    {
        SceneManager.LoadScene(id);
    }
}

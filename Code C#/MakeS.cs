using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MakeS : MonoBehaviour
{
    public But[] b;
    public AudioClip clip;
    private AudioSource auS;
    public float duocTao;
    public bool s;
    public int n;
    public float rate;
    public GameObject but;
    public GameObject target;
    public TextMeshProUGUI text;
    void Start()
    {
        auS=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > duocTao && s)
        {
            if (n >= b.Length)
            {
                n = 0;
                s = false;
                auS.Pause();
                target.SetActive(false);
                but.SetActive(true);
                return;
            }
            duocTao = Time.time + rate;
            target.transform.position = b[n].transform.position;
            if (b[n].on)
                auS.Play();
            else 
                auS.Pause();

            n++;
            
                
        }
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
        s = true;
        target.SetActive(true);
    }
    public void ChangeS(int id)
    {
        SceneManager.LoadScene(id);
    }
}

/*
Code làm chuyển màu nút sau khi bấm
*/
using UnityEngine;

public class But : MonoBehaviour
{
    public bool on;
    private SpriteRenderer sp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {

        if (on)
        {
            on = false;
            sp.color = Color.white;
        }
        else
        {
            on = true;
            sp.color = Color.black;
        }
    }
}

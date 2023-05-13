using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI statusText;
    // Start is called before the first frame update
    void Start()
    {
        statusText.text = "You scored "+GameManager.instance.score.ToString()+" kills!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

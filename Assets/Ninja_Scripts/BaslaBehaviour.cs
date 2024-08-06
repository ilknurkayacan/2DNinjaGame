using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaslaBehaviour : MonoBehaviour
{
    
    public void Basla()
    {
        SceneManager.LoadScene("SePart");
    }
    public void Baslailk()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

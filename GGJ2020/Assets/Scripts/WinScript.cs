using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public Enum.Player player;
    public float delayAfterWin = 4; 
    public Image win;

    public void Start()
    {
        win.enabled = false;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster") && player == other.gameObject.GetComponent<MonsterSystem>().player)
        {
            win.enabled = true;
            Invoke("ReloadMenu", delayAfterWin);
        }
    }

    private void ReloadMenu()
    {
        SceneManager.LoadScene(0);
    }
}

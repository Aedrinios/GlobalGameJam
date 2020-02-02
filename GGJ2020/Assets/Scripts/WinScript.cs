using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public Enum.Player player;
    public Image win;

    public void Start()
    {
        win.enabled = false;    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("y a pas moyen");
        if (other.CompareTag("Monster") && player == other.gameObject.GetComponent<MonsterSystem>().player)
        {
            win.enabled = true;
            Invoke("ReloadMenu", 2);
        }
    }

    private void ReloadMenu()
    {
        SceneManager.LoadScene(0);
    }
}

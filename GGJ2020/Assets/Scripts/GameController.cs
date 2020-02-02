using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioManager music;

	private void Start()
	{
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        music.PlayMusic();
	}
}

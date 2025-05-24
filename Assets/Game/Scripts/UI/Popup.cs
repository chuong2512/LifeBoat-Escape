using UnityEngine;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour
{
	[SerializeField] private AudioClip thudClip;
	[SerializeField] private AudioClip loseClip;
	[SerializeField] private AudioClip tapClip;

	private AudioSource audioSource;

	private void Awake() { audioSource=gameObject.AddComponent<AudioSource>(); }

	public void PlayThud()     { audioSource.PlayOneShot(thudClip); }
	public void PlayLose()     { audioSource.PlayOneShot(loseClip); }
	public void GoToMainMenu() { Game.Manager.OpenMainMenu(); }
	public void RestartLevel()
	{
		audioSource.PlayOneShot(tapClip);
		Game.Manager.StartGame();
	}

	public void NextLevel()
	{
		if(GameDataManager.Instance.playerData.intDiamond>=100)
		{
			GameDataManager.Instance.playerData.SubDiamond(100);
			LevelController.Instance.NextLevel();
			RestartLevel();
		}
	}
}

//This source code is originally bought from www.codebuysell.com
// Visit www.codebuysell.com
//
//Contact us at:
//
//Email : admin@codebuysell.com
//Whatsapp: +15055090428
//Telegram: t.me/CodeBuySellLLC
//Facebook: https://www.facebook.com/CodeBuySellLLC/
//Skype: https://join.skype.com/invite/wKcWMjVYDNvk
//Twitter: https://x.com/CodeBuySellLLC
//Instagram: https://www.instagram.com/codebuysell/
//Youtube: http://www.youtube.com/@CodeBuySell
//LinkedIn: www.linkedin.com/in/CodeBuySellLLC
//Pinterest: https://www.pinterest.com/CodeBuySell/

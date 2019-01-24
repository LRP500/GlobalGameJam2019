using UnityEngine;

namespace MonoBehaviors.UI.Navigation
{
	/// <inheritdoc/>
	/// <summary>
	/// Responsible for clean exit of application
	/// </summary>
	public class ApplicationQuit : MonoBehaviour
	{
		/// <summary>
		/// Passed to main title exit button 
		/// </summary>
		public void ExitToDesktop()
		{
		#if UNITY_EDITOR
			Debug.Log("Application.Quit()");
		#else
			Application.Quit();
		#endif
		}
	}
}

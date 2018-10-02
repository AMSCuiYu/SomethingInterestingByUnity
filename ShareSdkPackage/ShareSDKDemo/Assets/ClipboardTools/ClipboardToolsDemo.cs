using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClipboardToolsDemo : MonoBehaviour 
{
	public Text Con;

	public Text input;
	public Text output;

	public Button Copy;
	public Button Paste;

	public void SetClipboardContent()
	{
		ClipboardTools.SetClipboardContent(input.text);
		Con.text = "Success";
	}

	public void GetClipboardContent()
	{
		output.text = ClipboardTools.GetClipboardContent();
		Con.text = "Success";
	}
}

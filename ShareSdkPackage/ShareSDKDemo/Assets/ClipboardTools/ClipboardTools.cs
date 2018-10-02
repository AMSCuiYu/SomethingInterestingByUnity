using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipboardTools : MonoBehaviour 
{
    #if UNITY_ANDROID
    static AndroidJavaObject androidObject;
    static AndroidJavaObject activity;

    #elif UNITY_IPHONE
        [DllImport ("__Internal")]
        private static extern void _copyTextToClipboard(string text);
        [DllImport("__Internal")]
        private static extern string _GetClipboardText();
    #endif

    private void Awake()
    {
        #if UNITY_ANDROID
        androidObject = new AndroidJavaObject("ClipboardTools");     
        activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        #elif UNITY_IPHONE

        #endif
    }


    #if UNITY_EDITOR
    static TextEditor te;
    #endif
    public static void SetClipboardContent(string content)
    {
        #if UNITY_ANDROID
        if (activity == null) return;
        //复制到剪贴板
        androidObject.Call("copyTextToClipboard", activity, content);

        #elif UNITY_IPHONE

        _copyTextToClipboard(content);

        #elif UNITY_EDITOR
        te = new TextEditor();
        te.text = content;
        //te.OnFocus();
        //te.Copy();
        #endif
    }

    public static string GetClipboardContent()
    {
        #if UNITY_ANDROID
        //从剪贴板中获取文本
        String text =androidObject.Call<String>("getTextFromClipboard");
        return text;

        #elif UNITY_IPHONE
        return _GetClipboardText();

        #elif UNITY_EDITOR
        return te.text;
        #endif
    }
}

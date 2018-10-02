using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cn.sharesdk.unity3d;
using System;
using UnityEngine.UI;
using System.IO;

public class Share : MonoBehaviour 
{
	private static ShareSDK shareSDK;
    
    public Text ConsoleText;

	void Start()
	{
		shareSDK = GetComponent<ShareSDK>();
		shareSDK.authHandler = authResulHandler;                  
		shareSDK.followFriendHandler = followFriendResultHandler; 
		shareSDK.getFriendsHandler = getFrinendsResultHandler;
		shareSDK.shareHandler = shareResultHandler;
		shareSDK.showUserHandler = showUserResultHandler;

        
	}


	#region 回调函数
    private void authResulHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            ConsoleText.text = "Success";
            
        }
        else if(state == ResponseState.Fail)
        {
            ConsoleText.text = "Fail";
        }
        else if(state == ResponseState.Cancel)
        {
            ConsoleText.text = "Cancel";
        }
    }

    private void followFriendResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            ConsoleText.text = "Success";
        }
        else if(state == ResponseState.Fail)
        {
            ConsoleText.text = "Fail";
        }
        else if(state == ResponseState.Cancel)
        {
            ConsoleText.text = "Cancel";
        }
    }

    private void getFrinendsResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            ConsoleText.text = "Success";
        }
        else if(state == ResponseState.Fail)
        {
            ConsoleText.text = "Fail";
        }
        else if(state == ResponseState.Cancel)
        {
            ConsoleText.text = "Cancel";
        }
    }

    private void shareResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            ConsoleText.text = "Success";
        }
        else if(state == ResponseState.Fail)
        {
            ConsoleText.text = "Fail";
        }
        else if(state == ResponseState.Cancel)
        {
            ConsoleText.text = "Cancel";
        }
    }

    private void showUserResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            ConsoleText.text = "Success";
        }
        else if(state == ResponseState.Fail)
        {
            ConsoleText.text = "Fail";
        }
        else if(state == ResponseState.Cancel)
        {
            ConsoleText.text = "Cancel";
        }
    }
	#endregion

    #region 成员
    ///<summary>
    ///授权QQ。
    ///</summary>
    public void QQLogic()
    {
        shareSDK.Authorize(PlatformType.QQ);
    }

    /// <summary>
    /// 取消授权QQ。
    /// </summary>
    public void QQCancelAuthorize()
    {
        shareSDK.CancelAuthorize(PlatformType.QQ);
    }

    /// <summary>
    /// 得到QQ授权信息。
    /// </summary>
    /// <returns></returns>
    public Hashtable QQGetAuthInfo()
    {
        return shareSDK.GetAuthInfo(PlatformType.QQ);
    }

    /// <summary>
    /// 添加QQ好友。
    /// </summary>
    /// <param name="account">账号</param>
    public void QQAddFriend(string account)
    {
        shareSDK.AddFriend(PlatformType.QQ, account);
    }

    /// <summary>
    /// 得到qq好友列表
    /// </summary>
    /// <param name="count">每页的数量</param>
    /// <param name="page">页数</param>
    public void QQGetFriendList(int count, int page)
    {
        shareSDK.GetFriendList(PlatformType.QQ, count, page);
    }

    /// <summary>
    /// 得到用户信息。
    /// </summary>
    /// <returns></returns>
    public void QQGetUserInfo()
    {
        shareSDK.GetUserInfo(PlatformType.QQ);
    }

    /// <summary>
    /// 截屏并分享。
    /// </summary>
    /// <param name="title">分享的标题</param>
    /// <param name="content">分享的文字内容</param>
    public void QQScreenshotAndShare(string title, string content)
    {
        ScreenCapture.CaptureScreenshot("Screenshot");
        ShareContent shareContent = new ShareContent();
        shareContent.SetTitle(title);
        shareContent.SetText(content);
        shareContent.SetImageUrl("Screenshot");
        try
        {
            File.Delete(Application.dataPath + @"\Screenshot");
            ConsoleText.text = "ShareSuccess";
        }
        catch(Exception ex)
        {
            ConsoleText.text = ex.Message;
        }

        shareSDK.ShareContent(PlatformType.QQ, shareContent);

    }

    #endregion
}

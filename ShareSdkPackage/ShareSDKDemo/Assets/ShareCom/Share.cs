using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cn.sharesdk.unity3d;
using System;

public class Share : MonoBehaviour 
{
	private static ShareSDK shareSDK;

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
            Debug.Log("Success");
        }
        else if(state == ResponseState.Fail)
        {
            Debug.Log("Fail");
        }
        else if(state == ResponseState.Cancel)
        {
            Debug.Log("Cancel");
        }
    }

    private void followFriendResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            Debug.Log("Success");
        }
        else if(state == ResponseState.Fail)
        {
            Debug.Log("Fail");
        }
        else if(state == ResponseState.Cancel)
        {
            Debug.Log("Cancel");
        }
    }

    private void getFrinendsResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            Debug.Log("Success");
        }
        else if(state == ResponseState.Fail)
        {
            Debug.Log("Fail");
        }
        else if(state == ResponseState.Cancel)
        {
            Debug.Log("Cancel");
        }
    }

    private void shareResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            Debug.Log("Success");
        }
        else if(state == ResponseState.Fail)
        {
            Debug.Log("Fail");
        }
        else if(state == ResponseState.Cancel)
        {
            Debug.Log("Cancel");
        }
    }

    private void showUserResultHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        if(state == ResponseState.Success)
        {
            Debug.Log("Success");
        }
        else if(state == ResponseState.Fail)
        {
            Debug.Log("Fail");
        }
        else if(state == ResponseState.Cancel)
        {
            Debug.Log("Cancel");
        }
    }
	#endregion

    #region 静态成员
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
    public static void QQCancelAuthorize()
    {
        shareSDK.CancelAuthorize(PlatformType.QQ);
    }

    /// <summary>
    /// 得到QQ授权信息。
    /// </summary>
    /// <returns></returns>
    public static Hashtable QQGetAuthInfo()
    {
        return shareSDK.GetAuthInfo(PlatformType.QQ);
    }

    /// <summary>
    /// 添加QQ好友。
    /// </summary>
    /// <param name="account">账号</param>
    public static int QQAddFriend(string account)
    {
        return shareSDK.AddFriend(PlatformType.QQ, account);
    }

    /// <summary>
    /// 得到qq好友列表
    /// </summary>
    /// <param name="count">每页的数量</param>
    /// <param name="page">页数</param>
    public static int QQGetFriendList(int count, int page)
    {
        return shareSDK.GetFriendList(PlatformType.QQ, count, page);
    }

    /// <summary>
    /// 得到用户信息。
    /// </summary>
    /// <returns></returns>
    public static int QQGetUserInfo()
    {
        return shareSDK.GetUserInfo(PlatformType.QQ);
    }



    #endregion
}

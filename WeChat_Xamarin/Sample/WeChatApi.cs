using System;
using Foundation;
using UIKit;
using WeChat;

namespace Sample
{
    public class WeChatApi : WXApiDelegate
    {
        /// <summary>
        /// 当前Api版本号
        /// </summary>
        /// <value>The current version.</value>
        public string CurrentVersion => WXApi.ApiVersion;

        /// <summary>
        /// 检查微信是否安装
        /// </summary>
        /// <value><c>true</c> if WXI nstalled; otherwise, <c>false</c>.</value>
        public bool WXInstalled => WXApi.IsWXAppInstalled;

        /// <summary>
        /// 注册微信sdk
        /// </summary>
        public bool Register(string appId)
        {
            return WXApi.RegisterApp(appId);
        }

        /// <summary>
        /// Sends the auth request.
        /// </summary>
        public bool SendAuthRequest(string scope, string state)
        {
            SendAuthReq req = new SendAuthReq()
            {
                Scope = scope,
                State = state
            };
            return WXApi.SendReq(req);
        }

        /// <summary>
        /// 微信链接打开
        /// </summary>
        /// <param name="url">URL.</param>
        public bool OpenUrl(NSUrl url)
        {
            return WXApi.HandleOpenURL(url, this);
        }

        /// <summary>
        /// 发送信息到朋友圈
        /// </summary>
        /// <param name="text">消息内容.</param>
        /// <param name="scene">发送场景(可以选择发送到会话(Session), 朋友圈(Timeline), 收藏(Favorite), 指定联系人(SpecifiedSession)。 默认发送到会话)</param>
        public bool SendText(string text, int scene = 0)
        {
            SendMessageToWXReq req = new SendMessageToWXReq()
            {
                Text = text,
                BText = true,
                Scene = scene
            };
            return WXApi.SendReq(req);
        }

        /// <summary>
        /// 请求打开微信。
        /// </summary>
        /// <param name="req">Req.</param>
        public override void OnReq(BaseReq req)
        {

        }

        /// <summary>
        /// 响应微信。
        /// </summary>
        /// <param name="resp">Resp.</param>
        public override void OnResp(BaseResp resp)
        {
            if(resp.ErrCode == 0)
            {
                if(resp is SendMessageToWXResp)
                {
                    System.Diagnostics.Debug.WriteLine("iOS wechat onResp share success");
                }
                else if (resp is SendAuthResp)
                {
                    System.Diagnostics.Debug.WriteLine("iOS wechat onResp auth");
                }
                else if (resp is PayResp)
                {
                    System.Diagnostics.Debug.WriteLine("iOS wechat onResp pay success");

                }
            }
            else
            {
                if (resp is PayResp)
                {
                    System.Diagnostics.Debug.WriteLine("iOS wechat onResp pay failed");

                }
            }
        }
    }
}

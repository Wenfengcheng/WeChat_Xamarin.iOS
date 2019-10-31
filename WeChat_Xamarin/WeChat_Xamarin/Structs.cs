using System;
using ObjCRuntime;

namespace WeChat
{
    /// <summary>
    /// 错误码
    /// </summary>
    public enum WXErrCode
    {
        Success = 0,    /**< 成功    */
        Common = -1,   /**< 普通错误类型    */
        UserCancel = -2,   /**< 用户点击取消并返回    */
        SentFail = -3,   /**< 发送失败    */
        AuthDeny = -4,   /**< 授权失败    */    
        Unsupport = -5,   /**< 微信不支持    */
    }

    /// <summary>
    /// 请求发送场景
    /// </summary>
    public enum WXScene : uint
    {
        Session = 0,   /**< 聊天界面    */
        Timeline = 1,   /**< 朋友圈     */
        Favorite = 2,   /**< 收藏       */
        SpecifiedSession = 3,   /**< 指定联系人  */
    }
        
    public enum WXAPISupport : uint
    {
        WXAPISupportSession = 0
    }

    /// <summary>
    /// 跳转profile类型
    /// </summary>
    public enum WXBizProfileType : uint
    {
        Normal = 0,    //**< 普通公众号  */
        Device = 1,    //**< 硬件公众号  */
    }

    /// <summary>
    /// 分享小程序类型
    /// </summary>
    public enum WXMiniProgramType : ulong
    {
        Release = 0,       //**< 正式版  */
        Test = 1,        //**< 开发版  */
        Preview = 2,         //**< 体验版  */
    }

    /// <summary>
    /// 跳转mp网页类型
    /// </summary>
    public enum WXMPWebviewType : uint
    {
        Ad = 0,        /**< 广告网页 **/
    }

    /// <summary>
    /// log的级别
    /// </summary>
    [Native]
    public enum WXLogLevel : long
    {
        Normal = 0, // 打印日常的日志
        Detail = 1  // 打印详细的日志
    }

    /// <summary>
    /// Auth error code.
    /// </summary>
    public enum AuthErrCode
    {
        Ok = 0,  //Auth成功
        NormalErr = -1,  //普通错误
        NetworkErr = -2, //网络错误
        GetQrcodeFailed = -3,    //获取二维码失败
        Cancel = -4,     //用户取消授权
        Timeout = -5,    //超时
    }
}

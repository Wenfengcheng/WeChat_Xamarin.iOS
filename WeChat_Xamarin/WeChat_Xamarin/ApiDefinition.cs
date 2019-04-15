using Foundation;
using ObjCRuntime;
using UIKit;

namespace WeChat
{
    /// <summary>
    /// 打印回调的block
    /// </summary>
    // typedef void (^WXLogBolock)(NSString *);
    delegate void WXLogBolock(string arg0);

    /// <summary>
    /// 该类为微信终端SDK所有请求类的基类
    /// </summary>
    // @interface BaseReq : NSObject
    [BaseType(typeof(NSObject))]
    interface BaseReq
    {
        /** 请求类型 */
        // @property (assign, nonatomic) int type;
        [Export("type")]
        int Type { get; set; }

        /** 由用户微信号和AppID组成的唯一标识，发送请求时第三方程序必须填写，用于校验微信用户是否换号登录*/
        // @property (retain, nonatomic) NSString * openID;
        [Export("openID", ArgumentSemantic.Retain)]
        string OpenID { get; set; }
    }

    /// <summary>
    /// 该类为微信终端SDK所有响应类的基类
    /// </summary>
    // @interface BaseResp : NSObject
    [BaseType(typeof(NSObject))]
    interface BaseResp
    {
        /** 错误码 */
        // @property (assign, nonatomic) int errCode;
        [Export("errCode")]
        int ErrCode { get; set; }

        /** 错误提示字符串 */
        // @property (retain, nonatomic) NSString * errStr;
        [Export("errStr", ArgumentSemantic.Retain)]
        string ErrStr { get; set; }

        /** 响应类型 */
        // @property (assign, nonatomic) int type;
        [Export("type")]
        int Type { get; set; }
    }

    /// <summary>
    /// 第三方向微信终端发起支付的消息结构体
    /// </summary>
    // @interface PayReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface PayReq
    {
        /** 商家向财付通申请的商家id */
        // @property (retain, nonatomic) NSString * partnerId;
        [Export("partnerId", ArgumentSemantic.Retain)]
        string PartnerId { get; set; }

        /** 预支付订单 */
        // @property (retain, nonatomic) NSString * prepayId;
        [Export("prepayId", ArgumentSemantic.Retain)]
        string PrepayId { get; set; }

        /** 随机串，防重发 */
        // @property (retain, nonatomic) NSString * nonceStr;
        [Export("nonceStr", ArgumentSemantic.Retain)]
        string NonceStr { get; set; }

        /** 时间戳，防重发 */
        // @property (assign, nonatomic) UInt32 timeStamp;
        [Export("timeStamp")]
        uint TimeStamp { get; set; }

        /** 商家根据财付通文档填写的数据和签名 */
        // @property (retain, nonatomic) NSString * package;
        [Export("package", ArgumentSemantic.Retain)]
        string Package { get; set; }

        /** 商家根据微信开放平台文档对数据做的签名 */
        // @property (retain, nonatomic) NSString * sign;
        [Export("sign", ArgumentSemantic.Retain)]
        string Sign { get; set; }
    }

    /// <summary>
    /// 微信终端返回给第三方的关于支付结果的结构体
    /// </summary>
    // @interface PayResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface PayResp
    {
        /** 财付通返回给商家的信息 */
        // @property (retain, nonatomic) NSString * returnKey;
        [Export("returnKey", ArgumentSemantic.Retain)]
        string ReturnKey { get; set; }
    }

    /// <summary>
    /// 第三方向微信终端发起离线支付
    /// </summary>
    // @interface WXOfflinePayReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXOfflinePayReq
    {
    }

    /// <summary>
    /// 第三方向微信终端发起离线支付返回
    /// </summary>
    // @interface WXOfflinePayResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXOfflinePayResp
    {
    }

    /// <summary>
    /// 第三方程序要向微信申请认证，并请求某些权限，需要调用WXApi的sendReq成员函数，向微信终端发送一个SendAuthReq消息结构。微信终端处理完后会向第三方程序发送一个处理结果。
    /// </summary>
    // @interface SendAuthReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface SendAuthReq
    {
        // @property (retain, nonatomic) NSString * scope;
        [Export("scope", ArgumentSemantic.Retain)]
        string Scope { get; set; }

        /** 第三方程序本身用来标识其请求的唯一性，最后跳转回第三方程序时，由微信终端回传。*/
        // @property (retain, nonatomic) NSString * state;
        [Export("state", ArgumentSemantic.Retain)]
        string State { get; set; }
    }

    /// <summary>
    /// 微信处理完第三方程序的认证和权限申请后向第三方程序回送的处理结果。
    /// </summary>
    // @interface SendAuthResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface SendAuthResp
    {
        // @property (retain, nonatomic) NSString * code;
        [Export("code", ArgumentSemantic.Retain)]
        string Code { get; set; }

        // @property (retain, nonatomic) NSString * state;
        [Export("state", ArgumentSemantic.Retain)]
        string State { get; set; }

        // @property (retain, nonatomic) NSString * lang;
        [Export("lang", ArgumentSemantic.Retain)]
        string Lang { get; set; }

        // @property (retain, nonatomic) NSString * country;
        [Export("country", ArgumentSemantic.Retain)]
        string Country { get; set; }
    }

    // @interface SendMessageToWXReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface SendMessageToWXReq
    {
        /**     发送消息的文本内容   */
        // @property (retain, nonatomic) NSString * text;
        [Export("text", ArgumentSemantic.Retain)]
        string Text { get; set; }

        /**     发送消息的多媒体内容   */
        // @property (retain, nonatomic) WXMediaMessage * message;
        [Export("message", ArgumentSemantic.Retain)]
        WXMediaMessage Message { get; set; }

        /**     发送消息的类型，包括文本消息和多媒体消息两种，两者只能选择其一，不能同时发送文本和多媒体消息   */
        // @property (assign, nonatomic) BOOL bText;
        [Export("bText")]
        bool BText { get; set; }

        /**     发送的目标场景，可以选择发送到会话(WXSceneSession)或者朋友圈(WXSceneTimeline)。 默认发送到会话   */
        // @property (assign, nonatomic) int scene;
        [Export("scene")]
        int Scene { get; set; }

        /**     指定发送消息的人，WXSceneSpecifiedSession时有效   */
        // @property (retain, nonatomic) NSString * toUserOpenId;
        [Export("toUserOpenId", ArgumentSemantic.Retain)]
        string ToUserOpenId { get; set; }
    }

    // @interface SendMessageToWXResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface SendMessageToWXResp
    {
        // @property (retain, nonatomic) NSString * lang;
        [Export("lang", ArgumentSemantic.Retain)]
        string Lang { get; set; }

        // @property (retain, nonatomic) NSString * country;
        [Export("country", ArgumentSemantic.Retain)]
        string Country { get; set; }
    }

    // @interface GetMessageFromWXReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface GetMessageFromWXReq
    {
        // @property (retain, nonatomic) NSString * lang;
        [Export("lang", ArgumentSemantic.Retain)]
        string Lang { get; set; }

        // @property (retain, nonatomic) NSString * country;
        [Export("country", ArgumentSemantic.Retain)]
        string Country { get; set; }
    }

    // @interface GetMessageFromWXResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface GetMessageFromWXResp
    {
        // @property (retain, nonatomic) NSString * text;
        [Export("text", ArgumentSemantic.Retain)]
        string Text { get; set; }

        // @property (retain, nonatomic) WXMediaMessage * message;
        [Export("message", ArgumentSemantic.Retain)]
        WXMediaMessage Message { get; set; }

        // @property (assign, nonatomic) BOOL bText;
        [Export("bText")]
        bool BText { get; set; }
    }

    // @interface ShowMessageFromWXReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface ShowMessageFromWXReq
    {
        // @property (retain, nonatomic) WXMediaMessage * message;
        [Export("message", ArgumentSemantic.Retain)]
        WXMediaMessage Message { get; set; }

        // @property (retain, nonatomic) NSString * lang;
        [Export("lang", ArgumentSemantic.Retain)]
        string Lang { get; set; }

        // @property (retain, nonatomic) NSString * country;
        [Export("country", ArgumentSemantic.Retain)]
        string Country { get; set; }
    }

    // @interface ShowMessageFromWXResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface ShowMessageFromWXResp
    {
    }

    // @interface LaunchFromWXReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface LaunchFromWXReq
    {
        // @property (retain, nonatomic) WXMediaMessage * message;
        [Export("message", ArgumentSemantic.Retain)]
        WXMediaMessage Message { get; set; }

        // @property (retain, nonatomic) NSString * lang;
        [Export("lang", ArgumentSemantic.Retain)]
        string Lang { get; set; }

        // @property (retain, nonatomic) NSString * country;
        [Export("country", ArgumentSemantic.Retain)]
        string Country { get; set; }
    }

    // @interface OpenTempSessionReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface OpenTempSessionReq
    {
        // @property (retain, nonatomic) NSString * username;
        [Export("username", ArgumentSemantic.Retain)]
        string Username { get; set; }

        // @property (retain, nonatomic) NSString * sessionFrom;
        [Export("sessionFrom", ArgumentSemantic.Retain)]
        string SessionFrom { get; set; }
    }

    // @interface OpenTempSessionResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface OpenTempSessionResp
    {
    }

    // @interface OpenWebviewReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface OpenWebviewReq
    {
        // @property (retain, nonatomic) NSString * url;
        [Export("url", ArgumentSemantic.Retain)]
        string Url { get; set; }
    }

    // @interface OpenWebviewResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface OpenWebviewResp
    {
    }

    // @interface WXOpenBusinessWebViewReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXOpenBusinessWebViewReq
    {
        // @property (assign, nonatomic) UInt32 businessType;
        [Export("businessType")]
        uint BusinessType { get; set; }

        // @property (retain, nonatomic) NSDictionary * queryInfoDic;
        [Export("queryInfoDic", ArgumentSemantic.Retain)]
        NSDictionary QueryInfoDic { get; set; }
    }

    // @interface WXOpenBusinessWebViewResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXOpenBusinessWebViewResp
    {
        // @property (retain, nonatomic) NSString * result;
        [Export("result", ArgumentSemantic.Retain)]
        string Result { get; set; }

        // @property (assign, nonatomic) UInt32 businessType;
        [Export("businessType")]
        uint BusinessType { get; set; }
    }

    // @interface OpenRankListReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface OpenRankListReq
    {
    }

    // @interface OpenRankListResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface OpenRankListResp
    {
    }

    // @interface JumpToBizProfileReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface JumpToBizProfileReq
    {
        // @property (retain, nonatomic) NSString * username;
        [Export("username", ArgumentSemantic.Retain)]
        string Username { get; set; }

        // @property (retain, nonatomic) NSString * extMsg;
        [Export("extMsg", ArgumentSemantic.Retain)]
        string ExtMsg { get; set; }

        // @property (assign, nonatomic) int profileType;
        [Export("profileType")]
        int ProfileType { get; set; }
    }

    // @interface JumpToBizWebviewReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface JumpToBizWebviewReq
    {
        // @property (assign, nonatomic) int webType;
        [Export("webType")]
        int WebType { get; set; }

        // @property (retain, nonatomic) NSString * tousrname;
        [Export("tousrname", ArgumentSemantic.Retain)]
        string Tousrname { get; set; }

        // @property (retain, nonatomic) NSString * extMsg;
        [Export("extMsg", ArgumentSemantic.Retain)]
        string ExtMsg { get; set; }
    }

    // @interface WXCardItem : NSObject
    [BaseType(typeof(NSObject))]
    interface WXCardItem
    {
        // @property (retain, nonatomic) NSString * cardId;
        [Export("cardId", ArgumentSemantic.Retain)]
        string CardId { get; set; }

        // @property (retain, nonatomic) NSString * extMsg;
        [Export("extMsg", ArgumentSemantic.Retain)]
        string ExtMsg { get; set; }

        // @property (assign, nonatomic) UInt32 cardState;
        [Export("cardState")]
        uint CardState { get; set; }

        // @property (retain, nonatomic) NSString * encryptCode;
        [Export("encryptCode", ArgumentSemantic.Retain)]
        string EncryptCode { get; set; }

        // @property (retain, nonatomic) NSString * appID;
        [Export("appID", ArgumentSemantic.Retain)]
        string AppID { get; set; }
    }

    // @interface WXInvoiceItem : NSObject
    [BaseType(typeof(NSObject))]
    interface WXInvoiceItem
    {
        // @property (retain, nonatomic) NSString * cardId;
        [Export("cardId", ArgumentSemantic.Retain)]
        string CardId { get; set; }

        // @property (retain, nonatomic) NSString * extMsg;
        [Export("extMsg", ArgumentSemantic.Retain)]
        string ExtMsg { get; set; }

        // @property (assign, nonatomic) UInt32 cardState;
        [Export("cardState")]
        uint CardState { get; set; }

        // @property (retain, nonatomic) NSString * encryptCode;
        [Export("encryptCode", ArgumentSemantic.Retain)]
        string EncryptCode { get; set; }

        // @property (retain, nonatomic) NSString * appID;
        [Export("appID", ArgumentSemantic.Retain)]
        string AppID { get; set; }
    }

    // @interface AddCardToWXCardPackageReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface AddCardToWXCardPackageReq
    {
        // @property (retain, nonatomic) NSArray * cardAry;
        [Export("cardAry", ArgumentSemantic.Retain)]

        NSObject[] CardAry { get; set; }
    }

    // @interface AddCardToWXCardPackageResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface AddCardToWXCardPackageResp
    {
        // @property (retain, nonatomic) NSArray * cardAry;
        [Export("cardAry", ArgumentSemantic.Retain)]
        NSObject[] CardAry { get; set; }
    }

    // @interface WXChooseCardReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXChooseCardReq
    {
        // @property (nonatomic, strong) NSString * appID;
        [Export("appID", ArgumentSemantic.Strong)]
        string AppID { get; set; }

        // @property (assign, nonatomic) UInt32 shopID;
        [Export("shopID")]
        uint ShopID { get; set; }

        // @property (assign, nonatomic) UInt32 canMultiSelect;
        [Export("canMultiSelect")]
        uint CanMultiSelect { get; set; }

        // @property (nonatomic, strong) NSString * cardType;
        [Export("cardType", ArgumentSemantic.Strong)]
        string CardType { get; set; }

        // @property (nonatomic, strong) NSString * cardTpID;
        [Export("cardTpID", ArgumentSemantic.Strong)]
        string CardTpID { get; set; }

        // @property (nonatomic, strong) NSString * signType;
        [Export("signType", ArgumentSemantic.Strong)]
        string SignType { get; set; }

        // @property (nonatomic, strong) NSString * cardSign;
        [Export("cardSign", ArgumentSemantic.Strong)]
        string CardSign { get; set; }

        // @property (assign, nonatomic) UInt32 timeStamp;
        [Export("timeStamp")]
        uint TimeStamp { get; set; }

        // @property (nonatomic, strong) NSString * nonceStr;
        [Export("nonceStr", ArgumentSemantic.Strong)]
        string NonceStr { get; set; }
    }

    // @interface WXChooseCardResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXChooseCardResp
    {
        // @property (retain, nonatomic) NSArray * cardAry;
        [Export("cardAry", ArgumentSemantic.Retain)]

        NSObject[] CardAry { get; set; }
    }

    // @interface WXChooseInvoiceReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXChooseInvoiceReq
    {
        // @property (nonatomic, strong) NSString * appID;
        [Export("appID", ArgumentSemantic.Strong)]
        string AppID { get; set; }

        // @property (assign, nonatomic) UInt32 shopID;
        [Export("shopID")]
        uint ShopID { get; set; }

        // @property (nonatomic, strong) NSString * signType;
        [Export("signType", ArgumentSemantic.Strong)]
        string SignType { get; set; }

        // @property (nonatomic, strong) NSString * cardSign;
        [Export("cardSign", ArgumentSemantic.Strong)]
        string CardSign { get; set; }

        // @property (assign, nonatomic) UInt32 timeStamp;
        [Export("timeStamp")]
        uint TimeStamp { get; set; }

        // @property (nonatomic, strong) NSString * nonceStr;
        [Export("nonceStr", ArgumentSemantic.Strong)]
        string NonceStr { get; set; }
    }

    // @interface WXChooseInvoiceResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXChooseInvoiceResp
    {
        // @property (nonatomic, strong) NSArray * cardAry;
        [Export("cardAry", ArgumentSemantic.Strong)]

        NSObject[] CardAry { get; set; }
    }

    // @interface WXSubscribeMsgReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXSubscribeMsgReq
    {
        // @property (assign, nonatomic) UInt32 scene;
        [Export("scene")]
        uint Scene { get; set; }

        // @property (nonatomic, strong) NSString * templateId;
        [Export("templateId", ArgumentSemantic.Strong)]
        string TemplateId { get; set; }

        // @property (nonatomic, strong) NSString * reserved;
        [Export("reserved", ArgumentSemantic.Strong)]
        string Reserved { get; set; }
    }

    // @interface WXSubscribeMsgResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXSubscribeMsgResp
    {
        // @property (nonatomic, strong) NSString * templateId;
        [Export("templateId", ArgumentSemantic.Strong)]
        string TemplateId { get; set; }

        // @property (assign, nonatomic) UInt32 scene;
        [Export("scene")]
        uint Scene { get; set; }

        // @property (nonatomic, strong) NSString * action;
        [Export("action", ArgumentSemantic.Strong)]
        string Action { get; set; }

        // @property (nonatomic, strong) NSString * reserved;
        [Export("reserved", ArgumentSemantic.Strong)]
        string Reserved { get; set; }

        // @property (nonatomic, strong) NSString * openId;
        [Export("openId", ArgumentSemantic.Strong)]
        string OpenId { get; set; }
    }

    // @interface WXSubscribeMiniProgramMsgReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXSubscribeMiniProgramMsgReq
    {
        // @property (nonatomic, strong) NSString * miniProgramAppid;
        [Export("miniProgramAppid", ArgumentSemantic.Strong)]
        string MiniProgramAppid { get; set; }
    }

    // @interface WXSubscribeMiniProgramMsgResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXSubscribeMiniProgramMsgResp
    {
        // @property (nonatomic, strong) NSString * openId;
        [Export("openId", ArgumentSemantic.Strong)]
        string OpenId { get; set; }

        // @property (nonatomic, strong) NSString * unionId;
        [Export("unionId", ArgumentSemantic.Strong)]
        string UnionId { get; set; }

        // @property (nonatomic, strong) NSString * nickName;
        [Export("nickName", ArgumentSemantic.Strong)]
        string NickName { get; set; }
    }

    // @interface WXInvoiceAuthInsertReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXInvoiceAuthInsertReq
    {
        // @property (nonatomic, strong) NSString * urlString;
        [Export("urlString", ArgumentSemantic.Strong)]
        string UrlString { get; set; }
    }

    // @interface WXInvoiceAuthInsertResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXInvoiceAuthInsertResp
    {
        // @property (nonatomic, strong) NSString * wxOrderId;
        [Export("wxOrderId", ArgumentSemantic.Strong)]
        string WxOrderId { get; set; }
    }

    // @interface WXNontaxPayReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXNontaxPayReq
    {
        // @property (nonatomic, strong) NSString * urlString;
        [Export("urlString", ArgumentSemantic.Strong)]
        string UrlString { get; set; }
    }

    // @interface WXNontaxPayResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXNontaxPayResp
    {
        // @property (nonatomic, strong) NSString * wxOrderId;
        [Export("wxOrderId", ArgumentSemantic.Strong)]
        string WxOrderId { get; set; }
    }

    // @interface WXPayInsuranceReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXPayInsuranceReq
    {
        // @property (nonatomic, strong) NSString * urlString;
        [Export("urlString", ArgumentSemantic.Strong)]
        string UrlString { get; set; }
    }

    // @interface WXPayInsuranceResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXPayInsuranceResp
    {
        // @property (nonatomic, strong) NSString * wxOrderId;
        [Export("wxOrderId", ArgumentSemantic.Strong)]
        string WxOrderId { get; set; }
    }

    // @interface WXMediaMessage : NSObject
    [BaseType(typeof(NSObject))]
    interface WXMediaMessage
    {
        // +(WXMediaMessage *)message;
        [Static]
        [Export("message")]

        WXMediaMessage Message { get; }

        // @property (retain, nonatomic) NSString * title;
        [Export("title", ArgumentSemantic.Retain)]
        string Title { get; set; }

        // @property (retain, nonatomic) NSString * description;
        [Export("description", ArgumentSemantic.Retain)]
        string Description { get; set; }

        // @property (retain, nonatomic) NSData * thumbData;
        [Export("thumbData", ArgumentSemantic.Retain)]
        NSData ThumbData { get; set; }

        // @property (retain, nonatomic) NSString * mediaTagName;
        [Export("mediaTagName", ArgumentSemantic.Retain)]
        string MediaTagName { get; set; }

        // @property (retain, nonatomic) NSString * messageExt;
        [Export("messageExt", ArgumentSemantic.Retain)]
        string MessageExt { get; set; }

        // @property (retain, nonatomic) NSString * messageAction;
        [Export("messageAction", ArgumentSemantic.Retain)]
        string MessageAction { get; set; }

        // @property (retain, nonatomic) id mediaObject;
        [Export("mediaObject", ArgumentSemantic.Retain)]
        NSObject MediaObject { get; set; }

        // -(void)setThumbImage:(UIImage *)image;
        [Export("setThumbImage:")]
        void SetThumbImage(UIImage image);
    }

    // @interface WXImageObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXImageObject
    {
        // +(WXImageObject *)object;
        [Static]
        [Export("object")]

        WXImageObject Object { get; }

        // @property (retain, nonatomic) NSData * imageData;
        [Export("imageData", ArgumentSemantic.Retain)]
        NSData ImageData { get; set; }
    }

    // @interface WXMusicObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXMusicObject
    {
        // +(WXMusicObject *)object;
        [Static]
        [Export("object")]

        WXMusicObject Object { get; }

        // @property (retain, nonatomic) NSString * musicUrl;
        [Export("musicUrl", ArgumentSemantic.Retain)]
        string MusicUrl { get; set; }

        // @property (retain, nonatomic) NSString * musicLowBandUrl;
        [Export("musicLowBandUrl", ArgumentSemantic.Retain)]
        string MusicLowBandUrl { get; set; }

        // @property (retain, nonatomic) NSString * musicDataUrl;
        [Export("musicDataUrl", ArgumentSemantic.Retain)]
        string MusicDataUrl { get; set; }

        // @property (retain, nonatomic) NSString * musicLowBandDataUrl;
        [Export("musicLowBandDataUrl", ArgumentSemantic.Retain)]
        string MusicLowBandDataUrl { get; set; }
    }

    // @interface WXVideoObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXVideoObject
    {
        // +(WXVideoObject *)object;
        [Static]
        [Export("object")]

        WXVideoObject Object { get; }

        // @property (retain, nonatomic) NSString * videoUrl;
        [Export("videoUrl", ArgumentSemantic.Retain)]
        string VideoUrl { get; set; }

        // @property (retain, nonatomic) NSString * videoLowBandUrl;
        [Export("videoLowBandUrl", ArgumentSemantic.Retain)]
        string VideoLowBandUrl { get; set; }
    }

    // @interface WXWebpageObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXWebpageObject
    {
        // +(WXWebpageObject *)object;
        [Static]
        [Export("object")]

        WXWebpageObject Object { get; }

        // @property (retain, nonatomic) NSString * webpageUrl;
        [Export("webpageUrl", ArgumentSemantic.Retain)]
        string WebpageUrl { get; set; }
    }

    // @interface WXAppExtendObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXAppExtendObject
    {
        // +(WXAppExtendObject *)object;
        [Static]
        [Export("object")]

        WXAppExtendObject Object { get; }

        // @property (retain, nonatomic) NSString * url;
        [Export("url", ArgumentSemantic.Retain)]
        string Url { get; set; }

        // @property (retain, nonatomic) NSString * extInfo;
        [Export("extInfo", ArgumentSemantic.Retain)]
        string ExtInfo { get; set; }

        // @property (retain, nonatomic) NSData * fileData;
        [Export("fileData", ArgumentSemantic.Retain)]
        NSData FileData { get; set; }
    }

    // @interface WXEmoticonObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXEmoticonObject
    {
        // +(WXEmoticonObject *)object;
        [Static]
        [Export("object")]

        WXEmoticonObject Object { get; }

        // @property (retain, nonatomic) NSData * emoticonData;
        [Export("emoticonData", ArgumentSemantic.Retain)]
        NSData EmoticonData { get; set; }
    }

    // @interface WXFileObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXFileObject
    {
        // +(WXFileObject *)object;
        [Static]
        [Export("object")]

        WXFileObject Object { get; }

        // @property (retain, nonatomic) NSString * fileExtension;
        [Export("fileExtension", ArgumentSemantic.Retain)]
        string FileExtension { get; set; }

        // @property (retain, nonatomic) NSData * fileData;
        [Export("fileData", ArgumentSemantic.Retain)]
        NSData FileData { get; set; }
    }

    // @interface WXLocationObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXLocationObject
    {
        // +(WXLocationObject *)object;
        [Static]
        [Export("object")]
        WXLocationObject Object { get; }

        // @property (assign, nonatomic) double lng;
        [Export("lng")]
        double Lng { get; set; }

        // @property (assign, nonatomic) double lat;
        [Export("lat")]
        double Lat { get; set; }
    }

    // @interface WXMiniProgramObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXMiniProgramObject
    {
        // +(WXMiniProgramObject *)object;
        [Static]
        [Export("object")]

        WXMiniProgramObject Object { get; }

        // @property (nonatomic, strong) NSString * webpageUrl;
        [Export("webpageUrl", ArgumentSemantic.Strong)]
        string WebpageUrl { get; set; }

        // @property (nonatomic, strong) NSString * userName;
        [Export("userName", ArgumentSemantic.Strong)]
        string UserName { get; set; }

        // @property (nonatomic, strong) NSString * path;
        [Export("path", ArgumentSemantic.Strong)]
        string Path { get; set; }

        // @property (nonatomic, strong) NSData * hdImageData;
        [Export("hdImageData", ArgumentSemantic.Strong)]
        NSData HdImageData { get; set; }

        // @property (assign, nonatomic) BOOL withShareTicket;
        [Export("withShareTicket")]
        bool WithShareTicket { get; set; }

        // @property (assign, nonatomic) WXMiniProgramType miniProgramType;
        [Export("miniProgramType", ArgumentSemantic.Assign)]
        WXMiniProgramType MiniProgramType { get; set; }
    }

    // @interface WXLaunchMiniProgramReq : BaseReq
    [BaseType(typeof(BaseReq))]
    interface WXLaunchMiniProgramReq
    {
        // +(WXLaunchMiniProgramReq *)object;
        [Static]
        [Export("object")]

        WXLaunchMiniProgramReq Object { get; }

        // @property (nonatomic, strong) NSString * userName;
        [Export("userName", ArgumentSemantic.Strong)]
        string UserName { get; set; }

        // @property (nonatomic, strong) NSString * path;
        [Export("path", ArgumentSemantic.Strong)]
        string Path { get; set; }

        // @property (assign, nonatomic) WXMiniProgramType miniProgramType;
        [Export("miniProgramType", ArgumentSemantic.Assign)]
        WXMiniProgramType MiniProgramType { get; set; }

        // @property (nonatomic, strong) NSString * extMsg;
        [Export("extMsg", ArgumentSemantic.Strong)]
        string ExtMsg { get; set; }
    }

    // @interface WXLaunchMiniProgramResp : BaseResp
    [BaseType(typeof(BaseResp))]
    interface WXLaunchMiniProgramResp
    {
        // @property (retain, nonatomic) NSString * extMsg;
        [Export("extMsg", ArgumentSemantic.Retain)]
        string ExtMsg { get; set; }
    }

    // @interface WXTextObject : NSObject
    [BaseType(typeof(NSObject))]
    interface WXTextObject
    {
        // +(WXTextObject *)object;
        [Static]
        [Export("object")]

        WXTextObject Object { get; }

        // @property (retain, nonatomic) NSString * contentText;
        [Export("contentText", ArgumentSemantic.Retain)]
        string ContentText { get; set; }
    }

    /// <summary>
    /// 接收并处理来自微信终端程序的事件消息，期间微信界面会切换到第三方应用程序。
    /// </summary>
    // @protocol WXApiDelegate <NSObject>
    partial interface IWXApiDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXApiDelegate
    {
        /// <summary>
        /// 收到一个来自微信的请求，第三方应用程序处理完后调用sendResp向微信发送结果
        /// 可能收到的请求有GetMessageFromWXReq、ShowMessageFromWXReq等。
        /// </summary>
        /// <param name="req">具体请求内容，是自动释放的.</param>
        // @optional -(void)onReq:(BaseReq *)req;
        [Export("onReq:")]
        void OnReq(BaseReq req);

        /// <summary>
        /// 发送一个sendReq后，收到微信的回应
        /// 可能收到的处理结果有SendMessageToWXResp、SendAuthResp等。
        /// </summary>
        /// <param name="resp">resp具体的回应内容，是自动释放的.</param>
        // @optional -(void)onResp:(BaseResp *)resp;
        [Export("onResp:")]
        void OnResp(BaseResp resp);
    }

    // @protocol WXApiLogDelegate <NSObject>
    partial interface IWXApiLogDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WXApiLogDelegate
    {
        // @required -(void)onLog:(NSString *)log logLevel:(WXLogLevel)level;
        [Abstract]
        [Export("onLog:logLevel:")]
        void LogLevel(string log, WXLogLevel level);
    }

    /// <summary>
    /// 微信Api接口函数类
    /// </summary>
    // @interface WXApi : NSObject
    [BaseType(typeof(NSObject))]
    interface WXApi
    {
        /// <summary>
        /// WXApi的成员函数，向微信终端程序注册第三方应用。
        /// 请保证在主线程中调用此函数
        /// </summary>
        /// <param name="appid">微信开发者ID.</param>
        // +(BOOL)registerApp:(NSString *)appid;
        [Static]
        [Export("registerApp:")]
        bool RegisterApp(string appid);

        /// <summary>
        /// WXApi的成员函数，向微信终端程序注册第三方应用。
        /// 需要在每次启动第三方应用程序时调用。第一次调用后，会在微信的可用应用列表中出现。
        /// </summary>
        /// <param name="appid">微信开发者ID.</param>
        /// <param name="isEnableMTA">是否支持MTA数据上报.</param>
        // +(BOOL)registerApp:(NSString *)appid enableMTA:(BOOL)isEnableMTA;
        [Static]
        [Export("registerApp:enableMTA:")]
        bool RegisterApp(string appid, bool isEnableMTA);

        /// <summary>
        /// WXApi的成员函数，向微信终端程序注册应用支持打开的文件类型。
        /// </summary>
        /// <param name="typeFlag">应用支持打开的数据类型, enAppSupportContentFlag枚举类型 “|” 操作后结果.</param>
        // +(void)registerAppSupportContentFlag:(UInt64)typeFlag;
        [Static]
        [Export("registerAppSupportContentFlag:")]
        void RegisterAppSupportContentFlag(ulong typeFlag);

        /// <summary>
        /// 处理微信通过URL启动App时传递的数据
        /// </summary>
        /// <returns><c>true</c>, if open URL was handled, <c>false</c> otherwise.</returns>
        /// <param name="url">微信启动第三方应用时传递过来的URL.</param>
        /// <param name="delegate">WXApiDelegate对象，用来接收微信触发的消息.</param>
        // +(BOOL)handleOpenURL:(NSURL *)url delegate:(id<WXApiDelegate>)delegate;
        [Static]
        [Export("handleOpenURL:delegate:")]
        bool HandleOpenURL(NSUrl url, IWXApiDelegate @delegate);

        /// <summary>
        /// 检查微信是否已被用户安装
        /// </summary>
        // +(BOOL)isWXAppInstalled;
        [Static]
        [Export("isWXAppInstalled")]
        bool IsWXAppInstalled { get; }

        /// <summary>
        /// 判断当前微信的版本是否支持OpenApi
        /// </summary>
        // +(BOOL)isWXAppSupportApi;
        [Static]
        [Export("isWXAppSupportApi")]
        bool IsWXAppSupportApi { get; }

        /// <summary>
        /// 获取微信的itunes安装地址
        /// </summary>
        // +(NSString *)getWXAppInstallUrl;
        [Static]
        [Export("getWXAppInstallUrl")]
        string WXAppInstallUrl { get; }

        /// <summary>
        /// 获取当前微信SDK的版本号
        /// </summary>
        // +(NSString *)getApiVersion;
        [Static]
        [Export("getApiVersion")]
        string ApiVersion { get; }

        /// <summary>
        /// 打开微信
        /// </summary>
        // +(BOOL)openWXApp;
        [Static]
        [Export("openWXApp")]
        bool OpenWXApp { get; }

        /// <summary>
        /// 发送请求到微信，等待微信返回onResp
        /// 函数调用后，会切换到微信的界面。第三方应用程序等待微信返回onResp。微信在异步处理完成后一定会调用onResp。
        /// </summary>
        /// <param name="req">具体的发送请求，在调用函数后，请自己释放。</param>
        // +(BOOL)sendReq:(BaseReq *)req;
        [Static]
        [Export("sendReq:")]
        bool SendReq(BaseReq req);

        /// <summary>
        /// 发送Auth请求到微信，支持用户没安装微信，等待微信返回onResp
        /// </summary>
        /// <param name="req">具体的发送请求，在调用函数后，请自己释放.</param>
        /// <param name="viewController">当前界面对象.</param>
        /// <param name="delegate">WXApiDelegate对象，用来接收微信触发的消息.</param>
        // +(BOOL)sendAuthReq:(SendAuthReq *)req viewController:(UIViewController *)viewController delegate:(id<WXApiDelegate>)delegate;
        [Static]
        [Export("sendAuthReq:viewController:delegate:")]
        bool SendAuthReq(SendAuthReq req, UIViewController viewController, IWXApiDelegate @delegate);

        /// <summary>
        /// 收到微信onReq的请求，发送对应的应答给微信，并切换到微信界面
        /// </summary>
        /// <param name="resp">具体的应答内容，调用函数后，请自己释放.</param>
        // +(BOOL)sendResp:(BaseResp *)resp;
        [Static]
        [Export("sendResp:")]
        bool SendResp(BaseResp resp);

        /// <summary>
        /// WXApi的成员函数，接受微信的log信息。byBlock
        /// 注意1:SDK会强引用这个block,注意不要导致内存泄漏,注意不要导致内存泄漏
        /// 注意2:调用过一次startLog by block之后，如果再调用一次任意方式的startLoad,会释放上一次logBlock，不再回调上一个logBlock
        /// </summary>
        /// <param name="level">打印log的级别.</param>
        /// <param name="logBlock">打印log的回调block.</param>
        // +(void)startLogByLevel:(WXLogLevel)level logBlock:(WXLogBolock)logBlock;
        [Static]
        [Export("startLogByLevel:logBlock:")]
        void StartLogByLevel(WXLogLevel level, WXLogBolock logBlock);

        /// <summary>
        /// WXApi的成员函数，接受微信的log信息。byDelegate 
        /// 注意1:sdk会弱引用这个delegate，这里可加任意对象为代理，不需要与WXApiDelegate同一个对象
        /// 注意2:调用过一次startLog by delegate之后，再调用一次任意方式的startLoad,不会再回调上一个logDelegate对象
        /// </summary>
        /// <param name="level">打印log的级别.</param>
        /// <param name="logDelegate">打印log的回调代理.</param>
        // +(void)startLogByLevel:(WXLogLevel)level logDelegate:(id<WXApiLogDelegate>)logDelegate;
        [Static]
        [Export("startLogByLevel:logDelegate:")]
        void StartLogByLevel(WXLogLevel level, IWXApiLogDelegate logDelegate);

        /// <summary>
        /// 停止打印log，会清理block或者delegate为空，释放block
        /// </summary>
        // +(void)stopLog;
        [Static]
        [Export("stopLog")]
        void StopLog();
    }

    // @protocol WechatAuthAPIDelegate <NSObject>
    partial interface IWechatAuthAPIDelegate { }


    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface WechatAuthAPIDelegate
    {
        /// <summary>
        /// 得到二维码
        /// </summary>
        // @optional -(void)onAuthGotQrcode:(UIImage *)image;
        [Export("onAuthGotQrcode:")]
        void OnAuthGotQrcode(UIImage image);

        /// <summary>
        /// 二维码被扫描
        /// </summary>
        // @optional -(void)onQrcodeScanned;
        [Export("onQrcodeScanned")]
        void OnQrcodeScanned();

        /// <summary>
        /// //成功登录
        /// </summary>
        // @optional -(void)onAuthFinish:(int)errCode AuthCode:(NSString *)authCode;
        [Export("onAuthFinish:AuthCode:")]
        void OnAuthFinish(int errCode, string authCode);
    }

    // @interface WechatAuthSDK : NSObject
    [BaseType(typeof(NSObject))]
    interface WechatAuthSDK
    {
        [Wrap("WeakDelegate")]
        IWechatAuthAPIDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<WechatAuthAPIDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        /// <summary>
        /// authSDK版本号
        /// </summary>
        // @property (readonly, nonatomic) NSString * sdkVersion;
        [Export("sdkVersion")]
        string SdkVersion { get; }

        /// <summary>
        /// 发送登录请求，等待WechatAuthAPIDelegate回调
        /// </summary>
        /// <returns>成功返回True，失败返回False.</returns>
        /// <param name="appId">微信开发者ID.</param>
        /// <param name="nonceStr">一个随机的尽量不重复的字符串，用来使得每次的signature不同.</param>
        /// <param name="timeStamp">时间戳.</param>
        /// <param name="scope">应用授权作用域，拥有多个作用域用逗号（,）分隔.</param>
        /// <param name="signature">签名.</param>
        /// <param name="schemeData">会在扫码后拼在scheme后.</param>
        /// 该实现只保证同时只有一个Auth在运行，Auth未完成或未Stop再次调用Auth接口时会返回NO。
        // -(BOOL)Auth:(NSString *)appId nonceStr:(NSString *)nonceStr timeStamp:(NSString *)timeStamp scope:(NSString *)scope signature:(NSString *)signature schemeData:(NSString *)schemeData;
        [Export("Auth:nonceStr:timeStamp:scope:signature:schemeData:")]
        bool Auth(string appId, string nonceStr, string timeStamp, string scope, string signature, string schemeData);

        /// <summary>
        /// 暂停登录请求
        /// </summary>
        /// 成功返回True，失败返回False.
        // -(BOOL)StopAuth;
        [Export("StopAuth")]
        bool StopAuth { get; }
    }
}

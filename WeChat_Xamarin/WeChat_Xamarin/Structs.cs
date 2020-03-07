using System;
using ObjCRuntime;

namespace WeChat
{
    public enum WXErrCode
    {
        Success = 0,
        Common = -1,
        UserCancel = -2,
        SentFail = -3,
        AuthDeny = -4,
        Unsupport = -5,   
    }

    public enum WXScene : uint
    {
        Session = 0,   
        Timeline = 1,   
        Favorite = 2,   
        SpecifiedSession = 3,  
    }
        
    public enum WXAPISupport : uint
    {
        WXAPISupportSession = 0
    }

    public enum WXBizProfileType : uint
    {
        Normal = 0,    
        Device = 1,    
    }

    public enum WXMiniProgramType : ulong
    {
        Release = 0,       
        Test = 1,        
        Preview = 2,         
    }

    public enum WXMPWebviewType : uint
    {
        Ad = 0,        
    }

    [Native]
    public enum WXLogLevel : long
    {
        Normal = 0, 
        Detail = 1  
    }

    public enum AuthErrCode
    {
        Ok = 0,  
        NormalErr = -1,  
        NetworkErr = -2, 
        GetQrcodeFailed = -3,    
        Cancel = -4,     
        Timeout = -5,    
    }
}

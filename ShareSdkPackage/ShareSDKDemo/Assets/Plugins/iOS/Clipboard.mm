#import "Clipboard.h"    
@implementation Clipboard
    -(void)objc_copyTextToClipboard : (NSString*)text
    {     
    UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];     
    pasteboard.string = text; 
    } 
    - (NSString*)GetClipboardText  
    {     
         UIPasteboard *pasteboard = [UIPasteboard generalPasteboard];  
         return pasteboard.string; 
    }
@end
extern "C" 
{     
    static Clipboard *iosClipboard;  
    char* _MakeStringCopy(const char* str)    
    {        
        if(str==NULL)
        { 
            return NULL;
        }        
        char* res=(char*)malloc(strlen(str)+1);        
        strcpy(res,str);        
        return res;    
        }         
        void _copyTextToClipboard(const char *textList)     
        {           
            NSString *text = [NSString stringWithUTF8String: textList] ;                
            if(iosClipboard == NULL)        
            {            
                iosClipboard = [[Clipboard alloc] init];        
            }             
            [iosClipboard objc_copyTextToClipboard: text];     
        }	
        const char* _GetClipboardText()	
        {	    
            if(iosClipboard == NULL)        
            {            
                iosClipboard = [[Clipboard alloc] init];        
            }  		      	
            return _MakeStringCopy([[iosClipboard GetClipboardText] UTF8String]);	
            }    
        }

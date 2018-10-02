#import <Foundation/Foundation.h>  //这个是要放到xcode中的.h文件
@ interface Clipboard : NSObject
extern "C"
    {	
    void _copyTextToClipboard(const char *textList);	
    const char* _GetClipboardText();
    }
@end
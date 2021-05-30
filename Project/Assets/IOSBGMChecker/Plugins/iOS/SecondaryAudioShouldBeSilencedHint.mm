#import <AVFoundation/AVFoundation.h>

extern "C"
{
    bool getSecondaryAudioShouldBeSilencedHint_()
    {
        return [[AVAudioSession sharedInstance] secondaryAudioShouldBeSilencedHint];
    }
}
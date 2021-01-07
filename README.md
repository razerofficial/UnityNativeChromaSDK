# UnityNativeChromaSDK - Unity native library for the ChromaSDK

**Table of Contents**

* [See also](#see-also)
* [Quick Start](#quick-start)
* [Frameworks supported](#frameworks-supported)
* [Prerequisites](#prerequisites)
* [Dependencies](#dependencies)
* [Packaging](#packaging)
* [Getting Started](#getting-started)
* [Tutorials](#tutorials)
* [Assets](#assets)
* [API](#api)
* [Examples](#examples)

<a name="related"></a>
## See Also

**Docs:**

- [Chroma Animation Guide](http://chroma.razer.com/ChromaGuide/) - Visual examples of the Chroma Animation API methods

**Apps:**

- [ChromaClientForDiscord](https://github.com/tgraupmann/ChromaDiscordApp) - Add Chroma lighting to the Discord App events

- [ChromaClientForMixer](https://github.com/tgraupmann/ChromaClientForMixer) - Add Chroma lighting to the Mixer streaming experience

- [ChromaClientForTwitch](https://github.com/tgraupmann/ChromaTwitchExtension) - Add Chroma lighting to the Twitch streaming experience

**Plugins:**

- [CChromaEditor](https://github.com/RazerOfficial/CChromaEditor) - C++ native MFC library for playing and editing Chroma animations

- [GameMakerChromaExtension](https://github.com/RazerOfficial/GameMakerChromaExtension) - GameMaker extension to control lighting for Razer Chroma

- [HTML5ChromaSDK](https://github.com/RazerOfficial/HTML5ChromaSDK) - JavaScript library for playing Chroma animations

- [UE4_XDK_SampleApp](https://github.com/razerofficial/UE4_XDK_SampleApp) - UE4 Chroma samples and runtime module with Blueprint library for the ChromaSDK

- [UnityNativeChromaSDK](https://github.com/RazerOfficial/UnityNativeChromaSDK) - Unity native library for the ChromaSDK


## Quick Start ##

* Install [Synapse](https://www.razer.com/synapse-3)

* Make sure the Chroma Connect module is installed.

![image_7](images/image_7.png)

* If you don't have Chroma hardware, you can see Chroma effects with the [Chroma Emulator](https://github.com/razerofficial/ChromaEmulator)

* This project is the Unity capture tool for authoring Chroma animations.

* This repo also has the docs on the [Unity Chroma API](#api)

* Head over to the [Unity Sample App](https://github.com/razerofficial/Unity_SampleApp) to see the sample code with animations that correspond to the [Chroma Animation Guide](http://chroma.razer.com/ChromaGuide/)


<a name="frameworks-supported"></a>
## Frameworks supported
- Unity 3.5.7 or later
- Windows Editor / Windows Standalone


<a name="prerequisites"></a>
## Prerequisites
- Install [Synapse](http://developer.razerzone.com/works-with-chroma/download/)
- Synapse will install the Chroma SDK when a Chroma enabled device is connected
- Install [Microsoft Visual C++ Redistributable for Visual Studio 2017](https://www.visualstudio.com/downloads/)


<a name="dependencies"></a>
## Dependencies
- [CChromaEditor](https://github.com/RazerOfficial/CChromaEditor) - C++ Native MFC Library for playing and editing Chroma animations

<a name="packaging"></a>
## Packaging

Import [UnityNativeChromaSDK.unitypackage](https://github.com/razerofficial/UnityNativeChromaSDK/releases/tag/1.0) into your project.

<a name="getting-started"></a>
## Getting Started

1 Install [Synapse](http://developer.razerzone.com/works-with-chroma/download/)

2 (Optional) Install the [Emulator](http://developer.razerzone.com/works-with-chroma/download/)

3 Connect [Razer Chroma hardware](http://developer.razerzone.com/works-with-chroma/compatible-devices/)

4 Install [Unity3d](https://unity3d.com/)

5 Open Unity and start with an existing project or open a new project

6 Backup your project in source control!

7 Import [UnityNativeChromaSDK.unitypackage](https://github.com/razerofficial/UnityNativeChromaSDK/releases/tag/1.0) into your project.

**Import Unity Package**

<a target="_blank" href="https://www.youtube.com/watch?v=pmtuaSLXeME"><img src="https://img.youtube.com/vi/pmtuaSLXeME/0.jpg"/></a>


8 Create `Chroma` animations from the `Assets/ChromaSDK/Create Chroma Animation` menu item. This will open a file save dialog and create a chroma animation file when saved.

9 Edit `Chroma` animations by selecting a `Chroma` animation in the `Object Hierarchy` and select the `Assets/ChromaSDK/Edit Chroma Animation` menu item.

![image_1](images/image_1.png)

10 Also edit `Chroma` animations by selecting a `.chroma` file in the `Object Hierarchy`, right-click, and select the `ChromaSDK/Edit Chroma Animation` context item.

![image_6](images/image_6.png)


<a name="tutorials"></a>
## Tutorials

**Convert Video to Chroma Animation**

* Step 1: Capture video with a tool like `Camtasia` and export the video as a GIF image sequence.

* Step 2: Convert the GIF to a PNG image sequence. I use the online tool [onlineconverter.com](https://www.onlineconverter.com/gif-to-png) to convert the GIF to an image sequence.

* Step 3: Use the `Chroma Material Window` to play the image sequence on a material.

* Step 4: Capture the material on a plane with the Unity Capture tool.


[Razer Chroma Playlist](https://www.youtube.com/playlist?list=PL4mjXeDqRBMRE19MjB8aiNPRnm_nYtct7)


**Capture Window**

<a target="_blank" href="https://www.youtube.com/watch?v=dUo0wYkh6oM"><img src="https://img.youtube.com/vi/dUo0wYkh6oM/0.jpg"/></a>


**Composite Capture**

<a target="_blank" href="https://www.youtube.com/watch?v=1m9Qzo6dEyE"><img src="https://img.youtube.com/vi/1m9Qzo6dEyE/0.jpg"/></a>


**Composite Playback**

<a target="_blank" href="https://www.youtube.com/watch?v=PeQfVA6E_2M"><img src="https://img.youtube.com/vi/PeQfVA6E_2M/0.jpg"/></a>


**Capture With Images**

<a target="_blank" href="https://www.youtube.com/watch?v=6XKO6u7nWGk"><img src="https://img.youtube.com/vi/6XKO6u7nWGk/0.jpg"/></a>


**Keyboard Layout Toggle**

<a target="_blank" href="https://www.youtube.com/watch?v=48l0cO3mITk"><img src="https://img.youtube.com/vi/48l0cO3mITk/0.jpg"/></a>


**Loop and Reverse**

<a target="_blank" href="https://www.youtube.com/watch?v=jkcdqcBsGi0"><img src="https://img.youtube.com/vi/jkcdqcBsGi0/0.jpg"/></a>


**Keyboard Masks**

<a target="_blank" href="https://www.youtube.com/watch?v=gOegDh8tLUo"><img src="https://img.youtube.com/vi/gOegDh8tLUo/0.jpg"/></a>


**Layouts and Playback Looping**

<a target="_blank" href="https://www.youtube.com/watch?v=J6BWRsBHzWo"><img src="https://img.youtube.com/vi/J6BWRsBHzWo/0.jpg"/></a>


<a name="assets"></a>
## Assets

`Chroma` animations are loaded from the [`StreamingAssets`](https://docs.unity3d.com/Manual/StreamingAssets.html) folder.

Use the `GameObject->ChromaSDK` menu to create `Chroma` animations.

![image_1](images/image_1.png)

`Chroma` animations should be saved in the [`StreamingAssets`](https://docs.unity3d.com/Manual/StreamingAssets.html) folder.

Editing `Chroma` animations will open the `Chroma` editor dialog.

![image_2](images/image_2.png)

<a name="api"></a>
## API

* [AddFrame](#AddFrame)
* [AddNonZeroAllKeysAllFrames](#AddNonZeroAllKeysAllFrames)
* [AddNonZeroAllKeysAllFramesName](#AddNonZeroAllKeysAllFramesName)
* [AddNonZeroAllKeysAllFramesNameD](#AddNonZeroAllKeysAllFramesNameD)
* [AddNonZeroAllKeysAllFramesOffset](#AddNonZeroAllKeysAllFramesOffset)
* [AddNonZeroAllKeysAllFramesOffsetName](#AddNonZeroAllKeysAllFramesOffsetName)
* [AddNonZeroAllKeysAllFramesOffsetNameD](#AddNonZeroAllKeysAllFramesOffsetNameD)
* [AddNonZeroAllKeysOffset](#AddNonZeroAllKeysOffset)
* [AddNonZeroAllKeysOffsetName](#AddNonZeroAllKeysOffsetName)
* [AddNonZeroAllKeysOffsetNameD](#AddNonZeroAllKeysOffsetNameD)
* [AddNonZeroTargetAllKeysAllFrames](#AddNonZeroTargetAllKeysAllFrames)
* [AddNonZeroTargetAllKeysAllFramesName](#AddNonZeroTargetAllKeysAllFramesName)
* [AddNonZeroTargetAllKeysAllFramesNameD](#AddNonZeroTargetAllKeysAllFramesNameD)
* [AddNonZeroTargetAllKeysAllFramesOffset](#AddNonZeroTargetAllKeysAllFramesOffset)
* [AddNonZeroTargetAllKeysAllFramesOffsetName](#AddNonZeroTargetAllKeysAllFramesOffsetName)
* [AddNonZeroTargetAllKeysAllFramesOffsetNameD](#AddNonZeroTargetAllKeysAllFramesOffsetNameD)
* [AddNonZeroTargetAllKeysOffset](#AddNonZeroTargetAllKeysOffset)
* [AddNonZeroTargetAllKeysOffsetName](#AddNonZeroTargetAllKeysOffsetName)
* [AddNonZeroTargetAllKeysOffsetNameD](#AddNonZeroTargetAllKeysOffsetNameD)
* [AppendAllFrames](#AppendAllFrames)
* [AppendAllFramesName](#AppendAllFramesName)
* [AppendAllFramesNameD](#AppendAllFramesNameD)
* [ClearAll](#ClearAll)
* [ClearAnimationType](#ClearAnimationType)
* [CloseAll](#CloseAll)
* [CloseAnimation](#CloseAnimation)
* [CloseAnimationD](#CloseAnimationD)
* [CloseAnimationName](#CloseAnimationName)
* [CloseAnimationNameD](#CloseAnimationNameD)
* [CloseComposite](#CloseComposite)
* [CloseCompositeD](#CloseCompositeD)
* [CopyAnimation](#CopyAnimation)
* [CopyAnimationName](#CopyAnimationName)
* [CopyAnimationNameD](#CopyAnimationNameD)
* [CopyBlueChannelAllFrames](#CopyBlueChannelAllFrames)
* [CopyBlueChannelAllFramesName](#CopyBlueChannelAllFramesName)
* [CopyBlueChannelAllFramesNameD](#CopyBlueChannelAllFramesNameD)
* [CopyGreenChannelAllFrames](#CopyGreenChannelAllFrames)
* [CopyGreenChannelAllFramesName](#CopyGreenChannelAllFramesName)
* [CopyGreenChannelAllFramesNameD](#CopyGreenChannelAllFramesNameD)
* [CopyKeyColor](#CopyKeyColor)
* [CopyKeyColorAllFrames](#CopyKeyColorAllFrames)
* [CopyKeyColorAllFramesName](#CopyKeyColorAllFramesName)
* [CopyKeyColorAllFramesNameD](#CopyKeyColorAllFramesNameD)
* [CopyKeyColorAllFramesOffset](#CopyKeyColorAllFramesOffset)
* [CopyKeyColorAllFramesOffsetName](#CopyKeyColorAllFramesOffsetName)
* [CopyKeyColorAllFramesOffsetNameD](#CopyKeyColorAllFramesOffsetNameD)
* [CopyKeyColorName](#CopyKeyColorName)
* [CopyKeyColorNameD](#CopyKeyColorNameD)
* [CopyKeysColor](#CopyKeysColor)
* [CopyKeysColorName](#CopyKeysColorName)
* [CopyKeysColorOffset](#CopyKeysColorOffset)
* [CopyKeysColorOffsetName](#CopyKeysColorOffsetName)
* [CopyNonZeroAllKeys](#CopyNonZeroAllKeys)
* [CopyNonZeroAllKeysAllFrames](#CopyNonZeroAllKeysAllFrames)
* [CopyNonZeroAllKeysAllFramesName](#CopyNonZeroAllKeysAllFramesName)
* [CopyNonZeroAllKeysAllFramesNameD](#CopyNonZeroAllKeysAllFramesNameD)
* [CopyNonZeroAllKeysAllFramesOffset](#CopyNonZeroAllKeysAllFramesOffset)
* [CopyNonZeroAllKeysAllFramesOffsetName](#CopyNonZeroAllKeysAllFramesOffsetName)
* [CopyNonZeroAllKeysAllFramesOffsetNameD](#CopyNonZeroAllKeysAllFramesOffsetNameD)
* [CopyNonZeroAllKeysName](#CopyNonZeroAllKeysName)
* [CopyNonZeroAllKeysNameD](#CopyNonZeroAllKeysNameD)
* [CopyNonZeroAllKeysOffset](#CopyNonZeroAllKeysOffset)
* [CopyNonZeroAllKeysOffsetName](#CopyNonZeroAllKeysOffsetName)
* [CopyNonZeroAllKeysOffsetNameD](#CopyNonZeroAllKeysOffsetNameD)
* [CopyNonZeroKeyColor](#CopyNonZeroKeyColor)
* [CopyNonZeroKeyColorName](#CopyNonZeroKeyColorName)
* [CopyNonZeroKeyColorNameD](#CopyNonZeroKeyColorNameD)
* [CopyNonZeroTargetAllKeys](#CopyNonZeroTargetAllKeys)
* [CopyNonZeroTargetAllKeysAllFrames](#CopyNonZeroTargetAllKeysAllFrames)
* [CopyNonZeroTargetAllKeysAllFramesName](#CopyNonZeroTargetAllKeysAllFramesName)
* [CopyNonZeroTargetAllKeysAllFramesNameD](#CopyNonZeroTargetAllKeysAllFramesNameD)
* [CopyNonZeroTargetAllKeysAllFramesOffset](#CopyNonZeroTargetAllKeysAllFramesOffset)
* [CopyNonZeroTargetAllKeysAllFramesOffsetName](#CopyNonZeroTargetAllKeysAllFramesOffsetName)
* [CopyNonZeroTargetAllKeysAllFramesOffsetNameD](#CopyNonZeroTargetAllKeysAllFramesOffsetNameD)
* [CopyNonZeroTargetAllKeysName](#CopyNonZeroTargetAllKeysName)
* [CopyNonZeroTargetAllKeysNameD](#CopyNonZeroTargetAllKeysNameD)
* [CopyNonZeroTargetAllKeysOffset](#CopyNonZeroTargetAllKeysOffset)
* [CopyNonZeroTargetAllKeysOffsetName](#CopyNonZeroTargetAllKeysOffsetName)
* [CopyNonZeroTargetAllKeysOffsetNameD](#CopyNonZeroTargetAllKeysOffsetNameD)
* [CopyNonZeroTargetZeroAllKeysAllFrames](#CopyNonZeroTargetZeroAllKeysAllFrames)
* [CopyNonZeroTargetZeroAllKeysAllFramesName](#CopyNonZeroTargetZeroAllKeysAllFramesName)
* [CopyNonZeroTargetZeroAllKeysAllFramesNameD](#CopyNonZeroTargetZeroAllKeysAllFramesNameD)
* [CopyRedChannelAllFrames](#CopyRedChannelAllFrames)
* [CopyRedChannelAllFramesName](#CopyRedChannelAllFramesName)
* [CopyRedChannelAllFramesNameD](#CopyRedChannelAllFramesNameD)
* [CopyZeroAllKeysAllFrames](#CopyZeroAllKeysAllFrames)
* [CopyZeroAllKeysAllFramesName](#CopyZeroAllKeysAllFramesName)
* [CopyZeroAllKeysAllFramesNameD](#CopyZeroAllKeysAllFramesNameD)
* [CopyZeroAllKeysAllFramesOffset](#CopyZeroAllKeysAllFramesOffset)
* [CopyZeroAllKeysAllFramesOffsetName](#CopyZeroAllKeysAllFramesOffsetName)
* [CopyZeroAllKeysAllFramesOffsetNameD](#CopyZeroAllKeysAllFramesOffsetNameD)
* [CopyZeroKeyColor](#CopyZeroKeyColor)
* [CopyZeroKeyColorName](#CopyZeroKeyColorName)
* [CopyZeroKeyColorNameD](#CopyZeroKeyColorNameD)
* [CopyZeroTargetAllKeysAllFrames](#CopyZeroTargetAllKeysAllFrames)
* [CopyZeroTargetAllKeysAllFramesName](#CopyZeroTargetAllKeysAllFramesName)
* [CopyZeroTargetAllKeysAllFramesNameD](#CopyZeroTargetAllKeysAllFramesNameD)
* [CoreCreateChromaLinkEffect](#CoreCreateChromaLinkEffect)
* [CoreCreateEffect](#CoreCreateEffect)
* [CoreCreateHeadsetEffect](#CoreCreateHeadsetEffect)
* [CoreCreateKeyboardEffect](#CoreCreateKeyboardEffect)
* [CoreCreateKeypadEffect](#CoreCreateKeypadEffect)
* [CoreCreateMouseEffect](#CoreCreateMouseEffect)
* [CoreCreateMousepadEffect](#CoreCreateMousepadEffect)
* [CoreDeleteEffect](#CoreDeleteEffect)
* [CoreInit](#CoreInit)
* [CoreQueryDevice](#CoreQueryDevice)
* [CoreSetEffect](#CoreSetEffect)
* [CoreUnInit](#CoreUnInit)
* [CreateAnimation](#CreateAnimation)
* [CreateAnimationInMemory](#CreateAnimationInMemory)
* [CreateEffect](#CreateEffect)
* [DeleteEffect](#DeleteEffect)
* [DuplicateFirstFrame](#DuplicateFirstFrame)
* [DuplicateFirstFrameName](#DuplicateFirstFrameName)
* [DuplicateFirstFrameNameD](#DuplicateFirstFrameNameD)
* [DuplicateFrames](#DuplicateFrames)
* [DuplicateFramesName](#DuplicateFramesName)
* [DuplicateFramesNameD](#DuplicateFramesNameD)
* [DuplicateMirrorFrames](#DuplicateMirrorFrames)
* [DuplicateMirrorFramesName](#DuplicateMirrorFramesName)
* [DuplicateMirrorFramesNameD](#DuplicateMirrorFramesNameD)
* [FadeEndFrames](#FadeEndFrames)
* [FadeEndFramesName](#FadeEndFramesName)
* [FadeEndFramesNameD](#FadeEndFramesNameD)
* [FadeStartFrames](#FadeStartFrames)
* [FadeStartFramesName](#FadeStartFramesName)
* [FadeStartFramesNameD](#FadeStartFramesNameD)
* [FillColor](#FillColor)
* [FillColorAllFrames](#FillColorAllFrames)
* [FillColorAllFramesName](#FillColorAllFramesName)
* [FillColorAllFramesNameD](#FillColorAllFramesNameD)
* [FillColorAllFramesRGB](#FillColorAllFramesRGB)
* [FillColorAllFramesRGBName](#FillColorAllFramesRGBName)
* [FillColorAllFramesRGBNameD](#FillColorAllFramesRGBNameD)
* [FillColorName](#FillColorName)
* [FillColorNameD](#FillColorNameD)
* [FillColorRGB](#FillColorRGB)
* [FillColorRGBName](#FillColorRGBName)
* [FillColorRGBNameD](#FillColorRGBNameD)
* [FillNonZeroColor](#FillNonZeroColor)
* [FillNonZeroColorAllFrames](#FillNonZeroColorAllFrames)
* [FillNonZeroColorAllFramesName](#FillNonZeroColorAllFramesName)
* [FillNonZeroColorAllFramesNameD](#FillNonZeroColorAllFramesNameD)
* [FillNonZeroColorAllFramesRGB](#FillNonZeroColorAllFramesRGB)
* [FillNonZeroColorAllFramesRGBName](#FillNonZeroColorAllFramesRGBName)
* [FillNonZeroColorAllFramesRGBNameD](#FillNonZeroColorAllFramesRGBNameD)
* [FillNonZeroColorName](#FillNonZeroColorName)
* [FillNonZeroColorNameD](#FillNonZeroColorNameD)
* [FillNonZeroColorRGB](#FillNonZeroColorRGB)
* [FillNonZeroColorRGBName](#FillNonZeroColorRGBName)
* [FillNonZeroColorRGBNameD](#FillNonZeroColorRGBNameD)
* [FillRandomColors](#FillRandomColors)
* [FillRandomColorsAllFrames](#FillRandomColorsAllFrames)
* [FillRandomColorsAllFramesName](#FillRandomColorsAllFramesName)
* [FillRandomColorsAllFramesNameD](#FillRandomColorsAllFramesNameD)
* [FillRandomColorsBlackAndWhite](#FillRandomColorsBlackAndWhite)
* [FillRandomColorsBlackAndWhiteAllFrames](#FillRandomColorsBlackAndWhiteAllFrames)
* [FillRandomColorsBlackAndWhiteAllFramesName](#FillRandomColorsBlackAndWhiteAllFramesName)
* [FillRandomColorsBlackAndWhiteAllFramesNameD](#FillRandomColorsBlackAndWhiteAllFramesNameD)
* [FillRandomColorsBlackAndWhiteName](#FillRandomColorsBlackAndWhiteName)
* [FillRandomColorsBlackAndWhiteNameD](#FillRandomColorsBlackAndWhiteNameD)
* [FillRandomColorsName](#FillRandomColorsName)
* [FillRandomColorsNameD](#FillRandomColorsNameD)
* [FillThresholdColors](#FillThresholdColors)
* [FillThresholdColorsAllFrames](#FillThresholdColorsAllFrames)
* [FillThresholdColorsAllFramesName](#FillThresholdColorsAllFramesName)
* [FillThresholdColorsAllFramesNameD](#FillThresholdColorsAllFramesNameD)
* [FillThresholdColorsAllFramesRGB](#FillThresholdColorsAllFramesRGB)
* [FillThresholdColorsAllFramesRGBName](#FillThresholdColorsAllFramesRGBName)
* [FillThresholdColorsAllFramesRGBNameD](#FillThresholdColorsAllFramesRGBNameD)
* [FillThresholdColorsMinMaxAllFramesRGB](#FillThresholdColorsMinMaxAllFramesRGB)
* [FillThresholdColorsMinMaxAllFramesRGBName](#FillThresholdColorsMinMaxAllFramesRGBName)
* [FillThresholdColorsMinMaxAllFramesRGBNameD](#FillThresholdColorsMinMaxAllFramesRGBNameD)
* [FillThresholdColorsMinMaxRGB](#FillThresholdColorsMinMaxRGB)
* [FillThresholdColorsMinMaxRGBName](#FillThresholdColorsMinMaxRGBName)
* [FillThresholdColorsMinMaxRGBNameD](#FillThresholdColorsMinMaxRGBNameD)
* [FillThresholdColorsName](#FillThresholdColorsName)
* [FillThresholdColorsNameD](#FillThresholdColorsNameD)
* [FillThresholdColorsRGB](#FillThresholdColorsRGB)
* [FillThresholdColorsRGBName](#FillThresholdColorsRGBName)
* [FillThresholdColorsRGBNameD](#FillThresholdColorsRGBNameD)
* [FillThresholdRGBColorsAllFramesRGB](#FillThresholdRGBColorsAllFramesRGB)
* [FillThresholdRGBColorsAllFramesRGBName](#FillThresholdRGBColorsAllFramesRGBName)
* [FillThresholdRGBColorsAllFramesRGBNameD](#FillThresholdRGBColorsAllFramesRGBNameD)
* [FillThresholdRGBColorsRGB](#FillThresholdRGBColorsRGB)
* [FillThresholdRGBColorsRGBName](#FillThresholdRGBColorsRGBName)
* [FillThresholdRGBColorsRGBNameD](#FillThresholdRGBColorsRGBNameD)
* [FillZeroColor](#FillZeroColor)
* [FillZeroColorAllFrames](#FillZeroColorAllFrames)
* [FillZeroColorAllFramesName](#FillZeroColorAllFramesName)
* [FillZeroColorAllFramesNameD](#FillZeroColorAllFramesNameD)
* [FillZeroColorAllFramesRGB](#FillZeroColorAllFramesRGB)
* [FillZeroColorAllFramesRGBName](#FillZeroColorAllFramesRGBName)
* [FillZeroColorAllFramesRGBNameD](#FillZeroColorAllFramesRGBNameD)
* [FillZeroColorName](#FillZeroColorName)
* [FillZeroColorNameD](#FillZeroColorNameD)
* [FillZeroColorRGB](#FillZeroColorRGB)
* [FillZeroColorRGBName](#FillZeroColorRGBName)
* [FillZeroColorRGBNameD](#FillZeroColorRGBNameD)
* [Get1DColor](#Get1DColor)
* [Get1DColorName](#Get1DColorName)
* [Get1DColorNameD](#Get1DColorNameD)
* [Get2DColor](#Get2DColor)
* [Get2DColorName](#Get2DColorName)
* [Get2DColorNameD](#Get2DColorNameD)
* [GetAnimation](#GetAnimation)
* [GetAnimationCount](#GetAnimationCount)
* [GetAnimationD](#GetAnimationD)
* [GetAnimationId](#GetAnimationId)
* [GetAnimationName](#GetAnimationName)
* [GetCurrentFrame](#GetCurrentFrame)
* [GetCurrentFrameName](#GetCurrentFrameName)
* [GetCurrentFrameNameD](#GetCurrentFrameNameD)
* [GetDevice](#GetDevice)
* [GetDeviceName](#GetDeviceName)
* [GetDeviceNameD](#GetDeviceNameD)
* [GetDeviceType](#GetDeviceType)
* [GetDeviceTypeName](#GetDeviceTypeName)
* [GetDeviceTypeNameD](#GetDeviceTypeNameD)
* [GetFrame](#GetFrame)
* [GetFrameCount](#GetFrameCount)
* [GetFrameCountName](#GetFrameCountName)
* [GetFrameCountNameD](#GetFrameCountNameD)
* [GetKeyColor](#GetKeyColor)
* [GetKeyColorD](#GetKeyColorD)
* [GetKeyColorName](#GetKeyColorName)
* [GetLibraryLoadedState](#GetLibraryLoadedState)
* [GetLibraryLoadedStateD](#GetLibraryLoadedStateD)
* [GetMaxColumn](#GetMaxColumn)
* [GetMaxColumnD](#GetMaxColumnD)
* [GetMaxLeds](#GetMaxLeds)
* [GetMaxLedsD](#GetMaxLedsD)
* [GetMaxRow](#GetMaxRow)
* [GetMaxRowD](#GetMaxRowD)
* [GetPlayingAnimationCount](#GetPlayingAnimationCount)
* [GetPlayingAnimationId](#GetPlayingAnimationId)
* [GetRGB](#GetRGB)
* [GetRGBD](#GetRGBD)
* [HasAnimationLoop](#HasAnimationLoop)
* [HasAnimationLoopName](#HasAnimationLoopName)
* [HasAnimationLoopNameD](#HasAnimationLoopNameD)
* [Init](#Init)
* [InitD](#InitD)
* [InsertDelay](#InsertDelay)
* [InsertDelayName](#InsertDelayName)
* [InsertDelayNameD](#InsertDelayNameD)
* [InsertFrame](#InsertFrame)
* [InsertFrameName](#InsertFrameName)
* [InsertFrameNameD](#InsertFrameNameD)
* [InvertColors](#InvertColors)
* [InvertColorsAllFrames](#InvertColorsAllFrames)
* [InvertColorsAllFramesName](#InvertColorsAllFramesName)
* [InvertColorsAllFramesNameD](#InvertColorsAllFramesNameD)
* [InvertColorsName](#InvertColorsName)
* [InvertColorsNameD](#InvertColorsNameD)
* [IsAnimationPaused](#IsAnimationPaused)
* [IsAnimationPausedName](#IsAnimationPausedName)
* [IsAnimationPausedNameD](#IsAnimationPausedNameD)
* [IsDialogOpen](#IsDialogOpen)
* [IsDialogOpenD](#IsDialogOpenD)
* [IsInitialized](#IsInitialized)
* [IsInitializedD](#IsInitializedD)
* [IsPlatformSupported](#IsPlatformSupported)
* [IsPlatformSupportedD](#IsPlatformSupportedD)
* [IsPlaying](#IsPlaying)
* [IsPlayingD](#IsPlayingD)
* [IsPlayingName](#IsPlayingName)
* [IsPlayingNameD](#IsPlayingNameD)
* [IsPlayingType](#IsPlayingType)
* [IsPlayingTypeD](#IsPlayingTypeD)
* [Lerp](#Lerp)
* [LerpColor](#LerpColor)
* [LoadAnimation](#LoadAnimation)
* [LoadAnimationD](#LoadAnimationD)
* [LoadAnimationName](#LoadAnimationName)
* [LoadComposite](#LoadComposite)
* [MakeBlankFrames](#MakeBlankFrames)
* [MakeBlankFramesName](#MakeBlankFramesName)
* [MakeBlankFramesNameD](#MakeBlankFramesNameD)
* [MakeBlankFramesRandom](#MakeBlankFramesRandom)
* [MakeBlankFramesRandomBlackAndWhite](#MakeBlankFramesRandomBlackAndWhite)
* [MakeBlankFramesRandomBlackAndWhiteName](#MakeBlankFramesRandomBlackAndWhiteName)
* [MakeBlankFramesRandomBlackAndWhiteNameD](#MakeBlankFramesRandomBlackAndWhiteNameD)
* [MakeBlankFramesRandomName](#MakeBlankFramesRandomName)
* [MakeBlankFramesRandomNameD](#MakeBlankFramesRandomNameD)
* [MakeBlankFramesRGB](#MakeBlankFramesRGB)
* [MakeBlankFramesRGBName](#MakeBlankFramesRGBName)
* [MakeBlankFramesRGBNameD](#MakeBlankFramesRGBNameD)
* [MirrorHorizontally](#MirrorHorizontally)
* [MirrorVertically](#MirrorVertically)
* [MultiplyColorLerpAllFrames](#MultiplyColorLerpAllFrames)
* [MultiplyColorLerpAllFramesName](#MultiplyColorLerpAllFramesName)
* [MultiplyColorLerpAllFramesNameD](#MultiplyColorLerpAllFramesNameD)
* [MultiplyIntensity](#MultiplyIntensity)
* [MultiplyIntensityAllFrames](#MultiplyIntensityAllFrames)
* [MultiplyIntensityAllFramesName](#MultiplyIntensityAllFramesName)
* [MultiplyIntensityAllFramesNameD](#MultiplyIntensityAllFramesNameD)
* [MultiplyIntensityAllFramesRGB](#MultiplyIntensityAllFramesRGB)
* [MultiplyIntensityAllFramesRGBName](#MultiplyIntensityAllFramesRGBName)
* [MultiplyIntensityAllFramesRGBNameD](#MultiplyIntensityAllFramesRGBNameD)
* [MultiplyIntensityColor](#MultiplyIntensityColor)
* [MultiplyIntensityColorAllFrames](#MultiplyIntensityColorAllFrames)
* [MultiplyIntensityColorAllFramesName](#MultiplyIntensityColorAllFramesName)
* [MultiplyIntensityColorAllFramesNameD](#MultiplyIntensityColorAllFramesNameD)
* [MultiplyIntensityColorName](#MultiplyIntensityColorName)
* [MultiplyIntensityColorNameD](#MultiplyIntensityColorNameD)
* [MultiplyIntensityName](#MultiplyIntensityName)
* [MultiplyIntensityNameD](#MultiplyIntensityNameD)
* [MultiplyIntensityRGB](#MultiplyIntensityRGB)
* [MultiplyIntensityRGBName](#MultiplyIntensityRGBName)
* [MultiplyIntensityRGBNameD](#MultiplyIntensityRGBNameD)
* [MultiplyNonZeroTargetColorLerp](#MultiplyNonZeroTargetColorLerp)
* [MultiplyNonZeroTargetColorLerpAllFrames](#MultiplyNonZeroTargetColorLerpAllFrames)
* [MultiplyNonZeroTargetColorLerpAllFramesName](#MultiplyNonZeroTargetColorLerpAllFramesName)
* [MultiplyNonZeroTargetColorLerpAllFramesNameD](#MultiplyNonZeroTargetColorLerpAllFramesNameD)
* [MultiplyNonZeroTargetColorLerpAllFramesRGB](#MultiplyNonZeroTargetColorLerpAllFramesRGB)
* [MultiplyNonZeroTargetColorLerpAllFramesRGBName](#MultiplyNonZeroTargetColorLerpAllFramesRGBName)
* [MultiplyNonZeroTargetColorLerpAllFramesRGBNameD](#MultiplyNonZeroTargetColorLerpAllFramesRGBNameD)
* [MultiplyTargetColorLerp](#MultiplyTargetColorLerp)
* [MultiplyTargetColorLerpAllFrames](#MultiplyTargetColorLerpAllFrames)
* [MultiplyTargetColorLerpAllFramesName](#MultiplyTargetColorLerpAllFramesName)
* [MultiplyTargetColorLerpAllFramesNameD](#MultiplyTargetColorLerpAllFramesNameD)
* [MultiplyTargetColorLerpAllFramesRGB](#MultiplyTargetColorLerpAllFramesRGB)
* [MultiplyTargetColorLerpAllFramesRGBName](#MultiplyTargetColorLerpAllFramesRGBName)
* [MultiplyTargetColorLerpAllFramesRGBNameD](#MultiplyTargetColorLerpAllFramesRGBNameD)
* [OffsetColors](#OffsetColors)
* [OffsetColorsAllFrames](#OffsetColorsAllFrames)
* [OffsetColorsAllFramesName](#OffsetColorsAllFramesName)
* [OffsetColorsAllFramesNameD](#OffsetColorsAllFramesNameD)
* [OffsetColorsName](#OffsetColorsName)
* [OffsetColorsNameD](#OffsetColorsNameD)
* [OffsetNonZeroColors](#OffsetNonZeroColors)
* [OffsetNonZeroColorsAllFrames](#OffsetNonZeroColorsAllFrames)
* [OffsetNonZeroColorsAllFramesName](#OffsetNonZeroColorsAllFramesName)
* [OffsetNonZeroColorsAllFramesNameD](#OffsetNonZeroColorsAllFramesNameD)
* [OffsetNonZeroColorsName](#OffsetNonZeroColorsName)
* [OffsetNonZeroColorsNameD](#OffsetNonZeroColorsNameD)
* [OpenAnimation](#OpenAnimation)
* [OpenAnimationD](#OpenAnimationD)
* [OpenAnimationFromMemory](#OpenAnimationFromMemory)
* [OpenEditorDialog](#OpenEditorDialog)
* [OpenEditorDialogAndPlay](#OpenEditorDialogAndPlay)
* [OpenEditorDialogAndPlayD](#OpenEditorDialogAndPlayD)
* [OpenEditorDialogD](#OpenEditorDialogD)
* [OverrideFrameDuration](#OverrideFrameDuration)
* [OverrideFrameDurationD](#OverrideFrameDurationD)
* [OverrideFrameDurationName](#OverrideFrameDurationName)
* [PauseAnimation](#PauseAnimation)
* [PauseAnimationName](#PauseAnimationName)
* [PauseAnimationNameD](#PauseAnimationNameD)
* [PlayAnimation](#PlayAnimation)
* [PlayAnimationD](#PlayAnimationD)
* [PlayAnimationFrame](#PlayAnimationFrame)
* [PlayAnimationFrameName](#PlayAnimationFrameName)
* [PlayAnimationFrameNameD](#PlayAnimationFrameNameD)
* [PlayAnimationLoop](#PlayAnimationLoop)
* [PlayAnimationName](#PlayAnimationName)
* [PlayAnimationNameD](#PlayAnimationNameD)
* [PlayComposite](#PlayComposite)
* [PlayCompositeD](#PlayCompositeD)
* [PreviewFrame](#PreviewFrame)
* [PreviewFrameD](#PreviewFrameD)
* [PreviewFrameName](#PreviewFrameName)
* [ReduceFrames](#ReduceFrames)
* [ReduceFramesName](#ReduceFramesName)
* [ReduceFramesNameD](#ReduceFramesNameD)
* [ResetAnimation](#ResetAnimation)
* [ResumeAnimation](#ResumeAnimation)
* [ResumeAnimationName](#ResumeAnimationName)
* [ResumeAnimationNameD](#ResumeAnimationNameD)
* [Reverse](#Reverse)
* [ReverseAllFrames](#ReverseAllFrames)
* [ReverseAllFramesName](#ReverseAllFramesName)
* [ReverseAllFramesNameD](#ReverseAllFramesNameD)
* [SaveAnimation](#SaveAnimation)
* [SaveAnimationName](#SaveAnimationName)
* [Set1DColor](#Set1DColor)
* [Set1DColorName](#Set1DColorName)
* [Set1DColorNameD](#Set1DColorNameD)
* [Set2DColor](#Set2DColor)
* [Set2DColorName](#Set2DColorName)
* [Set2DColorNameD](#Set2DColorNameD)
* [SetChromaCustomColorAllFrames](#SetChromaCustomColorAllFrames)
* [SetChromaCustomColorAllFramesName](#SetChromaCustomColorAllFramesName)
* [SetChromaCustomColorAllFramesNameD](#SetChromaCustomColorAllFramesNameD)
* [SetChromaCustomFlag](#SetChromaCustomFlag)
* [SetChromaCustomFlagName](#SetChromaCustomFlagName)
* [SetChromaCustomFlagNameD](#SetChromaCustomFlagNameD)
* [SetCurrentFrame](#SetCurrentFrame)
* [SetCurrentFrameName](#SetCurrentFrameName)
* [SetCurrentFrameNameD](#SetCurrentFrameNameD)
* [SetDevice](#SetDevice)
* [SetEffect](#SetEffect)
* [SetIdleAnimation](#SetIdleAnimation)
* [SetIdleAnimationName](#SetIdleAnimationName)
* [SetKeyColor](#SetKeyColor)
* [SetKeyColorAllFrames](#SetKeyColorAllFrames)
* [SetKeyColorAllFramesName](#SetKeyColorAllFramesName)
* [SetKeyColorAllFramesNameD](#SetKeyColorAllFramesNameD)
* [SetKeyColorAllFramesRGB](#SetKeyColorAllFramesRGB)
* [SetKeyColorAllFramesRGBName](#SetKeyColorAllFramesRGBName)
* [SetKeyColorAllFramesRGBNameD](#SetKeyColorAllFramesRGBNameD)
* [SetKeyColorName](#SetKeyColorName)
* [SetKeyColorNameD](#SetKeyColorNameD)
* [SetKeyColorRGB](#SetKeyColorRGB)
* [SetKeyColorRGBName](#SetKeyColorRGBName)
* [SetKeyColorRGBNameD](#SetKeyColorRGBNameD)
* [SetKeyNonZeroColor](#SetKeyNonZeroColor)
* [SetKeyNonZeroColorName](#SetKeyNonZeroColorName)
* [SetKeyNonZeroColorNameD](#SetKeyNonZeroColorNameD)
* [SetKeyNonZeroColorRGB](#SetKeyNonZeroColorRGB)
* [SetKeyNonZeroColorRGBName](#SetKeyNonZeroColorRGBName)
* [SetKeyNonZeroColorRGBNameD](#SetKeyNonZeroColorRGBNameD)
* [SetKeysColor](#SetKeysColor)
* [SetKeysColorAllFrames](#SetKeysColorAllFrames)
* [SetKeysColorAllFramesName](#SetKeysColorAllFramesName)
* [SetKeysColorAllFramesRGB](#SetKeysColorAllFramesRGB)
* [SetKeysColorAllFramesRGBName](#SetKeysColorAllFramesRGBName)
* [SetKeysColorName](#SetKeysColorName)
* [SetKeysColorRGB](#SetKeysColorRGB)
* [SetKeysColorRGBName](#SetKeysColorRGBName)
* [SetKeysNonZeroColor](#SetKeysNonZeroColor)
* [SetKeysNonZeroColorAllFrames](#SetKeysNonZeroColorAllFrames)
* [SetKeysNonZeroColorAllFramesName](#SetKeysNonZeroColorAllFramesName)
* [SetKeysNonZeroColorName](#SetKeysNonZeroColorName)
* [SetKeysNonZeroColorRGB](#SetKeysNonZeroColorRGB)
* [SetKeysNonZeroColorRGBName](#SetKeysNonZeroColorRGBName)
* [SetKeysZeroColor](#SetKeysZeroColor)
* [SetKeysZeroColorAllFrames](#SetKeysZeroColorAllFrames)
* [SetKeysZeroColorAllFramesName](#SetKeysZeroColorAllFramesName)
* [SetKeysZeroColorAllFramesRGB](#SetKeysZeroColorAllFramesRGB)
* [SetKeysZeroColorAllFramesRGBName](#SetKeysZeroColorAllFramesRGBName)
* [SetKeysZeroColorName](#SetKeysZeroColorName)
* [SetKeysZeroColorRGB](#SetKeysZeroColorRGB)
* [SetKeysZeroColorRGBName](#SetKeysZeroColorRGBName)
* [SetKeyZeroColor](#SetKeyZeroColor)
* [SetKeyZeroColorName](#SetKeyZeroColorName)
* [SetKeyZeroColorNameD](#SetKeyZeroColorNameD)
* [SetKeyZeroColorRGB](#SetKeyZeroColorRGB)
* [SetKeyZeroColorRGBName](#SetKeyZeroColorRGBName)
* [SetKeyZeroColorRGBNameD](#SetKeyZeroColorRGBNameD)
* [SetLogDelegate](#SetLogDelegate)
* [StaticColor](#StaticColor)
* [StaticColorD](#StaticColorD)
* [StopAll](#StopAll)
* [StopAnimation](#StopAnimation)
* [StopAnimationD](#StopAnimationD)
* [StopAnimationName](#StopAnimationName)
* [StopAnimationNameD](#StopAnimationNameD)
* [StopAnimationType](#StopAnimationType)
* [StopAnimationTypeD](#StopAnimationTypeD)
* [StopComposite](#StopComposite)
* [StopCompositeD](#StopCompositeD)
* [SubtractNonZeroAllKeysAllFrames](#SubtractNonZeroAllKeysAllFrames)
* [SubtractNonZeroAllKeysAllFramesName](#SubtractNonZeroAllKeysAllFramesName)
* [SubtractNonZeroAllKeysAllFramesNameD](#SubtractNonZeroAllKeysAllFramesNameD)
* [SubtractNonZeroAllKeysAllFramesOffset](#SubtractNonZeroAllKeysAllFramesOffset)
* [SubtractNonZeroAllKeysAllFramesOffsetName](#SubtractNonZeroAllKeysAllFramesOffsetName)
* [SubtractNonZeroAllKeysAllFramesOffsetNameD](#SubtractNonZeroAllKeysAllFramesOffsetNameD)
* [SubtractNonZeroAllKeysOffset](#SubtractNonZeroAllKeysOffset)
* [SubtractNonZeroAllKeysOffsetName](#SubtractNonZeroAllKeysOffsetName)
* [SubtractNonZeroAllKeysOffsetNameD](#SubtractNonZeroAllKeysOffsetNameD)
* [SubtractNonZeroTargetAllKeysAllFrames](#SubtractNonZeroTargetAllKeysAllFrames)
* [SubtractNonZeroTargetAllKeysAllFramesName](#SubtractNonZeroTargetAllKeysAllFramesName)
* [SubtractNonZeroTargetAllKeysAllFramesNameD](#SubtractNonZeroTargetAllKeysAllFramesNameD)
* [SubtractNonZeroTargetAllKeysAllFramesOffset](#SubtractNonZeroTargetAllKeysAllFramesOffset)
* [SubtractNonZeroTargetAllKeysAllFramesOffsetName](#SubtractNonZeroTargetAllKeysAllFramesOffsetName)
* [SubtractNonZeroTargetAllKeysAllFramesOffsetNameD](#SubtractNonZeroTargetAllKeysAllFramesOffsetNameD)
* [SubtractNonZeroTargetAllKeysOffset](#SubtractNonZeroTargetAllKeysOffset)
* [SubtractNonZeroTargetAllKeysOffsetName](#SubtractNonZeroTargetAllKeysOffsetName)
* [SubtractNonZeroTargetAllKeysOffsetNameD](#SubtractNonZeroTargetAllKeysOffsetNameD)
* [TrimEndFrames](#TrimEndFrames)
* [TrimEndFramesName](#TrimEndFramesName)
* [TrimEndFramesNameD](#TrimEndFramesNameD)
* [TrimFrame](#TrimFrame)
* [TrimFrameName](#TrimFrameName)
* [TrimFrameNameD](#TrimFrameNameD)
* [TrimStartFrames](#TrimStartFrames)
* [TrimStartFramesName](#TrimStartFramesName)
* [TrimStartFramesNameD](#TrimStartFramesNameD)
* [Uninit](#Uninit)
* [UninitD](#UninitD)
* [UnloadAnimation](#UnloadAnimation)
* [UnloadAnimationD](#UnloadAnimationD)
* [UnloadAnimationName](#UnloadAnimationName)
* [UnloadComposite](#UnloadComposite)
* [UpdateFrame](#UpdateFrame)
* [UseIdleAnimation](#UseIdleAnimation)
* [UseIdleAnimations](#UseIdleAnimations)
* [UsePreloading](#UsePreloading)
* [UsePreloadingName](#UsePreloadingName)
---

<a name="AddFrame"></a>
**AddFrame**

Adds a frame to the `Chroma` animation and sets the `duration` (in seconds).
The `color` is expected to be an array of the dimensions for the `deviceType/device`.
The `length` parameter is the size of the `color` array. For `EChromaSDKDevice1DEnum`
the array size should be `MAX LEDS`. For `EChromaSDKDevice2DEnum` the array
size should be `MAX ROW` * `MAX COLUMN`. Returns the animation id upon
success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.AddFrame(int animationId, float duration, int[] colors, int length);
```

---

<a name="AddNonZeroAllKeysAllFrames"></a>
**AddNonZeroAllKeysAllFrames**

Add source color to target where color is not black for all frames, reference
source and target by id.

```charp
UnityNativeChromaSDK.AddNonZeroAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="AddNonZeroAllKeysAllFramesName"></a>
**AddNonZeroAllKeysAllFramesName**

Add source color to target where color is not black for all frames, reference
source and target by name.

```charp
UnityNativeChromaSDK.AddNonZeroAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="AddNonZeroAllKeysAllFramesNameD"></a>
**AddNonZeroAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.AddNonZeroAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="AddNonZeroAllKeysAllFramesOffset"></a>
**AddNonZeroAllKeysAllFramesOffset**

Add source color to target where color is not black for all frames starting
at offset for the length of the source, reference source and target by
id.

```charp
UnityNativeChromaSDK.AddNonZeroAllKeysAllFramesOffset(int sourceAnimationId, int targetAnimationId, int offset);
```

---

<a name="AddNonZeroAllKeysAllFramesOffsetName"></a>
**AddNonZeroAllKeysAllFramesOffsetName**

Add source color to target where color is not black for all frames starting
at offset for the length of the source, reference source and target by
name.

```charp
UnityNativeChromaSDK.AddNonZeroAllKeysAllFramesOffsetName(string sourceAnimation, string targetAnimation, int offset);
```

---

<a name="AddNonZeroAllKeysAllFramesOffsetNameD"></a>
**AddNonZeroAllKeysAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.AddNonZeroAllKeysAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double offset);
```

---

<a name="AddNonZeroAllKeysOffset"></a>
**AddNonZeroAllKeysOffset**

Add source color to target where color is not black for the source frame
and target offset frame, reference source and target by id.

```charp
UnityNativeChromaSDK.AddNonZeroAllKeysOffset(int sourceAnimationId, int targetAnimationId, int frameId, int offset);
```

---

<a name="AddNonZeroAllKeysOffsetName"></a>
**AddNonZeroAllKeysOffsetName**

Add source color to target where color is not black for the source frame
and target offset frame, reference source and target by name.

```charp
UnityNativeChromaSDK.AddNonZeroAllKeysOffsetName(string sourceAnimation, string targetAnimation, int frameId, int offset);
```

---

<a name="AddNonZeroAllKeysOffsetNameD"></a>
**AddNonZeroAllKeysOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.AddNonZeroAllKeysOffsetNameD(string sourceAnimation, string targetAnimation, double frameId, double offset);
```

---

<a name="AddNonZeroTargetAllKeysAllFrames"></a>
**AddNonZeroTargetAllKeysAllFrames**

Add source color to target where the target color is not black for all frames,
reference source and target by id.

```charp
UnityNativeChromaSDK.AddNonZeroTargetAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="AddNonZeroTargetAllKeysAllFramesName"></a>
**AddNonZeroTargetAllKeysAllFramesName**

Add source color to target where the target color is not black for all frames,
reference source and target by name.

```charp
UnityNativeChromaSDK.AddNonZeroTargetAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="AddNonZeroTargetAllKeysAllFramesNameD"></a>
**AddNonZeroTargetAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.AddNonZeroTargetAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="AddNonZeroTargetAllKeysAllFramesOffset"></a>
**AddNonZeroTargetAllKeysAllFramesOffset**

Add source color to target where the target color is not black for all frames
starting at offset for the length of the source, reference source and target
by id.

```charp
UnityNativeChromaSDK.AddNonZeroTargetAllKeysAllFramesOffset(int sourceAnimationId, int targetAnimationId, int offset);
```

---

<a name="AddNonZeroTargetAllKeysAllFramesOffsetName"></a>
**AddNonZeroTargetAllKeysAllFramesOffsetName**

Add source color to target where the target color is not black for all frames
starting at offset for the length of the source, reference source and target
by name.

```charp
UnityNativeChromaSDK.AddNonZeroTargetAllKeysAllFramesOffsetName(string sourceAnimation, string targetAnimation, int offset);
```

---

<a name="AddNonZeroTargetAllKeysAllFramesOffsetNameD"></a>
**AddNonZeroTargetAllKeysAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.AddNonZeroTargetAllKeysAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double offset);
```

---

<a name="AddNonZeroTargetAllKeysOffset"></a>
**AddNonZeroTargetAllKeysOffset**

Add source color to target where target color is not blank from the source
frame to the target offset frame, reference source and target by id.

```charp
UnityNativeChromaSDK.AddNonZeroTargetAllKeysOffset(int sourceAnimationId, int targetAnimationId, int frameId, int offset);
```

---

<a name="AddNonZeroTargetAllKeysOffsetName"></a>
**AddNonZeroTargetAllKeysOffsetName**

Add source color to target where target color is not blank from the source
frame to the target offset frame, reference source and target by name.

```charp
UnityNativeChromaSDK.AddNonZeroTargetAllKeysOffsetName(string sourceAnimation, string targetAnimation, int frameId, int offset);
```

---

<a name="AddNonZeroTargetAllKeysOffsetNameD"></a>
**AddNonZeroTargetAllKeysOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.AddNonZeroTargetAllKeysOffsetNameD(string sourceAnimation, string targetAnimation, double frameId, double offset);
```

---

<a name="AppendAllFrames"></a>
**AppendAllFrames**

Append all source frames to the target animation, reference source and target
by id.

```charp
UnityNativeChromaSDK.AppendAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="AppendAllFramesName"></a>
**AppendAllFramesName**

Append all source frames to the target animation, reference source and target
by name.

```charp
UnityNativeChromaSDK.AppendAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="AppendAllFramesNameD"></a>
**AppendAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.AppendAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="ClearAll"></a>
**ClearAll**

`PluginClearAll` will issue a `CLEAR` effect for all devices.

```charp
UnityNativeChromaSDK.ClearAll();
```

---

<a name="ClearAnimationType"></a>
**ClearAnimationType**

`PluginClearAnimationType` will issue a `CLEAR` effect for the given device.

```charp
UnityNativeChromaSDK.ClearAnimationType(int deviceType, int device);
```

---

<a name="CloseAll"></a>
**CloseAll**

`PluginCloseAll` closes all open animations so they can be reloaded from
disk. The set of animations will be stopped if playing.

```charp
UnityNativeChromaSDK.CloseAll();
```

---

<a name="CloseAnimation"></a>
**CloseAnimation**

Closes the `Chroma` animation to free up resources referenced by id. Returns
the animation id upon success. Returns -1 upon failure. This might be used
while authoring effects if there was a change necessitating re-opening
the animation. The animation id can no longer be used once closed.

```charp
int result = UnityNativeChromaSDK.CloseAnimation(int animationId);
```

---

<a name="CloseAnimationD"></a>
**CloseAnimationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CloseAnimationD(double animationId);
```

---

<a name="CloseAnimationName"></a>
**CloseAnimationName**

Closes the `Chroma` animation referenced by name so that the animation can
be reloaded from disk.

```charp
UnityNativeChromaSDK.CloseAnimationName(string path);
```

---

<a name="CloseAnimationNameD"></a>
**CloseAnimationNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CloseAnimationNameD(string path);
```

---

<a name="CloseComposite"></a>
**CloseComposite**

`PluginCloseComposite` closes a set of animations so they can be reloaded
from disk. The set of animations will be stopped if playing.

```charp
UnityNativeChromaSDK.CloseComposite(string name);
```

---

<a name="CloseCompositeD"></a>
**CloseCompositeD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CloseCompositeD(string name);
```

---

<a name="CopyAnimation"></a>
**CopyAnimation**

Copy animation to named target animation in memory. If target animation
exists, close first. Source is referenced by id.

```charp
int result = UnityNativeChromaSDK.CopyAnimation(int sourceAnimationId, string targetAnimation);
```

---

<a name="CopyAnimationName"></a>
**CopyAnimationName**

Copy animation to named target animation in memory. If target animation
exists, close first. Source is referenced by name.

```charp
UnityNativeChromaSDK.CopyAnimationName(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyAnimationNameD"></a>
**CopyAnimationNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyAnimationNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyBlueChannelAllFrames"></a>
**CopyBlueChannelAllFrames**

Copy blue channel to other channels for all frames. Intensity range is 0.0
to 1.0. Reference the animation by id.

```charp
UnityNativeChromaSDK.CopyBlueChannelAllFrames(int animationId, float redIntensity, float greenIntensity);
```

---

<a name="CopyBlueChannelAllFramesName"></a>
**CopyBlueChannelAllFramesName**

Copy blue channel to other channels for all frames. Intensity range is 0.0
to 1.0. Reference the animation by name.

```charp
UnityNativeChromaSDK.CopyBlueChannelAllFramesName(string path, float redIntensity, float greenIntensity);
```

---

<a name="CopyBlueChannelAllFramesNameD"></a>
**CopyBlueChannelAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyBlueChannelAllFramesNameD(string path, double redIntensity, double greenIntensity);
```

---

<a name="CopyGreenChannelAllFrames"></a>
**CopyGreenChannelAllFrames**

Copy green channel to other channels for all frames. Intensity range is
0.0 to 1.0. Reference the animation by id.

```charp
UnityNativeChromaSDK.CopyGreenChannelAllFrames(int animationId, float redIntensity, float blueIntensity);
```

---

<a name="CopyGreenChannelAllFramesName"></a>
**CopyGreenChannelAllFramesName**

Copy green channel to other channels for all frames. Intensity range is
0.0 to 1.0. Reference the animation by name.

```charp
UnityNativeChromaSDK.CopyGreenChannelAllFramesName(string path, float redIntensity, float blueIntensity);
```

---

<a name="CopyGreenChannelAllFramesNameD"></a>
**CopyGreenChannelAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyGreenChannelAllFramesNameD(string path, double redIntensity, double blueIntensity);
```

---

<a name="CopyKeyColor"></a>
**CopyKeyColor**

Copy animation key color from the source animation to the target animation
for the given frame. Reference the source and target by id.

```charp
UnityNativeChromaSDK.CopyKeyColor(int sourceAnimationId, int targetAnimationId, int frameId, int rzkey);
```

---

<a name="CopyKeyColorAllFrames"></a>
**CopyKeyColorAllFrames**

Copy animation key color from the source animation to the target animation
for all frames. Reference the source and target by id.

```charp
UnityNativeChromaSDK.CopyKeyColorAllFrames(int sourceAnimationId, int targetAnimationId, int rzkey);
```

---

<a name="CopyKeyColorAllFramesName"></a>
**CopyKeyColorAllFramesName**

Copy animation key color from the source animation to the target animation
for all frames. Reference the source and target by name.

```charp
UnityNativeChromaSDK.CopyKeyColorAllFramesName(string sourceAnimation, string targetAnimation, int rzkey);
```

---

<a name="CopyKeyColorAllFramesNameD"></a>
**CopyKeyColorAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyKeyColorAllFramesNameD(string sourceAnimation, string targetAnimation, double rzkey);
```

---

<a name="CopyKeyColorAllFramesOffset"></a>
**CopyKeyColorAllFramesOffset**

Copy animation key color from the source animation to the target animation
for all frames, starting at the offset for the length of the source animation.
Source and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyKeyColorAllFramesOffset(int sourceAnimationId, int targetAnimationId, int rzkey, int offset);
```

---

<a name="CopyKeyColorAllFramesOffsetName"></a>
**CopyKeyColorAllFramesOffsetName**

Copy animation key color from the source animation to the target animation
for all frames, starting at the offset for the length of the source animation.
Source and target are referenced by name.

```charp
UnityNativeChromaSDK.CopyKeyColorAllFramesOffsetName(string sourceAnimation, string targetAnimation, int rzkey, int offset);
```

---

<a name="CopyKeyColorAllFramesOffsetNameD"></a>
**CopyKeyColorAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyKeyColorAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double rzkey, double offset);
```

---

<a name="CopyKeyColorName"></a>
**CopyKeyColorName**

Copy animation key color from the source animation to the target animation
for the given frame.

```charp
UnityNativeChromaSDK.CopyKeyColorName(string sourceAnimation, string targetAnimation, int frameId, int rzkey);
```

---

<a name="CopyKeyColorNameD"></a>
**CopyKeyColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyKeyColorNameD(string sourceAnimation, string targetAnimation, double frameId, double rzkey);
```

---

<a name="CopyKeysColor"></a>
**CopyKeysColor**

Copy animation color for a set of keys from the source animation to the
target animation for the given frame. Reference the source and target by
id.

```charp
UnityNativeChromaSDK.CopyKeysColor(int sourceAnimationId, int targetAnimationId, int frameId, int[] keys, int size);
```

---

<a name="CopyKeysColorName"></a>
**CopyKeysColorName**

Copy animation color for a set of keys from the source animation to the
target animation for the given frame. Reference the source and target by
name.

```charp
UnityNativeChromaSDK.CopyKeysColorName(string sourceAnimation, string targetAnimation, int frameId, int[] keys, int size);
```

---

<a name="CopyKeysColorOffset"></a>
**CopyKeysColorOffset**

Copy animation color for a set of keys from the source animation to the
target animation from the source frame to the target frame. Reference the
source and target by id.

```charp
UnityNativeChromaSDK.CopyKeysColorOffset(int sourceAnimationId, int targetAnimationId, int sourceFrameId, int targetFrameId, int[] keys, int size);
```

---

<a name="CopyKeysColorOffsetName"></a>
**CopyKeysColorOffsetName**

Copy animation color for a set of keys from the source animation to the
target animation from the source frame to the target frame. Reference the
source and target by name.

```charp
UnityNativeChromaSDK.CopyKeysColorOffsetName(string sourceAnimation, string targetAnimation, int sourceFrameId, int targetFrameId, int[] keys, int size);
```

---

<a name="CopyNonZeroAllKeys"></a>
**CopyNonZeroAllKeys**

Copy source animation to target animation for the given frame. Source and
target are referenced by id.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeys(int sourceAnimationId, int targetAnimationId, int frameId);
```

---

<a name="CopyNonZeroAllKeysAllFrames"></a>
**CopyNonZeroAllKeysAllFrames**

Copy nonzero colors from a source animation to a target animation for all
frames. Reference source and target by id.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="CopyNonZeroAllKeysAllFramesName"></a>
**CopyNonZeroAllKeysAllFramesName**

Copy nonzero colors from a source animation to a target animation for all
frames. Reference source and target by name.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyNonZeroAllKeysAllFramesNameD"></a>
**CopyNonZeroAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyNonZeroAllKeysAllFramesOffset"></a>
**CopyNonZeroAllKeysAllFramesOffset**

Copy nonzero colors from a source animation to a target animation for all
frames starting at the offset for the length of the source animation. The
source and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesOffset(int sourceAnimationId, int targetAnimationId, int offset);
```

---

<a name="CopyNonZeroAllKeysAllFramesOffsetName"></a>
**CopyNonZeroAllKeysAllFramesOffsetName**

Copy nonzero colors from a source animation to a target animation for all
frames starting at the offset for the length of the source animation. The
source and target are referenced by name.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesOffsetName(string sourceAnimation, string targetAnimation, int offset);
```

---

<a name="CopyNonZeroAllKeysAllFramesOffsetNameD"></a>
**CopyNonZeroAllKeysAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroAllKeysAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double offset);
```

---

<a name="CopyNonZeroAllKeysName"></a>
**CopyNonZeroAllKeysName**

Copy nonzero colors from source animation to target animation for the specified
frame. Source and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeysName(string sourceAnimation, string targetAnimation, int frameId);
```

---

<a name="CopyNonZeroAllKeysNameD"></a>
**CopyNonZeroAllKeysNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroAllKeysNameD(string sourceAnimation, string targetAnimation, double frameId);
```

---

<a name="CopyNonZeroAllKeysOffset"></a>
**CopyNonZeroAllKeysOffset**

Copy nonzero colors from the source animation to the target animation from
the source frame to the target offset frame. Source and target are referenced
by id.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeysOffset(int sourceAnimationId, int targetAnimationId, int frameId, int offset);
```

---

<a name="CopyNonZeroAllKeysOffsetName"></a>
**CopyNonZeroAllKeysOffsetName**

Copy nonzero colors from the source animation to the target animation from
the source frame to the target offset frame. Source and target are referenced
by name.

```charp
UnityNativeChromaSDK.CopyNonZeroAllKeysOffsetName(string sourceAnimation, string targetAnimation, int frameId, int offset);
```

---

<a name="CopyNonZeroAllKeysOffsetNameD"></a>
**CopyNonZeroAllKeysOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroAllKeysOffsetNameD(string sourceAnimation, string targetAnimation, double frameId, double offset);
```

---

<a name="CopyNonZeroKeyColor"></a>
**CopyNonZeroKeyColor**

Copy animation key color from the source animation to the target animation
for the given frame where color is not zero.

```charp
UnityNativeChromaSDK.CopyNonZeroKeyColor(int sourceAnimationId, int targetAnimationId, int frameId, int rzkey);
```

---

<a name="CopyNonZeroKeyColorName"></a>
**CopyNonZeroKeyColorName**

Copy animation key color from the source animation to the target animation
for the given frame where color is not zero.

```charp
UnityNativeChromaSDK.CopyNonZeroKeyColorName(string sourceAnimation, string targetAnimation, int frameId, int rzkey);
```

---

<a name="CopyNonZeroKeyColorNameD"></a>
**CopyNonZeroKeyColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroKeyColorNameD(string sourceAnimation, string targetAnimation, double frameId, double rzkey);
```

---

<a name="CopyNonZeroTargetAllKeys"></a>
**CopyNonZeroTargetAllKeys**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for the specified frame. Source and target
are referenced by id.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeys(int sourceAnimationId, int targetAnimationId, int frameId);
```

---

<a name="CopyNonZeroTargetAllKeysAllFrames"></a>
**CopyNonZeroTargetAllKeysAllFrames**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for all frames. Source and target are referenced
by id.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="CopyNonZeroTargetAllKeysAllFramesName"></a>
**CopyNonZeroTargetAllKeysAllFramesName**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for all frames. Source and target are referenced
by name.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyNonZeroTargetAllKeysAllFramesNameD"></a>
**CopyNonZeroTargetAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroTargetAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyNonZeroTargetAllKeysAllFramesOffset"></a>
**CopyNonZeroTargetAllKeysAllFramesOffset**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for all frames. Source and target are referenced
by name.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeysAllFramesOffset(int sourceAnimationId, int targetAnimationId, int offset);
```

---

<a name="CopyNonZeroTargetAllKeysAllFramesOffsetName"></a>
**CopyNonZeroTargetAllKeysAllFramesOffsetName**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for all frames starting at the target offset
for the length of the source animation. Source and target animations are
referenced by name.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeysAllFramesOffsetName(string sourceAnimation, string targetAnimation, int offset);
```

---

<a name="CopyNonZeroTargetAllKeysAllFramesOffsetNameD"></a>
**CopyNonZeroTargetAllKeysAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroTargetAllKeysAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double offset);
```

---

<a name="CopyNonZeroTargetAllKeysName"></a>
**CopyNonZeroTargetAllKeysName**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for the specified frame. The source and target
are referenced by name.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeysName(string sourceAnimation, string targetAnimation, int frameId);
```

---

<a name="CopyNonZeroTargetAllKeysNameD"></a>
**CopyNonZeroTargetAllKeysNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroTargetAllKeysNameD(string sourceAnimation, string targetAnimation, double frameId);
```

---

<a name="CopyNonZeroTargetAllKeysOffset"></a>
**CopyNonZeroTargetAllKeysOffset**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for the specified source frame and target offset
frame. The source and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeysOffset(int sourceAnimationId, int targetAnimationId, int frameId, int offset);
```

---

<a name="CopyNonZeroTargetAllKeysOffsetName"></a>
**CopyNonZeroTargetAllKeysOffsetName**

Copy nonzero colors from the source animation to the target animation where
the target color is nonzero for the specified source frame and target offset
frame. The source and target are referenced by name.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetAllKeysOffsetName(string sourceAnimation, string targetAnimation, int frameId, int offset);
```

---

<a name="CopyNonZeroTargetAllKeysOffsetNameD"></a>
**CopyNonZeroTargetAllKeysOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroTargetAllKeysOffsetNameD(string sourceAnimation, string targetAnimation, double frameId, double offset);
```

---

<a name="CopyNonZeroTargetZeroAllKeysAllFrames"></a>
**CopyNonZeroTargetZeroAllKeysAllFrames**

Copy nonzero colors from the source animation to the target animation where
the target color is zero for all frames. Source and target are referenced
by id.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetZeroAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="CopyNonZeroTargetZeroAllKeysAllFramesName"></a>
**CopyNonZeroTargetZeroAllKeysAllFramesName**

Copy nonzero colors from the source animation to the target animation where
the target color is zero for all frames. Source and target are referenced
by name.

```charp
UnityNativeChromaSDK.CopyNonZeroTargetZeroAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyNonZeroTargetZeroAllKeysAllFramesNameD"></a>
**CopyNonZeroTargetZeroAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyNonZeroTargetZeroAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyRedChannelAllFrames"></a>
**CopyRedChannelAllFrames**

Copy red channel to other channels for all frames. Intensity range is 0.0
to 1.0. Reference the animation by id.

```charp
UnityNativeChromaSDK.CopyRedChannelAllFrames(int animationId, float greenIntensity, float blueIntensity);
```

---

<a name="CopyRedChannelAllFramesName"></a>
**CopyRedChannelAllFramesName**

Copy green channel to other channels for all frames. Intensity range is
0.0 to 1.0. Reference the animation by name.

```charp
UnityNativeChromaSDK.CopyRedChannelAllFramesName(string path, float greenIntensity, float blueIntensity);
```

---

<a name="CopyRedChannelAllFramesNameD"></a>
**CopyRedChannelAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyRedChannelAllFramesNameD(string path, double greenIntensity, double blueIntensity);
```

---

<a name="CopyZeroAllKeysAllFrames"></a>
**CopyZeroAllKeysAllFrames**

Copy zero colors from source animation to target animation for all frames.
Source and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyZeroAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="CopyZeroAllKeysAllFramesName"></a>
**CopyZeroAllKeysAllFramesName**

Copy zero colors from source animation to target animation for all frames.
Source and target are referenced by name.

```charp
UnityNativeChromaSDK.CopyZeroAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyZeroAllKeysAllFramesNameD"></a>
**CopyZeroAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyZeroAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyZeroAllKeysAllFramesOffset"></a>
**CopyZeroAllKeysAllFramesOffset**

Copy zero colors from source animation to target animation for all frames
starting at the target offset for the length of the source animation. Source
and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyZeroAllKeysAllFramesOffset(int sourceAnimationId, int targetAnimationId, int offset);
```

---

<a name="CopyZeroAllKeysAllFramesOffsetName"></a>
**CopyZeroAllKeysAllFramesOffsetName**

Copy zero colors from source animation to target animation for all frames
starting at the target offset for the length of the source animation. Source
and target are referenced by name.

```charp
UnityNativeChromaSDK.CopyZeroAllKeysAllFramesOffsetName(string sourceAnimation, string targetAnimation, int offset);
```

---

<a name="CopyZeroAllKeysAllFramesOffsetNameD"></a>
**CopyZeroAllKeysAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyZeroAllKeysAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double offset);
```

---

<a name="CopyZeroKeyColor"></a>
**CopyZeroKeyColor**

Copy zero key color from source animation to target animation for the specified
frame. Source and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyZeroKeyColor(int sourceAnimationId, int targetAnimationId, int frameId, int rzkey);
```

---

<a name="CopyZeroKeyColorName"></a>
**CopyZeroKeyColorName**

Copy zero key color from source animation to target animation for the specified
frame. Source and target are referenced by name.

```charp
UnityNativeChromaSDK.CopyZeroKeyColorName(string sourceAnimation, string targetAnimation, int frameId, int rzkey);
```

---

<a name="CopyZeroKeyColorNameD"></a>
**CopyZeroKeyColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyZeroKeyColorNameD(string sourceAnimation, string targetAnimation, double frameId, double rzkey);
```

---

<a name="CopyZeroTargetAllKeysAllFrames"></a>
**CopyZeroTargetAllKeysAllFrames**

Copy nonzero color from source animation to target animation where target
is zero for all frames. Source and target are referenced by id.

```charp
UnityNativeChromaSDK.CopyZeroTargetAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="CopyZeroTargetAllKeysAllFramesName"></a>
**CopyZeroTargetAllKeysAllFramesName**

Copy nonzero color from source animation to target animation where target
is zero for all frames. Source and target are referenced by name.

```charp
UnityNativeChromaSDK.CopyZeroTargetAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="CopyZeroTargetAllKeysAllFramesNameD"></a>
**CopyZeroTargetAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.CopyZeroTargetAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="CoreCreateChromaLinkEffect"></a>
**CoreCreateChromaLinkEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreCreateChromaLinkEffect(int Effect, IntPtr pParam, out Guid pEffectId);
```

---

<a name="CoreCreateEffect"></a>
**CoreCreateEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreCreateEffect(Guid DeviceId, EFFECT_TYPE Effect, IntPtr pParam, out Guid pEffectId);
```

---

<a name="CoreCreateHeadsetEffect"></a>
**CoreCreateHeadsetEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreCreateHeadsetEffect(int Effect, IntPtr pParam, out Guid pEffectId);
```

---

<a name="CoreCreateKeyboardEffect"></a>
**CoreCreateKeyboardEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreCreateKeyboardEffect(int Effect, IntPtr pParam, out Guid pEffectId);
```

---

<a name="CoreCreateKeypadEffect"></a>
**CoreCreateKeypadEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreCreateKeypadEffect(int Effect, IntPtr pParam, out Guid pEffectId);
```

---

<a name="CoreCreateMouseEffect"></a>
**CoreCreateMouseEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreCreateMouseEffect(int Effect, IntPtr pParam, out Guid pEffectId);
```

---

<a name="CoreCreateMousepadEffect"></a>
**CoreCreateMousepadEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreCreateMousepadEffect(int Effect, IntPtr pParam, out Guid pEffectId);
```

---

<a name="CoreDeleteEffect"></a>
**CoreDeleteEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreDeleteEffect(Guid EffectId);
```

---

<a name="CoreInit"></a>
**CoreInit**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreInit();
```

---

<a name="CoreQueryDevice"></a>
**CoreQueryDevice**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreQueryDevice(Guid DeviceId, out DEVICE_INFO_TYPE DeviceInfo);
```

---

<a name="CoreSetEffect"></a>
**CoreSetEffect**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreSetEffect(Guid EffectId);
```

---

<a name="CoreUnInit"></a>
**CoreUnInit**

Direct access to low level API.

```charp
long result = UnityNativeChromaSDK.CoreUnInit();
```

---

<a name="CreateAnimation"></a>
**CreateAnimation**

Creates a `Chroma` animation at the given path. The `deviceType` parameter
uses `EChromaSDKDeviceTypeEnum` as an integer. The `device` parameter uses
`EChromaSDKDevice1DEnum` or `EChromaSDKDevice2DEnum` as an integer, respective
to the `deviceType`. Returns the animation id upon success. Returns -1
upon failure. Saves a `Chroma` animation file with the `.chroma` extension
at the given path. Returns the animation id upon success. Returns -1 upon
failure.

```charp
int result = UnityNativeChromaSDK.CreateAnimation(string path, int deviceType, int device);
```

---

<a name="CreateAnimationInMemory"></a>
**CreateAnimationInMemory**

Creates a `Chroma` animation in memory without creating a file. The `deviceType`
parameter uses `EChromaSDKDeviceTypeEnum` as an integer. The `device` parameter
uses `EChromaSDKDevice1DEnum` or `EChromaSDKDevice2DEnum` as an integer,
respective to the `deviceType`. Returns the animation id upon success.
Returns -1 upon failure. Returns the animation id upon success. Returns
-1 upon failure.

```charp
int result = UnityNativeChromaSDK.CreateAnimationInMemory(int deviceType, int device);
```

---

<a name="CreateEffect"></a>
**CreateEffect**

Create a device specific effect.

```charp
long result = UnityNativeChromaSDK.CreateEffect(Guid deviceId, EFFECT_TYPE effect, int[] colors, int size, out FChromaSDKGuid effectId);
```

---

<a name="DeleteEffect"></a>
**DeleteEffect**

Delete an effect given the effect id.

```charp
long result = UnityNativeChromaSDK.DeleteEffect(Guid effectId);
```

---

<a name="DuplicateFirstFrame"></a>
**DuplicateFirstFrame**

Duplicate the first animation frame so that the animation length matches
the frame count. Animation is referenced by id.

```charp
UnityNativeChromaSDK.DuplicateFirstFrame(int animationId, int frameCount);
```

---

<a name="DuplicateFirstFrameName"></a>
**DuplicateFirstFrameName**

Duplicate the first animation frame so that the animation length matches
the frame count. Animation is referenced by name.

```charp
UnityNativeChromaSDK.DuplicateFirstFrameName(string path, int frameCount);
```

---

<a name="DuplicateFirstFrameNameD"></a>
**DuplicateFirstFrameNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.DuplicateFirstFrameNameD(string path, double frameCount);
```

---

<a name="DuplicateFrames"></a>
**DuplicateFrames**

Duplicate all the frames of the animation to double the animation length.
Frame 1 becomes frame 1 and 2. Frame 2 becomes frame 3 and 4. And so on.
The animation is referenced by id.

```charp
UnityNativeChromaSDK.DuplicateFrames(int animationId);
```

---

<a name="DuplicateFramesName"></a>
**DuplicateFramesName**

Duplicate all the frames of the animation to double the animation length.
Frame 1 becomes frame 1 and 2. Frame 2 becomes frame 3 and 4. And so on.
The animation is referenced by name.

```charp
UnityNativeChromaSDK.DuplicateFramesName(string path);
```

---

<a name="DuplicateFramesNameD"></a>
**DuplicateFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.DuplicateFramesNameD(string path);
```

---

<a name="DuplicateMirrorFrames"></a>
**DuplicateMirrorFrames**

Duplicate all the animation frames in reverse so that the animation plays
forwards and backwards. Animation is referenced by id.

```charp
UnityNativeChromaSDK.DuplicateMirrorFrames(int animationId);
```

---

<a name="DuplicateMirrorFramesName"></a>
**DuplicateMirrorFramesName**

Duplicate all the animation frames in reverse so that the animation plays
forwards and backwards. Animation is referenced by name.

```charp
UnityNativeChromaSDK.DuplicateMirrorFramesName(string path);
```

---

<a name="DuplicateMirrorFramesNameD"></a>
**DuplicateMirrorFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.DuplicateMirrorFramesNameD(string path);
```

---

<a name="FadeEndFrames"></a>
**FadeEndFrames**

Fade the animation to black starting at the fade frame index to the end
of the animation. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FadeEndFrames(int animationId, int fade);
```

---

<a name="FadeEndFramesName"></a>
**FadeEndFramesName**

Fade the animation to black starting at the fade frame index to the end
of the animation. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FadeEndFramesName(string path, int fade);
```

---

<a name="FadeEndFramesNameD"></a>
**FadeEndFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FadeEndFramesNameD(string path, double fade);
```

---

<a name="FadeStartFrames"></a>
**FadeStartFrames**

Fade the animation from black to full color starting at 0 to the fade frame
index. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FadeStartFrames(int animationId, int fade);
```

---

<a name="FadeStartFramesName"></a>
**FadeStartFramesName**

Fade the animation from black to full color starting at 0 to the fade frame
index. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FadeStartFramesName(string path, int fade);
```

---

<a name="FadeStartFramesNameD"></a>
**FadeStartFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FadeStartFramesNameD(string path, double fade);
```

---

<a name="FillColor"></a>
**FillColor**

Set the RGB value for all colors in the specified frame. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.FillColor(int animationId, int frameId, int color);
```

---

<a name="FillColorAllFrames"></a>
**FillColorAllFrames**

Set the RGB value for all colors for all frames. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.FillColorAllFrames(int animationId, int color);
```

---

<a name="FillColorAllFramesName"></a>
**FillColorAllFramesName**

Set the RGB value for all colors for all frames. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.FillColorAllFramesName(string path, int color);
```

---

<a name="FillColorAllFramesNameD"></a>
**FillColorAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillColorAllFramesNameD(string path, double color);
```

---

<a name="FillColorAllFramesRGB"></a>
**FillColorAllFramesRGB**

Set the RGB value for all colors for all frames. Use the range of 0 to 255
for red, green, and blue parameters. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillColorAllFramesRGB(int animationId, int red, int green, int blue);
```

---

<a name="FillColorAllFramesRGBName"></a>
**FillColorAllFramesRGBName**

Set the RGB value for all colors for all frames. Use the range of 0 to 255
for red, green, and blue parameters. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillColorAllFramesRGBName(string path, int red, int green, int blue);
```

---

<a name="FillColorAllFramesRGBNameD"></a>
**FillColorAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillColorAllFramesRGBNameD(string path, double red, double green, double blue);
```

---

<a name="FillColorName"></a>
**FillColorName**

Set the RGB value for all colors in the specified frame. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.FillColorName(string path, int frameId, int color);
```

---

<a name="FillColorNameD"></a>
**FillColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillColorNameD(string path, double frameId, double color);
```

---

<a name="FillColorRGB"></a>
**FillColorRGB**

Set the RGB value for all colors in the specified frame. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.FillColorRGB(int animationId, int frameId, int red, int green, int blue);
```

---

<a name="FillColorRGBName"></a>
**FillColorRGBName**

Set the RGB value for all colors in the specified frame. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.FillColorRGBName(string path, int frameId, int red, int green, int blue);
```

---

<a name="FillColorRGBNameD"></a>
**FillColorRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillColorRGBNameD(string path, double frameId, double red, double green, double blue);
```

---

<a name="FillNonZeroColor"></a>
**FillNonZeroColor**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors in the specified
frame. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillNonZeroColor(int animationId, int frameId, int color);
```

---

<a name="FillNonZeroColorAllFrames"></a>
**FillNonZeroColorAllFrames**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors for all frames.
Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillNonZeroColorAllFrames(int animationId, int color);
```

---

<a name="FillNonZeroColorAllFramesName"></a>
**FillNonZeroColorAllFramesName**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors for all frames.
Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillNonZeroColorAllFramesName(string path, int color);
```

---

<a name="FillNonZeroColorAllFramesNameD"></a>
**FillNonZeroColorAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillNonZeroColorAllFramesNameD(string path, double color);
```

---

<a name="FillNonZeroColorAllFramesRGB"></a>
**FillNonZeroColorAllFramesRGB**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors for all frames.
Use the range of 0 to 255 for red, green, and blue parameters. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.FillNonZeroColorAllFramesRGB(int animationId, int red, int green, int blue);
```

---

<a name="FillNonZeroColorAllFramesRGBName"></a>
**FillNonZeroColorAllFramesRGBName**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors for all frames.
Use the range of 0 to 255 for red, green, and blue parameters. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.FillNonZeroColorAllFramesRGBName(string path, int red, int green, int blue);
```

---

<a name="FillNonZeroColorAllFramesRGBNameD"></a>
**FillNonZeroColorAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillNonZeroColorAllFramesRGBNameD(string path, double red, double green, double blue);
```

---

<a name="FillNonZeroColorName"></a>
**FillNonZeroColorName**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors in the specified
frame. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillNonZeroColorName(string path, int frameId, int color);
```

---

<a name="FillNonZeroColorNameD"></a>
**FillNonZeroColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillNonZeroColorNameD(string path, double frameId, double color);
```

---

<a name="FillNonZeroColorRGB"></a>
**FillNonZeroColorRGB**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors in the specified
frame. Use the range of 0 to 255 for red, green, and blue parameters. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.FillNonZeroColorRGB(int animationId, int frameId, int red, int green, int blue);
```

---

<a name="FillNonZeroColorRGBName"></a>
**FillNonZeroColorRGBName**

This method will only update colors in the animation that are not already
set to black. Set the RGB value for a subset of colors in the specified
frame. Use the range of 0 to 255 for red, green, and blue parameters. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.FillNonZeroColorRGBName(string path, int frameId, int red, int green, int blue);
```

---

<a name="FillNonZeroColorRGBNameD"></a>
**FillNonZeroColorRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillNonZeroColorRGBNameD(string path, double frameId, double red, double green, double blue);
```

---

<a name="FillRandomColors"></a>
**FillRandomColors**

Fill the frame with random RGB values for the given frame. Animation is
referenced by id.

```charp
UnityNativeChromaSDK.FillRandomColors(int animationId, int frameId);
```

---

<a name="FillRandomColorsAllFrames"></a>
**FillRandomColorsAllFrames**

Fill the frame with random RGB values for all frames. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.FillRandomColorsAllFrames(int animationId);
```

---

<a name="FillRandomColorsAllFramesName"></a>
**FillRandomColorsAllFramesName**

Fill the frame with random RGB values for all frames. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.FillRandomColorsAllFramesName(string path);
```

---

<a name="FillRandomColorsAllFramesNameD"></a>
**FillRandomColorsAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillRandomColorsAllFramesNameD(string path);
```

---

<a name="FillRandomColorsBlackAndWhite"></a>
**FillRandomColorsBlackAndWhite**

Fill the frame with random black and white values for the specified frame.
Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillRandomColorsBlackAndWhite(int animationId, int frameId);
```

---

<a name="FillRandomColorsBlackAndWhiteAllFrames"></a>
**FillRandomColorsBlackAndWhiteAllFrames**

Fill the frame with random black and white values for all frames. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.FillRandomColorsBlackAndWhiteAllFrames(int animationId);
```

---

<a name="FillRandomColorsBlackAndWhiteAllFramesName"></a>
**FillRandomColorsBlackAndWhiteAllFramesName**

Fill the frame with random black and white values for all frames. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.FillRandomColorsBlackAndWhiteAllFramesName(string path);
```

---

<a name="FillRandomColorsBlackAndWhiteAllFramesNameD"></a>
**FillRandomColorsBlackAndWhiteAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillRandomColorsBlackAndWhiteAllFramesNameD(string path);
```

---

<a name="FillRandomColorsBlackAndWhiteName"></a>
**FillRandomColorsBlackAndWhiteName**

Fill the frame with random black and white values for the specified frame.
Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillRandomColorsBlackAndWhiteName(string path, int frameId);
```

---

<a name="FillRandomColorsBlackAndWhiteNameD"></a>
**FillRandomColorsBlackAndWhiteNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillRandomColorsBlackAndWhiteNameD(string path, double frameId);
```

---

<a name="FillRandomColorsName"></a>
**FillRandomColorsName**

Fill the frame with random RGB values for the given frame. Animation is
referenced by name.

```charp
UnityNativeChromaSDK.FillRandomColorsName(string path, int frameId);
```

---

<a name="FillRandomColorsNameD"></a>
**FillRandomColorsNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillRandomColorsNameD(string path, double frameId);
```

---

<a name="FillThresholdColors"></a>
**FillThresholdColors**

Fill the specified frame with RGB color where the animation color is less
than the RGB threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdColors(int animationId, int frameId, int threshold, int color);
```

---

<a name="FillThresholdColorsAllFrames"></a>
**FillThresholdColorsAllFrames**

Fill all frames with RGB color where the animation color is less than the
RGB threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdColorsAllFrames(int animationId, int threshold, int color);
```

---

<a name="FillThresholdColorsAllFramesName"></a>
**FillThresholdColorsAllFramesName**

Fill all frames with RGB color where the animation color is less than the
RGB threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdColorsAllFramesName(string path, int threshold, int color);
```

---

<a name="FillThresholdColorsAllFramesNameD"></a>
**FillThresholdColorsAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdColorsAllFramesNameD(string path, double threshold, double color);
```

---

<a name="FillThresholdColorsAllFramesRGB"></a>
**FillThresholdColorsAllFramesRGB**

Fill all frames with RGB color where the animation color is less than the
threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdColorsAllFramesRGB(int animationId, int threshold, int red, int green, int blue);
```

---

<a name="FillThresholdColorsAllFramesRGBName"></a>
**FillThresholdColorsAllFramesRGBName**

Fill all frames with RGB color where the animation color is less than the
threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdColorsAllFramesRGBName(string path, int threshold, int red, int green, int blue);
```

---

<a name="FillThresholdColorsAllFramesRGBNameD"></a>
**FillThresholdColorsAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdColorsAllFramesRGBNameD(string path, double threshold, double red, double green, double blue);
```

---

<a name="FillThresholdColorsMinMaxAllFramesRGB"></a>
**FillThresholdColorsMinMaxAllFramesRGB**

Fill all frames with the min RGB color where the animation color is less
than the min threshold AND with the max RGB color where the animation is
more than the max threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdColorsMinMaxAllFramesRGB(int animationId, int minThreshold, int minRed, int minGreen, int minBlue, int maxThreshold, int maxRed, int maxGreen, int maxBlue);
```

---

<a name="FillThresholdColorsMinMaxAllFramesRGBName"></a>
**FillThresholdColorsMinMaxAllFramesRGBName**

Fill all frames with the min RGB color where the animation color is less
than the min threshold AND with the max RGB color where the animation is
more than the max threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdColorsMinMaxAllFramesRGBName(string path, int minThreshold, int minRed, int minGreen, int minBlue, int maxThreshold, int maxRed, int maxGreen, int maxBlue);
```

---

<a name="FillThresholdColorsMinMaxAllFramesRGBNameD"></a>
**FillThresholdColorsMinMaxAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdColorsMinMaxAllFramesRGBNameD(string path, double minThreshold, double minRed, double minGreen, double minBlue, double maxThreshold, double maxRed, double maxGreen, double maxBlue);
```

---

<a name="FillThresholdColorsMinMaxRGB"></a>
**FillThresholdColorsMinMaxRGB**

Fill the specified frame with the min RGB color where the animation color
is less than the min threshold AND with the max RGB color where the animation
is more than the max threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdColorsMinMaxRGB(int animationId, int frameId, int minThreshold, int minRed, int minGreen, int minBlue, int maxThreshold, int maxRed, int maxGreen, int maxBlue);
```

---

<a name="FillThresholdColorsMinMaxRGBName"></a>
**FillThresholdColorsMinMaxRGBName**

Fill the specified frame with the min RGB color where the animation color
is less than the min threshold AND with the max RGB color where the animation
is more than the max threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdColorsMinMaxRGBName(string path, int frameId, int minThreshold, int minRed, int minGreen, int minBlue, int maxThreshold, int maxRed, int maxGreen, int maxBlue);
```

---

<a name="FillThresholdColorsMinMaxRGBNameD"></a>
**FillThresholdColorsMinMaxRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdColorsMinMaxRGBNameD(string path, double frameId, double minThreshold, double minRed, double minGreen, double minBlue, double maxThreshold, double maxRed, double maxGreen, double maxBlue);
```

---

<a name="FillThresholdColorsName"></a>
**FillThresholdColorsName**

Fill the specified frame with RGB color where the animation color is less
than the RGB threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdColorsName(string path, int frameId, int threshold, int color);
```

---

<a name="FillThresholdColorsNameD"></a>
**FillThresholdColorsNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdColorsNameD(string path, double frameId, double threshold, double color);
```

---

<a name="FillThresholdColorsRGB"></a>
**FillThresholdColorsRGB**

Fill the specified frame with RGB color where the animation color is less
than the RGB threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdColorsRGB(int animationId, int frameId, int threshold, int red, int green, int blue);
```

---

<a name="FillThresholdColorsRGBName"></a>
**FillThresholdColorsRGBName**

Fill the specified frame with RGB color where the animation color is less
than the RGB threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdColorsRGBName(string path, int frameId, int threshold, int red, int green, int blue);
```

---

<a name="FillThresholdColorsRGBNameD"></a>
**FillThresholdColorsRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdColorsRGBNameD(string path, double frameId, double threshold, double red, double green, double blue);
```

---

<a name="FillThresholdRGBColorsAllFramesRGB"></a>
**FillThresholdRGBColorsAllFramesRGB**

Fill all frames with RGB color where the animation color is less than the
RGB threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdRGBColorsAllFramesRGB(int animationId, int redThreshold, int greenThreshold, int blueThreshold, int red, int green, int blue);
```

---

<a name="FillThresholdRGBColorsAllFramesRGBName"></a>
**FillThresholdRGBColorsAllFramesRGBName**

Fill all frames with RGB color where the animation color is less than the
RGB threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdRGBColorsAllFramesRGBName(string path, int redThreshold, int greenThreshold, int blueThreshold, int red, int green, int blue);
```

---

<a name="FillThresholdRGBColorsAllFramesRGBNameD"></a>
**FillThresholdRGBColorsAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdRGBColorsAllFramesRGBNameD(string path, double redThreshold, double greenThreshold, double blueThreshold, double red, double green, double blue);
```

---

<a name="FillThresholdRGBColorsRGB"></a>
**FillThresholdRGBColorsRGB**

Fill the specified frame with RGB color where the animation color is less
than the RGB threshold. Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillThresholdRGBColorsRGB(int animationId, int frameId, int redThreshold, int greenThreshold, int blueThreshold, int red, int green, int blue);
```

---

<a name="FillThresholdRGBColorsRGBName"></a>
**FillThresholdRGBColorsRGBName**

Fill the specified frame with RGB color where the animation color is less
than the RGB threshold. Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillThresholdRGBColorsRGBName(string path, int frameId, int redThreshold, int greenThreshold, int blueThreshold, int red, int green, int blue);
```

---

<a name="FillThresholdRGBColorsRGBNameD"></a>
**FillThresholdRGBColorsRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillThresholdRGBColorsRGBNameD(string path, double frameId, double redThreshold, double greenThreshold, double blueThreshold, double red, double green, double blue);
```

---

<a name="FillZeroColor"></a>
**FillZeroColor**

Fill the specified frame with RGB color where the animation color is zero.
Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillZeroColor(int animationId, int frameId, int color);
```

---

<a name="FillZeroColorAllFrames"></a>
**FillZeroColorAllFrames**

Fill all frames with RGB color where the animation color is zero. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.FillZeroColorAllFrames(int animationId, int color);
```

---

<a name="FillZeroColorAllFramesName"></a>
**FillZeroColorAllFramesName**

Fill all frames with RGB color where the animation color is zero. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.FillZeroColorAllFramesName(string path, int color);
```

---

<a name="FillZeroColorAllFramesNameD"></a>
**FillZeroColorAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillZeroColorAllFramesNameD(string path, double color);
```

---

<a name="FillZeroColorAllFramesRGB"></a>
**FillZeroColorAllFramesRGB**

Fill all frames with RGB color where the animation color is zero. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.FillZeroColorAllFramesRGB(int animationId, int red, int green, int blue);
```

---

<a name="FillZeroColorAllFramesRGBName"></a>
**FillZeroColorAllFramesRGBName**

Fill all frames with RGB color where the animation color is zero. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.FillZeroColorAllFramesRGBName(string path, int red, int green, int blue);
```

---

<a name="FillZeroColorAllFramesRGBNameD"></a>
**FillZeroColorAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillZeroColorAllFramesRGBNameD(string path, double red, double green, double blue);
```

---

<a name="FillZeroColorName"></a>
**FillZeroColorName**

Fill the specified frame with RGB color where the animation color is zero.
Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillZeroColorName(string path, int frameId, int color);
```

---

<a name="FillZeroColorNameD"></a>
**FillZeroColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillZeroColorNameD(string path, double frameId, double color);
```

---

<a name="FillZeroColorRGB"></a>
**FillZeroColorRGB**

Fill the specified frame with RGB color where the animation color is zero.
Animation is referenced by id.

```charp
UnityNativeChromaSDK.FillZeroColorRGB(int animationId, int frameId, int red, int green, int blue);
```

---

<a name="FillZeroColorRGBName"></a>
**FillZeroColorRGBName**

Fill the specified frame with RGB color where the animation color is zero.
Animation is referenced by name.

```charp
UnityNativeChromaSDK.FillZeroColorRGBName(string path, int frameId, int red, int green, int blue);
```

---

<a name="FillZeroColorRGBNameD"></a>
**FillZeroColorRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.FillZeroColorRGBNameD(string path, double frameId, double red, double green, double blue);
```

---

<a name="Get1DColor"></a>
**Get1DColor**

Get the animation color for a frame given the `1D` `led`. The `led` should
be greater than or equal to 0 and less than the `MaxLeds`. Animation is
referenced by id.

```charp
int result = UnityNativeChromaSDK.Get1DColor(int animationId, int frameId, int led);
```

---

<a name="Get1DColorName"></a>
**Get1DColorName**

Get the animation color for a frame given the `1D` `led`. The `led` should
be greater than or equal to 0 and less than the `MaxLeds`. Animation is
referenced by name.

```charp
int result = UnityNativeChromaSDK.Get1DColorName(string path, int frameId, int led);
```

---

<a name="Get1DColorNameD"></a>
**Get1DColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.Get1DColorNameD(string path, double frameId, double led);
```

---

<a name="Get2DColor"></a>
**Get2DColor**

Get the animation color for a frame given the `2D` `row` and `column`. The
`row` should be greater than or equal to 0 and less than the `MaxRow`.
The `column` should be greater than or equal to 0 and less than the `MaxColumn`.
Animation is referenced by id.

```charp
int result = UnityNativeChromaSDK.Get2DColor(int animationId, int frameId, int row, int column);
```

---

<a name="Get2DColorName"></a>
**Get2DColorName**

Get the animation color for a frame given the `2D` `row` and `column`. The
`row` should be greater than or equal to 0 and less than the `MaxRow`.
The `column` should be greater than or equal to 0 and less than the `MaxColumn`.
Animation is referenced by name.

```charp
int result = UnityNativeChromaSDK.Get2DColorName(string path, int frameId, int row, int column);
```

---

<a name="Get2DColorNameD"></a>
**Get2DColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.Get2DColorNameD(string path, double frameId, double row, double column);
```

---

<a name="GetAnimation"></a>
**GetAnimation**

Get the animation id for the named animation.

```charp
int result = UnityNativeChromaSDK.GetAnimation(string name);
```

---

<a name="GetAnimationCount"></a>
**GetAnimationCount**

`PluginGetAnimationCount` will return the number of loaded animations.

```charp
int result = UnityNativeChromaSDK.GetAnimationCount();
```

---

<a name="GetAnimationD"></a>
**GetAnimationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetAnimationD(string name);
```

---

<a name="GetAnimationId"></a>
**GetAnimationId**

`PluginGetAnimationId` will return the `animationId` given the `index` of
the loaded animation. The `index` is zero-based and less than the number
returned by `PluginGetAnimationCount`. Use `PluginGetAnimationName` to
get the name of the animation.

```charp
int result = UnityNativeChromaSDK.GetAnimationId(int index);
```

---

<a name="GetAnimationName"></a>
**GetAnimationName**

`PluginGetAnimationName` takes an `animationId` and returns the name of
the animation of the `.chroma` animation file. If a name is not available
then an empty string will be returned.

```charp
string result = UnityNativeChromaSDK.GetAnimationName(int animationId);
```

---

<a name="GetCurrentFrame"></a>
**GetCurrentFrame**

Get the current frame of the animation referenced by id.

```charp
int result = UnityNativeChromaSDK.GetCurrentFrame(int animationId);
```

---

<a name="GetCurrentFrameName"></a>
**GetCurrentFrameName**

Get the current frame of the animation referenced by name.

```charp
int result = UnityNativeChromaSDK.GetCurrentFrameName(string path);
```

---

<a name="GetCurrentFrameNameD"></a>
**GetCurrentFrameNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetCurrentFrameNameD(string path);
```

---

<a name="GetDevice"></a>
**GetDevice**

Returns the `EChromaSDKDevice1DEnum` or `EChromaSDKDevice2DEnum` of a `Chroma`
animation respective to the `deviceType`, as an integer upon success. Returns
-1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetDevice(int animationId);
```

---

<a name="GetDeviceName"></a>
**GetDeviceName**

Returns the `EChromaSDKDevice1DEnum` or `EChromaSDKDevice2DEnum` of a `Chroma`
animation respective to the `deviceType`, as an integer upon success. Returns
-1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetDeviceName(string path);
```

---

<a name="GetDeviceNameD"></a>
**GetDeviceNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetDeviceNameD(string path);
```

---

<a name="GetDeviceType"></a>
**GetDeviceType**

Returns the `EChromaSDKDeviceTypeEnum` of a `Chroma` animation as an integer
upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetDeviceType(int animationId);
```

---

<a name="GetDeviceTypeName"></a>
**GetDeviceTypeName**

Returns the `EChromaSDKDeviceTypeEnum` of a `Chroma` animation as an integer
upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetDeviceTypeName(string path);
```

---

<a name="GetDeviceTypeNameD"></a>
**GetDeviceTypeNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetDeviceTypeNameD(string path);
```

---

<a name="GetFrame"></a>
**GetFrame**

Gets the frame colors and duration (in seconds) for a `Chroma` animation.
The `color` is expected to be an array of the expected dimensions for the
`deviceType/device`. The `length` parameter is the size of the `color`
array. For `EChromaSDKDevice1DEnum` the array size should be `MAX LEDS`.
For `EChromaSDKDevice2DEnum` the array size should be `MAX ROW` * `MAX
COLUMN`. Returns the animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetFrame(int animationId, int frameIndex, out float duration, int[] colors, int length);
```

---

<a name="GetFrameCount"></a>
**GetFrameCount**

Returns the frame count of a `Chroma` animation upon success. Returns -1
upon failure.

```charp
int result = UnityNativeChromaSDK.GetFrameCount(int animationId);
```

---

<a name="GetFrameCountName"></a>
**GetFrameCountName**

Returns the frame count of a `Chroma` animation upon success. Returns -1
upon failure.

```charp
int result = UnityNativeChromaSDK.GetFrameCountName(string path);
```

---

<a name="GetFrameCountNameD"></a>
**GetFrameCountNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetFrameCountNameD(string path);
```

---

<a name="GetKeyColor"></a>
**GetKeyColor**

Get the color of an animation key for the given frame referenced by id.

```charp
int result = UnityNativeChromaSDK.GetKeyColor(int animationId, int frameId, int rzkey);
```

---

<a name="GetKeyColorD"></a>
**GetKeyColorD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetKeyColorD(string path, double frameId, double rzkey);
```

---

<a name="GetKeyColorName"></a>
**GetKeyColorName**

Get the color of an animation key for the given frame referenced by name.

```charp
int result = UnityNativeChromaSDK.GetKeyColorName(string path, int frameId, int rzkey);
```

---

<a name="GetLibraryLoadedState"></a>
**GetLibraryLoadedState**

Returns `RZRESULT_SUCCESS` if the plugin has been initialized successfully.
Returns `RZRESULT_DLL_NOT_FOUND` if core Chroma library is not found. Returns
`RZRESULT_DLL_INVALID_SIGNATURE` if core Chroma library has an invalid
signature.

```charp
long result = UnityNativeChromaSDK.GetLibraryLoadedState();
```

---

<a name="GetLibraryLoadedStateD"></a>
**GetLibraryLoadedStateD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetLibraryLoadedStateD();
```

---

<a name="GetMaxColumn"></a>
**GetMaxColumn**

Returns the `MAX COLUMN` given the `EChromaSDKDevice2DEnum` device as an
integer upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetMaxColumn(Device2D device);
```

---

<a name="GetMaxColumnD"></a>
**GetMaxColumnD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetMaxColumnD(double device);
```

---

<a name="GetMaxLeds"></a>
**GetMaxLeds**

Returns the MAX LEDS given the `EChromaSDKDevice1DEnum` device as an integer
upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetMaxLeds(Device1D device);
```

---

<a name="GetMaxLedsD"></a>
**GetMaxLedsD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetMaxLedsD(double device);
```

---

<a name="GetMaxRow"></a>
**GetMaxRow**

Returns the `MAX ROW` given the `EChromaSDKDevice2DEnum` device as an integer
upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.GetMaxRow(Device2D device);
```

---

<a name="GetMaxRowD"></a>
**GetMaxRowD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetMaxRowD(double device);
```

---

<a name="GetPlayingAnimationCount"></a>
**GetPlayingAnimationCount**

`PluginGetPlayingAnimationCount` will return the number of playing animations.

```charp
int result = UnityNativeChromaSDK.GetPlayingAnimationCount();
```

---

<a name="GetPlayingAnimationId"></a>
**GetPlayingAnimationId**

`PluginGetPlayingAnimationId` will return the `animationId` given the `index`
of the playing animation. The `index` is zero-based and less than the number
returned by `PluginGetPlayingAnimationCount`. Use `PluginGetAnimationName`
to get the name of the animation.

```charp
int result = UnityNativeChromaSDK.GetPlayingAnimationId(int index);
```

---

<a name="GetRGB"></a>
**GetRGB**

Get the RGB color given red, green, and blue.

```charp
int result = UnityNativeChromaSDK.GetRGB(int red, int green, int blue);
```

---

<a name="GetRGBD"></a>
**GetRGBD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.GetRGBD(double red, double green, double blue);
```

---

<a name="HasAnimationLoop"></a>
**HasAnimationLoop**

Check if the animation has loop enabled referenced by id.

```charp
bool result = UnityNativeChromaSDK.HasAnimationLoop(int animationId);
```

---

<a name="HasAnimationLoopName"></a>
**HasAnimationLoopName**

Check if the animation has loop enabled referenced by name.

```charp
bool result = UnityNativeChromaSDK.HasAnimationLoopName(string path);
```

---

<a name="HasAnimationLoopNameD"></a>
**HasAnimationLoopNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.HasAnimationLoopNameD(string path);
```

---

<a name="Init"></a>
**Init**

Initialize the ChromaSDK. Zero indicates  success, otherwise failure. Many
API methods auto initialize the ChromaSDK if not already initialized.

```charp
long result = UnityNativeChromaSDK.Init();
```

---

<a name="InitD"></a>
**InitD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.InitD();
```

---

<a name="InsertDelay"></a>
**InsertDelay**

Insert an animation delay by duplicating the frame by the delay number of
times. Animation is referenced by id.

```charp
UnityNativeChromaSDK.InsertDelay(int animationId, int frameId, int delay);
```

---

<a name="InsertDelayName"></a>
**InsertDelayName**

Insert an animation delay by duplicating the frame by the delay number of
times. Animation is referenced by name.

```charp
UnityNativeChromaSDK.InsertDelayName(string path, int frameId, int delay);
```

---

<a name="InsertDelayNameD"></a>
**InsertDelayNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.InsertDelayNameD(string path, double frameId, double delay);
```

---

<a name="InsertFrame"></a>
**InsertFrame**

Duplicate the source frame index at the target frame index. Animation is
referenced by id.

```charp
UnityNativeChromaSDK.InsertFrame(int animationId, int sourceFrame, int targetFrame);
```

---

<a name="InsertFrameName"></a>
**InsertFrameName**

Duplicate the source frame index at the target frame index. Animation is
referenced by name.

```charp
UnityNativeChromaSDK.InsertFrameName(string path, int sourceFrame, int targetFrame);
```

---

<a name="InsertFrameNameD"></a>
**InsertFrameNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.InsertFrameNameD(string path, double sourceFrame, double targetFrame);
```

---

<a name="InvertColors"></a>
**InvertColors**

Invert all the colors at the specified frame. Animation is referenced by
id.

```charp
UnityNativeChromaSDK.InvertColors(int animationId, int frameId);
```

---

<a name="InvertColorsAllFrames"></a>
**InvertColorsAllFrames**

Invert all the colors for all frames. Animation is referenced by id.

```charp
UnityNativeChromaSDK.InvertColorsAllFrames(int animationId);
```

---

<a name="InvertColorsAllFramesName"></a>
**InvertColorsAllFramesName**

Invert all the colors for all frames. Animation is referenced by name.

```charp
UnityNativeChromaSDK.InvertColorsAllFramesName(string path);
```

---

<a name="InvertColorsAllFramesNameD"></a>
**InvertColorsAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.InvertColorsAllFramesNameD(string path);
```

---

<a name="InvertColorsName"></a>
**InvertColorsName**

Invert all the colors at the specified frame. Animation is referenced by
name.

```charp
UnityNativeChromaSDK.InvertColorsName(string path, int frameId);
```

---

<a name="InvertColorsNameD"></a>
**InvertColorsNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.InvertColorsNameD(string path, double frameId);
```

---

<a name="IsAnimationPaused"></a>
**IsAnimationPaused**

Check if the animation is paused referenced by id.

```charp
bool result = UnityNativeChromaSDK.IsAnimationPaused(int animationId);
```

---

<a name="IsAnimationPausedName"></a>
**IsAnimationPausedName**

Check if the animation is paused referenced by name.

```charp
bool result = UnityNativeChromaSDK.IsAnimationPausedName(string path);
```

---

<a name="IsAnimationPausedNameD"></a>
**IsAnimationPausedNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.IsAnimationPausedNameD(string path);
```

---

<a name="IsDialogOpen"></a>
**IsDialogOpen**

The editor dialog is a non-blocking modal window, this method returns true
if the modal window is open, otherwise false.

```charp
bool result = UnityNativeChromaSDK.IsDialogOpen();
```

---

<a name="IsDialogOpenD"></a>
**IsDialogOpenD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.IsDialogOpenD();
```

---

<a name="IsInitialized"></a>
**IsInitialized**

Returns true if the plugin has been initialized. Returns false if the plugin
is uninitialized.

```charp
bool result = UnityNativeChromaSDK.IsInitialized();
```

---

<a name="IsInitializedD"></a>
**IsInitializedD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.IsInitializedD();
```

---

<a name="IsPlatformSupported"></a>
**IsPlatformSupported**

If the method can be invoked the method returns true.

```charp
bool result = UnityNativeChromaSDK.IsPlatformSupported();
```

---

<a name="IsPlatformSupportedD"></a>
**IsPlatformSupportedD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.IsPlatformSupportedD();
```

---

<a name="IsPlaying"></a>
**IsPlaying**

`PluginIsPlayingName` automatically handles initializing the `ChromaSDK`.
The named `.chroma` animation file will be automatically opened. The method
will return whether the animation is playing or not. Animation is referenced
by id.

```charp
bool result = UnityNativeChromaSDK.IsPlaying(int animationId);
```

---

<a name="IsPlayingD"></a>
**IsPlayingD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.IsPlayingD(double animationId);
```

---

<a name="IsPlayingName"></a>
**IsPlayingName**

`PluginIsPlayingName` automatically handles initializing the `ChromaSDK`.
The named `.chroma` animation file will be automatically opened. The method
will return whether the animation is playing or not. Animation is referenced
by name.

```charp
bool result = UnityNativeChromaSDK.IsPlayingName(string path);
```

---

<a name="IsPlayingNameD"></a>
**IsPlayingNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.IsPlayingNameD(string path);
```

---

<a name="IsPlayingType"></a>
**IsPlayingType**

`PluginIsPlayingType` automatically handles initializing the `ChromaSDK`.
If any animation is playing for the `deviceType` and `device` combination,
the method will return true, otherwise false.

```charp
bool result = UnityNativeChromaSDK.IsPlayingType(int deviceType, int device);
```

---

<a name="IsPlayingTypeD"></a>
**IsPlayingTypeD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.IsPlayingTypeD(double deviceType, double device);
```

---

<a name="Lerp"></a>
**Lerp**

Do a lerp math operation on a float.

```charp
float result = UnityNativeChromaSDK.Lerp(float start, float end, float amt);
```

---

<a name="LerpColor"></a>
**LerpColor**

Lerp from one color to another given t in the range 0.0 to 1.0.

```charp
int result = UnityNativeChromaSDK.LerpColor(int from, int to, float t);
```

---

<a name="LoadAnimation"></a>
**LoadAnimation**

Loads `Chroma` effects so that the animation can be played immediately.
Returns the animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.LoadAnimation(int animationId);
```

---

<a name="LoadAnimationD"></a>
**LoadAnimationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.LoadAnimationD(double animationId);
```

---

<a name="LoadAnimationName"></a>
**LoadAnimationName**

Load the named animation.

```charp
UnityNativeChromaSDK.LoadAnimationName(string path);
```

---

<a name="LoadComposite"></a>
**LoadComposite**

Load a composite set of animations.

```charp
UnityNativeChromaSDK.LoadComposite(string name);
```

---

<a name="MakeBlankFrames"></a>
**MakeBlankFrames**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color defaults to color. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.MakeBlankFrames(int animationId, int frameCount, float duration, int color);
```

---

<a name="MakeBlankFramesName"></a>
**MakeBlankFramesName**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color defaults to color. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.MakeBlankFramesName(string path, int frameCount, float duration, int color);
```

---

<a name="MakeBlankFramesNameD"></a>
**MakeBlankFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MakeBlankFramesNameD(string path, double frameCount, double duration, double color);
```

---

<a name="MakeBlankFramesRandom"></a>
**MakeBlankFramesRandom**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color is random. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.MakeBlankFramesRandom(int animationId, int frameCount, float duration);
```

---

<a name="MakeBlankFramesRandomBlackAndWhite"></a>
**MakeBlankFramesRandomBlackAndWhite**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color is random black and white. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.MakeBlankFramesRandomBlackAndWhite(int animationId, int frameCount, float duration);
```

---

<a name="MakeBlankFramesRandomBlackAndWhiteName"></a>
**MakeBlankFramesRandomBlackAndWhiteName**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color is random black and white. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.MakeBlankFramesRandomBlackAndWhiteName(string path, int frameCount, float duration);
```

---

<a name="MakeBlankFramesRandomBlackAndWhiteNameD"></a>
**MakeBlankFramesRandomBlackAndWhiteNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MakeBlankFramesRandomBlackAndWhiteNameD(string path, double frameCount, double duration);
```

---

<a name="MakeBlankFramesRandomName"></a>
**MakeBlankFramesRandomName**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color is random. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.MakeBlankFramesRandomName(string path, int frameCount, float duration);
```

---

<a name="MakeBlankFramesRandomNameD"></a>
**MakeBlankFramesRandomNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MakeBlankFramesRandomNameD(string path, double frameCount, double duration);
```

---

<a name="MakeBlankFramesRGB"></a>
**MakeBlankFramesRGB**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color defaults to color. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.MakeBlankFramesRGB(int animationId, int frameCount, float duration, int red, int green, int blue);
```

---

<a name="MakeBlankFramesRGBName"></a>
**MakeBlankFramesRGBName**

Make a blank animation for the length of the frame count. Frame duration
defaults to the duration. The frame color defaults to color. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.MakeBlankFramesRGBName(string path, int frameCount, float duration, int red, int green, int blue);
```

---

<a name="MakeBlankFramesRGBNameD"></a>
**MakeBlankFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MakeBlankFramesRGBNameD(string path, double frameCount, double duration, double red, double green, double blue);
```

---

<a name="MirrorHorizontally"></a>
**MirrorHorizontally**

Flips the color grid horizontally for all `Chroma` animation frames. Returns
the animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.MirrorHorizontally(int animationId);
```

---

<a name="MirrorVertically"></a>
**MirrorVertically**

Flips the color grid vertically for all `Chroma` animation frames. This
method has no effect for `EChromaSDKDevice1DEnum` devices. Returns the
animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.MirrorVertically(int animationId);
```

---

<a name="MultiplyColorLerpAllFrames"></a>
**MultiplyColorLerpAllFrames**

Multiply the color intensity with the lerp result from color 1 to color
2 using the frame index divided by the frame count for the `t` parameter.
Animation is referenced in id.

```charp
UnityNativeChromaSDK.MultiplyColorLerpAllFrames(int animationId, int color1, int color2);
```

---

<a name="MultiplyColorLerpAllFramesName"></a>
**MultiplyColorLerpAllFramesName**

Multiply the color intensity with the lerp result from color 1 to color
2 using the frame index divided by the frame count for the `t` parameter.
Animation is referenced in name.

```charp
UnityNativeChromaSDK.MultiplyColorLerpAllFramesName(string path, int color1, int color2);
```

---

<a name="MultiplyColorLerpAllFramesNameD"></a>
**MultiplyColorLerpAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyColorLerpAllFramesNameD(string path, double color1, double color2);
```

---

<a name="MultiplyIntensity"></a>
**MultiplyIntensity**

Multiply all the colors in the frame by the intensity value. The valid the
intensity range is from 0.0 to 255.0. RGB components are multiplied equally.
An intensity of 0.5 would half the color value. Black colors in the frame
will not be affected by this method.

```charp
UnityNativeChromaSDK.MultiplyIntensity(int animationId, int frameId, float intensity);
```

---

<a name="MultiplyIntensityAllFrames"></a>
**MultiplyIntensityAllFrames**

Multiply all the colors for all frames by the intensity value. The valid
the intensity range is from 0.0 to 255.0. RGB components are multiplied
equally. An intensity of 0.5 would half the color value. Black colors in
the frame will not be affected by this method.

```charp
UnityNativeChromaSDK.MultiplyIntensityAllFrames(int animationId, float intensity);
```

---

<a name="MultiplyIntensityAllFramesName"></a>
**MultiplyIntensityAllFramesName**

Multiply all the colors for all frames by the intensity value. The valid
the intensity range is from 0.0 to 255.0. RGB components are multiplied
equally. An intensity of 0.5 would half the color value. Black colors in
the frame will not be affected by this method.

```charp
UnityNativeChromaSDK.MultiplyIntensityAllFramesName(string path, float intensity);
```

---

<a name="MultiplyIntensityAllFramesNameD"></a>
**MultiplyIntensityAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyIntensityAllFramesNameD(string path, double intensity);
```

---

<a name="MultiplyIntensityAllFramesRGB"></a>
**MultiplyIntensityAllFramesRGB**

Multiply all frames by the RBG color intensity. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.MultiplyIntensityAllFramesRGB(int animationId, int red, int green, int blue);
```

---

<a name="MultiplyIntensityAllFramesRGBName"></a>
**MultiplyIntensityAllFramesRGBName**

Multiply all frames by the RBG color intensity. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.MultiplyIntensityAllFramesRGBName(string path, int red, int green, int blue);
```

---

<a name="MultiplyIntensityAllFramesRGBNameD"></a>
**MultiplyIntensityAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyIntensityAllFramesRGBNameD(string path, double red, double green, double blue);
```

---

<a name="MultiplyIntensityColor"></a>
**MultiplyIntensityColor**

Multiply the specific frame by the RBG color intensity. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.MultiplyIntensityColor(int animationId, int frameId, int color);
```

---

<a name="MultiplyIntensityColorAllFrames"></a>
**MultiplyIntensityColorAllFrames**

Multiply all frames by the RBG color intensity. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.MultiplyIntensityColorAllFrames(int animationId, int color);
```

---

<a name="MultiplyIntensityColorAllFramesName"></a>
**MultiplyIntensityColorAllFramesName**

Multiply all frames by the RBG color intensity. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.MultiplyIntensityColorAllFramesName(string path, int color);
```

---

<a name="MultiplyIntensityColorAllFramesNameD"></a>
**MultiplyIntensityColorAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyIntensityColorAllFramesNameD(string path, double color);
```

---

<a name="MultiplyIntensityColorName"></a>
**MultiplyIntensityColorName**

Multiply the specific frame by the RBG color intensity. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.MultiplyIntensityColorName(string path, int frameId, int color);
```

---

<a name="MultiplyIntensityColorNameD"></a>
**MultiplyIntensityColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyIntensityColorNameD(string path, double frameId, double color);
```

---

<a name="MultiplyIntensityName"></a>
**MultiplyIntensityName**

Multiply all the colors in the frame by the intensity value. The valid the
intensity range is from 0.0 to 255.0. RGB components are multiplied equally.
An intensity of 0.5 would half the color value. Black colors in the frame
will not be affected by this method.

```charp
UnityNativeChromaSDK.MultiplyIntensityName(string path, int frameId, float intensity);
```

---

<a name="MultiplyIntensityNameD"></a>
**MultiplyIntensityNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyIntensityNameD(string path, double frameId, double intensity);
```

---

<a name="MultiplyIntensityRGB"></a>
**MultiplyIntensityRGB**

Multiply the specific frame by the RBG color intensity. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.MultiplyIntensityRGB(int animationId, int frameId, int red, int green, int blue);
```

---

<a name="MultiplyIntensityRGBName"></a>
**MultiplyIntensityRGBName**

Multiply the specific frame by the RBG color intensity. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.MultiplyIntensityRGBName(string path, int frameId, int red, int green, int blue);
```

---

<a name="MultiplyIntensityRGBNameD"></a>
**MultiplyIntensityRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyIntensityRGBNameD(string path, double frameId, double red, double green, double blue);
```

---

<a name="MultiplyNonZeroTargetColorLerp"></a>
**MultiplyNonZeroTargetColorLerp**

Multiply the specific frame by the color lerp result between color 1 and
2 using the frame color value as the `t` value. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.MultiplyNonZeroTargetColorLerp(int animationId, int frameId, int color1, int color2);
```

---

<a name="MultiplyNonZeroTargetColorLerpAllFrames"></a>
**MultiplyNonZeroTargetColorLerpAllFrames**

Multiply all frames by the color lerp result between color 1 and 2 using
the frame color value as the `t` value. Animation is referenced by id.

```charp
UnityNativeChromaSDK.MultiplyNonZeroTargetColorLerpAllFrames(int animationId, int color1, int color2);
```

---

<a name="MultiplyNonZeroTargetColorLerpAllFramesName"></a>
**MultiplyNonZeroTargetColorLerpAllFramesName**

Multiply all frames by the color lerp result between color 1 and 2 using
the frame color value as the `t` value. Animation is referenced by name.

```charp
UnityNativeChromaSDK.MultiplyNonZeroTargetColorLerpAllFramesName(string path, int color1, int color2);
```

---

<a name="MultiplyNonZeroTargetColorLerpAllFramesNameD"></a>
**MultiplyNonZeroTargetColorLerpAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyNonZeroTargetColorLerpAllFramesNameD(string path, double color1, double color2);
```

---

<a name="MultiplyNonZeroTargetColorLerpAllFramesRGB"></a>
**MultiplyNonZeroTargetColorLerpAllFramesRGB**

Multiply the specific frame by the color lerp result between RGB 1 and 2
using the frame color value as the `t` value. Animation is referenced by
id.

```charp
UnityNativeChromaSDK.MultiplyNonZeroTargetColorLerpAllFramesRGB(int animationId, int red1, int green1, int blue1, int red2, int green2, int blue2);
```

---

<a name="MultiplyNonZeroTargetColorLerpAllFramesRGBName"></a>
**MultiplyNonZeroTargetColorLerpAllFramesRGBName**

Multiply the specific frame by the color lerp result between RGB 1 and 2
using the frame color value as the `t` value. Animation is referenced by
name.

```charp
UnityNativeChromaSDK.MultiplyNonZeroTargetColorLerpAllFramesRGBName(string path, int red1, int green1, int blue1, int red2, int green2, int blue2);
```

---

<a name="MultiplyNonZeroTargetColorLerpAllFramesRGBNameD"></a>
**MultiplyNonZeroTargetColorLerpAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyNonZeroTargetColorLerpAllFramesRGBNameD(string path, double red1, double green1, double blue1, double red2, double green2, double blue2);
```

---

<a name="MultiplyTargetColorLerp"></a>
**MultiplyTargetColorLerp**

Multiply the specific frame by the color lerp result between color 1 and
2 using the frame color value as the `t` value. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.MultiplyTargetColorLerp(int animationId, int frameId, int color1, int color2);
```

---

<a name="MultiplyTargetColorLerpAllFrames"></a>
**MultiplyTargetColorLerpAllFrames**

Multiply all frames by the color lerp result between color 1 and 2 using
the frame color value as the `t` value. Animation is referenced by id.

```charp
UnityNativeChromaSDK.MultiplyTargetColorLerpAllFrames(int animationId, int color1, int color2);
```

---

<a name="MultiplyTargetColorLerpAllFramesName"></a>
**MultiplyTargetColorLerpAllFramesName**

Multiply all frames by the color lerp result between color 1 and 2 using
the frame color value as the `t` value. Animation is referenced by name.

```charp
UnityNativeChromaSDK.MultiplyTargetColorLerpAllFramesName(string path, int color1, int color2);
```

---

<a name="MultiplyTargetColorLerpAllFramesNameD"></a>
**MultiplyTargetColorLerpAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyTargetColorLerpAllFramesNameD(string path, double color1, double color2);
```

---

<a name="MultiplyTargetColorLerpAllFramesRGB"></a>
**MultiplyTargetColorLerpAllFramesRGB**

Multiply all frames by the color lerp result between RGB 1 and 2 using the
frame color value as the `t` value. Animation is referenced by id.

```charp
UnityNativeChromaSDK.MultiplyTargetColorLerpAllFramesRGB(int animationId, int red1, int green1, int blue1, int red2, int green2, int blue2);
```

---

<a name="MultiplyTargetColorLerpAllFramesRGBName"></a>
**MultiplyTargetColorLerpAllFramesRGBName**

Multiply all frames by the color lerp result between RGB 1 and 2 using the
frame color value as the `t` value. Animation is referenced by name.

```charp
UnityNativeChromaSDK.MultiplyTargetColorLerpAllFramesRGBName(string path, int red1, int green1, int blue1, int red2, int green2, int blue2);
```

---

<a name="MultiplyTargetColorLerpAllFramesRGBNameD"></a>
**MultiplyTargetColorLerpAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.MultiplyTargetColorLerpAllFramesRGBNameD(string path, double red1, double green1, double blue1, double red2, double green2, double blue2);
```

---

<a name="OffsetColors"></a>
**OffsetColors**

Offset all colors in the frame using the RGB offset. Use the range of -255
to 255 for red, green, and blue parameters. Negative values remove color.
Positive values add color.

```charp
UnityNativeChromaSDK.OffsetColors(int animationId, int frameId, int red, int green, int blue);
```

---

<a name="OffsetColorsAllFrames"></a>
**OffsetColorsAllFrames**

Offset all colors for all frames using the RGB offset. Use the range of
-255 to 255 for red, green, and blue parameters. Negative values remove
color. Positive values add color.

```charp
UnityNativeChromaSDK.OffsetColorsAllFrames(int animationId, int red, int green, int blue);
```

---

<a name="OffsetColorsAllFramesName"></a>
**OffsetColorsAllFramesName**

Offset all colors for all frames using the RGB offset. Use the range of
-255 to 255 for red, green, and blue parameters. Negative values remove
color. Positive values add color.

```charp
UnityNativeChromaSDK.OffsetColorsAllFramesName(string path, int red, int green, int blue);
```

---

<a name="OffsetColorsAllFramesNameD"></a>
**OffsetColorsAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OffsetColorsAllFramesNameD(string path, double red, double green, double blue);
```

---

<a name="OffsetColorsName"></a>
**OffsetColorsName**

Offset all colors in the frame using the RGB offset. Use the range of -255
to 255 for red, green, and blue parameters. Negative values remove color.
Positive values add color.

```charp
UnityNativeChromaSDK.OffsetColorsName(string path, int frameId, int red, int green, int blue);
```

---

<a name="OffsetColorsNameD"></a>
**OffsetColorsNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OffsetColorsNameD(string path, double frameId, double red, double green, double blue);
```

---

<a name="OffsetNonZeroColors"></a>
**OffsetNonZeroColors**

This method will only update colors in the animation that are not already
set to black. Offset a subset of colors in the frame using the RGB offset.
Use the range of -255 to 255 for red, green, and blue parameters. Negative
values remove color. Positive values add color.

```charp
UnityNativeChromaSDK.OffsetNonZeroColors(int animationId, int frameId, int red, int green, int blue);
```

---

<a name="OffsetNonZeroColorsAllFrames"></a>
**OffsetNonZeroColorsAllFrames**

This method will only update colors in the animation that are not already
set to black. Offset a subset of colors for all frames using the RGB offset.
Use the range of -255 to 255 for red, green, and blue parameters. Negative
values remove color. Positive values add color.

```charp
UnityNativeChromaSDK.OffsetNonZeroColorsAllFrames(int animationId, int red, int green, int blue);
```

---

<a name="OffsetNonZeroColorsAllFramesName"></a>
**OffsetNonZeroColorsAllFramesName**

This method will only update colors in the animation that are not already
set to black. Offset a subset of colors for all frames using the RGB offset.
Use the range of -255 to 255 for red, green, and blue parameters. Negative
values remove color. Positive values add color.

```charp
UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesName(string path, int red, int green, int blue);
```

---

<a name="OffsetNonZeroColorsAllFramesNameD"></a>
**OffsetNonZeroColorsAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OffsetNonZeroColorsAllFramesNameD(string path, double red, double green, double blue);
```

---

<a name="OffsetNonZeroColorsName"></a>
**OffsetNonZeroColorsName**

This method will only update colors in the animation that are not already
set to black. Offset a subset of colors in the frame using the RGB offset.
Use the range of -255 to 255 for red, green, and blue parameters. Negative
values remove color. Positive values add color.

```charp
UnityNativeChromaSDK.OffsetNonZeroColorsName(string path, int frameId, int red, int green, int blue);
```

---

<a name="OffsetNonZeroColorsNameD"></a>
**OffsetNonZeroColorsNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OffsetNonZeroColorsNameD(string path, double frameId, double red, double green, double blue);
```

---

<a name="OpenAnimation"></a>
**OpenAnimation**

Opens a `Chroma` animation file so that it can be played. Returns an animation
id >= 0 upon success. Returns -1 if there was a failure. The animation
id is used in most of the API methods.

```charp
int result = UnityNativeChromaSDK.OpenAnimation(string path);
```

---

<a name="OpenAnimationD"></a>
**OpenAnimationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OpenAnimationD(string path);
```

---

<a name="OpenAnimationFromMemory"></a>
**OpenAnimationFromMemory**

Opens a `Chroma` animation data from memory so that it can be played. `Data`
is a pointer to byte array of the loaded animation in memory. `Name` will
be assigned to the animation when loaded. Returns an animation id >= 0
upon success. Returns -1 if there was a failure. The animation id is used
in most of the API methods.

```charp
int result = UnityNativeChromaSDK.OpenAnimationFromMemory(byte[] data, string name);
```

---

<a name="OpenEditorDialog"></a>
**OpenEditorDialog**

Opens a `Chroma` animation file with the `.chroma` extension. Returns zero
upon success. Returns -1 if there was a failure.

```charp
int result = UnityNativeChromaSDK.OpenEditorDialog(string path);
```

---

<a name="OpenEditorDialogAndPlay"></a>
**OpenEditorDialogAndPlay**

Open the named animation in the editor dialog and play the animation at
start.

```charp
int result = UnityNativeChromaSDK.OpenEditorDialogAndPlay(string path);
```

---

<a name="OpenEditorDialogAndPlayD"></a>
**OpenEditorDialogAndPlayD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OpenEditorDialogAndPlayD(string path);
```

---

<a name="OpenEditorDialogD"></a>
**OpenEditorDialogD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OpenEditorDialogD(string path);
```

---

<a name="OverrideFrameDuration"></a>
**OverrideFrameDuration**

Sets the `duration` for all grames in the `Chroma` animation to the `duration`
parameter. Returns the animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.OverrideFrameDuration(int animationId, float duration);
```

---

<a name="OverrideFrameDurationD"></a>
**OverrideFrameDurationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.OverrideFrameDurationD(double animationId, double duration);
```

---

<a name="OverrideFrameDurationName"></a>
**OverrideFrameDurationName**

Override the duration of all frames with the `duration` value. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.OverrideFrameDurationName(string path, float duration);
```

---

<a name="PauseAnimation"></a>
**PauseAnimation**

Pause the current animation referenced by id.

```charp
UnityNativeChromaSDK.PauseAnimation(int animationId);
```

---

<a name="PauseAnimationName"></a>
**PauseAnimationName**

Pause the current animation referenced by name.

```charp
UnityNativeChromaSDK.PauseAnimationName(string path);
```

---

<a name="PauseAnimationNameD"></a>
**PauseAnimationNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.PauseAnimationNameD(string path);
```

---

<a name="PlayAnimation"></a>
**PlayAnimation**

Plays the `Chroma` animation. This will load the animation, if not loaded
previously. Returns the animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.PlayAnimation(int animationId);
```

---

<a name="PlayAnimationD"></a>
**PlayAnimationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.PlayAnimationD(double animationId);
```

---

<a name="PlayAnimationFrame"></a>
**PlayAnimationFrame**

`PluginPlayAnimationFrame` automatically handles initializing the `ChromaSDK`.
The method will play the animation given the `animationId` with looping
`on` or `off` starting at the `frameId`.

```charp
UnityNativeChromaSDK.PlayAnimationFrame(int animationId, int frameId, bool loop);
```

---

<a name="PlayAnimationFrameName"></a>
**PlayAnimationFrameName**

`PluginPlayAnimationFrameName` automatically handles initializing the `ChromaSDK`.
The named `.chroma` animation file will be automatically opened. The animation
will play with looping `on` or `off` starting at the `frameId`.

```charp
UnityNativeChromaSDK.PlayAnimationFrameName(string path, int frameId, bool loop);
```

---

<a name="PlayAnimationFrameNameD"></a>
**PlayAnimationFrameNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.PlayAnimationFrameNameD(string path, double frameId, double loop);
```

---

<a name="PlayAnimationLoop"></a>
**PlayAnimationLoop**

`PluginPlayAnimationLoop` automatically handles initializing the `ChromaSDK`.
The method will play the animation given the `animationId` with looping
`on` or `off`.

```charp
UnityNativeChromaSDK.PlayAnimationLoop(int animationId, bool loop);
```

---

<a name="PlayAnimationName"></a>
**PlayAnimationName**

`PluginPlayAnimationName` automatically handles initializing the `ChromaSDK`.
The named `.chroma` animation file will be automatically opened. The animation
will play with looping `on` or `off`.

```charp
UnityNativeChromaSDK.PlayAnimationName(string path, bool loop);
```

---

<a name="PlayAnimationNameD"></a>
**PlayAnimationNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.PlayAnimationNameD(string path, double loop);
```

---

<a name="PlayComposite"></a>
**PlayComposite**

`PluginPlayComposite` automatically handles initializing the `ChromaSDK`.
The named animation files for the `.chroma` set will be automatically opened.
The set of animations will play with looping `on` or `off`.

```charp
UnityNativeChromaSDK.PlayComposite(string name, bool loop);
```

---

<a name="PlayCompositeD"></a>
**PlayCompositeD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.PlayCompositeD(string name, double loop);
```

---

<a name="PreviewFrame"></a>
**PreviewFrame**

Displays the `Chroma` animation frame on `Chroma` hardware given the `frameIndex`.
Returns the animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.PreviewFrame(int animationId, int frameIndex);
```

---

<a name="PreviewFrameD"></a>
**PreviewFrameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.PreviewFrameD(double animationId, double frameIndex);
```

---

<a name="PreviewFrameName"></a>
**PreviewFrameName**

Displays the `Chroma` animation frame on `Chroma` hardware given the `frameIndex`.
Animaton is referenced by name.

```charp
UnityNativeChromaSDK.PreviewFrameName(string path, int frameIndex);
```

---

<a name="ReduceFrames"></a>
**ReduceFrames**

Reduce the frames of the animation by removing every nth element. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.ReduceFrames(int animationId, int n);
```

---

<a name="ReduceFramesName"></a>
**ReduceFramesName**

Reduce the frames of the animation by removing every nth element. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.ReduceFramesName(string path, int n);
```

---

<a name="ReduceFramesNameD"></a>
**ReduceFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.ReduceFramesNameD(string path, double n);
```

---

<a name="ResetAnimation"></a>
**ResetAnimation**

Resets the `Chroma` animation to 1 blank frame. Returns the animation id
upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.ResetAnimation(int animationId);
```

---

<a name="ResumeAnimation"></a>
**ResumeAnimation**

Resume the animation with loop `ON` or `OFF` referenced by id.

```charp
UnityNativeChromaSDK.ResumeAnimation(int animationId, bool loop);
```

---

<a name="ResumeAnimationName"></a>
**ResumeAnimationName**

Resume the animation with loop `ON` or `OFF` referenced by name.

```charp
UnityNativeChromaSDK.ResumeAnimationName(string path, bool loop);
```

---

<a name="ResumeAnimationNameD"></a>
**ResumeAnimationNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.ResumeAnimationNameD(string path, double loop);
```

---

<a name="Reverse"></a>
**Reverse**

Reverse the animation frame order of the `Chroma` animation. Returns the
animation id upon success. Returns -1 upon failure. Animation is referenced
by id.

```charp
int result = UnityNativeChromaSDK.Reverse(int animationId);
```

---

<a name="ReverseAllFrames"></a>
**ReverseAllFrames**

Reverse the animation frame order of the `Chroma` animation. Animation is
referenced by id.

```charp
UnityNativeChromaSDK.ReverseAllFrames(int animationId);
```

---

<a name="ReverseAllFramesName"></a>
**ReverseAllFramesName**

Reverse the animation frame order of the `Chroma` animation. Animation is
referenced by name.

```charp
UnityNativeChromaSDK.ReverseAllFramesName(string path);
```

---

<a name="ReverseAllFramesNameD"></a>
**ReverseAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.ReverseAllFramesNameD(string path);
```

---

<a name="SaveAnimation"></a>
**SaveAnimation**

Save the animation referenced by id to the path specified.

```charp
int result = UnityNativeChromaSDK.SaveAnimation(int animationId, string path);
```

---

<a name="SaveAnimationName"></a>
**SaveAnimationName**

Save the named animation to the target path specified.

```charp
int result = UnityNativeChromaSDK.SaveAnimationName(string sourceAnimation, string targetAnimation);
```

---

<a name="Set1DColor"></a>
**Set1DColor**

Set the animation color for a frame given the `1D` `led`. The `led` should
be greater than or equal to 0 and less than the `MaxLeds`. The animation
is referenced by id.

```charp
UnityNativeChromaSDK.Set1DColor(int animationId, int frameId, int led, int color);
```

---

<a name="Set1DColorName"></a>
**Set1DColorName**

Set the animation color for a frame given the `1D` `led`. The `led` should
be greater than or equal to 0 and less than the `MaxLeds`. The animation
is referenced by name.

```charp
UnityNativeChromaSDK.Set1DColorName(string path, int frameId, int led, int color);
```

---

<a name="Set1DColorNameD"></a>
**Set1DColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.Set1DColorNameD(string path, double frameId, double led, double color);
```

---

<a name="Set2DColor"></a>
**Set2DColor**

Set the animation color for a frame given the `2D` `row` and `column`. The
`row` should be greater than or equal to 0 and less than the `MaxRow`.
The `column` should be greater than or equal to 0 and less than the `MaxColumn`.
The animation is referenced by id.

```charp
UnityNativeChromaSDK.Set2DColor(int animationId, int frameId, int row, int column, int color);
```

---

<a name="Set2DColorName"></a>
**Set2DColorName**

Set the animation color for a frame given the `2D` `row` and `column`. The
`row` should be greater than or equal to 0 and less than the `MaxRow`.
The `column` should be greater than or equal to 0 and less than the `MaxColumn`.
The animation is referenced by name.

```charp
UnityNativeChromaSDK.Set2DColorName(string path, int frameId, int row, int column, int color);
```

---

<a name="Set2DColorNameD"></a>
**Set2DColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.Set2DColorNameD(string path, double frameId, double rowColumnIndex, double color);
```

---

<a name="SetChromaCustomColorAllFrames"></a>
**SetChromaCustomColorAllFrames**

When custom color is set, the custom key mode will be used. The animation
is referenced by id.

```charp
UnityNativeChromaSDK.SetChromaCustomColorAllFrames(int animationId);
```

---

<a name="SetChromaCustomColorAllFramesName"></a>
**SetChromaCustomColorAllFramesName**

When custom color is set, the custom key mode will be used. The animation
is referenced by name.

```charp
UnityNativeChromaSDK.SetChromaCustomColorAllFramesName(string path);
```

---

<a name="SetChromaCustomColorAllFramesNameD"></a>
**SetChromaCustomColorAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetChromaCustomColorAllFramesNameD(string path);
```

---

<a name="SetChromaCustomFlag"></a>
**SetChromaCustomFlag**

Set the Chroma custom key color flag on all frames. `True` changes the layout
from grid to key. `True` changes the layout from key to grid. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.SetChromaCustomFlag(int animationId, bool flag);
```

---

<a name="SetChromaCustomFlagName"></a>
**SetChromaCustomFlagName**

Set the Chroma custom key color flag on all frames. `True` changes the layout
from grid to key. `True` changes the layout from key to grid. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.SetChromaCustomFlagName(string path, bool flag);
```

---

<a name="SetChromaCustomFlagNameD"></a>
**SetChromaCustomFlagNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetChromaCustomFlagNameD(string path, double flag);
```

---

<a name="SetCurrentFrame"></a>
**SetCurrentFrame**

Set the current frame of the animation referenced by id.

```charp
UnityNativeChromaSDK.SetCurrentFrame(int animationId, int frameId);
```

---

<a name="SetCurrentFrameName"></a>
**SetCurrentFrameName**

Set the current frame of the animation referenced by name.

```charp
UnityNativeChromaSDK.SetCurrentFrameName(string path, int frameId);
```

---

<a name="SetCurrentFrameNameD"></a>
**SetCurrentFrameNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetCurrentFrameNameD(string path, double frameId);
```

---

<a name="SetDevice"></a>
**SetDevice**

Changes the `deviceType` and `device` of a `Chroma` animation. If the device
is changed, the `Chroma` animation will be reset with 1 blank frame. Returns
the animation id upon success. Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.SetDevice(int animationId, int deviceType, int device);
```

---

<a name="SetEffect"></a>
**SetEffect**

SetEffect will display the referenced effect id.

```charp
long result = UnityNativeChromaSDK.SetEffect(Guid effectId);
```

---

<a name="SetIdleAnimation"></a>
**SetIdleAnimation**

When the idle animation is used, the named animation will play when no other
animations are playing. Reference the animation by id.

```charp
UnityNativeChromaSDK.SetIdleAnimation(int animationId);
```

---

<a name="SetIdleAnimationName"></a>
**SetIdleAnimationName**

When the idle animation is used, the named animation will play when no other
animations are playing. Reference the animation by name.

```charp
UnityNativeChromaSDK.SetIdleAnimationName(string path);
```

---

<a name="SetKeyColor"></a>
**SetKeyColor**

Set animation key to a static color for the given frame.

```charp
UnityNativeChromaSDK.SetKeyColor(int animationId, int frameId, int rzkey, int color);
```

---

<a name="SetKeyColorAllFrames"></a>
**SetKeyColorAllFrames**

Set the key to the specified key color for all frames. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.SetKeyColorAllFrames(int animationId, int rzkey, int color);
```

---

<a name="SetKeyColorAllFramesName"></a>
**SetKeyColorAllFramesName**

Set the key to the specified key color for all frames. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.SetKeyColorAllFramesName(string path, int rzkey, int color);
```

---

<a name="SetKeyColorAllFramesNameD"></a>
**SetKeyColorAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyColorAllFramesNameD(string path, double rzkey, double color);
```

---

<a name="SetKeyColorAllFramesRGB"></a>
**SetKeyColorAllFramesRGB**

Set the key to the specified key color for all frames. Animation is referenced
by id.

```charp
UnityNativeChromaSDK.SetKeyColorAllFramesRGB(int animationId, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyColorAllFramesRGBName"></a>
**SetKeyColorAllFramesRGBName**

Set the key to the specified key color for all frames. Animation is referenced
by name.

```charp
UnityNativeChromaSDK.SetKeyColorAllFramesRGBName(string path, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyColorAllFramesRGBNameD"></a>
**SetKeyColorAllFramesRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyColorAllFramesRGBNameD(string path, double rzkey, double red, double green, double blue);
```

---

<a name="SetKeyColorName"></a>
**SetKeyColorName**

Set animation key to a static color for the given frame.

```charp
UnityNativeChromaSDK.SetKeyColorName(string path, int frameId, int rzkey, int color);
```

---

<a name="SetKeyColorNameD"></a>
**SetKeyColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyColorNameD(string path, double frameId, double rzkey, double color);
```

---

<a name="SetKeyColorRGB"></a>
**SetKeyColorRGB**

Set the key to the specified key color for the specified frame. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.SetKeyColorRGB(int animationId, int frameId, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyColorRGBName"></a>
**SetKeyColorRGBName**

Set the key to the specified key color for the specified frame. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.SetKeyColorRGBName(string path, int frameId, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyColorRGBNameD"></a>
**SetKeyColorRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyColorRGBNameD(string path, double frameId, double rzkey, double red, double green, double blue);
```

---

<a name="SetKeyNonZeroColor"></a>
**SetKeyNonZeroColor**

Set animation key to a static color for the given frame if the existing
color is not already black.

```charp
UnityNativeChromaSDK.SetKeyNonZeroColor(int animationId, int frameId, int rzkey, int color);
```

---

<a name="SetKeyNonZeroColorName"></a>
**SetKeyNonZeroColorName**

Set animation key to a static color for the given frame if the existing
color is not already black.

```charp
UnityNativeChromaSDK.SetKeyNonZeroColorName(string path, int frameId, int rzkey, int color);
```

---

<a name="SetKeyNonZeroColorNameD"></a>
**SetKeyNonZeroColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyNonZeroColorNameD(string path, double frameId, double rzkey, double color);
```

---

<a name="SetKeyNonZeroColorRGB"></a>
**SetKeyNonZeroColorRGB**

Set the key to the specified key color for the specified frame where color
is not black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeyNonZeroColorRGB(int animationId, int frameId, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyNonZeroColorRGBName"></a>
**SetKeyNonZeroColorRGBName**

Set the key to the specified key color for the specified frame where color
is not black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeyNonZeroColorRGBName(string path, int frameId, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyNonZeroColorRGBNameD"></a>
**SetKeyNonZeroColorRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyNonZeroColorRGBNameD(string path, double frameId, double rzkey, double red, double green, double blue);
```

---

<a name="SetKeysColor"></a>
**SetKeysColor**

Set an array of animation keys to a static color for the given frame. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysColor(int animationId, int frameId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysColorAllFrames"></a>
**SetKeysColorAllFrames**

Set an array of animation keys to a static color for all frames. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysColorAllFrames(int animationId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysColorAllFramesName"></a>
**SetKeysColorAllFramesName**

Set an array of animation keys to a static color for all frames. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysColorAllFramesName(string path, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysColorAllFramesRGB"></a>
**SetKeysColorAllFramesRGB**

Set an array of animation keys to a static color for all frames. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysColorAllFramesRGB(int animationId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysColorAllFramesRGBName"></a>
**SetKeysColorAllFramesRGBName**

Set an array of animation keys to a static color for all frames. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysColorAllFramesRGBName(string path, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysColorName"></a>
**SetKeysColorName**

Set an array of animation keys to a static color for the given frame.

```charp
UnityNativeChromaSDK.SetKeysColorName(string path, int frameId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysColorRGB"></a>
**SetKeysColorRGB**

Set an array of animation keys to a static color for the given frame. Animation
is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysColorRGB(int animationId, int frameId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysColorRGBName"></a>
**SetKeysColorRGBName**

Set an array of animation keys to a static color for the given frame. Animation
is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysColorRGBName(string path, int frameId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysNonZeroColor"></a>
**SetKeysNonZeroColor**

Set an array of animation keys to a static color for the given frame if
the existing color is not already black.

```charp
UnityNativeChromaSDK.SetKeysNonZeroColor(int animationId, int frameId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysNonZeroColorAllFrames"></a>
**SetKeysNonZeroColorAllFrames**

Set an array of animation keys to a static color for the given frame where
the color is not black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysNonZeroColorAllFrames(int animationId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysNonZeroColorAllFramesName"></a>
**SetKeysNonZeroColorAllFramesName**

Set an array of animation keys to a static color for all frames if the existing
color is not already black. Reference animation by name.

```charp
UnityNativeChromaSDK.SetKeysNonZeroColorAllFramesName(string path, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysNonZeroColorName"></a>
**SetKeysNonZeroColorName**

Set an array of animation keys to a static color for the given frame if
the existing color is not already black. Reference animation by name.

```charp
UnityNativeChromaSDK.SetKeysNonZeroColorName(string path, int frameId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysNonZeroColorRGB"></a>
**SetKeysNonZeroColorRGB**

Set an array of animation keys to a static color for the given frame where
the color is not black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysNonZeroColorRGB(int animationId, int frameId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysNonZeroColorRGBName"></a>
**SetKeysNonZeroColorRGBName**

Set an array of animation keys to a static color for the given frame where
the color is not black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysNonZeroColorRGBName(string path, int frameId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysZeroColor"></a>
**SetKeysZeroColor**

Set an array of animation keys to a static color for the given frame where
the color is black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysZeroColor(int animationId, int frameId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysZeroColorAllFrames"></a>
**SetKeysZeroColorAllFrames**

Set an array of animation keys to a static color for all frames where the
color is black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysZeroColorAllFrames(int animationId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysZeroColorAllFramesName"></a>
**SetKeysZeroColorAllFramesName**

Set an array of animation keys to a static color for all frames where the
color is black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysZeroColorAllFramesName(string path, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysZeroColorAllFramesRGB"></a>
**SetKeysZeroColorAllFramesRGB**

Set an array of animation keys to a static color for all frames where the
color is black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysZeroColorAllFramesRGB(int animationId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysZeroColorAllFramesRGBName"></a>
**SetKeysZeroColorAllFramesRGBName**

Set an array of animation keys to a static color for all frames where the
color is black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysZeroColorAllFramesRGBName(string path, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysZeroColorName"></a>
**SetKeysZeroColorName**

Set an array of animation keys to a static color for the given frame where
the color is black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysZeroColorName(string path, int frameId, int[] rzkeys, int keyCount, int color);
```

---

<a name="SetKeysZeroColorRGB"></a>
**SetKeysZeroColorRGB**

Set an array of animation keys to a static color for the given frame where
the color is black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeysZeroColorRGB(int animationId, int frameId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeysZeroColorRGBName"></a>
**SetKeysZeroColorRGBName**

Set an array of animation keys to a static color for the given frame where
the color is black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeysZeroColorRGBName(string path, int frameId, int[] rzkeys, int keyCount, int red, int green, int blue);
```

---

<a name="SetKeyZeroColor"></a>
**SetKeyZeroColor**

Set animation key to a static color for the given frame where the color
is black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeyZeroColor(int animationId, int frameId, int rzkey, int color);
```

---

<a name="SetKeyZeroColorName"></a>
**SetKeyZeroColorName**

Set animation key to a static color for the given frame where the color
is black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeyZeroColorName(string path, int frameId, int rzkey, int color);
```

---

<a name="SetKeyZeroColorNameD"></a>
**SetKeyZeroColorNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyZeroColorNameD(string path, double frameId, double rzkey, double color);
```

---

<a name="SetKeyZeroColorRGB"></a>
**SetKeyZeroColorRGB**

Set animation key to a static color for the given frame where the color
is black. Animation is referenced by id.

```charp
UnityNativeChromaSDK.SetKeyZeroColorRGB(int animationId, int frameId, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyZeroColorRGBName"></a>
**SetKeyZeroColorRGBName**

Set animation key to a static color for the given frame where the color
is black. Animation is referenced by name.

```charp
UnityNativeChromaSDK.SetKeyZeroColorRGBName(string path, int frameId, int rzkey, int red, int green, int blue);
```

---

<a name="SetKeyZeroColorRGBNameD"></a>
**SetKeyZeroColorRGBNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SetKeyZeroColorRGBNameD(string path, double frameId, double rzkey, double red, double green, double blue);
```

---

<a name="SetLogDelegate"></a>
**SetLogDelegate**

Invokes the setup for a debug logging callback so that `stdout` is redirected
to the callback. This is used by `Unity` so that debug messages can appear
in the console window.

```charp
UnityNativeChromaSDK.SetLogDelegate(IntPtr fp);
```

---

<a name="StaticColor"></a>
**StaticColor**

`PluginStaticColor` sets the target device to the static color.

```charp
UnityNativeChromaSDK.StaticColor(int deviceType, int device, int color);
```

---

<a name="StaticColorD"></a>
**StaticColorD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.StaticColorD(double deviceType, double device, double color);
```

---

<a name="StopAll"></a>
**StopAll**

`PluginStopAll` will automatically stop all animations that are playing.

```charp
UnityNativeChromaSDK.StopAll();
```

---

<a name="StopAnimation"></a>
**StopAnimation**

Stops animation playback if in progress. Returns the animation id upon success.
Returns -1 upon failure.

```charp
int result = UnityNativeChromaSDK.StopAnimation(int animationId);
```

---

<a name="StopAnimationD"></a>
**StopAnimationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.StopAnimationD(double animationId);
```

---

<a name="StopAnimationName"></a>
**StopAnimationName**

`PluginStopAnimationName` automatically handles initializing the `ChromaSDK`.
The named `.chroma` animation file will be automatically opened. The animation
will stop if playing.

```charp
UnityNativeChromaSDK.StopAnimationName(string path);
```

---

<a name="StopAnimationNameD"></a>
**StopAnimationNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.StopAnimationNameD(string path);
```

---

<a name="StopAnimationType"></a>
**StopAnimationType**

`PluginStopAnimationType` automatically handles initializing the `ChromaSDK`.
If any animation is playing for the `deviceType` and `device` combination,
it will be stopped.

```charp
UnityNativeChromaSDK.StopAnimationType(int deviceType, int device);
```

---

<a name="StopAnimationTypeD"></a>
**StopAnimationTypeD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.StopAnimationTypeD(double deviceType, double device);
```

---

<a name="StopComposite"></a>
**StopComposite**

`PluginStopComposite` automatically handles initializing the `ChromaSDK`.
The named animation files for the `.chroma` set will be automatically opened.
The set of animations will be stopped if playing.

```charp
UnityNativeChromaSDK.StopComposite(string name);
```

---

<a name="StopCompositeD"></a>
**StopCompositeD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.StopCompositeD(string name);
```

---

<a name="SubtractNonZeroAllKeysAllFrames"></a>
**SubtractNonZeroAllKeysAllFrames**

Subtract the source color from the target color for all frames where the
target color is not black. Source and target are referenced by id.

```charp
UnityNativeChromaSDK.SubtractNonZeroAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="SubtractNonZeroAllKeysAllFramesName"></a>
**SubtractNonZeroAllKeysAllFramesName**

Subtract the source color from the target color for all frames where the
target color is not black. Source and target are referenced by name.

```charp
UnityNativeChromaSDK.SubtractNonZeroAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="SubtractNonZeroAllKeysAllFramesNameD"></a>
**SubtractNonZeroAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SubtractNonZeroAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="SubtractNonZeroAllKeysAllFramesOffset"></a>
**SubtractNonZeroAllKeysAllFramesOffset**

Subtract the source color from the target color for all frames where the
target color is not black starting at offset for the length of the source.
Source and target are referenced by id.

```charp
UnityNativeChromaSDK.SubtractNonZeroAllKeysAllFramesOffset(int sourceAnimationId, int targetAnimationId, int offset);
```

---

<a name="SubtractNonZeroAllKeysAllFramesOffsetName"></a>
**SubtractNonZeroAllKeysAllFramesOffsetName**

Subtract the source color from the target color for all frames where the
target color is not black starting at offset for the length of the source.
Source and target are referenced by name.

```charp
UnityNativeChromaSDK.SubtractNonZeroAllKeysAllFramesOffsetName(string sourceAnimation, string targetAnimation, int offset);
```

---

<a name="SubtractNonZeroAllKeysAllFramesOffsetNameD"></a>
**SubtractNonZeroAllKeysAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SubtractNonZeroAllKeysAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double offset);
```

---

<a name="SubtractNonZeroAllKeysOffset"></a>
**SubtractNonZeroAllKeysOffset**

Subtract the source color from the target where color is not black for the
source frame and target offset frame, reference source and target by id.

```charp
UnityNativeChromaSDK.SubtractNonZeroAllKeysOffset(int sourceAnimationId, int targetAnimationId, int frameId, int offset);
```

---

<a name="SubtractNonZeroAllKeysOffsetName"></a>
**SubtractNonZeroAllKeysOffsetName**

Subtract the source color from the target where color is not black for the
source frame and target offset frame, reference source and target by name.

```charp
UnityNativeChromaSDK.SubtractNonZeroAllKeysOffsetName(string sourceAnimation, string targetAnimation, int frameId, int offset);
```

---

<a name="SubtractNonZeroAllKeysOffsetNameD"></a>
**SubtractNonZeroAllKeysOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SubtractNonZeroAllKeysOffsetNameD(string sourceAnimation, string targetAnimation, double frameId, double offset);
```

---

<a name="SubtractNonZeroTargetAllKeysAllFrames"></a>
**SubtractNonZeroTargetAllKeysAllFrames**

Subtract the source color from the target color where the target color is
not black for all frames. Reference source and target by id.

```charp
UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysAllFrames(int sourceAnimationId, int targetAnimationId);
```

---

<a name="SubtractNonZeroTargetAllKeysAllFramesName"></a>
**SubtractNonZeroTargetAllKeysAllFramesName**

Subtract the source color from the target color where the target color is
not black for all frames. Reference source and target by name.

```charp
UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysAllFramesName(string sourceAnimation, string targetAnimation);
```

---

<a name="SubtractNonZeroTargetAllKeysAllFramesNameD"></a>
**SubtractNonZeroTargetAllKeysAllFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysAllFramesNameD(string sourceAnimation, string targetAnimation);
```

---

<a name="SubtractNonZeroTargetAllKeysAllFramesOffset"></a>
**SubtractNonZeroTargetAllKeysAllFramesOffset**

Subtract the source color from the target color where the target color is
not black for all frames starting at the target offset for the length of
the source. Reference source and target by id.

```charp
UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysAllFramesOffset(int sourceAnimationId, int targetAnimationId, int offset);
```

---

<a name="SubtractNonZeroTargetAllKeysAllFramesOffsetName"></a>
**SubtractNonZeroTargetAllKeysAllFramesOffsetName**

Subtract the source color from the target color where the target color is
not black for all frames starting at the target offset for the length of
the source. Reference source and target by name.

```charp
UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysAllFramesOffsetName(string sourceAnimation, string targetAnimation, int offset);
```

---

<a name="SubtractNonZeroTargetAllKeysAllFramesOffsetNameD"></a>
**SubtractNonZeroTargetAllKeysAllFramesOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysAllFramesOffsetNameD(string sourceAnimation, string targetAnimation, double offset);
```

---

<a name="SubtractNonZeroTargetAllKeysOffset"></a>
**SubtractNonZeroTargetAllKeysOffset**

Subtract the source color from the target color where the target color is
not black from the source frame to the target offset frame. Reference source
and target by id.

```charp
UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysOffset(int sourceAnimationId, int targetAnimationId, int frameId, int offset);
```

---

<a name="SubtractNonZeroTargetAllKeysOffsetName"></a>
**SubtractNonZeroTargetAllKeysOffsetName**

Subtract the source color from the target color where the target color is
not black from the source frame to the target offset frame. Reference source
and target by name.

```charp
UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysOffsetName(string sourceAnimation, string targetAnimation, int frameId, int offset);
```

---

<a name="SubtractNonZeroTargetAllKeysOffsetNameD"></a>
**SubtractNonZeroTargetAllKeysOffsetNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.SubtractNonZeroTargetAllKeysOffsetNameD(string sourceAnimation, string targetAnimation, double frameId, double offset);
```

---

<a name="TrimEndFrames"></a>
**TrimEndFrames**

Trim the end of the animation. The length of the animation will be the lastFrameId
+ 1. Reference the animation by id.

```charp
UnityNativeChromaSDK.TrimEndFrames(int animationId, int lastFrameId);
```

---

<a name="TrimEndFramesName"></a>
**TrimEndFramesName**

Trim the end of the animation. The length of the animation will be the lastFrameId
+ 1. Reference the animation by name.

```charp
UnityNativeChromaSDK.TrimEndFramesName(string path, int lastFrameId);
```

---

<a name="TrimEndFramesNameD"></a>
**TrimEndFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.TrimEndFramesNameD(string path, double lastFrameId);
```

---

<a name="TrimFrame"></a>
**TrimFrame**

Remove the frame from the animation. Reference animation by id.

```charp
UnityNativeChromaSDK.TrimFrame(int animationId, int frameId);
```

---

<a name="TrimFrameName"></a>
**TrimFrameName**

Remove the frame from the animation. Reference animation by name.

```charp
UnityNativeChromaSDK.TrimFrameName(string path, int frameId);
```

---

<a name="TrimFrameNameD"></a>
**TrimFrameNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.TrimFrameNameD(string path, double frameId);
```

---

<a name="TrimStartFrames"></a>
**TrimStartFrames**

Trim the start of the animation starting at frame 0 for the number of frames.
Reference the animation by id.

```charp
UnityNativeChromaSDK.TrimStartFrames(int animationId, int numberOfFrames);
```

---

<a name="TrimStartFramesName"></a>
**TrimStartFramesName**

Trim the start of the animation starting at frame 0 for the number of frames.
Reference the animation by name.

```charp
UnityNativeChromaSDK.TrimStartFramesName(string path, int numberOfFrames);
```

---

<a name="TrimStartFramesNameD"></a>
**TrimStartFramesNameD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.TrimStartFramesNameD(string path, double numberOfFrames);
```

---

<a name="Uninit"></a>
**Uninit**

Uninitializes the `ChromaSDK`. Returns 0 upon success. Returns -1 upon failure.

```charp
long result = UnityNativeChromaSDK.Uninit();
```

---

<a name="UninitD"></a>
**UninitD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.UninitD();
```

---

<a name="UnloadAnimation"></a>
**UnloadAnimation**

Unloads `Chroma` effects to free up resources. Returns the animation id
upon success. Returns -1 upon failure. Reference the animation by id.

```charp
int result = UnityNativeChromaSDK.UnloadAnimation(int animationId);
```

---

<a name="UnloadAnimationD"></a>
**UnloadAnimationD**

D suffix for limited data types.

```charp
double result = UnityNativeChromaSDK.UnloadAnimationD(double animationId);
```

---

<a name="UnloadAnimationName"></a>
**UnloadAnimationName**

Unload the animation effects. Reference the animation by name.

```charp
UnityNativeChromaSDK.UnloadAnimationName(string path);
```

---

<a name="UnloadComposite"></a>
**UnloadComposite**

Unload the the composite set of animation effects. Reference the animation
by name.

```charp
UnityNativeChromaSDK.UnloadComposite(string name);
```

---

<a name="UpdateFrame"></a>
**UpdateFrame**

Updates the `frameIndex` of the `Chroma` animation and sets the `duration`
(in seconds). The `color` is expected to be an array of the dimensions
for the `deviceType/device`. The `length` parameter is the size of the
`color` array. For `EChromaSDKDevice1DEnum` the array size should be `MAX
LEDS`. For `EChromaSDKDevice2DEnum` the array size should be `MAX ROW`
* `MAX COLUMN`. Returns the animation id upon success. Returns -1 upon
failure.

```charp
int result = UnityNativeChromaSDK.UpdateFrame(int animationId, int frameIndex, float duration, int[] colors, int length);
```

---

<a name="UseIdleAnimation"></a>
**UseIdleAnimation**

When the idle animation flag is true, when no other animations are playing,
the idle animation will be used. The idle animation will not be affected
by the API calls to PluginIsPlaying, PluginStopAnimationType, PluginGetPlayingAnimationId,
and PluginGetPlayingAnimationCount. Then the idle animation flag is false,
the idle animation is disabled. `Device` uses `EChromaSDKDeviceEnum` enums.

```charp
UnityNativeChromaSDK.UseIdleAnimation(int device, bool flag);
```

---

<a name="UseIdleAnimations"></a>
**UseIdleAnimations**

Set idle animation flag for all devices.

```charp
UnityNativeChromaSDK.UseIdleAnimations(bool flag);
```

---

<a name="UsePreloading"></a>
**UsePreloading**

Set preloading animation flag, which is set to true by default. Reference
animation by id.

```charp
UnityNativeChromaSDK.UsePreloading(int animationId, bool flag);
```

---

<a name="UsePreloadingName"></a>
**UsePreloadingName**

Set preloading animation flag, which is set to true by default. Reference
animation by name.

```charp
UnityNativeChromaSDK.UsePreloadingName(string path, bool flag);
```


<a name="examples"></a>
## Examples

**Example01**

[UnityNativeChromaSDKExample01.cs](Assets/UnityNativeChromaSDK/Examples/Scripts/UnityNativeChromaSDKExample01.cs) has a GUI example to play/stop/edit `Chroma` animations at runtime.

 ![image_3](images/image_3.png)

**Example02**

[UnityNativeChromaSDKExample02.cs](Assets/UnityNativeChromaSDK/Examples/Scripts/UnityNativeChromaSDKExample02.cs) has a GUI button to load scene 1 to show animations work with multiple scenes.

![image_4](images/image_4.png)

**UnityNativeChromaSDKPlayOnEnable**

The [UnityNativeChromaSDKPlayOnEnable.cs](Assets/UnityNativeChromaSDK/Scripts/UnityNativeChromaSDKPlayOnEnable.cs) script will automatically open and play a `Chroma` animation by name.

The `AnimationName` field references a `.chroma` asset `filename` from the [`StreamingAssets`](https://docs.unity3d.com/Manual/StreamingAssets.html) folder.

The `.chroma` extension on the `AnimationName` field is optional.

The `UnityNativeChromaSDKPlayOnEnable.cs` script will play the animation when the `OnEnable` event fires.

The `UnityNativeChromaSDKPlayOnEnable.cs` script will stop the animation when the `OnDisable` event fires.

![image_5](images/image_5.png)

**Example03**

Particle capture example

**Example04**

Show `PlayOnEnable` script

**Example05**

Image plane capture example

**Example06**

Show `PlayAndDeactivate` script

**Example07**

Show `PlayOnDestroy` script

**Example08**

`SetKeys` and `CopyKeys` can be used to highlight keys on top of an animated base layer.

**Example09**

Chroma animations can be paused and resumed with looping ON or OFF.

**Example10**

Chroma animations support independent layering.

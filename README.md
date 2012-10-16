kinect-replay
=============
This is a C# library that allows recording and playback of kinect data from files saved to disk. Unlike the Kinect Studio which is a standalone program from Microsoft, this library allows you to perform tasks without the need for a connected sensor.

Differences from Kinect Studio
------------------------------
- Can replay data without requiring a connected sensor, and data is not dependent on a specific sensor
- Saves skeletal tracking information, including depth mapping

Known limitations
-----------------
- Currently skeleton to depth mapping is saved using the 640x480x30 DepthImageFormat without a way to specify which to use

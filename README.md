# OneWayUp (Mobile Virtual Reality Game)

One Way Up is a mobile game that is designed to invoke fear through the illusion of heights and free falling in a virtual reality setting. Gameplay involves using timed gaze input to interact with items to determine if the player ascends or falls. Developed in C# using the Unity Game Engine and built for iOS.

## How to play? (As of 02/08/2018 alpha prototype)

Open build from unity in xcode, compile, and deploy to iOS device. Launch app and place iOS device in a virtual reality headset (Merge used for development https://mergevr.com/).

Locate the golden cube, and place gaze upon cube for 5 seconds. This will initiate the player's ascent. As ascending, place gaze upon blue cubes for 2 seconds. This will deactivate the cube and be counted as a 'hit'. Once the player has hit 10 cubes, they will go into free fall until death. Level automatically restarts. 

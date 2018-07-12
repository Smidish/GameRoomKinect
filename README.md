# GameRoomKinect
This game is a prototype for a modal gaming room concept. The User stands in front of a big projection of the game and moves through a space tunnel, where he can collect objects. While playing he's wearing a vest, which shows his remaining life and gives haptic &amp; audio feedback when the player is hit by an object

P6_2018_Exe_GameRoom.zip includes a final build, running on Windows PCs. Kinect V2 Sdk and Mosqitto(if used with vest) has to be installed on the pc.

The folder ESP Code Vest holds the Code for the Esp8266, which controls the vest. It can be deployed with the Arduino IDE.

To make the highscore work, create a textfile @ D:/highscore.txt and write the line {"Scores":[]}

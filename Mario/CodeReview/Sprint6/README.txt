Superer Mario MANUAL -

Welcome to Superer Mario. Unlike previous mario games, you challenged to race the timer. Once reaching the end of the level, a new one will be generated ahead of you. 
Get the highest score possible before the time runs out. Look out for a challenge by Mini Bowser along the way.

Controls-

S - Crouch
A - Move Left
D - Move Right

Z - Jump
X - Run/Fire

esc,Q - Quit Game
T - Pause Game
R - Reset Game

Additional Controls

Y - Change Mario to Regular size
U - Change Mario to Super Mario
I - Change Mario to Fire Mario
O - Kill Mario
P - Give Mario Star Powerup

Features Unique to Superer Mario:

Endless Levels!
Meaningful sections of the original 1-1 as well as level pieces of our own creation were cut up and scrambled. 

Race Against the Clock!
You have 300s to get the highest score possible. The timer will quickly count down and persist with you as you move through new levels. 

Add More Time by Collecting Coins and Killing Enemies!
Collecting coins and chaining enemy kills (either by stomping or using a shell) will temporarily increase the amount of time that you have.

Challenge Bowser to Duel!
At the end of every level, there is a Bowser enemy to defeat. If you defeat him , you will receive a time bonus. 
Otherwise, you may pass onto the next level (passing by unharmed may be difficult, however). Bowser's jumps make the ground shake 


New Suppressions:

CA 1059 Member should not expose concrete types in LevelLoader - 
The main benefit of these functions revolves around the ability to deserialize a XMLReader. 
The preferred generic type is not compatible with any of the reader classes. 
Hence, it's just as well that we pass in the XMLNode type. In the future, it would be possible to create one type of loading function, in which case there would be no exposed concrete types.
This is not feasible in the scope of this Sprint.

CA1502 CA1809 Large cyclomatic complexity of collision detection - 
We began to implement a unified collision class that would eliminate cyclomatic complexity issues. However, due to communication issues, new features became incompatible, and we had to roll back. 
We recognize this is an ongoing issue, and future work would allow us to address it. 





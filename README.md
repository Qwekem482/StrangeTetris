
# Strange Tetris

Game are under development

A simple Tetris but with 9 blocks

Developed by Qwekem482

Graphic Design by Qwekem482 & Nemie


## Game Mechanism

Same as other Tetris game, random block will spawn from top of the play ground. There is a small windows that will show next spawn block.

**Level Mechanism**

There is a level mechanism that will increase score and ~~drop speed~~. Amount of exp point is equal to number of total cleared row.

Exp formula: MIN((level x 10 + 10), MAX(100, level x 10 -50))

**Score Mechanism**

Score will increase as level and number of clear line at once increase. Because the longest block is 4 block, maximum number of clear line at once is 4

Score formula:

|Level  |1 line      |2 lines      |3 lines      |4 lines       |
|:-----:|:----------:|:-----------:|:-----------:|:------------:|
|0      |40          |100          |300          |1200          |
|1      |80          |200          |600          |2400          |
|2      |120         |300          |900          |3600          |
|9      |400         |1000         |3000         |12000         |
|n      |40 x (n + 1)|100 x (n + 1)|300 x (n + 1)|1200 x (n + 1)|

**Increse Speed Mechanism**

Under Development
## Support and Tutorial

![Group 310](https://user-images.githubusercontent.com/80797630/229062282-eaad0b16-af8a-4aaa-8652-a4be474f380c.png)

 - This project is made with Unity Engine, coded with Visual Studio Code.
 - Sprite and UI created with the help of [Nemie](https://www.facebook.com/nemie1502 "Nemie") and me using [Figma](https://www.figma.com/ "Figma").
 - This game is created with the help of ![#f37700](https://placehold.co/15x15/f37700/f37700.png)[Stackoverflow](https://stackoverflow.com/ "Stackoverflow"), ![#00fff0](https://placehold.co/15x15/00fff0/00fff0.png)[noobtuts](https://noobtuts.com/unity/2d-arkanoid-game "noobtuts").

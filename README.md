# Text-Based Car Racing Game

Welcome to the Text-Based Car Racing Game! This is a choice-based game developed in Unity, where players make decisions during a race to try and beat their rivals. The game runs through a state machine to handle different game states and player choices.

## Table of Contents

- [Features](#features)
- [Game States](#game-states)
- [Try the Game](#try-the-game)

## Features

- **Choice-Based Gameplay**: Make strategic decisions during the race.
- **State Machine**: Efficiently handles different game states and transitions.
- **Probability-Based Outcomes**: Actions like hitting nitro have probabilistic outcomes.

## Game States

The game uses a state machine to manage different states. Here are the key states:

- **State 1**: The game asks if you are experienced in driving.
  - **Yes**: Continue to State 2.
  - **No**: The game tells the player to wait until 18 and get a driving license. Clicking brings the player back to the main menu.

- **State 2**: The player has three choices:
  1. **Select an Average Car**: Proceed with an average car.
  2. **Take a Risk**: Attempt to get a supercar, but there is a chance to get a terrible car.
     - If the player gets a terrible car, an additional option is provided:
       - **Sell Kidney**: Upgrade to an average car, but there is a chance the player might still need 5000 more game coins.
         - If the player still needs 5000 more coins:
           - **Continue with Terrible Car**: Proceed with the terrible car.
           - **Sell Second Kidney**: The player dies, loses all progress, and is brought back to the main menu.
  3. **Go on Vacation**: The main objective of the game, requiring at least 10000 game coins, which can be gained from winning races and taking good actions like hitting nitro.

- **Race State**: After getting the car, the player starts a race with a higher chance of winning depending on the car (supercar = high chance, terrible car = low chance). During the race, several actions can randomly appear:
  - **Nitro**: If the player is in 2nd place and the race is still going, the player can toggle nitro to speed up. If the player stays in 2nd place, they might use nitro multiple times. However, using nitro several times might result in running out of fuel and losing the race.
  - **Civil Car Encounter**: If the player is in 1st place but the race is still going, a civil car might appear in the same lane. The player has two choices:
    - **Stop the Car**: Lose the race but gain respect and some coins for not risking civilian lives.
    - **Overtake the Civil Car**: Attempt to overtake, with a chance of success or the car running out of control, resulting in the player's death and a return to the main menu.
  - **Shortcut**: If the player is in 2nd place, a shortcut might appear. Taking the shortcut is risky due to a police department on the way. If successful, the player passes the rival and takes 1st place. If caught, the player is busted, loses progress, and returns to the main menu.

- **Post-Race State**: After every finished race, the player is asked if they want to take a vacation if they have enough money.

## Try the Game

You can try the game on the web by following this [link](https://simmer.io/@AbdulTara/b1). 

🕳 BlindMaze

A 2D stealth-maze game where vision is a limited, risky resource.
BlindMaze is a top-down maze stealth game where the player navigates in darkness using limited sonar pings while avoiding slow-moving stalkers that react to proximity. Every ping reveals the maze — but also increases danger.

🎮 Play the Game

🔗 WebGL Build:
https://arshia786-stack.github.io/blindmaze-pairedprototype/

🎥 Gameplay Video:
https://drive.google.com/drive/folders/1JDcvemh1aDziqdLxYKxmBbVlTvqiTg_L


🧠 Game Concept

BlindMaze explores the idea that information is not safety — it is a strategic risk.
Unlike traditional maze or stealth games where vision is reliable, BlindMaze makes visibility:

- Limited
- Temporary
- Strategic
- Risk-inducing

Players must constantly decide:
"Is it worth revealing the maze right now?"

🕹 Core Features

- 🔦 Limited Sonar Vision
    - Press Space to activate a temporary sonar pulse
    - Reveals nearby walls and paths
    - Sonar uses are limited

- 👁 Complete Darkness by Default
    - Maze is hidden unless pinged

- 🧟 Stalker AI
    - Patrol behavior
    - Chase mode when player enters detection radius
    - Speed increases during chase

- 🧭 Maze-Based Navigation
    - Top-down 2D layout
    - Constrained movement increases tension

- ⚠️ High-Risk Decision Making
    - Use pings early and risk getting lost later
    - Save pings and navigate blindly?

🎯 Objective

Reach the exit before:
- Being caught by a stalker
- Running out of sonar pings
- Losing spatial awareness

🎮 Controls
Action Keys:
- Move	WASD / Arrow Keys
- Sonar Ping: Space

🔄 Core Mechanics

1. Sonar as Resource
- Limited count
- Temporarily reveals environment
- Creates tension through scarcity

2. Patrol -> Chase AI
- Stalkers patrol predefined paths
- Switch to chase mode when player is detected
- Return to patrol when player escapes radius

3. Risk-Reward Movement
- Exploration requires committing to uncertainty
- Spatial awareness becomes essential


🏗 Technical Implementation

Built With:
- Unity (2D)
- C#
- WebGL build for browser deployment


📊 Design Goals

- Create tension without complex graphics
- Make information a strategic currency
- Encourage uncertainty-driven decision-making
- Build psychological pressure using simple mechanics

🚀 Future Improvements

- Dynamic maze generation
- Increasing difficulty levels
- Multiple stalker types
- Audio-based detection system
- Replay analytics (ping usage tracking)
- Power-ups that alter visibility mechanics

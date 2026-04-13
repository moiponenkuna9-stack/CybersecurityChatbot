# Cybersecurity Awareness Bot – Part 1

## My Project

This is my Part 1 submission for the Cybersecurity Awareness Bot assignment. I built a command-line chatbot that teaches users about online safety. The bot plays a voice greeting, shows an ASCII logo, asks for my name, and answers questions about password safety, phishing, and safe browsing. It can also "elaborate more" and give examples when I ask.

## What I Did Step by Step

### Step 1. Setting Up the Project
I created a new Console App in Visual Studio using .NET 6.0. I named the project `CybersecurityAwarenessBot`. Then I created five C# classes: `Program.cs`, `Chatbot.cs`, `ResponseManager.cs`, `UIManager.cs`, and `AudioManager.cs`.

### Step 2. Voice Greeting (Question 1)
I recorded a short voice message saying "Hello! Welcome to the Cybersecurity Awareness Bot…" and saved it as `chatbot.wav`. In `AudioManager.cs`, I wrote code that searches for the file and plays it when the bot starts. If the file is missing, the bot still runs without crashing.

### Step 3. ASCII Art Logo (Question 2)
In `UIManager.cs`, I added a large ASCII art drawing that spells out "CYBERSECURITY AWARENESS BOT" at the bottom. I used cyan colour to make it stand out.

### Step 4. Text Greeting and User Name (Question 3)
The bot first asks for my name. It checks that I don't leave it empty. Then it personalises the welcome message, for example "Hello Maria!".

### Step 5. Basic Responses (Question 4)
I programmed the bot to answer:
- "How are you?" – gives a random friendly reply.
- "What is your purpose?" – explains the bot's mission.
- "What can I ask you about?" – lists topics.
- Password safety, phishing, and safe browsing – each has a clear definition.

### Step 6. Input Validation (Question 5)
If I type nothing, the bot asks me to try again. If I type something it doesn't understand, it says "I didn't quite understand that. Could you rephrase?" I also added try-catch blocks everywhere so the bot never crashes.

### Step 7. Enhanced Console UI (Question 6)
I used `Console.ForegroundColor` to add colours: cyan for the logo, green for borders, yellow for warnings, magenta for help. I added borders made of `=` and `?`, section headers with `????`, and a typing effect that shows "[BOT is typing...]" before each response.

### Step 8. Code Structure (Question 7)
I split the code into five classes, each with its own responsibility. In `ResponseManager.cs`, I used a `Dictionary` to store keywords and their responses, and `List`s for random selection. This makes it easy to add more topics later.

### Step 9. Making the Bot Smarter (Follow?ups)
I wanted the bot to remember what we were talking about. So I added a `lastTopic` variable. When I ask "elaborate more" or "tell me more", the bot gives extra details. If I ask again, it gives real?life examples. I also added typo correction: "phising" becomes "phishing", "satey" becomes "safety".

### Step 10. Testing
I tested many inputs:
- `define password safety` ? works
- `elaborate more` ? gives more tips
- `give examples` ? shows strong/weak password examples
- `define phishing` ? works
- `tell me more` ? gives phishing details
- `define safe browsing` ? works
- `how are you` ? random reply each time
- `what is your purpose` ? correct answer
- `exit` ? closes nicely

### 11. GitHub and CI
I made a GitHub repository and committed my code after each major feature (at least 6 commits). I set up GitHub Actions to automatically build the project on every push – this checks for any errors.

### 12. Video Presentation
I recorded an 8?minute video showing the bot running, explaining my code, and demonstrating all the features. I used my own voice (no AI voice) and uploaded it as an unlisted YouTube link.

## How to Run My Project

1. Place your `chatbot.wav` file in the `bin\Debug\net6.0\` folder (or the output folder after building).
2. Open the solution in Visual Studio.
3. Press F5 to run.

## My Files

- `Program.cs` – starts the chatbot.
- `Chatbot.cs` – main loop, asks for name, handles exit.
- `ResponseManager.cs` – stores all responses, handles follow?ups and typos.
- `UIManager.cs` – all console colours, ASCII art, borders, typing effect.
- `AudioManager.cs` – plays the voice greeting.

## What I Learned

I learned how to use dictionaries for keyword matching, how to add a typing effect, how to play sound in C#, and how to make a console app look professional with colours and borders. I also got practice with Git and GitHub Actions.

---

**Thank you for reviewing my project.**  
* 13 April 2026*

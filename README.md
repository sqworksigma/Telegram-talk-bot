Telegram-Talk-Bot
A simple Telegram bot written in C# that allows users to send messages, spam messages, send files, and images via the Telegram Bot API. It also logs chat interactions and prevents duplicate log entries.

Features
📩 Send Messages – Send single or repeated messages to Telegram chats.
📝 Log User Interactions – Automatically logs user chat IDs and messages.
📂 Send Files & Images – Send text file contents and images to Telegram.
🔄 Prevent Duplicate Logs – Ensures messages are not logged multiple times.
Dependencies
This project requires the following NuGet packages:

Newtonsoft.Json (13.0.3) – A high-performance JSON framework for .NET.
Telegram.Bot (22.3.0) – A .NET client for the Telegram Bot API.
Installation
Clone the repository:
![image](https://github.com/user-attachments/assets/aa41a14d-37ad-4891-bc3d-6aaae07c6acc)

sh
Copy
Edit
git clone https://github.com/your-username/Telegram-Talk-Bot.git
cd Telegram-Talk-Bot
Install the required dependencies:

sh
Copy
Edit
dotnet restore
Open Program.cs and replace botToken with your own Telegram Bot API token.

Build and run the project:

sh
Copy
Edit
dotnet run
Usage
Once the bot is running, you can use the following commands:

spam <message> – Sends a message repeatedly.
send <message> – Sends a single message.
file <filepath> – Sends the content of a text file.
img <filepath> – Sends an image.
Contributing
Contributions are welcome! Feel free to submit issues and pull requests to improve the project.

License
This project is licensed under the MIT License.

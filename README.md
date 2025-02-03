Telegram-Talk-Bot
A simple Telegram bot written in C# that allows users to send messages, spam messages, send files, and images via the Telegram Bot API. It also logs chat interactions and prevents duplicate log entries.

🚀 Features
📩 Send Messages – Send single or repeated messages to Telegram chats.
📝 Log User Interactions – Automatically logs user chat IDs and messages.
📂 Send Files & Images – Send text file contents and images to Telegram.
🔄 Prevent Duplicate Logs – Ensures messages are not logged multiple times.
🔧 Dependencies
This project requires the following NuGet packages:

Newtonsoft.Json (13.0.3) – A high-performance JSON framework for .NET.
Telegram.Bot (22.3.0) – A .NET client for the Telegram Bot API.
📥 Installation
1️⃣ Clone the Repository

```sh
Copy
Edit
git clone https://github.com/your-username/Telegram-Talk-Bot.git
cd Telegram-Talk-Bot
2️⃣ Install Dependencies ```

sh
Copy
Edit
dotnet restore
3️⃣ Set Up Your Bot Token
Open Program.cs and replace botToken with your own Telegram Bot API token.

4️⃣ Build and Run the Project

sh
Copy
Edit
dotnet run
🛠 Usage
📨 Send a Single Message

sh
Copy
Edit
send <message>
Sends a single message to the last active chat.

📢 Spam a Message

sh
Copy
Edit
spam <message>
Repeatedly sends a message to the last active chat.

📂 Send a File’s Content

sh
Copy
Edit
file <filepath>
Sends the contents of a specified text file as a message.

🖼 Send an Image

sh
Copy
Edit
img <filepath>
Sends an image file to the last active chat.

🤝 Contributing
Contributions are welcome! Feel free to submit issues and pull requests to improve the project.

📜 License
This project is licensed under the MIT License.

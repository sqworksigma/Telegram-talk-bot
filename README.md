# Telegram-Talk-Bot

> 📌 **A simple Telegram bot written in C# that allows users to send messages, spam messages, send files, and images via the Telegram Bot API.**  
> It also logs chat interactions and prevents duplicate log entries.  

---

## 🚀 Features  
> 📨 **Send Messages** – Send single or repeated messages to Telegram chats.  
> 📝 **Log User Interactions** – Automatically logs user chat IDs and messages.  
> 📂 **Send Files & Images** – Send text file contents and images to Telegram.  
> 🔄 **Prevent Duplicate Logs** – Ensures messages are not logged multiple times.  





![0203-ezgif com-video-to-gif-converter (1)](https://github.com/user-attachments/assets/c2429487-d0bf-4769-a5f6-a4baa086fce5)





---

## 🔧 Dependencies  
> This project requires the following NuGet packages:  
> ✅ **[Newtonsoft.Json (13.0.3)](https://www.nuget.org/packages/Newtonsoft.Json/)** – A high-performance JSON framework for .NET.  
> ✅ **[Telegram.Bot (22.3.0)](https://www.nuget.org/packages/Telegram.Bot/)** – A .NET client for the Telegram Bot API.  

![image](https://github.com/user-attachments/assets/610f1ad2-03fa-43e3-84da-be31ae00df32)



---

## 📥 Installation  

> **1️⃣ Clone the Repository**  
> ```sh
> git clone https://github.com/your-username/Telegram-Talk-Bot.git
> cd Telegram-Talk-Bot
> ```

> **2️⃣ Install Dependencies**  
> ```sh
> dotnet restore
> ```

> **3️⃣ Set Up Your Bot Token**  
> Open `Program.cs` and replace **botToken** with your own **Telegram Bot API token**.

> **4️⃣ Build and Run the Project**  
> ```sh
> dotnet run
> ```

---

## 🛠 Usage  

> **📨 Send a Single Message**  
> ```sh
> send <message>
> ```  
> Sends a single message to the last active chat.

> **📢 Spam a Message**  
> ```sh
> spam <message>
> ```  
> Repeatedly sends a message to the last active chat.

> **📂 Send a File’s Content**  
> ```sh
> file <filepath>
> ```  
> Sends the contents of a specified text file as a message.

> **🖼 Send an Image**  
> ```sh
> img <filepath>
> ```  
> Sends an image file to the last active chat.

---

## 🤝 Contributing  
> Contributions are welcome! Feel free to submit issues and pull requests to improve the project.  

---

## 📜 License  
> This project is licensed under the **MIT License**.  

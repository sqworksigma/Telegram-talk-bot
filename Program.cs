using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotExample
{
    class Program
    {
        private static TelegramBotClient _botClient;
        private static long _lastChatId;
        private const string LogFilePath = "message_log.txt";

        private static async Task Main(string[] args)
        {
            string botToken = "bot_token"; // Replace with your bot token
            _botClient = new TelegramBotClient(botToken);

            var cts = new CancellationTokenSource();
            _botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                cancellationToken: cts.Token
            );

            Console.WriteLine("Bot started.");
            Console.WriteLine("Type 'spam <message>'");
            Console.WriteLine("'send <message>' to send it once,");
            Console.WriteLine("'file <filepath>' to send a file's content, or 'img <filepath>'");
            Console.WriteLine("Press Enter to exit.");

            while (true)
            {
                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    break;
                }

                if (userInput.StartsWith("spam ", StringComparison.OrdinalIgnoreCase))
                {
                    string spamMessage = userInput.Substring(5).Trim();
                    await SendMessagesFromLog(spamMessage, true, cts.Token);
                }
                else if (userInput.StartsWith("send ", StringComparison.OrdinalIgnoreCase))
                {
                    string sendMessage = userInput.Substring(5).Trim();
                    await SendMessagesFromLog(sendMessage, false, cts.Token);
                }
                else if (userInput.StartsWith("file ", StringComparison.OrdinalIgnoreCase))
                {
                    string filePath = userInput.Substring(5).Trim();
                    await SendFileContent(filePath, cts.Token);
                }
                else if (userInput.StartsWith("img ", StringComparison.OrdinalIgnoreCase))
                {
                    string imgPath = userInput.Substring(4).Trim();
                    await SendImage(imgPath, cts.Token);
                }
                else
                {
                    Console.WriteLine("Unknown command. Please type 'spam <message>', 'send <message>', 'file <filepath>', or 'img <filepath>' to send an image.");
                }
            }

            cts.Cancel();
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message?.Type == MessageType.Text)
            {
                _lastChatId = update.Message.Chat.Id;
                long userId = update.Message.From.Id;
                int messageId = update.Message.MessageId;
                string userMessage = update.Message.Text;

                Console.WriteLine($"Received message: {userMessage} from Chat ID: {_lastChatId}, User ID: {userId}, Message ID: {messageId}");
                await LogUserDetails(_lastChatId, messageId);
            }
        }

        private static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"An error occurred: {exception.Message}");
        }

        private static async Task LogUserDetails(long chatId, int messageId)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"Chat ID: {chatId}, Message ID: {messageId}, Timestamp: {timestamp}";

            if (!await IsDuplicateEntry(chatId, messageId))
            {
                await File.AppendAllTextAsync(LogFilePath, logEntry + Environment.NewLine);
            }
        }

        private static async Task<bool> IsDuplicateEntry(long chatId, int messageId)
        {
            if (!File.Exists(LogFilePath))
            {
                return false;
            }

            var lines = await File.ReadAllLinesAsync(LogFilePath);
            return lines.Any(line => line.Contains($"Chat ID: {chatId}, Message ID: {messageId}"));
        }

        private static async Task SendMessage(long chatId, string messageText, CancellationToken cancellationToken)
        {
            try
            {
                await _botClient.SendTextMessageAsync(chatId, messageText, cancellationToken: cancellationToken);
                Console.WriteLine($"Sent message: '{messageText}' to chat ID: {chatId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sending the message: {ex.Message}");
            }
        }

        private static async Task SendImage(string imagePath, CancellationToken cancellationToken)
        {
            if (File.Exists(imagePath))
            {
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    await _botClient.SendPhotoAsync(_lastChatId, stream, cancellationToken: cancellationToken);
                    Console.WriteLine($"Sent image: '{imagePath}' to chat ID: {_lastChatId}");
                }
            }
            else
            {
                Console.WriteLine("Image file not found.");
            }
        }

        private static async Task SendMessagesFromLog(string customMessage, bool isSpam, CancellationToken cancellationToken)
        {
            if (File.Exists(LogFilePath))
            {
                var lines = await File.ReadAllLinesAsync(LogFilePath, cancellationToken);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    long chatId = 0;

                    foreach (var part in parts)
                    {
                        if (part.Trim().StartsWith("Chat ID:"))
                        {
                            string chatIdStr = part.Split(':')[1].Trim();
                            if (long.TryParse(chatIdStr, out long parsedChatId))
                            {
                                chatId = parsedChatId;
                            }
                        }
                    }

                    if (chatId != 0)
                    {
                        int messageCount = isSpam ? 10 : 1;
                        for (int i = 0; i < messageCount; i++)
                        {
                            await SendMessage(chatId, customMessage, cancellationToken);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Log file not found.");
            }
        }

        private static async Task SendFileContent(string filePath, CancellationToken cancellationToken)
        {
            if (File.Exists(filePath))
            {
                string fileContent = await File.ReadAllTextAsync(filePath, cancellationToken);
                await SendMessage(_lastChatId, fileContent, cancellationToken);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}

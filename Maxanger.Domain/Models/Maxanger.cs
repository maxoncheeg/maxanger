namespace Maxanger.Domain.Models;

public class Message
{
    public int ChatId { get; set; }
    public string FromUsername { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string? WhisperToUsername { get; set; }
}

public class Maxanger
{
    private static Maxanger? _maxanger;

    private readonly List<Message> _messages;
    private readonly List<int> _existedChatIds;

    private Maxanger()
    {
        _messages = [];
        _existedChatIds = [];
    }

    public static Maxanger GetInstance()
    {
        if (_maxanger == null)
        {
            return _maxanger = new Maxanger();
        }

        return _maxanger;
    }

    public static Maxanger UpdateInstance()
    {
        return _maxanger = new Maxanger();
    }

    public List<string> GetMessages(int chatId, string username)
    {
        if (!_existedChatIds.Contains(chatId)) return [];
        
        return _messages
            .Where(message =>
                message.ChatId == chatId &&
                (message.WhisperToUsername != null &&
                 (message.WhisperToUsername == username || message.FromUsername == username) ||
                 message.WhisperToUsername == null))
            .OrderBy(message => message.Date)
            .Select(message =>
                $"{message.Date.ToShortTimeString()} " +
                $"{(message.FromUsername == username ? "Вы" : message.FromUsername)} " +
                $"{(message.WhisperToUsername != null ? (message.FromUsername == username ? $"шепчет {message.WhisperToUsername} " : "шепчет Вам ") : "")}" +
                $": {message.Text}")
            .ToList();
    }

    public bool SendMessage(int chatId, string username, string text)
    {
        if (!_existedChatIds.Contains(chatId)) return false;
        
        _messages.Add(new Message()
        {
            ChatId = chatId,
            FromUsername = username,
            Text = text,
            Date = DateTime.Now
        });

        return true;
    }

    public bool WhisperMessage(int chatId, string username, string to, string text)
    {
        if (!_existedChatIds.Contains(chatId)) return false;
        
        _messages.Add(new Message()
        {
            ChatId = chatId,
            FromUsername = username,
            Text = text,
            Date = DateTime.Now,
            WhisperToUsername = to
        });

        return true;
    }

    public int CreateChat(string chatName)
    {
        int id = 0;
        if (_existedChatIds.Count > 0)
            id = _existedChatIds.Max() + 1;
        
        Console.WriteLine("Новый чат: " + chatName);
        _existedChatIds.Add(id);

        return id;
    }
}
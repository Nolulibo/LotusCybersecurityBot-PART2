using System.Windows;
using System.Windows.Input;
using LotusCyberSecurityBot.Classes;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Animation;


namespace LotusCyberSecurityBot
{
    public partial class MainWindow : Window
    {
        // I created a single ChatBot instance to handle all logic centrally
        private Chatbot chatbot;

        // I created a file path to store chat history permanently
        private readonly string chatHistoryPath = "ChatHistory.txt";

        private void StartAsciiAnimation()
        {
            DoubleAnimation fadeAnimation = new DoubleAnimation
            {
                From = 0.08,
                To = 0.25,
                Duration = new Duration(TimeSpan.FromSeconds(3)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            AsciiBackground.BeginAnimation(OpacityProperty, fadeAnimation);
        }

        public MainWindow()
        {
            InitializeComponent();

            StartAsciiAnimation();

            // I initialised the chatbot so all logic stays outside the UI layer
            chatbot = new Chatbot();

            // I added an initial bot greeting to improve user experience
            AddMessage("Bot", "Welcome to Lotus Cybersecurity Awareness Bot. Please enter your name to begin.");

            AudioPlayer.PlayGreeting();
        }

        // I created this method to handle the Send button click event
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // I added keyboard support so the user can press Enter to send messages
        private void UserInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendMessage();
            }
        }

        // I centralised message handling into one method to avoid duplicated code
        private async void SendMessage()
        {
            string userMessage = UserInputTextBox.Text.Trim();

            // I prevent empty messages from being processed
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            // I display the user's message immediately
            AddMessage("You", userMessage);

            UserInputTextBox.Clear();

            // I display a temporary typing indicator
            Border typingBubble = AddTypingIndicator();

            // I simulate AI thinking time to improve realism
            await Task.Delay(1200);

            // I remove the typing indicator before showing the actual response
            ChatPanel.Children.Remove(typingBubble.Parent as UIElement);

            // I retrieve the chatbot response
            string response = chatbot.GetResponse(userMessage);

            // I display the chatbot response
            AddMessage("Bot", response);

            AudioPlayer.SpeakAsync(response);
        }



        // I created this method to format messages consistently in the chat UI
        private void AddMessage(string sender, string message)
        {
            // I created a message bubble container for a modern chat interface
            Border bubble = new Border
            {
                CornerRadius = new CornerRadius(15),
                Padding = new Thickness(14),
                Margin = new Thickness(8),
                MaxWidth = 650,
                Opacity = 0
            };

            // I created a vertical layout for message text and timestamp
            StackPanel contentPanel = new StackPanel();

            // Message text
            TextBlock text = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.White,
                FontSize = 14,
                FontWeight = sender == "You"
                    ? FontWeights.SemiBold
                    : FontWeights.Normal
            };

            // Timestamp
            TextBlock timestamp = new TextBlock
            {
                Text = DateTime.Now.ToString("HH:mm"),
                Foreground = Brushes.LightGray,
                FontSize = 10,
                Margin = new Thickness(0, 5, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Right
            };

            contentPanel.Children.Add(text);
            contentPanel.Children.Add(timestamp);

            bubble.Child = contentPanel;

            // I align user and bot messages differently for readability
            StackPanel container = new StackPanel();

            if (sender == "You")
            {
                bubble.Background = new SolidColorBrush(Color.FromRgb(209, 0, 209));
                container.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                bubble.Background = new SolidColorBrush(Color.FromRgb(45, 45, 45));
                container.HorizontalAlignment = HorizontalAlignment.Left;
            }

            container.Children.Add(bubble);

            ChatPanel.Children.Add(container);

            //I save every conversation message into persistent chat histrory
            SaveChatMessage(sender, message);

            // I added a fade-in animation for smoother UI interaction
            DoubleAnimation fadeAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(300)
            };

            bubble.BeginAnimation(OpacityProperty, fadeAnimation);

            // I ensure the newest message remains visible automatically
            Dispatcher.InvokeAsync(() =>
            {
                if (VisualTreeHelper.GetParent(ChatPanel) is ScrollViewer scrollViewer)
                {
                    scrollViewer.ScrollToEnd();
                }
            }, DispatcherPriority.Background);
        }

        private void SaveChatMessage(string sender, string message)
        {
            // I formatted each message with a timestamp for readability
            string formattedMessage =
                $"[{DateTime.Now:HH:mm}] {sender}: {message}";

            // I append all chat messages to the history text file
            File.AppendAllText(chatHistoryPath,
                formattedMessage + Environment.NewLine);
        }




        private Border AddTypingIndicator()
            {
            // I created a typing bubble to simulate AI interaction
            Border bubble = new Border
            {
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(12),
                Margin = new Thickness(5),
                Background = new SolidColorBrush(Color.FromRgb(40, 40, 40)),
                MaxWidth = 200
            };

            TextBlock typingText = new TextBlock
            {
                Text = "Lotus is typing...",
                Foreground = Brushes.White,
                FontStyle = FontStyles.Italic,
                FontSize = 13
            };

            bubble.Child = typingText;

            StackPanel container = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Left
            };

            container.Children.Add(bubble);

            ChatPanel.Children.Add(container);

            return bubble;
            }


     }
}



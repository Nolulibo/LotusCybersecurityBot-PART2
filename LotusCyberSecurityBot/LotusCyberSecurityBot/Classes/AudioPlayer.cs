using System.Media;
using System.Speech.Synthesis;

namespace LotusCyberSecurityBot.Classes
{
    // I created this class to manage all chatbot audio functionality
    public static class AudioPlayer
    {
        // I created a single speech synthesizer instance for text-to-speech
        private static SpeechSynthesizer synth = new SpeechSynthesizer();

        // Static constructor for voice configuration
        static AudioPlayer()
        {
            // I configured the speech settings to sound more natural
            synth.Rate = 0;
            synth.Volume = 100;
        }

        // I play a WAV greeting when the application launches
        public static void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("LOTUS.wav");

                // I ensure the greeting finishes before continuing
                player.PlaySync();
            }
            catch (Exception)
            {
                // I prevent crashes if the audio file fails
            }
        }

        // I created asynchronous speech output for smoother UI interaction
        public static async Task SpeakAsync(string message)
        {
            try
            {
                await Task.Run(() =>
                {
                    synth.Speak(message);
                });
            }
            catch (Exception)
            {
                // I prevent application crashes if speech fails
            }
        }
    }
}


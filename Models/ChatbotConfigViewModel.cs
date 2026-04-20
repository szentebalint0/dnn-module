using System;

namespace HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Models
{
    public class ChatbotConfigViewModel
    {
        public int ModuleId { get; set; }

        public bool Enabled { get; set; }
        public string Endpoint { get; set; }
        public int HistoryWindow { get; set; }

        public string Title { get; set; }
        public string InputPlaceholder { get; set; }
        public string WelcomeMessage { get; set; }
        public string StarterQuestions { get; set; }

        // UI-hoz kell
        public bool IsEditable { get; set; }
        public bool IsAdmin { get; set; }
    }
}
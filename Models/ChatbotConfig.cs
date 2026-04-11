using System;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Models
{
    [TableName("Dnn_ClosedAI_HelloWorld_Config")]
    [PrimaryKey("ConfigId", AutoIncrement = true)]
    public class ChatbotConfig
    {
        public int ConfigId { get; set; }
        public int ModuleId { get; set; }

        public bool Enabled { get; set; }
        public string Endpoint { get; set; }
        public int HistoryWindow { get; set; }

        public string Title { get; set; }
        public string InputPlaceholder { get; set; }
        public string WelcomeMessage { get; set; }
        public string StarterQuestions { get; set; }

        public DateTime CreatedOnDate { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime LastModifiedOnDate { get; set; }
        public int LastModifiedByUserId { get; set; }
    }
}
using System;
using System.Data;
using System.Linq;
using DotNetNuke.Data;
using HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Models;

namespace HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Providers
{
    public class ChatbotConfigRepository
    {
        public ChatbotConfig GetByModuleId(int moduleId)
        {
            using (var ctx = DataContext.Instance())
            {
                var sql = "SELECT * FROM Dnn_ClosedAI_HelloWorld_Config WHERE ModuleId = @0";
                return ctx.ExecuteQuery<ChatbotConfig>(System.Data.CommandType.Text, sql, moduleId).FirstOrDefault();
            }
        }

        public ChatbotConfig GetOrCreateDefault(int moduleId, int userId)
        {
            var config = GetByModuleId(moduleId);
            if (config != null)
            {
                return config;
            }

            var now = DateTime.UtcNow;

            config = new ChatbotConfig
            {
                ModuleId = moduleId,
                Enabled = true,
                Endpoint = "/closedai-api/question",
                HistoryWindow = 6,
                Title = "A te asszisztensed",
                InputPlaceholder = "Írd be a kérdésed...",
                WelcomeMessage = "Szia! Miben segíthetek?",
                StarterQuestions = "Mik a legkelendőbb termékek?\nAjánlj nekem egy modellt!",
                CreatedOnDate = now,
                CreatedByUserId = userId,
                LastModifiedOnDate = now,
                LastModifiedByUserId = userId
            };

            Insert(config);
            return GetByModuleId(moduleId);
        }

        public void Save(ChatbotConfig config)
        {
            var existing = GetByModuleId(config.ModuleId);

            if (existing == null)
            {
                Insert(config);
            }
            else
            {
                config.ConfigId = existing.ConfigId;
                config.CreatedOnDate = existing.CreatedOnDate;
                config.CreatedByUserId = existing.CreatedByUserId;

                Update(config);
            }
        }

        private void Insert(ChatbotConfig config)
        {
            using (var ctx = DataContext.Instance())
            {
                ctx.GetRepository<ChatbotConfig>().Insert(config);
            }
        }

        private void Update(ChatbotConfig config)
        {
            using (var ctx = DataContext.Instance())
            {
                ctx.GetRepository<ChatbotConfig>().Update(config);
            }
        }
    }
}
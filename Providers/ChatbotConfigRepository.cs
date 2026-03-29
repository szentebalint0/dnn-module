using System;
using System.Data;
using DotNetNuke.Data;
using HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Models;

namespace HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Providers
{
    public class ChatbotConfigRepository
    {
        private const string TableName = "Dnn_ClosedAI_HelloWorld_Config";

        public ChatbotConfig GetByModuleId(int moduleId)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChatbotConfig>();
                return rep.GetById(moduleId);
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
                Update(config);
            }
        }

        private void Insert(ChatbotConfig config)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChatbotConfig>();
                rep.Insert(config);
            }
        }

        private void Update(ChatbotConfig config)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<ChatbotConfig>();
                rep.Update(config);
            }
        }
    }
}
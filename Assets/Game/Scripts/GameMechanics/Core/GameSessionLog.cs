using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.GameMechanics.Core
{
    public class GameSessionLog
    {
        public string FilePath { get; }
        
        public GameSessionLog()
        {
            var folder = "Logs";
            var folderPath = $"{Application.persistentDataPath}/{folder}";
            if (!Directory.Exists(folderPath)) 
                Directory.CreateDirectory(folderPath);

            var fileName = $"log_game_session_{DateTime.Now:yy-MM-dd hh.mm.ss}.txt";
            FilePath = $"{folderPath}/{fileName}";
            
            Debug.Log("Path Game Session Log: " + folderPath);
            
            Application.logMessageReceivedThreaded += LogMessage;
        }
        
        private async void LogMessage(string condition, string stackTrace, LogType type)
        {
            await WriteLogMessage($"{type} {DateTime.Now:yy.MM.dd hh-mm-ss} {condition}");
        }

        private async Task WriteLogMessage(string message)
        {
            using StreamWriter sw = new StreamWriter(FilePath, true, System.Text.Encoding.UTF8);
            await sw.WriteLineAsync(message);
        }

        ~GameSessionLog()
        {
            Application.logMessageReceivedThreaded -= LogMessage;
        }
    }
}
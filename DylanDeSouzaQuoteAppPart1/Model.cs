using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

using System.Diagnostics;

namespace DylanDeSouzaQuoteAppPart1
{
    public partial class Model : INotifyPropertyChanged
    {
        const string fileName = "QuotesAndAuthorsFile.txt";
        string localFolder = FileSystem.AppDataDirectory;
        string filePath;
        string contents;
        Quote currentQuote;
        string randomQuote;
        List<Quote> quotesAuthors;

        List<Quote> QuotesAuthors { get => quotesAuthors; set => quotesAuthors = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        void InitializeDefaultData()
        {
            QuotesAuthors =
            [
                new("You must be the change you wish to see in the world.", "Mahatma Gandhi"),
                new("Everyone is a genius. But if you judge a fish by its ability to climb a tree, it will live its whole life believing that it is stupid.", "Albert Einstein"),
                new("A life spent making mistakes is not only more honorable, but more useful than a life spent doing nothing.", "George Bernard Shaw")
            ];
        }

        public Model() 
        {
            filePath = Path.Combine(localFolder, fileName);
            EnsureFileExists();
            LoadFileContents();
            CurrentQuote = new Quote("", "");
        }

        void EnsureFileExists()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                InitializeDefaultData();
                SaveQuotes();
            }
        }

        void SaveQuotes()
        {
            string jsonData = JsonConvert.SerializeObject(QuotesAuthors);
            File.WriteAllText(filePath, jsonData);
        }

        void LoadFileContents()
        {
            if (File.Exists(filePath))
            {
                contents = File.ReadAllText(filePath);
                if (string.IsNullOrWhiteSpace(contents))
                {
                    InitializeDefaultData();
                    SaveQuotes();
                }
                else QuotesAuthors = JsonConvert.DeserializeObject<List<Quote>>(contents);
            }
        }

        public Quote CurrentQuote
        {
            get => currentQuote;
            set
            {
                if (currentQuote != value)
                {
                    currentQuote = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string RandomQuote
        {
            get => randomQuote;
            set
            {
                if (randomQuote != value)
                {
                    randomQuote = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void FetchRandomQuote()
        {
            if (QuotesAuthors.Count == 0) return;
            var random = new Random();
            Quote randomQuote = QuotesAuthors[random.Next(QuotesAuthors.Count)];
            RandomQuote = $"{randomQuote.Author}\n\n{randomQuote.Message}";
        }

        public void AddQuote()
        {
            if (!string.IsNullOrWhiteSpace(CurrentQuote.Message) && !string.IsNullOrWhiteSpace(CurrentQuote.Message))
            {
                QuotesAuthors.Add(new Quote(CurrentQuote.Message, CurrentQuote.Author));
                SaveQuotes();
                CurrentQuote.Message = "";
                CurrentQuote.Author = "";
            }
        }
    }
}
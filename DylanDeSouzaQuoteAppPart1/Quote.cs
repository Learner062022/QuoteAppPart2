using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DylanDeSouzaQuoteAppPart1
{
    public partial class Quote : INotifyPropertyChanged
    {
        string message;
        string author;
        bool favourite = false;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Quote(string message, string author)
        {
            Message = message;
            Author = author;
        }

        public bool Favourite
        {
            get => favourite;
            set
            {
                if (favourite != value)
                {
                    favourite = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Message
        {
            get => message;
            set
            {
                if (message != value)
                {
                    message = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Author
        {
            get => author;
            set
            {
                if (author != value)
                {
                    author = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
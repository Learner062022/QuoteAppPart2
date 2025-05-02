using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DylanDeSouzaQuoteAppPart1
{
    public partial class Quote : INotifyPropertyChanged
    {
        string message;
        string author;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public Quote(string message, string author)
        {
            Message = message;
            Author = author;
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

using SQLite;
using System;
using System.ComponentModel;

namespace App3.Models
{
    public class Note : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private double gold;

        public double Gold
        {
            get { return gold; }
            set
            {
                if (gold != value)
                {
                    gold = value;
                    OnPropertyChanged(nameof(Gold));
                }
            }
        }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

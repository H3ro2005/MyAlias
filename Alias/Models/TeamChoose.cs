using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alias.Models
{
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Name { get; private set; }
        public Grouping(K name, IEnumerable<T> items) : base(items)
        {
            Name = name;
        }
    }
    public class PlayerChoose
    {
        public string Players { get; set; }

        public byte Points { get; set; }

        public int Id { get; set; }

        public bool IsOne { get; set; }

        public TeamChoose team { get; set; }

    }
    public class TeamChoose
    {
        public string TeamName { get; set; }

        public byte TeamCount { get; set; }

        public bool IsPlayer { get; set; }
    }
}

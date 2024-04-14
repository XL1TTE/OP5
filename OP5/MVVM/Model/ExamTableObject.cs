using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace OP5.MVVM.Model
{
    public class ExamTableObject
    {
        public string title { get; set; }
        public string lector { get; set; }
        public Enum difficalty { get; set; }

        public DateTime startDate { get; set; }
        public DateTime prepareDateStart { get; set; }

        public static List<Enum> Difficulties = new List<Enum>()
        {
            Difficalties.Легкий,
            Difficalties.Средний,
            Difficalties.Сложный
        };


        public ExamTableObject(string Title, string Lector, Enum Difficalty, DateTime StartDate, DateTime PrepareStart)
        {
            title = Title;
            lector = Lector;
            difficalty = Difficalty;
            startDate = StartDate;
            prepareDateStart = PrepareStart;
        }

        public enum Difficalties{
            Сложный,
            Легкий,
            Средний
        }
    }
}

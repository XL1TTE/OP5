using OP5.MVVM.Core;
using OP5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OP5.MVVM.ViewModel
{
    public class TableViewModel: ViewModelBase
    {


		private DateTime _examdate;
		public DateTime ExamDate
		{
			get => _examdate;
			set
			{
                _examdate = value;
				OnPropertyChanged();
			}
		}


		private string _examTitle;
		public string ExamTitle
		{
			get => _examTitle;
			set
			{
                _examTitle = value;
                OnPropertyChanged();
            }
		}
        private string _lectorName;
        public string LectorName
        {
            get => _lectorName;
            set
            {
                _lectorName = value;
                OnPropertyChanged();
            }
        }

		private Enum _difficalte;
		public Enum Difficalte
        {
			get => _difficalte;
			set
			{
				_difficalte = value;
                OnPropertyChanged();
            }
		}


        private ObservableCollection<ExamTableObject> _tableList = new ObservableCollection<ExamTableObject>();

        public ObservableCollection<ExamTableObject> TableList
        {
            get => _tableList;
            set
            {
                _tableList = value;
                OnPropertyChanged();
            }
        }

        private List<Enum> _difficultiese;
        public List<Enum> Difficulties
		{
            get => _difficultiese;
            set
            {
                _difficultiese = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddInTableCommand { get; set; }

        public RelayCommand RemoveFromTableCommand { get; set; }

		public TableViewModel()
        {
            Difficulties = ExamTableObject.Difficulties;

            AddInTableCommand = new RelayCommand(o => { AddExamInList(); }, o => AddInListValidate());
            RemoveFromTableCommand = new RelayCommand(o => { RemoveFromExamList(); }, o => AddInListValidate());
        }



        public void AddExamInList()
        {
            DateTime PrepStartDate = ExamDate;
            switch (Difficalte)
            {
                case ExamTableObject.Difficalties.Сложный:
                    PrepStartDate = PrepStartDate.AddMonths(1);
                    break;
                case ExamTableObject.Difficalties.Средний:
                    PrepStartDate = PrepStartDate.AddDays(14);
                    break;
                case ExamTableObject.Difficalties.Легкий:
                    break;
            }
            ExamTableObject exam = new ExamTableObject(ExamTitle, LectorName, Difficalte, ExamDate, PrepStartDate);
            TableList.Add(exam);
            AddPanelClear();
        }

        public void RemoveFromExamList()
        {
            foreach(ExamTableObject o in TableList)
            {
                if(o.title == ExamTitle && o.lector == LectorName && o.startDate == ExamDate)
                {
                    TableList.Remove(o); break;
                }
            }
        }

        public bool AddInListValidate()
        {
            bool valid = Difficalte != null && ExamTitle != String.Empty && LectorName != String.Empty && ExamDate >= DateTime.Now;
            if (valid)
            {
                return true;
            }
            else { return false; }
            
        }



        public void AddPanelClear()
        {
            ExamTitle = String.Empty;
            LectorName = String.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FileValidatorIntegrationTests 
{
    public class TestResult : INotifyPropertyChanged
    {
        private string _testName;
        private Boolean _testPassed;
        private string _errorMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        public string testName
        {
            get
            {
                return _testName;
            }
            set
            {
                _testName = value;
                OnPropertyChanged("testName");
            }
        }

        public Boolean testPassed
        {
            get
            {
                return _testPassed;
            }
            set
            {
                _testPassed = value;
                OnPropertyChanged("testPassed");
            }
        }

        public string errorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("errorMessage");
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

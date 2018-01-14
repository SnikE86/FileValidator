using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileValidator
{
    partial class FileValidationForm : Form
    {
        private FileValidationFormModel _model;

        public FileValidationForm( FileValidationFormModel model)
        {
            _model = model;

            dataGridViewToProcess.DataSource = _model.toProcess;
            dataGridViewSuccess.DataSource = _model.success;
            dataGridViewFailures.DataSource = _model.failures;

            InitializeComponent();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Logic
{
    public class LastPredictionDaysArgs : EventArgs
    {
        private int days;
        public int Days
        {
            get => days; set => days = value;
        }
        private int rowIndex;
        public int RowIndex 
        {
            get => rowIndex; set => rowIndex = value;
        }
    }
}

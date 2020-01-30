﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeyonSense.Models
{
    public class ClassPixels : Screen
    {
        public string ClassName { get; set; }

        // ObservableCollection will notify the changed only if any element is added or removed, not any changed variable in the element.

        private int numPoints;

        public int NumPoints 
        {
            get { return numPoints; }
            set
            {
                numPoints = value;
                NotifyOfPropertyChange(() => NumPoints);
            }
        
        }

        

        public Color ClassColor { get; set; }
    }
}
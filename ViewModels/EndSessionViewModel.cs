﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using SkiaSharp;

namespace YourTimeApp.ViewModels
{
    class EndSessionViewModel : ViewModelBase
    {
        TimeBlockViewModel finishedTimeBlock;

        public ISeries[] Series { get; set; } = [
        new ColumnSeries<int>(3, 4, 2),
        new ColumnSeries<int>(4, 2, 6),
        new ColumnSeries<double, DiamondGeometry>(4, 3, 4)
    ];

        public EndSessionViewModel(TimeBlockViewModel finished)
        {
                finishedTimeBlock = finished;
        }
    }
}
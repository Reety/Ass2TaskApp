using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Navigation;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Kernel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using SkiaSharp;
using YourTimeApp.Data;

namespace YourTimeApp.ViewModels
{
    class EndSessionViewModel : ViewModelBase
    {

        YourTimeStore appStore;
        TimeBlockViewModel finishedTimeBlock;

        /*public ISeries[] Series { get; set; } = [
        new ColumnSeries<int>(3, 4, 2),
        new ColumnSeries<int>(4, 2, 6),
        new ColumnSeries<double, DiamondGeometry>(4, 3, 4)
    ];*/

        public ISeries[] Series { get; set; }
        public PieSeries<TaskTimeViewModel> TaskSeries { get; set; }



        public EndSessionViewModel(YourTimeStore appStore)
        {
            this.appStore = appStore;
            appStore.TimeBlockFinished += OnTimeBlockFinished;
        }

        private void OnTimeBlockFinished(TimeBlockViewModel block)
        {
            finishedTimeBlock = block;
            Series = new PieSeries<TaskTimeViewModel>[finishedTimeBlock.TaskAndTimes.Count];

            fillChart(finishedTimeBlock.TaskAndTimes);

        }

        private void fillChart(IEnumerable<TaskTimeViewModel> taskAndTimes)
        {
            int i = 0;

            foreach (var item in taskAndTimes)
            {
                Series[i] = new PieSeries<TaskTimeViewModel>(item)
                {
                    Name = item.Task.TaskDescription,
                    ToolTipLabelFormatter = point =>
                    {
                        var pv = point.Coordinate.PrimaryValue;
                        var sv = point.StackedValue;
                        return (pv / sv.Total).ToString("P1");
                    },

                };
                i++;
            }

        }
    }
}

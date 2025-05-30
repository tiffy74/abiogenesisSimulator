using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Defaults;
using System.ComponentModel;

namespace AbiogenesisSimulator
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ISeries[] _energySeries;
        public ISeries[] EnergySeries
        {
            get => _energySeries;
            set
            {
                _energySeries = value;
                OnPropertyChanged(nameof(EnergySeries));
            }
        }

        private Axis[] _xAxes;
        public Axis[] XAxes
        {
            get => _xAxes;
            set
            {
                _xAxes = value;
                OnPropertyChanged(nameof(XAxes));
            }
        }

        private Axis[] _yAxes;
        public Axis[] YAxes
        {
            get => _yAxes;
            set
            {
                _yAxes = value;
                OnPropertyChanged(nameof(YAxes));
            }
        }

        private Random rng = new Random();
        private List<Reaction> currentReactions = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            EnergySeries = new ISeries[]
            {
                new LineSeries<ObservablePoint>
                {
                    Values = new List<ObservablePoint>(),
                    Fill = null,
                    GeometrySize = 6,
                    Name = "Net Energy"
                }
            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Time",
                    MinLimit = 0,
                    MaxLimit = 100,
                    UnitWidth = 10,
                    Labeler = value => value.ToString(),
                    MinStep = 10,
                    ForceStepToMin = true
                }
            };

            YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Net Energy",
                    MinLimit = -20,
                    MaxLimit = 20,
                    Labeler = value => value.ToString(),
                    MinStep = 10,
                    ForceStepToMin = true
                }
            };

            EnergyModeComboBox.ItemsSource = new List<string> { "Sinusoidal", "Random Gaussian", "Step Fluctuation", "Catastrophic Drop" };
            EnergyModeComboBox.SelectedIndex = 0;

            PresetComboBox.ItemsSource = ReactionLibrary.Presets.Keys.ToList();
            PresetComboBox.SelectedIndex = 0;

            TimeSlider.Value = 200;
            TimeSlider.ValueChanged += TimeSlider_ValueChanged;

            // Set default reaction set
            currentReactions = ReactionLibrary.Presets["Hydrothermal Vent"]
                .Select(r => new Reaction
                {
                    Name = r.Name,
                    InputEnergy = r.InputEnergy,
                    OutputEnergy = r.OutputEnergy,
                    StorageEnergy = r.StorageEnergy
                }).ToList();
            ReactionEditor.ItemsSource = currentReactions;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeValueLabel.Content = ((int)TimeSlider.Value).ToString();
        }

        private void RunSimulation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var values = new List<ObservablePoint>();
                int totalTime = (int)TimeSlider.Value;
                string selectedMode = EnergyModeComboBox.SelectedItem.ToString();

                for (int t = 0; t < totalTime; t++)
                {
                    double z = GetEnergyInput(t, selectedMode);
                    z = EventSystem.ApplyEvents(EventSystem.GetStandardEvents(), t, z);
                    z = SunModel.ModifyEnergyBasedOnSunAge(t, z);

                    double totalX = currentReactions.Sum(r => r.InputEnergy);
                    double totalR = currentReactions.Sum(r => r.OutputEnergy);
                    double totalS = currentReactions.Sum(r => r.StorageEnergy);

                    double net = z + totalR + totalS - totalX;
                    values.Add(new ObservablePoint(t, net));
                }

                EnergySeries = new ISeries[]
                {
                    new LineSeries<ObservablePoint>
                    {
                        Values = values,
                        Fill = null,
                        GeometrySize = 6,
                        Name = "Net Energy"
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void ResetZoom_Click(object sender, RoutedEventArgs e)
        {
            foreach (var axis in XAxes)
            {
                axis.MinLimit = null;
                axis.MaxLimit = null;
            }

            foreach (var axis in YAxes)
            {
                axis.MinLimit = null;
                axis.MaxLimit = null;
            }

            DataContext = null;
            DataContext = this;
        }

        private double GetEnergyInput(int t, string mode)
        {
            return mode switch
            {
                "Sinusoidal" => EnergyInput.Sinusoidal(t),
                "Random Gaussian" => EnergyInput.RandomGaussian(rng),
                "Step Fluctuation" => EnergyInput.StepFluctuation(t),
                "Catastrophic Drop" => EnergyInput.CatastrophicDrop(t),
                _ => 10
            };
        }

        private void LoadPreset_Click(object sender, RoutedEventArgs e)
        {
            if (PresetComboBox.SelectedItem is string selected && ReactionLibrary.Presets.ContainsKey(selected))
            {
                currentReactions = ReactionLibrary.Presets[selected]
                    .Select(r => new Reaction
                    {
                        Name = r.Name,
                        InputEnergy = r.InputEnergy,
                        OutputEnergy = r.OutputEnergy,
                        StorageEnergy = r.StorageEnergy
                    }).ToList();

                ReactionEditor.ItemsSource = currentReactions;
                ReactionEditor.Items.Refresh();
            }
        }

        private void AddReaction_Click(object sender, RoutedEventArgs e)
        {
            currentReactions.Add(new Reaction
            {
                Name = "New Reaction",
                InputEnergy = 0,
                OutputEnergy = 0,
                StorageEnergy = 0
            });

            ReactionEditor.Items.Refresh();
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            if (ReactionEditor.SelectedItem is Reaction selected)
            {
                currentReactions.Remove(selected);
                ReactionEditor.Items.Refresh();
            }
        }
    }
}

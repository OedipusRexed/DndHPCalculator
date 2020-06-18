using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DM5eCompanion.Models;
using System.ComponentModel;
using DM5eCompanion.ViewModels;


namespace DM5eCompanion.Views
{
    public partial class HPCalculator : ContentPage
    {
        public HPCalculator()
        {
            InitializeComponent();

            var classItems = new List<Classes>
            {
                new Classes{ Id = ClassType.Artificer, Title="Artificer", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Barbarian, Title="Barbarian", HitDie = 12, Average = 7},
                new Classes{ Id = ClassType.Bard, Title="Bard", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Bloodhunter, Title="Bloodhunter", HitDie = 10, Average = 6},
                new Classes{ Id = ClassType.Cleric, Title="Cleric", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Druid, Title="Druid", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Fighter, Title="Fighter", HitDie = 10, Average = 6},
                new Classes{ Id = ClassType.Monk, Title="Monk", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Paladin, Title="Paladin", HitDie = 10, Average = 6},
                new Classes{ Id = ClassType.Ranger, Title="Ranger", HitDie = 10, Average = 6},
                new Classes{ Id = ClassType.Rogue, Title="Rogue", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Sorcerer, Title="Sorcerer", HitDie = 6, Average = 4},
                new Classes{ Id = ClassType.Warlock, Title="Warlock", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Witch, Title="Witch", HitDie = 8, Average = 5},
                new Classes{ Id = ClassType.Wizard, Title="Wizard", HitDie = 6, Average = 4},

            };

            classPicker.ItemsSource = classItems;

        }

        private void classPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                infoText.Text = string.Format("{0} Levels", picker.Items.ElementAt(selectedIndex));
                displayLabel.IsVisible = true;
                _classStepper.IsVisible = true;
                infoText.IsVisible = true;
                levelLine.IsVisible = true;
            }
        }

        /// <summary>
        /// Need to figure out how to make number of flexlayout rows of average hp and checkboxes == number on label
        /// maybe utilize if(e.OldValue < e.NewValue) to remove, or figure out how to make the number of rows based on number in stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (_classStepper.IsVisible == true)
            {
                double value = e.NewValue;
                double oldValue = e.OldValue;
                displayLabel.Text = string.Format("{0}", value);

                FlexLayout newFlexLayout = new FlexLayout
                {
                    Direction = FlexDirection.Row,
                    JustifyContent = FlexJustify.End,
                    HeightRequest = 40,

                };
                Label newLabel = new Label
                {
                    Text = "Average HP",
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                };
                CheckBox newCheckbox = new CheckBox
                {

                };
                newFlexLayout.Children.Add(newLabel);
                newFlexLayout.Children.Add(newCheckbox);

                if (value > 1 && oldValue < value)
                {
                    for (int i = 1; i < value; i++)
                    { 
                        _FirstHpStack.Children.Add(newFlexLayout);
                    }
                }

                if(value < oldValue)
                {
                    var firstStackChildren = _FirstHpStack.Children;
                    var lastChild = firstStackChildren.Last();

                    firstStackChildren.Remove(lastChild);
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
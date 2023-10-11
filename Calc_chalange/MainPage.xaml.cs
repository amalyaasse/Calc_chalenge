using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xamarin.Forms;

namespace Calc_chalange
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            GenerateRows();
        }

        private void GenerateRows()
        {
            List<TaskRow> rows = new List<TaskRow>();

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int firstNumber = random.Next(1, 11);
                int secondNumber = random.Next(1, 11);

                rows.Add(new TaskRow { FirstNumber = firstNumber, SecondNumber = secondNumber });
            }

            taskListView.ItemsSource = rows;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Handle the button click event here if needed
        }
    }

    public class TaskRow
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
    }







}
    

    


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp17
{
    class TodoItem : INotifyPropertyChanged
    {
        public string Title { get; set; }
        private int _completion;
        public int Completion {
            get 
            {
                return _completion;
            }
            set
            {
                // _completion = Math.Min(100, Math.Max(0, Value));
                if(value > 100)
                {
                    _completion = 100;
                }
                else if(value < 0)
                {
                    _completion = 0;
                }
                else
                {
                    _completion = value;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void onPropertyChanged(string prop)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class Animals
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
            List<TodoItem> items = new List<TodoItem>();
            items.Add(new TodoItem() { Title = "Learn C#", Completion = 50 });
            items.Add(new TodoItem() { Title = "Wash the car", Completion = 0 });
            items.Add(new TodoItem() { Title = "Clean the car", Completion = 25 });
            items.Add(new TodoItem() { Title = "Walk the dog", Completion = 0 });

            Console.WriteLine();

            List<Animals> animals  = new List<Animals>();
            animals.Add(new Animals() { Name = "Bobic", Age = 5 });
            animals.Add(new Animals() { Name = "Tom", Age = 3 });
            animals.Add(new Animals() { Name = "Sharic", Age = 2 });
            animals.Add(new Animals() { Name = "Tubic", Age = 6 });

            listBoxTodoList.ItemsSource = items;
            listBoxAnimals.ItemsSource = animals;

            buttonIncrease.Click += ButtonIncrease_Click;
            buttonDecrease.Click += ButtonDecrease_Click;

            comboBox.SelectionChanged += Combobox_SelectionChanged;

        }

        private void ButtonDecrease_Click(object sender, EventArgs e)
        {
            foreach (object o in listBoxTodoList.SelectedItems)
            {
                var todoItem = (o as TodoItem);
                todoItem.Completion -= 5;
                todoItem.onPropertyChanged("Completion");
            }
        }

        private void ButtonIncrease_Click(object sender, EventArgs e)
        {
            foreach (object o in listBoxTodoList.SelectedItems)
            {
                var todoItem = (o as TodoItem);
                todoItem.Completion += 5;
                todoItem.Completion += 5;
                todoItem.onPropertyChanged("Completion");
            }
        }

        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color[] colors = { Colors.Blue, Colors.Green, Colors.Red };
            this.Background = 
                new SolidColorBrush(colors[comboBox.SelectedIndex]);

            //if(comboBox.SelectedIndex == 0)
            //{
            //    this.Background = new SolidColorBrush(Colors.Blue);
            //}
            //if (comboBox.SelectedIndex == 0)
            //{
            //    this.Background = new SolidColorBrush(Colors.Green);
            //}
            //if (comboBox.SelectedIndex == 0)
            //{
            //    this.Background = new SolidColorBrush(Colors.Red);
            //}
        }
    }
}

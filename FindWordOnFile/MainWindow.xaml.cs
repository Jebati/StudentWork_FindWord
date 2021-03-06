﻿using FindWord;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace FindWordOnFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string findWord = find.Text.Trim();

            if(!String.IsNullOrEmpty(findWord))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    FindWordSolver findWordSolver = new FindWordSolver();
                    FindWordResult result = await findWordSolver.OnFile(dialog.FileName, findWord);

                    MessageBox.Show($"В файле \"{result.Path}\" найдено {result.Count} вхождений слова \"{findWord}\"");
                }
            } else
            {
                MessageBox.Show($"Введите искомое слово");
            }
        }
    }
}

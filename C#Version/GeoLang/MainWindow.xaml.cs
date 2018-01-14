﻿using Microsoft.Win32;
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

namespace GeoLang
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Geolang files (.glang)|*.glang";
            var res = openFileDialog.ShowDialog();
            if (res == true)
            {
                if (this.cnv != null)
                {
                    //this.cnv.Children.Clear();
                }
                var path = openFileDialog.FileName;
                var expressions = Parser.ParseFromFile(path, cnv);
                if (expressions != null)
                {
                    foreach (var exp in expressions)
                    {
                        exp.Eval();
                    }
                }
            }
        }
    }
}
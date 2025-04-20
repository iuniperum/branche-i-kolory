using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using Avalonia.Media;

namespace lab4;

public partial class MainWindow : Window
{
    private double stopien = 0;
    public MainWindow()
    {
        InitializeComponent();
    }

    public async void load (object sender, RoutedEventArgs e) {
        var savefiledialog = new SaveFileDialog();
        var result = await savefiledialog.ShowAsync(this);
        var bitmap = new Bitmap(result);
        obraz.Source = bitmap;
    }
    
    private void wybor_stopnia(object sender, RoutedEventArgs args) {
        if (stopnie.SelectedItem is ComboBoxItem item)
        {
            if (item.Content is StackPanel panel)
            {
                if (panel.Children[0] is TextBlock text)
                {
                    stopien = Convert.ToDouble(text.Tag);
                }
            }
        }
    }

    public void rotate(object sender, RoutedEventArgs e) {
        
    }
    
    public void rotate90 (object sender, RoutedEventArgs e) {
        
    }
    
    public void rotate180 (object sender, RoutedEventArgs e) {
        
    }
    
    public void rotate270 (object sender, RoutedEventArgs e) {
        
    }
    
    public void invert (object sender, RoutedEventArgs e) {
        
    }
    
    public void green (object sender, RoutedEventArgs e) {
        
    }
}
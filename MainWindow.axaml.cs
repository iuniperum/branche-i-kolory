using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using System;
using Avalonia.Media;
using AvaloniaPixelSnoop;
using System.IO;
using Avalonia.Skia;
using SkiaSharp;

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
        FileStream fs = File.OpenRead(result);
        bitmap = WriteableBitmap.Decode(fs);
        obraz.Source = bitmap;
    }
    
    public void green (object sender, RoutedEventArgs e) {
        
    }

    public void upside(object sender, RoutedEventArgs e) {
        RotateTransform obrot = new RotateTransform(180);
        obraz.RenderTransform = obrot;
    }
    
    public void invert (object sender, RoutedEventArgs e) {
        using (var snoop = new BmpPixelSnoop(bitmap)) {
            for (int x = 0; x < bitmap.PixelSize.Width; x++)
            {
                for (int y = 0; y < bitmap.PixelSize.Height; y++) {
                    var kolor = snoop.GetPixel(x, y).ToSKColor();
                    var nowy = new Color((byte)(255 - kolor.Red), (byte)(255 - kolor.Green), (byte)(255 - kolor.Blue), kolor.Alpha);
                    snoop.SetPixel(x, y, nowy);
                }
            }
        }
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
        RotateTransform obrot = new RotateTransform(stopien);
        obraz.RenderTransform = obrot;
    }
    
}
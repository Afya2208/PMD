using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PersonnelManagementDeskrop.Entities;
using PersonnelManagementDeskrop.Windows;

namespace PersonnelManagementDeskrop;

public partial class MainWindow : Window
{
    private HttpClient httpClient = new HttpClient();
    public List<Worker> Workers {get; set;}
    public List<Division> Divisions {get; set;}
    public bool Connection { get; set; } = true;
    public MainWindow()
    {
        InitializeComponent();
        if (ReadData().Result)
        {
            Connection = true;
        }
        else
        {
            Connection = false;
        }
        DataContext = this;
    }

    async Task<bool> ReadData()
    {
        try
        {
            Divisions = httpClient.GetFromJsonAsync<List<Division>>("http://localhost:5222/desktop/divisions").Result;
            return true;
        }
        catch (Exception ex)
        {
            MessageBox box = new MessageBox("Ошибка соединения", $"{ex.Message} \n {ex.InnerException?.Message}", false);
            box.Show();
            return false;
        }
    }
    private void AddButton_OnClick(object? sender, RoutedEventArgs e)
    {
        
    }

    private void WorkersListBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
       
    }
}
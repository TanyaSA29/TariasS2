using System;
using Microsoft.Maui.Controls;
namespace TariasS2.Views;


public partial class vCalificaciones : ContentPage
{
    public vCalificaciones()
    {
        InitializeComponent();
    }
    private bool ValidarNota(string texto)
    {
        texto = texto.Replace(',', '.'); 

        if (!double.TryParse(texto, out double nota))
            return false;

        if (nota < 0 || nota > 10)
            return false;

        string[] partes = texto.Split('.');
        if (partes[0].Length > 2) return false;      
        if (partes.Length > 1 && partes[1].Length > 1) return false; 

        return true;
    }
    private void CalcularNotaFinal_Clicked(object sender, EventArgs e)
    {
        try
        {
           
            if (!ValidarNota(seguimiento1.Text) || !ValidarNota(examen1.Text) ||
                !ValidarNota(seguimiento2.Text) || !ValidarNota(examen2.Text))
            {
                DisplayAlert("Error", "Ingrese notas válidas (0-10) con máximo 1 decimal.", "Aceptar");
                return;
            }

          
            double s1 = double.Parse(seguimiento1.Text.Replace(',', '.'));
            double e1 = double.Parse(examen1.Text.Replace(',', '.'));
            double s2 = double.Parse(seguimiento2.Text.Replace(',', '.'));
            double e2 = double.Parse(examen2.Text.Replace(',', '.'));

        
            double notaParcial1 = s1 * 0.3 + e1 * 0.2;
            double notaParcial2 = s2 * 0.3 + e2 * 0.2;
            double notaFinal = notaParcial1 + notaParcial2;

       
            parcial1.Text = notaParcial1.ToString("0.0");
            parcial2.Text = notaParcial2.ToString("0.0");

      
            string estado = "";
            if (notaFinal >= 7)
                estado = "APROBADO";
            else if (notaFinal >= 5)
                estado = "COMPLEMENTARIO";
            else
                estado = "REPROBADO";

            DisplayAlert("Resultado",
                $"Nombre: {pickerEstudiantes.SelectedItem}\n" +
                $"Fecha: {fechaPicker.Date:dd/MM/yyyy}\n" +
                $"Nota Parcial 1: {notaParcial1:0.0}\n" +
                $"Nota Parcial 2: {notaParcial2:0.0}\n" +
                $"Nota Final: {notaFinal:0.0}\n" +
                $"Estado: {estado}",
                "Aceptar");
        }
        catch
        {
            DisplayAlert("Error", "Ingrese todas las notas correctamente.", "Aceptar");
        }
    }
}
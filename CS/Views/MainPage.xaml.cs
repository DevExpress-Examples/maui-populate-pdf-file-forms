using DevExpress.Drawing;
using FillPDFFile.Model;
using DevExpress.Office.DigitalSignatures;
using DevExpress.Pdf;
using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;
using DevExpress.Maui.DataForm;
using DevExpress.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using System.Reflection.Metadata;
using FillPDFFile.ViewModels;

namespace FillPDFFile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void NavigatedToPage(object sender, NavigatedToEventArgs args)
    {
        ((MainPageViewModel)BindingContext).UpdatePreview();
    }
}


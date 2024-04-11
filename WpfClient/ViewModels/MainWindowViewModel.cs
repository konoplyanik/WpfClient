using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WpfClient.Core.Models;
using WpfClient.Core.Services;
using WpfClient.Helpers;

namespace WpfClient.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private string _title;
    private byte[] _image;
    private List<ImageTextData> _uploadedImages;
    private readonly IImageTextService _imageTextService;

    public MainWindowViewModel(IImageTextService imageTextService)
    {
        _imageTextService = imageTextService;
    }

    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    public byte[] Image
    {
        get { return _image; }
        set
        {
            _image = value;
            OnPropertyChanged(nameof(Image));
        }
    }

    public List<ImageTextData> UploadedImages
    {
        get { return _uploadedImages; }
        set
        {
            _uploadedImages = value;
            OnPropertyChanged(nameof(UploadedImages));
        }
    }

    private ICommand _openImageCommand;
    public ICommand OpenImageCommand
    {
        get
        {
            if (_openImageCommand == null)
            {
                _openImageCommand = new RelayCommand(OpenImage);
            }
            return _openImageCommand;
        }
    }

    private ICommand _uploadCommand;
    public ICommand UploadCommand
    {
        get
        {
            if (_uploadCommand == null)
            {
                _uploadCommand = new RelayCommand(Upload);
            }
            return _uploadCommand;
        }
    }

    private ICommand _getImagesCommand;
    public ICommand GetImagesCommand
    {
        get
        {
            if (_getImagesCommand == null)
            {
                _getImagesCommand = new RelayCommand(GetImages);
            }
            return _getImagesCommand;
        }
    }

    private async void OpenImage()
    {
        // Open the file dialog and update the Image property
        var dialog = new OpenFileDialog();
        dialog.Filter = "Image files (*.png, *.jpg, *.jpeg, *.gif)|*.png;*.jpg;*.jpeg;*.gif";
        if (dialog.ShowDialog() == true)
        {
            Image = await File.ReadAllBytesAsync(dialog.FileName);
        }
    }

    private async void Upload()
    {
        // Upload the image and text to the web API
        // Проверка на заполнение полей
        if (string.IsNullOrEmpty(Title) || Image == null)
        {
            MessageBox.Show("Please fill in all the fields.");
            return;
        }

        try
        {
            // Создать объект ImageTextData и отправить данные на веб-API
            var imageTextData = new ImageTextData
            {
                Text = Title,
                Image = Image
            };

            await _imageTextService.UploadImageTextDataAsync(imageTextData);
            MessageBox.Show("Data uploaded successfully.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error uploading data: {ex.Message}");
        }
    }

    private async void GetImages()
    {
        try
        {
            // Получить список ранее загруженных изображений с сервера
            UploadedImages = await _imageTextService.GetImageTextDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error getting images: {ex.Message}");
        }
    }
}

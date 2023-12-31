﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CloudPass.Model;
using CloudPass.RelayComand;
using MaterialDesignThemes.Wpf;

namespace CloudPass.ViewModels
{
    public class DataManegerViewModel : INotifyPropertyChanged
    {
        // Event handler for property change notifications.
        public event PropertyChangedEventHandler PropertyChanged;

        // A collection of DataModel objects.
        public ObservableCollection<DataModel> Data { get; set; }

        // Custom command of copy login
        public ICommand CopyUsernameCommand { get; private set; }
        // Custom command of copy password
        public ICommand CopyPasswordCommand { get; private set; }

        // The currently selected DataModel object.
        private DataModel selectedData;
        public DataModel SelectedData
        {
            get { return selectedData; }
            set 
            { 
                selectedData = value; 
                OnPropertyChanged(nameof(SelectedData));
                UpdateFullUrl();
            }
        }

        // Property to show floating tip
        private SnackbarMessageQueue snackbarMessageQueue = new SnackbarMessageQueue();
        public SnackbarMessageQueue SnackbarMessageQueue
        {
            get { return snackbarMessageQueue; }
            set { snackbarMessageQueue = value; }
        }

        // Property to show full web adress of templete
        private string fullUrl;
        public string FullUrl
        {
            get { return fullUrl; }
            set
            {
                fullUrl = value;
                OnPropertyChanged(nameof(FullUrl));
            }
        }

        // Constructor for the DataManegerViewModel class.
        public DataManegerViewModel()
        {
            // Initialize the Data collection.
            Data = new ObservableCollection<DataModel>();

            // Add sample DataModel objects to the collection.
            Data.Add(new DataModel { Url = "Website.org", Username = "Bush", Password = "123213123" });
            Data.Add(new DataModel { Url = "te.org", Username = "fsd", Password = "vsdfsd" });

            // If there are items in the collection, select the first one by default.
            if (Data.Count > 0)
            {
                SelectedData = Data[0];
            }

            CopyUsernameCommand = new RelayCommand(CopyUsername, CanCopyUsername);
            CopyPasswordCommand = new RelayCommand(CopyPassword, CanCopyPassword);
        }

        // Process method that realizes copying login
        private void CopyUsername(object parameter)
        {
            if (SelectedData != null)
            {
                Clipboard.SetText(SelectedData.Username);
                SnackbarMessageQueue.Enqueue("Сopied successfully!");
            }
        }

        // Check when command copying login can done
        private bool CanCopyUsername(object parameter)
        {
            return SelectedData != null && !string.IsNullOrEmpty(SelectedData.Username);
        }

        // Process method that realizes copying password
        private void CopyPassword(object parameter)
        {
            if (SelectedData != null)
            {
                Clipboard.SetText(SelectedData.Password);
                SnackbarMessageQueue.Enqueue("Сopied successfully!");
            }
        }

        // Check when command copying password can done
        private bool CanCopyPassword(object parameter)
        {
            return SelectedData != null && !string.IsNullOrEmpty(SelectedData.Password);
        }

        private void UpdateFullUrl()
        {
            if (SelectedData != null)
            {
                FullUrl = ("https://" + SelectedData.Url).ToLower().Trim();
            }
        }

        // A method to raise the PropertyChanged event when a property changes.
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

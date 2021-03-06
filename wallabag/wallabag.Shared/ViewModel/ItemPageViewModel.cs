﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Media;
using wallabag.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace wallabag.ViewModel
{
    public class ItemPageViewModel : viewModelBase
    {
        private ItemViewModel _Item;
        public ItemViewModel Item
        {
            get { return _Item; }
            set { Set(() => Item, ref _Item, value); }
        }
        
        public RelayCommand shareCommand { get; private set; }
        public RelayCommand GoBackCommand { get; private set; }

        [PreferredConstructor]
        public ItemPageViewModel()
        {
            shareCommand = new RelayCommand(() => DataTransferManager.ShowShareUI());
        }
        public ItemPageViewModel(ItemViewModel item)
        {
            shareCommand = new RelayCommand(() => DataTransferManager.ShowShareUI());
            GoBackCommand = new RelayCommand(() => {
                Frame rootFrame = Window.Current.Content as Frame;
                if (rootFrame.CanGoBack)
                    rootFrame.GoBack();
            });
            Item = item;
        }

    }
}

﻿using AlphaTab.Wpf.Share.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using RockSmithTabExplorer.Services;

namespace RockSmithTabExplorer.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}
            SimpleIoc.Default.Register<IErrorService, ErrorService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SongLoader>();
            SimpleIoc.Default.Register<MainToolbarViewModel>();
            SimpleIoc.Default.Register<TrackToolbarViewModel>();
            SimpleIoc.Default.Register<TrackListingViewModel>();
            SimpleIoc.Default.Register<SongCollection>();
            SimpleIoc.Default.Register<CurrentSongService>();
            SimpleIoc.Default.Register<PrintService>();
            SimpleIoc.Default.Register<StatusViewModel>();
            SimpleIoc.Default.Register<ExportImageService>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MainToolbarViewModel MainToolbar { get { return ServiceLocator.Current.GetInstance<MainToolbarViewModel>(); } }
        public TrackToolbarViewModel TrackToolbar { get { return ServiceLocator.Current.GetInstance<TrackToolbarViewModel>(); } }
        public TrackListingViewModel TrackListing { get { return ServiceLocator.Current.GetInstance<TrackListingViewModel>(); } }
        public StatusViewModel StatusBar { get { return ServiceLocator.Current.GetInstance<StatusViewModel>(); } }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
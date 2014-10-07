using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MindPalace.Resources;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MindPalace
{
    public partial class MainPage : PhoneApplicationPage
    {
        ObservableCollection<Task> AllToDoItems = new ObservableCollection<Task>();
        private Point initialpoint;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Listloading();
            App.ViewModel.AllToDoItems = AllToDoItems;
            this.DataContext = App.ViewModel;

            Listloading();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            var binding = ((TextBox)sender).GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();

        }
        private void Listloading()
        {
            AllToDoItems.Clear();
            AllToDoItems.Add(new Task { Key = "Ananda", Description = "BlackPepper, Green Chilli, Cummin Seeds" });
            AllToDoItems.Add(new Task { Key = "WoolWorths", Description = "Banana, Bread, Milk" });
            AllToDoItems.Add(new Task { Key = "Joes", Description = "Capsicum, Potato, Soap" });
            

        }


        private void listBoxobj_LayoutUpdated(object sender, EventArgs e)
        {
            //if (LayoutUpdateFlag)
            //{
            //    SearchVisualTree(listBoxobj);
            //}
            //LayoutUpdateFlag = false;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    pvMemory.SelectedIndex++;
        //}

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
       

        private void listBoxobj_MouseEnter(object sender, MouseEventArgs e)
        {
            //pvMemory.SelectedIndex++;
        }

        private void Button_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            initialpoint = new Point(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
        }

        

        private void KeyTxt_MouseEnter(object sender, MouseEventArgs e)
        {
            //pvMemory.SelectedIndex++;
           // NavigationService.Navigate(new Uri("/MainPage.xaml?Select_Item=" + ((TextBlock)sender).Text + "&Index=1", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("Index"))
            {
                //pvMemory.SelectedIndex = Convert.ToInt32(NavigationContext.QueryString["Index"]);
                
            }
            if (NavigationContext.QueryString.ContainsKey("Select_Item"))
            {
                //DescTxt.Text = NavigationContext.QueryString["Select_Item"];
            }
        
        }

       

        //private void ContentPanel_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        //{
        //    initialpoint = new Point(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
            
        //}

        //private void ContentPanel_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        //{
        //    //if(e.IsInertial)
        //    //{
        //    //    Point currentpoint = new Point(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
        //    //    if (currentpoint.X > initialpoint.X)
        //    //    {
        //    //        NavigationService.Navigate(new Uri("/MainPage.xaml?Select_Item=" + ((TextBlock)sender).Text + "&Index=1", UriKind.Relative));
        //    //    }
        //    //}
        //}

        //private void ContentPanel_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        //{
        //    Point currentpoint = new Point(e.ManipulationOrigin.X, e.ManipulationOrigin.Y);
        //    if (currentpoint.X > initialpoint.X)
        //    {
        //        NavigationService.Navigate(new Uri("/MainPage.xaml?Select_Item=" + ((TextBlock)sender).Text + "&Index=1", UriKind.Relative));
        //    }
        //}
        private void GestureListener_DragStarted(object sender, DragStartedGestureEventArgs e)
        {
            int d = 0;
        }

        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            // handle the drag to offset the element
        }

        private void GestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            
        }
        private void GestureListener_Flick(object sender, FlickGestureEventArgs e)
        { 
        }

    }

    public class Task : INotifyPropertyChanged
    {
        public string _key;
        public string _description;

        public string Key
        {
            get { return _key; }
            set { _key = value; NotifyPropertyChanged("Name"); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged("Address"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
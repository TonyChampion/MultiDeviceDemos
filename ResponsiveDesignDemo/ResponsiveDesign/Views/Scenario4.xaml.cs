using ResponsiveDesign.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ResponsiveDesign.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Scenario4 : Page
    {
        public EndGameViewModel ViewModel;

        public Scenario4()
        {
            this.InitializeComponent();
            ViewModel = new EndGameViewModel();
            SizeChanged += Scenario4_SizeChanged;
        }

        bool isSmall = false;
        private void Scenario4_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            bool isCurrentlySmall = e.NewSize.Width < 600;

            if (isSmall != isCurrentlySmall)
            {
                if (isCurrentlySmall)
                {
                    VisualStateManager.GoToState(this, "Narrow", true);
                }
                else
                {
                    VisualStateManager.GoToState(this, "Wide", true);
                }
                isSmall = isCurrentlySmall;
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.LoadMovie();
        }
    }
}

using Windows.UI.Xaml.Controls;
using WindowsStore.Entities;

namespace WindowsStore.UserControls
{
    public sealed partial class SuggestControl : UserControl
    {
        public User User { get { return this.DataContext as User; } }
        public SuggestControl()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
        }
    }
}
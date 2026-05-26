using Microsoft.Extensions.DependencyInjection;

namespace chatAppMessage
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/VkV+XU9AclREQmJOYVF2R2VJeFRwcV9FaUwgOX1dQl9lSXtSfkVkWXdaeHNXTmhXUkc=");
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
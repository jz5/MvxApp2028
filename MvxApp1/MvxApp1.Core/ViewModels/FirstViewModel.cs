using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MvxApp1.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        string hello = "Hello MvvmCross";
        public string Hello
        {
            get { return hello; }
            set { SetProperty(ref hello, value); }
        }

        public MvxAsyncCommand ClickCommand => new MvxAsyncCommand(async () =>
        {
            await Mvx.Resolve<IMvxNavigationService>().Navigate<SecondViewModel, Parameter>(
                new Parameter
                {
                    Foo = 100,
                    Bar = "Baz",
                }
            );
        });
    }
}

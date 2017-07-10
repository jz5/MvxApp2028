using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;

namespace MvxApp1.Core.ViewModels
{
    public class SecondViewModel
        : MvxViewModel<Parameter>
    {

        public override Task Initialize(Parameter parameter)
        {
            System.Diagnostics.Debug.WriteLine(parameter.Foo);
            System.Diagnostics.Debug.WriteLine(parameter.Bar);

            return Task.FromResult(true);
        }
    }

    public abstract class MvxViewModel<TParameter> : MvxViewModel, IMvxViewModel<TParameter> where TParameter : class
    {
        public async Task Init(string parameter)
        {
            IMvxJsonConverter serializer;
            if (!Mvx.TryResolve(out serializer))
            {
                throw new MvxIoCResolveException("There is no implementation of IMvxJsonConverter registered. You need to use the MvvmCross Json plugin or create your own implementation of IMvxJsonConverter.");
            }

            var deserialized = serializer.DeserializeObject<TParameter>(parameter);
            await Initialize(deserialized);
        }

        public abstract Task Initialize(TParameter parameter);
    }
}

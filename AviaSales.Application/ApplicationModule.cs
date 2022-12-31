using Autofac;
using AviaSales.Application.Common.Extensions;

namespace AviaSales.Application;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.ConfigureMediatR();
        builder.ConfigureFluentValidation();
    }
}